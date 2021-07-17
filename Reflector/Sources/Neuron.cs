using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DynamicMosaic;
using DynamicParser;
using Processor = DynamicParser.Processor;

namespace DynamicReflector
{
    public sealed class Neuron
    {
        readonly Reflex _workReflex;
        readonly HashSet<char> _hashSetOriginalUniqueQuery;
        readonly Dictionary<char, Processor> _dicProcessors;

        public Neuron(ProcessorContainer pc)
        {
            ProcessorHandler ph = FromProcessorContainer(pc);
            HashSet<char> chs = new HashSet<char>();
            string phString = ph.ToString();
            if (phString.Any(c => !chs.Add(c)))
                throw new ArgumentException();
            _dicProcessors = new Dictionary<char, Processor>(phString.Length);
            ProcessorContainer phPc = ph.Processors;
            for (int k = 0; k < phPc.Count; k++)
                _dicProcessors.Add(phString[k], phPc[k]);
            _workReflex = new Reflex(phPc);
            _hashSetOriginalUniqueQuery = new HashSet<char>(phString);
        }

        static ProcessorHandler FromProcessorContainer(ProcessorContainer pc)
        {
            if (pc == null)
                throw new ArgumentNullException();

            ProcessorHandler ph = new ProcessorHandler();
            for (int k = 0; k < pc.Count; k++)
                ph.Add(pc[k]);

            return ph;
        }

        static HashSet<char> ToHashSet(IEnumerable<string> query)
        {
            HashSet<char> chs = new HashSet<char>();
            foreach (string q in query)
            {
                if (string.IsNullOrWhiteSpace(q))
                    throw new ArgumentNullException();
                if (q.Any(c => !chs.Add(char.ToUpper(c))))
                    throw new ArgumentException();
            }

            return chs;
        }

        IEnumerable<Processor> GetNewProcessors(Reflex start, Reflex finish, string query)
        {
            if (finish == null)
                yield break;

            Dictionary<char, Processor> dic = new Dictionary<char, Processor>();
            for (int k = start.Count; k < finish.Count; k++)
            {
                Processor p = finish[k];
                dic.Add(char.ToUpper(p.Tag[0]), p);
            }

            foreach (char c in query.Where(c => !dic.ContainsKey(char.ToUpper(c))))
                dic.Add(c, _dicProcessors[c]);

            foreach (Processor p in dic.Values)
                yield return p;
        }

        public Neuron FindRelation(IEnumerable<(Processor, string query)> queryPairs)
        {
            if (queryPairs == null)
                throw new ArgumentNullException();
            //карты (обе стороны) должны совпадать по размерам
            //запрос должен состоять только из одной буквы
            //карты должны различаться по названиям и содержимому одновременно
            //название карты должно быть из одной буквы
            IEnumerable<(Processor, string queryString)> queries = queryPairs as (Processor, string)[] ?? queryPairs.ToArray();
            if (!ToHashSet(queries.Select(q => q.queryString)).SetEquals(_hashSetOriginalUniqueQuery))
                return null;

            object lockObject = new object();

            string errString = string.Empty, errStopped = string.Empty;
            bool exThrown = false, exStopped = false;

            ProcessorHandler result = new ProcessorHandler();

            //Parallel.ForEach(queries, ((Processor processor, string query) q, ParallelLoopState state) =>
            foreach ((Processor processor, string query) in queries)
            {
                try
                {
                    //if (state.IsStopped)
                    //  return;

                    Reflex reflex = _workReflex.FindRelation(processor, query);
                    //if (reflex == null)// || state.IsStopped)
                      //  continue;//return;

                    lock (lockObject)
                        foreach (Processor p in GetNewProcessors(_workReflex, reflex, query))
                            result.Add(p);
                }
                catch (Exception ex)
                {
                    try
                    {
                        errString = ex.Message;
                        exThrown = true;
                        //state.Stop();
                    }
                    catch (Exception ex1)
                    {
                        errStopped = ex1.Message;
                        exStopped = true;
                    }
                }
            }//);

            if (exThrown)
                throw new Exception(exStopped ? $@"{errString}{Environment.NewLine}{errStopped}" : errString);

            return _hashSetOriginalUniqueQuery.SetEquals(result.ToString()) ? new Neuron(result.Processors) : null;
        }

        public IEnumerable<Processor> Processors
        {
            get
            {
                for (int k = 0; k < _workReflex.Count; k++)
                    yield return _workReflex[k];
            }
        }
    }
}