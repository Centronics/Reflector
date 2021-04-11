﻿using System;
using System.Collections.Generic;
using System.Text;
using DynamicMosaic;
using DynamicParser;
using Processor = DynamicParser.Processor;

namespace DynamicReflector
{
    public sealed class Neuron
    {
        readonly ProcessorContainer _processorContainer;
        readonly Reflex _workReflex;
        readonly Dictionary<char, char> _procNames;
        readonly string _stringQuery;

        public Neuron(ProcessorContainer pc)
        {
            if (pc == null)
                throw new ArgumentNullException();
            if (pc.Count > char.MaxValue)
                throw new ArgumentException();

            _procNames = new Dictionary<char, char>(pc.Count);
            ProcessorHandler ph = new ProcessorHandler();
            StringBuilder sb = new StringBuilder(pc.Count);
            for (char k = char.MinValue; k < pc.Count; ++k)
            {
                if (!ph.Add(ProcessorHandler.RenameProcessor(pc[k], k.ToString())))
                    continue;
                char c = char.ToUpper(pc[k].Tag[0]);
                _procNames[c] = k;
                sb.Append(c);
            }

            _processorContainer = ph.Processors;
            _workReflex = new Reflex(_processorContainer);
            _stringQuery = sb.ToString();
        }

        /// <summary>
        /// Преобразует запрос из человекочитаемой формы во внутреннее его представление.
        /// </summary>
        /// <param name="query"></param>
        /// <returns>В случае ошибки возвращается <see cref="string.Empty"/>. В противном случае, строка внутреннего запроса.</returns>
        string TranslateQuery(string query)
        {
            if (string.IsNullOrEmpty(query))
                throw new ArgumentException();
            StringBuilder sb = new StringBuilder(query.Length);
            foreach (char c in query)
            {
                if (!_procNames.TryGetValue(char.ToUpper(c), out char index))
                    return string.Empty;
                sb.Append(index);
            }
            return sb.ToString();
        }

        IEnumerable<Processor> GetNewProcessors(Reflex start, Reflex finish)
        {
            if (start == null)
                throw new ArgumentNullException();
            if (finish == null)
                throw new ArgumentNullException();
            for (int k = start.Count; k < finish.Count; ++k)
            {
                Processor p = finish[k];
                yield return ProcessorHandler.RenameProcessor(p, _stringQuery[p.Tag[0]].ToString());
            }
        }

        public Reflex ToReflex() => _workReflex;

        public ProcessorContainer ToProcessorContainer()
        {
            Processor GetProcessorWithOriginalTag(Processor p)
            {
                if (p == null)
                    throw new ArgumentNullException();
                StringBuilder sb = new StringBuilder(_stringQuery[p.Tag[0]].ToString());
                sb.Append(p.Tag, 1, p.Tag.Length - 1);
                return ProcessorHandler.RenameProcessor(p, sb.ToString());
            }

            ProcessorContainer pc = new ProcessorContainer(GetProcessorWithOriginalTag(_processorContainer[0]));
            for (int k = 1; k < _processorContainer.Count; ++k)
                pc.Add(GetProcessorWithOriginalTag(_processorContainer[k]));

            return pc;
        }

        public Neuron FindRelation(Request request)//Никакой "автоподбор" не требуется. Запоминает причины и следствия путём "перебора"... Причина и следствие могут быть любыми, отсюда - любой цвет любого пикселя на карте. Если надо поменять символ карты, можно задать такую карту без ограничений. Это и есть "счётчик".
        {
            if (!request.IsActual(_stringQuery))
                throw new ArgumentException();
            ProcessorHandler ph = new ProcessorHandler();
            foreach ((Processor processor, string query) in request.Queries)
            {
                Reflex refResult = _workReflex.FindRelation(processor, TranslateQuery(query));
                if (refResult != null)
                    ph.AddRange(GetNewProcessors(_workReflex, refResult));
            }
            return request.IsActual(ph.ToString()) ? new Neuron(ph.Processors) : null;
        }

        public bool CheckRelation(Request request)
        {
            if (!request.IsActual(_stringQuery))
                throw new ArgumentException();
            StringBuilder result = new StringBuilder(request.ToString().Length);
            foreach ((Processor processor, string query) in request.Queries)
            {
                if (!processor.GetEqual(_processorContainer).FindRelation(TranslateQuery(query)))
                    continue;
                foreach (char c in query)
                    result.Append(_stringQuery[c]);
            }
            return request.IsActual(result.ToString());
        }

        public bool IsActual(Request request)
        {
            if (request == null)
                throw new ArgumentNullException();
            return request.IsActual(_stringQuery);
        }

        public Processor this[int index]
        {
            get
            {
                Processor p = _processorContainer[index];
                return ProcessorHandler.RenameProcessor(p, _stringQuery[p.Tag[0]].ToString());
            }
        }

        public int Count => _processorContainer.Count;

        public override string ToString() => _stringQuery;
    }
}