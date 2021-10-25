using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using DynamicParser;
using DynamicProcessor;
using Processor = DynamicParser.Processor;

namespace DynamicReflector
{
    /// <summary>
    /// Хранит одни и те же данные в нескольких представлениях одновременно.
    /// Позволяет переходить из одной формы в другую, при сохранении формата данных, создавая новые <see cref="Neuron"/>.
    /// Содержит только уникальные данные, уникально их идентифицируя, без учёта регистра. Карты могут быть только одного размера.
    /// </summary>
    public sealed class Neuron
    {
        /// <summary>
        /// Служит для выполнения запроса на поиск данных.
        /// </summary>
        readonly ProcessorContainer _workProcessorContainer;

        /// <summary>
        /// Служит для контроля за уникальностью входных данных.
        /// Так же служит для проверки возможности выполнения запроса.
        /// </summary>
        readonly HashSet<char> _hashSetOriginalUniqueQuery = new HashSet<char>();

        /// <summary>
        /// Хранит размер карт, содержащихся в текущем экземпляре.
        /// Этот размер задаётся при инициализации и является константным.
        /// </summary>
        readonly Size _mainSize;

        /// <summary>
        /// Должно быть не менее двух карт. Содержимое карт должно быть уникальным, первые буквы названий карт также должны быть уникальными, без учёта регистра.
        /// Значение <see langword="null" /> не допускается.
        /// </summary>
        /// <param name="pc">Загружаемый контейнер.</param>
        public Neuron(ProcessorContainer pc)
        {
            if (pc == null)
                throw new ArgumentNullException(nameof(pc), $"{nameof(Neuron)}: Загружаемый контейнер равен null.");
            if (pc.Count < 2)
                throw new ArgumentException("Количество карт во входном контейнере должно быть два и более.", nameof(pc));
            _mainSize = new Size(pc.Width, pc.Height);
            _workProcessorContainer = new ProcessorContainer(ParseInitData(pc).ToArray());
        }

        /// <summary>
        /// Инициализирует текущий экземпляр, заполняет хранилище быстрого доступа к картам, проверяет содержимое и названия карт на уникальность, отрезая все остальные символы в их названии, кроме первого.
        /// Генерирует новый <see cref="ProcessorContainer"/>, который содержит карты, называемые только одной заглавной буквой.
        /// </summary>
        /// <param name="pc">Загружаемый контейнер.</param>
        /// <returns>Возвращает новый <see cref="ProcessorContainer"/>, который содержит карты, называемые только одной заглавной буквой.</returns>
        IEnumerable<Processor> ParseInitData(ProcessorContainer pc)
        {
            Dictionary<int, Processor> chi = new Dictionary<int, Processor>(pc.Count);
            for (int k = 0; k < pc.Count; k++)
            {
                Processor p = pc[k];
                if (!_hashSetOriginalUniqueQuery.Add(char.ToUpper(p.Tag[0])))
                    throw new ArgumentException("Требуется, чтобы первые буквы названий карт, были уникальными, без учёта регистра.", nameof(pc));
                int hash = HashCreator.GetHash(p);
                if (!chi.TryGetValue(hash, out Processor proc))
                    chi.Add(hash, p);
                else if (ProcessorCompare(proc, p))
                    throw new ArgumentException("Одинаковое содержимое карт недопустимо.", nameof(pc));
                yield return p;
            }
        }

        /// <summary>
        /// Генерирует карту с указанным новым значением свойства <see cref="Processor.Tag"/>.
        /// В случае, если новое и старое значения свойства <see cref="Processor.Tag"/> совпадают (с учётом регистра), то возвращается та же карта, которая была подана на вход.
        /// </summary>
        /// <param name="processor">Карта, значение свойства <see cref="Processor.Tag"/> которой требуется изменить.</param>
        /// <param name="newTag">Новое значение свойства <see cref="Processor.Tag"/>. Не может быть пустым.</param>
        /// <returns>Карта с новым значением свойства <see cref="Processor.Tag"/>.</returns>
        static Processor ChangeProcessorTag(Processor processor, string newTag)
        {
            if (processor.Tag == newTag)
                return processor;

            SignValue[,] sv = new SignValue[processor.Width, processor.Height];
            for (int i = 0; i < processor.Width; i++)
                for (int j = 0; j < processor.Height; j++)
                    sv[i, j] = processor[i, j];
            return new Processor(sv, newTag);
        }

        /// <summary>
        /// Сравнивает указанные карты.
        /// Сравнение производится только по содержимому.
        /// Подаваемые значения <see langword="null" /> вызовут неопределённое поведение.
        /// </summary>
        /// <param name="p1">Первая сравниваемая карта.</param>
        /// <param name="p2">Вторая сравниваемая карта.</param>
        /// <returns>
        /// В случае равенства карт возвращается значение <see langword="true" />, в противном случае - <see langword="false" />.
        /// </returns>
        static bool ProcessorCompare(Processor p1, Processor p2)
        {
            for (int i = 0; i < p1.Width; i++)
                for (int j = 0; j < p1.Height; j++)
                    if (p1[i, j] != p2[i, j])
                        return false;
            return true;
        }

