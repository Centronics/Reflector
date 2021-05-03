using System;
using System.Collections.Generic;
using System.Linq;
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
        readonly string _stringOriginalQuery, _stringInternalQuery;

        public Neuron(ProcessorContainer pc)
        {
            if (pc == null)
                throw new ArgumentNullException();
            if (pc.Count > char.MaxValue)
                throw new ArgumentException();

            ProcessorHandler ph = new ProcessorHandler();
            StringBuilder sbOriginal = new StringBuilder(pc.Count);
            for (char k = char.MinValue; k < pc.Count; k++)
            {
                Processor p = pc[k];
                if (ph.Add(ProcessorHandler.RenameProcessor(p, k.ToString())))
                    sbOriginal.Append(char.ToUpper(p.Tag[0]));
            }

            _processorContainer = ph.Processors;
            _stringInternalQuery = ph.ToString();
            _workReflex = new Reflex(_processorContainer);
            _stringOriginalQuery = sbOriginal.ToString();
        }

        char[] GetPositionsOfChar(char symbol)
        {
            IEnumerable<char> GetPositions()
            {
                for (char k = char.MinValue; k < _stringOriginalQuery.Length; k++)
                    if (_stringOriginalQuery[k] == symbol)
                        yield return k;
            }

            return GetPositions().ToArray();
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

        public ProcessorContainer ToProcessorContainer() => ConvertProcessorContainerToOriginal(_processorContainer);

        ProcessorContainer ConvertProcessorContainerToOriginal(ProcessorContainer toConvert)
        {
            Processor GetProcessorWithOriginalTag(Processor p)
            {
                if (p == null)
                    throw new ArgumentNullException();
                StringBuilder sb = new StringBuilder(_stringOriginalQuery[p.Tag[0]].ToString());
                sb.Append(p.Tag, 1, p.Tag.Length - 1);
                return ProcessorHandler.RenameProcessor(p, sb.ToString());
            }

            ProcessorContainer pc = new ProcessorContainer(GetProcessorWithOriginalTag(toConvert[0]));
            for (int k = 1; k < toConvert.Count; k++)
                pc.Add(GetProcessorWithOriginalTag(toConvert[k]));

            return pc;
        }

        public Neuron FindRelation(Request request)
        {
            if (!IsActual(request))
                throw new ArgumentException();
            ProcessorHandler ph = new ProcessorHandler();

            foreach ((Processor processor, string query) in request.Queries)
                foreach (string qMatrix in Matrixes(query))
                    ph.AddRange(GetNewProcessors(_workReflex, _workReflex.FindRelation(processor, qMatrix)));

            return ph.SetEquals(_stringInternalQuery) ? new Neuron(ConvertProcessorContainerToOriginal(ph.Processors)) : null;
        }

        public bool CheckRelation(Request request)
        {
            if (!IsActual(request))
                throw new ArgumentException();
            HashSet<char> strHash = new HashSet<char>();

            foreach ((Processor processor, string query) in request.Queries)
                foreach (string qMatrix in Matrixes(query))
                {
                    if (!processor.GetEqual(_processorContainer).FindRelation(qMatrix))
                        continue;

                    foreach (char c in qMatrix)
                        strHash.Add(c);
                }

            return strHash.SetEquals(_stringInternalQuery);
        }

        struct StringCounter
        {
            char _currentValue;
            readonly char _maxValue;
            readonly char[] _values;

            public StringCounter(IEnumerable<char> values)
            {
                if (values == null)
                    throw new ArgumentNullException();
                _values = values.ToArray();
                if (_values == null || _values.Length <= 0)
                    throw new ArgumentException();
                _currentValue = char.MinValue;
                _maxValue = Convert.ToChar(_values.Length);
            }

            public void Reset() => _currentValue = char.MinValue;

            public static StringCounter operator ++(StringCounter conv)
            {
                if (conv)
                    conv._currentValue++;
                return conv;
            }

            public static implicit operator bool(StringCounter conv) => conv._currentValue < conv._maxValue;

            public static implicit operator char(StringCounter conv) => conv._values[conv._currentValue];
        }

        /// <summary>
        ///     Возвращает все варианты запросов для распознавания какой-либо карты.
        /// </summary>
        /// <param name="query"></param>
        /// <returns>Возвращает все варианты запросов для распознавания какой-либо карты.</returns>
        IEnumerable<string> Matrixes(string query)
        {
            if (query == null)
                throw new ArgumentNullException(nameof(query), $"{nameof(Matrixes)}: {nameof(query)} равен null.");
            if (string.IsNullOrWhiteSpace(query))
                throw new ArgumentException($"{nameof(Matrixes)}: {nameof(query)} пустой.", nameof(query));

            List<StringCounter> lst = query.Select(GetPositionsOfChar).TakeWhile(chars => chars.Length > 0).Select(chars => new StringCounter(chars)).ToList();//ДОДЕЛАТЬ

            foreach (string qs in GetQueryStrings(query.Select(c => new StringCounter(GetPositionsOfChar(c))).ToArray()))
                yield return qs;
        }

        /// <summary>
        ///     Увеличивает значение старших разрядов счётчика букв, если это возможно.
        ///     Если увеличение было произведено, возвращается значение <see langword="true" />, в противном случае -
        ///     <see langword="false" />.
        /// </summary>
        /// <param name="counters">Массив-счётчик.</param>
        /// <returns>
        ///     Если увеличение было произведено, возвращается значение <see langword="true" />, в противном случае -
        ///     <see langword="false" />.
        /// </returns>
        IEnumerable<string> GetQueryStrings(StringCounter[] counters)
        {
            if (counters == null)
                throw new ArgumentNullException(nameof(counters), $"{nameof(GetQueryStrings)}: Массив-счётчик равен null.");
            if (counters.Length <= 0)
                throw new ArgumentException(
                    $"{nameof(GetQueryStrings)}: Длина массива-счётчика некорректна ({counters.Length}).", nameof(counters));

            char[] output = new char[counters.Length];
            for (int k = counters.Length - 1; k >= 0; --k)
            {
                output[k] = counters[k];

                if (!counters[k])
                    continue;

                counters[k]++;

                for (int x = k + 1; x < counters.Length; x++)
                {
                    counters[x].Reset();
                    output[x] = counters[x];
                }

                yield return new string(output);
            }
        }

        public bool IsActual(Request request)
        {
            if (request == null)
                throw new ArgumentNullException();
            return request.IsActual(_stringOriginalQuery);
        }

        public Processor this[int index]
        {
            get
            {
                Processor p = _processorContainer[index];
                return ProcessorHandler.RenameProcessor(p, _stringOriginalQuery[p.Tag[0]].ToString());
            }
        }

        public int Count => _processorContainer.Count;

        public override string ToString() => _stringOriginalQuery;
    }
}