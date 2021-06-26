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

        static HashSet<char> ToHashSet(IEnumerable<(Processor, string)> q)
        {
            HashSet<char> chs = new HashSet<char>();
            foreach ((Processor, string query) x in q)
                foreach (char c in x.query)
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

        public Neuron FindRelation(IEnumerable<(Processor, string query)> queries)
        {
            if (queries == null)
                throw new ArgumentNullException();

            IEnumerable<(Processor, string)> tq = queries as (Processor, string)[] ?? queries.ToArray();
            if (!ToHashSet(tq).SetEquals(_hashSetOriginalUniqueQuery))
                return null;

            object lockObject = new object();

            string errString = string.Empty, errStopped = string.Empty;
            bool exThrown = false, exStopped = false;

            ProcessorHandler result = new ProcessorHandler();

            Parallel.ForEach(tq, ((Processor processor, string query) q, ParallelLoopState state) =>
            {
                try
                {
                    if (state.IsStopped)
                        return;

                    Reflex reflex = _workReflex.FindRelation(q.processor, q.query);
                    if (reflex == null || state.IsStopped)
                        return;

                    lock (lockObject)
                        result.AddRange(GetNewProcessors(_workReflex, reflex));
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

        public Processor this[int index] => _workReflex[index];

        public int Count => _workReflex.Count;
    }
}