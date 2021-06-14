using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DynamicMosaic;
using DynamicParser;
using Processor = DynamicParser.Processor;

namespace DynamicReflector
{
    public sealed class Neuron
    {
        readonly Reflex _workReflex;
        readonly HashSet<char> _procNames;
        readonly string _stringOriginalUniqueQuery;

        public Neuron(ProcessorContainer pc)
        {
            ProcessorHandler ph = FromProcessorContainer(pc);
            _workReflex = new Reflex(ph.Processors);
            _procNames = ph.ToHashSet();
            _stringOriginalUniqueQuery = ph.ToString();
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

        public Neuron FindRelation(IEnumerable<(Processor, string query)> queries)//как обрабатывать коллекцию, перечислять несколько раз?
        {
            if (queries == null)
                throw new ArgumentNullException();

            if (!ToHashSet(queries).SetEquals(_procNames))
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

            return result.SetEquals(_stringOriginalUniqueQuery) ? new Neuron(result.Processors) : null;
        }

        public Processor this[int index] => _workReflex[index];

        public int Count => _workReflex.Count;

        public override string ToString() => _stringOriginalUniqueQuery;
    }
}