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

        public Neuron(ProcessorContainer pc)
        {
            ProcessorHandler ph = FromProcessorContainer(pc);
            _workReflex = new Reflex(ph.Processors);
            _hashSetOriginalUniqueQuery = new HashSet<char>(ph.ToString());
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
                foreach (char c in q)
                    chs.Add(char.ToUpper(c));
            return chs;
        }

        static IEnumerable<Processor> GetNewProcessors(Reflex start, Reflex finish)
        {
            if (start == null)
                throw new ArgumentNullException();
            if (finish == null)
                yield break;
            for (int k = start.Count; k < finish.Count; k++)
                yield return finish[k];
        }

        public Neuron FindRelation(IEnumerable<(Processor, string query)> queryPairs)
        {
            if (queryPairs == null)
                throw new ArgumentNullException();

            IEnumerable<(Processor, string queryString)> queries = queryPairs as (Processor, string)[] ?? queryPairs.ToArray();
            if (!ToHashSet(queries.Select(q => q.queryString)).SetEquals(_hashSetOriginalUniqueQuery))
                return null;

            object lockObject = new object();

            string errString = string.Empty, errStopped = string.Empty;
            bool exThrown = false, exStopped = false;

            ProcessorHandler result = new ProcessorHandler();

            Parallel.ForEach(queries, ((Processor processor, string query) q, ParallelLoopState state) =>
            {
                try
                {
                    if (state.IsStopped)
                        return;

                    Reflex reflex = _workReflex.FindRelation(q.processor, q.query);
                    if (reflex == null || state.IsStopped)
                        return;

                    lock (lockObject)
                        foreach (Processor p in GetNewProcessors(_workReflex, reflex))
                            result.Add(p);
                }
                catch (Exception ex)
                {
                    try
                    {
                        errString = ex.Message;
                        exThrown = true;
                        state.Stop();
                    }
                    catch (Exception ex1)
                    {
                        errStopped = ex1.Message;
                        exStopped = true;
                    }
                }
            });

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