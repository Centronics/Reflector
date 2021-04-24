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

        /// <summary>
        ///     Возвращает все варианты запросов для распознавания какой-либо карты.
        /// </summary>
        /// <param name="_processorContainer">Массив карт для чтения первых символов их названий. Остальные символы игнорируются.</param>
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
            int[] count = new int[subSet.Count];
            HashSet<char> charSet = new HashSet<char>();
            StringBuilder result = new StringBuilder(subSet.Count);
            do
            {
                result.Clear();
                charSet.Clear();
                foreach (int t in count)
                {
                    char cInternal = _processorContainer[t].Tag[0];
                    charSet.Add(_stringOriginalQuery[cInternal]);
                    result.Append(cInternal);
                }

                if (subSet.SetEquals(charSet))
                    yield return result.ToString();
            } while (ChangeCount(count));
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
        /// <param name="count">Массив-счётчик.</param>
        /// <returns>
        ///     Если увеличение было произведено, возвращается значение <see langword="true" />, в противном случае -
        ///     <see langword="false" />.
        /// </returns>
        bool ChangeCount(int[] count)
        {
            if (count == null)
                throw new ArgumentNullException(nameof(count), $"{nameof(ChangeCount)}: Массив-счётчик равен null.");
            if (count.Length <= 0)
                throw new ArgumentException(
                    $"{nameof(ChangeCount)}: Длина массива-счётчика некорректна ({count.Length}).", nameof(count));
            if (_processorContainer == null)
                throw new ArgumentNullException(nameof(_processorContainer), $"{nameof(ChangeCount)}: Массив карт равен null.");
            if (_processorContainer.Count <= 0)
                throw new ArgumentException($"{nameof(ChangeCount)}: Массив карт пустой (ось X).", nameof(_processorContainer));
            for (int k = count.Length - 1; k >= 0; k--)
            {
                if (count[k] >= _processorContainer.Count - 1)
                    continue;
                count[k]++;
                for (int x = k + 1; x < count.Length; x++)
                    count[x] = 0;
                return true;
            }
            return false;
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