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
        readonly string _stringOriginalQuery;
        readonly HashSet<char> _mainCharSet = new HashSet<char>();

        public Neuron(ProcessorContainer pc)
        {
            if (pc == null)
                throw new ArgumentNullException();
            if (pc.Count > char.MaxValue)
                throw new ArgumentException();

            ProcessorHandler ph = new ProcessorHandler();
            StringBuilder sbOriginal = new StringBuilder(pc.Count);
            for (char k = char.MinValue; k < pc.Count; ++k)
            {
                if (!ph.Add(ProcessorHandler.RenameProcessor(pc[k], k.ToString())))
                    continue;
                char c = char.ToUpper(pc[k].Tag[0]);
                _mainCharSet.Add(c);
                sbOriginal.Append(c);
            }

            _processorContainer = ph.Processors;
            _workReflex = new Reflex(_processorContainer);
            _stringOriginalQuery = sbOriginal.ToString();
        }

        /// <summary>
        /// Преобразует запрос из человекочитаемой формы во внутреннее его представление.
        /// </summary>
        /// <param name="origQuery"></param>
        /// <returns>В случае ошибки возвращается <see cref="string.Empty"/>. В противном случае, строка внутреннего запроса.</returns>
        string TranslateQueryToInternal(string origQuery)
        {
            if (origQuery == null)
                throw new ArgumentException();
            return new string(origQuery.SelectMany(GetPositionByChar).ToArray());
        }

        string TranslateQueryFromInternal(string intQuery)
        {
            if (intQuery == null)
                throw new ArgumentException();
            StringBuilder sbResult = new StringBuilder(intQuery.Length);
            foreach (char c in intQuery)
                sbResult.Append(_stringOriginalQuery[c]);
            return sbResult.ToString();
        }

        IEnumerable<char> GetPositionByChar(char symbol)
        {
            for (char k = char.MinValue; k < _stringOriginalQuery.Length; ++k)
                if (_stringOriginalQuery[k] == symbol)
                {
                    yield return k;
                    yield break;
                }
            throw new Exception("Символ обязательно должен быть найден!");
        }

        IEnumerable<Processor> GetNewProcessors(Reflex start, Reflex finish)
        {
            if (start == null)
                throw new ArgumentNullException();
            if (finish == null)
                yield break;
            for (int k = start.Count; k < finish.Count; ++k)
            {
                Processor p = finish[k];
                yield return ProcessorHandler.RenameProcessor(p, _stringOriginalQuery[p.Tag[0]].ToString());
            }
        }

        public Reflex ToReflex() => _workReflex;

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
            for (int k = 1; k < toConvert.Count; ++k)
                pc.Add(GetProcessorWithOriginalTag(toConvert[k]));

            return pc;
        }

        public Neuron FindRelation(Request request)//Никакой "автоподбор" не требуется. Запоминает причины и следствия путём "перебора"... Причина и следствие могут быть любыми, отсюда - любой цвет любого пикселя на карте. Если надо поменять символ карты, можно задать такую карту без ограничений. Это и есть "счётчик".
        {
            if (!IsActual(request))
                throw new ArgumentException();
            ProcessorHandler ph = new ProcessorHandler();

            foreach ((Processor processor, string query) in request.Queries)
                foreach (string qMatrix in Matrixes(query))
                    ph.AddRange(GetNewProcessors(_workReflex, _workReflex.FindRelation(processor, qMatrix)));

            return request.IsActual(TranslateQueryFromInternal(ph.ToString())) ? new Neuron(ConvertProcessorContainerToOriginal(ph.Processors)) : null;
        }

        public bool CheckRelation(Request request)
        {
            if (!IsActual(request))
                throw new ArgumentException();
            HashSet<char> strHash = new HashSet<char>();
            foreach ((Processor processor, string query) in request.Queries)
            {
                string translatedQuery = TranslateQueryToInternal(query);//Разобраться с выполнением запроса, так не будет работать, сделать его выполнение параллельным, т.е. каждую букву запроса обрабатывать отдельно.
                if (!processor.GetEqual(_processorContainer).FindRelation(translatedQuery))
                    continue;

                foreach (char c in translatedQuery)
                    strHash.Add(c);
            }

            return strHash.SetEquals(new HashSet<char>(TranslateQueryToInternal(request.ToString()))); // request.IsActual(result.ToString());
        }

        /*public string FindRelation(Processor processor)
        {
            if (processor == null)
                throw new ArgumentNullException(nameof(processor));

            object lockObject = new object();
            StringBuilder result = new StringBuilder(_stringQuery.Length);
            string errString = string.Empty, errStopped = string.Empty;
            bool exThrown = false, exStopped = false;

            ThreadPool.GetMinThreads(out _, out int comPortMin);
            ThreadPool.SetMinThreads(Environment.ProcessorCount * 3, comPortMin);
            ThreadPool.GetMaxThreads(out _, out int comPortMax);
            ThreadPool.SetMaxThreads(Environment.ProcessorCount * 15, comPortMax);
            Parallel.For(0, _stringQuery.Length, (k, state) =>
            {
                try
                {
                    if (!processor.GetEqual(_mainContainer).FindRelation(Convert.ToChar(k).ToString()))
                        return;
                    lock (lockObject)
                        result.Append(_stringQuery[k]);
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
            return result.ToString();
        }*/

        /*public Neuron FindRelation(Request request)
        {
            if (!request.IsActual(ToString()))
                return null;
            ProcessorContainer preResult = null;
            foreach ((Processor processor, string query) in request.Queries)
                foreach (string qMatrix in Matrixes(query))
                {
                    List<Processor> lstProcs = new List<Processor>(GetNewProcessors(workReflex, refResult));
                    if (preResult == null)
                        preResult = new ProcessorContainer(lstProcs);
                    else
                        preResult.AddRange(lstProcs);
                }
            if (preResult != null)
                return new Neuron(preResult);
            return null;
        }*/

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
                _maxValue = Convert.ToChar(_values.Length - 1);
            }

            public void Reset()
            {
                _currentValue = char.MinValue;
            }

            public static StringCounter operator ++(StringCounter conv)
            {
                ++conv._currentValue;
                return conv;
            }

            public static implicit operator bool(StringCounter conv)
            {
                return conv._currentValue < conv._maxValue;
            }

            public static implicit operator char(StringCounter conv)
            {
                return conv._values[conv._currentValue];
            }
        }

        StringCounter[] GetElementNumbers(ICollection<char> chs)
        {
            StringCounter[] qTextArray = new StringCounter[chs.Count];

            int k = 0;
            foreach (char c in chs)
                qTextArray[k++] = new StringCounter(GetPositionByChar(c));

            return qTextArray;
        }

        /// <summary>
        ///     Возвращает все варианты запросов для распознавания какой-либо карты.
        /// </summary>
        /// <param name="query"></param>
        /// <returns>Возвращает все варианты запросов для распознавания какой-либо карты.</returns>
        IEnumerable<string> Matrixes(string query)
        {
            if (_processorContainer == null)
                throw new ArgumentNullException(nameof(_processorContainer), $"{nameof(Matrixes)}: Массив карт равен null.");
            int mx = _processorContainer.Count;
            if (mx <= 0)
                throw new ArgumentException($"{nameof(Matrixes)}: Массив карт пустой (ось X).", nameof(_processorContainer));
            HashSet<char> subSet = new HashSet<char>();

            foreach (char c in query)
                subSet.Add(char.ToUpper(c));

            if (!subSet.IsSubsetOf(_mainCharSet))
                throw new ArgumentException();

            foreach (string qs in GetQueryStrings(GetElementNumbers(subSet)))
                yield return qs;
        }

        /* /// <summary> //OLDDDDDDDDDDDDDDD
           ///     Возвращает все варианты запросов для распознавания какой-либо карты.
           /// </summary>
           /// <param name="_processorContainer">Массив карт для чтения первых символов их названий. Остальные символы игнорируются.</param>
           /// <returns>Возвращает все варианты запросов для распознавания какой-либо карты.</returns>
           IEnumerable<ProcessorContainer> Matrixes//МОЖНО РАБОТАТЬ!
           {
               get
               {
                   if (_processorContainer == null)
                       throw new ArgumentNullException(nameof(_processorContainer), $"{nameof(Matrixes)}: Массив карт равен null.");
                   int mx = _processorContainer.Count;
                   if (mx <= 0)
                       throw new ArgumentException($"{nameof(Matrixes)}: Массив карт пустой (ось X).", nameof(_processorContainer));
                   int[] count = new int[_processorContainer.Count];
                   HashSet<char> charSet = new HashSet<char>();
                   do
                   {
                       ProcessorContainer result = null;
                       charSet.Clear();
                       for (int x = 0; x < mx; ++x)
                           if (count[x] < mx)
                           {
                               Processor p = _processorContainer[count[x]];
                               charSet.Add(_stringOriginalQuery[p.Tag[0]]);
                               if (result == null)
                                   result = new ProcessorContainer(p);
                               else
                                   result.Add(p);
                           }
                       if (_mainCharSet.IsSubsetOf(charSet))
                           yield return result;
                   } while (ChangeCount(count));
               }
           }
   */

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
                if (!counters[k])
                    continue;

                output[k] = ++counters[k];

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