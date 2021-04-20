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
                sbOriginal.Append(c);
            }

            _processorContainer = ph.Processors;
            _workReflex = new Reflex(_processorContainer);
            _stringOriginalQuery = sbOriginal.ToString();
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
            return new string(query.SelectMany(GetPositionByChar).ToArray());
        }

        IEnumerable<char> GetPositionByChar(char symbol)
        {
            bool result = false;
            for (char k = char.MinValue; k < _stringOriginalQuery.Length; ++k)
                if (_stringOriginalQuery[k] == symbol)
                {
                    result = true;
                    yield return k;
                }
            if (!result)
                throw new Exception("Символ обязательно должен быть найден!");
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
                yield return ProcessorHandler.RenameProcessor(p, _stringOriginalQuery[p.Tag[0]].ToString());
            }
        }

        public Reflex ToReflex() => _workReflex;

        public ProcessorContainer ToProcessorContainer()
        {
            Processor GetProcessorWithOriginalTag(Processor p)
            {
                if (p == null)
                    throw new ArgumentNullException();
                StringBuilder sb = new StringBuilder(_stringOriginalQuery[p.Tag[0]].ToString());
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
            if (!IsActual(request))
                throw new ArgumentException();
            ProcessorHandler ph = new ProcessorHandler();
            HashSet<char> strHash = new HashSet<char>();
            foreach ((Processor processor, string query) in request.Queries)
            {
                string translatedQuery = TranslateQuery(query);
                Reflex refResult = _workReflex.FindRelation(processor, translatedQuery);
                if (refResult == null)
                    continue;

                foreach (char c in translatedQuery)
                    strHash.Add(c);
                    
                ph.AddRange(GetNewProcessors(_workReflex, refResult));
            }

            return strHash.SetEquals(new HashSet<char>(TranslateQuery(request.ToString()))) ? new Neuron(ph.Processors) : null; // ПРИМЕРНО ТАК!
            //Проверить наличие ВСЕХ имеющихся карт!!
            //return request.IsActual(ph.ToString()) ? new Neuron(ph.Processors) : null;
        }

        public bool CheckRelation(Request request)
        {
            if (!IsActual(request))
                throw new ArgumentException();
            HashSet<char> strHash = new HashSet<char>();
            foreach ((Processor processor, string query) in request.Queries)
            {
                string translatedQuery = TranslateQuery(query);//Разобраться с выполнением запроса, так не будет работать, сделать его выполнение параллельным, т.е. каждую букву запроса обрабатывать отдельно.
                if (!processor.GetEqual(_processorContainer).FindRelation(translatedQuery))
                    continue;

                foreach (char c in translatedQuery)
                    strHash.Add(c);
            }

            return strHash.SetEquals(new HashSet<char>(TranslateQuery(request.ToString()))); // request.IsActual(result.ToString());
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