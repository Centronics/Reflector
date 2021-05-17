using System;
using System.Collections.Generic;
using System.Linq;
using DynamicMosaic;
using DynamicParser;
using Processor = DynamicParser.Processor;

namespace DynamicReflector
{
    public sealed class Neuron
    {
        readonly ProcessorContainer _processorContainer;
        readonly Reflex _workReflex;
        readonly string _stringOriginalUniqueQuery;

        public Neuron(ProcessorContainer pc)
        {
            if (pc == null)
                throw new ArgumentNullException();

            ProcessorHandler ph = new ProcessorHandler();
            HashSet<char> setUniqueQuery = new HashSet<char>();
            for (int k = 0; k < pc.Count; k++)
            {
                Processor proc = pc[k];
                char pTag = char.ToUpper(proc.Tag[0]);
                if (ph.Find(proc).Any(p => p.Tag[0] == pTag))
                    continue;

                ph.Add(proc);
                setUniqueQuery.Add(pTag);
            }

            _processorContainer = ph.Processors;
            _workReflex = new Reflex(_processorContainer);
            _stringOriginalUniqueQuery = new string(setUniqueQuery.ToArray());
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

        public Neuron FindRelation(Request request)
        {
            if (request == null)
                throw new ArgumentNullException();

            ProcessorHandler ph = new ProcessorHandler();

            foreach ((Processor processor, string query) in request.Queries)
                ph.AddRange(GetNewProcessors(_workReflex, _workReflex.FindRelation(processor, query)));

            return ph.SetEquals(_stringOriginalUniqueQuery) ? new Neuron(ph.Processors) : null;
        }

        public ProcessorContainer ToProcessorContainer()
        {
            IEnumerable<Processor> GetProcessors()
            {
                for (int k = 0; k < _processorContainer.Count; k++)
                    yield return _processorContainer[k];
            }

            return new ProcessorContainer(GetProcessors().ToArray());
        }

        public Processor this[int index] => _processorContainer[index];

        public int Count => _processorContainer.Count;

        public override string ToString() => _stringOriginalUniqueQuery;
    }
}