        /// <summary>
        /// Проверяет запрос на соответствие следующим правилам.
        /// 1) Карта не должна быть <see langword="null" />.
        /// 2) Запрос не может быть пустым, <see langword="null" /> или белым полем.
        /// 3) Размеры карт должны соответствовать размерам карт, принятым в текущем экземпляре.
        /// 4) В запросах не может быть повторений (без учёта регистра).
        /// 5) Содержимое карт не может повторяться.
        /// 6) Количество запросов должно быть равно количеству карт в текущем экземпляре.
        /// 7) Названия запрашиваемых карт должны полностью соответствовать тем, что есть в текущем экземпляре.
        /// </summary>
        /// <param name="queries">Пары, содержащие карту и запрос, который необходимо для неё выполнить.</param>
        void CheckQuery(IEnumerable<(Processor, char)> queries)
        {
            Dictionary<int, Processor> chi = new Dictionary<int, Processor>();
            HashSet<char> chs = new HashSet<char>();
            foreach ((Processor p, char c) in queries)
            {
                if (p == null)
                    throw new ArgumentNullException(nameof(queries), "Карта равна null.");
                if (char.IsWhiteSpace(c))
                    throw new ArgumentException("Запрос не может быть пустым, null или белым полем.", nameof(queries));
                if (p.Size != _mainSize)
                    throw new ArgumentException("Размеры входящих карт должны совпадать с размерами карт в текущем экземпляре.", nameof(queries));
                if (!chs.Add(char.ToUpper(c)))
                    throw new ArgumentException("Содержимое запросов не может дублироваться.", nameof(queries));
                int hash = HashCreator.GetHash(p);
                if (!chi.TryGetValue(hash, out Processor proc))
                {
                    chi.Add(hash, p);
                    continue;
                }
                if (ProcessorCompare(proc, p))
                    throw new ArgumentException("Карты с совпадающим содержимым в запросе недопустимы.", nameof(queries));
            }

            if (chs.Count != _hashSetOriginalUniqueQuery.Count)
                throw new ArgumentException("Количество запросов не равно количеству карт в текущем экземпляре.", nameof(queries));
            if (!chs.SetEquals(_hashSetOriginalUniqueQuery))
                throw new ArgumentException("Названия запрашиваемых карт не соответствуют тем, что есть в текущем экземпляре.", nameof(queries));
        }

        /// <summary>
        /// Выполняет все запросы в заданной коллекции. Выполнение производится в многопоточном режиме, поэтому порядок их выполнения неопределён.
        /// Для параллельного выполнения запросов используется пул потоков.
        /// В результате выполнения запросов будет сформирован новый <see cref="Neuron"/>, содержащий новые карты, взятые из результатов выполнения запросов.
        /// Названия карт берутся из символов запросов.
        /// В случае ошибки в каком-либо запросе, выбрасывается исключение <see cref="ArgumentException"/>.
        /// После вызова этого метода текущий экземпляр класса <see cref="Neuron"/> остаётся в том же состоянии, в котором он был до вызова.
        /// Этот метод можно вызывать из нескольких потоков без блокировки.
        /// Проверка правильности запроса выполняется по следующим правилам.
        /// 1) Карта не должна быть <see langword="null" />.
        /// 2) Запрос не может быть пустым, <see langword="null" /> или белым полем.
        /// 3) Размеры карт должны соответствовать размерам карт, принятым в текущем экземпляре.
        /// 4) В запросах не может быть повторений (без учёта регистра).
        /// 5) Содержимое карт не может повторяться.
        /// 6) Количество запросов должно быть равно количеству карт в текущем экземпляре.
        /// 7) Названия запрашиваемых карт должны полностью соответствовать тем, что есть в текущем экземпляре.
        /// </summary>
        /// <param name="queryPairs">Пары, содержащие карту и запрос, который необходимо для неё выполнить.</param>
        /// <returns>Возвращает новый <see cref="Neuron"/>, содержащий новые карты, взятые из результатов выполнения запросов, или исключение <see cref="ArgumentException"/>, в случае ошибки.</returns>
        public Neuron FindRelation(IEnumerable<(Processor, char)> queryPairs)
        {
            if (queryPairs == null)
                throw new ArgumentNullException(nameof(queryPairs), "Последовательность запросов равна null.");
            (Processor, char)[] queries = queryPairs as (Processor, char)[] ?? queryPairs.ToArray();

            CheckQuery(queries);

            Exception exThrown = null;

            //Parallel.ForEach(queries, ((Processor p, string q), ParallelLoopState state) =>
            foreach ((Processor p, char c) in queries)
            {
                try
                {
                    if (!p.GetEqual(_workProcessorContainer).FindRelation(c.ToString()))
                        throw new ArgumentException("При выполнении запроса произошла ошибка - результат отсутствует.", nameof(queryPairs));
                }
                catch (Exception ex)
                {
                    exThrown = ex;
                    break;
                    //state.Stop();
                }
            }//);

            if (exThrown != null)
                throw exThrown;

            return new Neuron(new ProcessorContainer(queries.Select(((Processor p, char c) e) => ChangeProcessorTag(e.p, e.c.ToString())).ToArray()));
        }

        /// <summary>
        /// Получает карты текущего экземпляра.
        /// </summary>
        public IEnumerable<Processor> Processors
        {
            get
            {
                for (int k = 0; k < _workProcessorContainer.Count; k++)
                    yield return _workProcessorContainer[k];
            }
        }
    }
}