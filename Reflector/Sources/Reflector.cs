using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DynamicParser;
using DynamicProcessor;
using Processor = DynamicParser.Processor;

namespace DynamicReflector
{
    /// <summary>
    ///     Синхронизирует несколькие параллельные процессы, каждый из которых будет выполнять свой запрос вне зависимости от
    ///     других процессов.
    /// </summary>
    public class Reflector
    {
        /// <summary>
        ///     Карты для выборки результатов распознавания.
        /// </summary>
        protected readonly Dictionary<char, Processor> _processors = new Dictionary<char, Processor>();

        /// <summary>
        ///     Процессы, которые будут происходить вне зависимости друг от друга.
        /// </summary>
        protected readonly ProcessorContainer[,] _processorContainers;

        /// <summary>
        ///     Инициализирует текущий экземпляр класса, добавляя указанные карты в коллекцию класса, создавая её копию. Массив
        ///     <see cref="ProcessorContainer" /> не может быть пустым или равен <see langword="null" />.
        ///     Производится проверка на отсутствие карт с одинаковыми значениями свойств <see cref="Processor.Tag" />, также
        ///     необходимо, чтобы все объекты <see cref="ProcessorContainer" /> были одинакового размера.
        ///     Количество карт в объектах <see cref="ProcessorContainer" /> должно быть не менее двух, а их свойства
        ///     <see cref="Processor.Tag" /> состояли не более, чем из одного символа.
        ///     Объекты <see cref="ProcessorContainer" /> не могут быть равны <see langword="null" />.
        /// </summary>
        /// <param name="processors">Карты, которые требуется распознать.</param>
        public Reflector(ProcessorContainer[,] processors)
        {
            if (!IsOneSize(processors))
                throw new ArgumentException(
                    $"{nameof(Reflector)}: Искомые карты не прошли проверку на размер и/или количество карт в массиве, а также на значение null или значение свойства {nameof(Processor.Tag)}.",
                    nameof(processors));
            int lx = processors.GetLength(0), ly = processors.GetLength(1);
            _processorContainers = new ProcessorContainer[lx, ly];
            for (int y = 0; y < ly; y++)
                for (int x = 0; x < lx; x++)
                {
                    ProcessorContainer pc = processors[x, y];
                    _processorContainers[x, y] = CopyContainer(pc);
                    CopyProcessorContainer(pc);
                }
            MapHeight = processors[0, 0].Height;
            MapWidth = processors[0, 0].Width;
        }

        /// <summary>
        ///     Размер добавленных карт для распознавания по высоте.
        /// </summary>
        public virtual int MapHeight { get; }

        /// <summary>
        ///     Размер добавленных карт для распознавания по ширине.
        /// </summary>
        public virtual int MapWidth { get; }

        /// <summary>
        ///     Размер, которому должна соответствовать входная распознаваемая карта по ширине.
        /// </summary>
        public virtual int ProcessorWidth => _processorContainers.GetLength(0) * MapWidth;

        /// <summary>
        ///     Размер, которому должна соответствовать входная распознаваемая карта по высоте.
        /// </summary>
        public virtual int ProcessorHeight => _processorContainers.GetLength(1) * MapHeight;

        /// <summary>
        /// Создаёт полную копию заданного контейнера.
        /// </summary>
        /// <param name="pc">Копируемый контейнер.</param>
        /// <returns>Возвращает полную копию заданного контейнера.</returns>
        static ProcessorContainer CopyContainer(ProcessorContainer pc)
        {
            if (pc == null)
                throw new ArgumentNullException(nameof(pc), "Копируемый контейнер не может быть null.");
            ProcessorContainer copy = new ProcessorContainer(pc[0]);
            for (int k = 1; k < pc.Count; k++)
                copy.Add(pc[k]);
            return copy;
        }

        /// <summary>
        ///     Добавляет карты в коллекцию, проверяя их на предмет совпадающих значений свойств <see cref="Processor.Tag" />.
        ///     Добавление производится в общую коллекцию для ускорения поиска.
        /// </summary>
        /// <param name="pc">Коллекция добавляемых карт.</param>
        protected void CopyProcessorContainer(ProcessorContainer pc)
        {
            if (pc == null)
                throw new ArgumentNullException(nameof(pc),
                    $"{nameof(CopyProcessorContainer)}: Коллекция добавляемых карт отсутствует (null).");
            for (int k = 0; k < pc.Count; k++)
            {
                Processor p = pc[k];
                char tag = char.ToUpper(p.Tag[0]);
                if (_processors.ContainsKey(tag))
                    throw new ArgumentException(
                        $"{nameof(CopyProcessorContainer)}: Обнаружены повторяющиеся карты: карта с таким названием ({tag}) уже была добавлена.",
                        nameof(pc));
                _processors[tag] = p;
            }
        }

        /// <summary>
        ///     Выполняет проверку указанного массива объектов <see cref="ProcessorContainer" /> без их изменения.
        ///     Необходимо, чтобы все объекты <see cref="ProcessorContainer" /> были одинакового размера. Массив
        ///     <see cref="ProcessorContainer" /> не может быть пустым или равен <see langword="null" />.
        ///     Количество карт в каждом объекте <see cref="ProcessorContainer" /> должно быть не менее двух, а их свойства
        ///     <see cref="Processor.Tag" /> состояли не более, чем из одного символа.
        ///     Объекты <see cref="ProcessorContainer" /> не могут быть равны <see langword="null" />.
        /// </summary>
        /// <param name="processors">Проверяемые карты.</param>
        /// <returns>
        ///     В случае успеха возвращает значение <see langword="true" />, в противном случае возвращает значение
        ///     <see langword="false" />.
        /// </returns>
        protected static bool IsOneSize(ProcessorContainer[,] processors)
        {
            if (processors == null)
                throw new ArgumentNullException(nameof(processors),
                    $"{nameof(IsOneSize)}: Проверяемые карты отсутствуют (null).");
            if (processors.GetLength(0) <= 0)
                throw new ArgumentException($"{nameof(IsOneSize)}: Массив проверяемых карт пустой (ось X).",
                    nameof(processors));
            if (processors.GetLength(1) <= 0)
                throw new ArgumentException($"{nameof(IsOneSize)}: Массив проверяемых карт пустой (ось Y).",
                    nameof(processors));
            ProcessorContainer fpc = processors[0, 0];
            if (fpc == null)
                throw new ArgumentNullException(nameof(processors),
                    $"{nameof(IsOneSize)}: Первый проверяемый массив карт равен null.");
            if (fpc.Count < 2)
                throw new ArgumentException(
                    $"{nameof(IsOneSize)}: В первом проверяемом массиве менее двух карт ({fpc.Count}).",
                    nameof(processors));
            int cx = fpc.Width;
            int cy = fpc.Height;
            for (int y = 0, my = processors.GetLength(1); y < my; y++)
                for (int x = 0, mx = processors.GetLength(0); x < mx; x++)
                {
                    ProcessorContainer pc = processors[x, y];
                    if (pc == null)
                        throw new ArgumentNullException(nameof(processors),
                            $"{nameof(IsOneSize)}: Обнаружен контейнер, равный null.");
                    if (pc.Count < 2)
                        throw new ArgumentException(
                            $"{nameof(IsOneSize)}: Обнаружен контейнер, в котором менее двух карт ({pc.Count}).",
                            nameof(processors));
                    for (int k = 0; k < pc.Count; k++)
                        if (pc[k].Tag.Length != 1)
                            throw new ArgumentException(
                                $"{nameof(IsOneSize)}: Обнаружен контейнер, в котором название карты состоит более или менее, чем из одного символа ({pc[k].Tag.Length}): ({pc[k].Tag}).",
                                nameof(processors));
                    if (pc.Width != cx || pc.Height != cy)
                        return false;
                }
            return true;
        }

        /// <summary>
        ///     В случае нахождения карты с указанным названием, возвращает её.
        ///     Название не может состоять из символа пробела или ему подобных.
        /// </summary>
        /// <param name="tag">Название карты, которую необходимо выбрать.</param>
        /// <returns>
        ///     В случае нахождения карты с указанным названием, возвращает её. В противном случае выбрасывает исключение типа
        ///     <see cref="ArgumentNullException" />.
        /// </returns>
        protected Processor GetMapByName(char tag)
        {
            if (char.IsWhiteSpace(tag))
                throw new ArgumentNullException(nameof(tag),
                    $"{nameof(GetMapByName)}: Название карты должно состоять из любых значимых символов ({tag}).");
            return _processors[char.ToUpper(tag)];
        }

        /// <summary>
        ///     Объединяет указанные карты в единую карту в соответствии с расположением карт в указанном массиве.
        ///     При этом важно, чтобы все указанные карты были одного размера.
        ///     Карты со значением <see langword="null" /> должны отсутствовать.
        /// </summary>
        /// <param name="processors">Карты, которые необходимо объединить.</param>
        /// <returns>Возвращает итоговую карту в виде массива <see cref="SignValue" />.</returns>
        protected SignValue[,] CreateMap(Processor[,] processors)
        {
            int mx = ProcessorWidth, my = ProcessorHeight;
            SignValue[,] sv = new SignValue[mx, my];
            for (int y = 0, pry = 0; y < my; y += MapHeight, pry++)
                for (int x = 0, prx = 0; x < mx; x += MapWidth, prx++)
                {
                    Processor p = processors[prx, pry];
                    for (int cy = y, pryy = 0, py = y + MapHeight; cy < py; cy++, pryy++)
                        for (int cx = x, prxx = 0, px = x + MapWidth; cx < px; cx++, prxx++)
                            sv[cx, cy] = p[prxx, pryy];
                }
            return sv;
        }

        /// <summary>
        ///     Получает заданную часть указанной карты.
        ///     Часть эта по размерам соответствует полям <see cref="MapWidth" /> и <see cref="MapHeight" />.
        /// </summary>
        /// <param name="processor">Карта, часть которой необходимо получить.</param>
        /// <param name="x">Координата X необходимой части карты.</param>
        /// <param name="y">Координата Y необходимой части карты.</param>
        /// <returns>Возвращает указанную часть карты в виде массива <see cref="SignValue" />.</returns>
        protected SignValue[,] GetMapPiece(Processor processor, int x, int y)
        {
            SignValue[,] sv = new SignValue[MapWidth, MapHeight];
            for (int cy = y, y1 = 0, my = y + MapHeight; cy < my; cy++, y1++)
                for (int cx = x, x1 = 0, mx = x + MapWidth; cx < mx; cx++, x1++)
                    sv[x1, y1] = processor[cx, cy];
            return sv;
        }

        /// <summary>
        ///     Выполняет проверку каждого символа на то, является ли он пробелом или ему подобным.
        /// </summary>
        /// <param name="words">Массив проверяемых символов.</param>
        /// <returns>
        ///     В случае, если какой-либо символ является пробелом или ему подобным, возвращается значение
        ///     <see langword="true" />, в противном случае возвращается значение <see langword="false" />.
        /// </returns>
        protected static bool IsNull(char[,] words)
        {
            if (words == null || words.Length == 0)
                return true;
            for (int y = 0, my = words.GetLength(1); y < my; y++)
                for (int x = 0, mx = words.GetLength(0); x < mx; x++)
                    if (char.IsWhiteSpace(words[x, y]))
                        return true;
            return false;
        }

        /// <summary>
        ///     Распознаёт указанную карту в соответствии с указанным шаблоном.
        ///     В случае нахождения результатов, возвращает карту, составленную из тех карт, названия которых были указаны в
        ///     параметре matrix, в противном случае возвращает значение <see langword="null" />.
        /// </summary>
        /// <param name="proc">
        ///     Карта, которую требуется распознать. Её размеры должны соответствовать значению свойств
        ///     <see cref="ProcessorWidth" /> и <see cref="ProcessorHeight" />.
        /// </param>
        /// <param name="matrix">
        ///     Шаблон распознавания. Его размеры (по ширине и высоте) равны размерам изначального массива
        ///     <see cref="ProcessorContainer" />, подаваемого на вход конструктора.
        ///     Эти размеры вычисляются как <see cref="ProcessorWidth" /> <see langword="/" /> <see cref="MapWidth" /> и
        ///     <see cref="ProcessorHeight" /> <see langword="/" /> <see cref="MapHeight" />.
        /// </param>
        /// <returns>
        ///     В случае нахождения результатов возвращает карту, составленную из тех карт, названия которых были указаны в
        ///     параметре matrix, в противном случае возвращает значение <see langword="null" />.
        /// </returns>
        public virtual Processor Push(Processor proc, char[,] matrix)
        {
            if (proc == null)
                throw new ArgumentNullException(nameof(proc), $"{nameof(Push)}: Распознаваемая карта равна null.");
            if (proc.Width != ProcessorWidth)
                throw new ArgumentException(
                    $"{nameof(Push)}: Распознаваемая карта не соответствует по ширине: ({proc.Width}) против ({ProcessorWidth}).",
                    nameof(proc));
            if (proc.Height != ProcessorHeight)
                throw new ArgumentException(
                    $"{nameof(Push)}: Распознаваемая карта не соответствует по высоте: ({proc.Height}) против ({ProcessorHeight}).",
                    nameof(proc));
            if (matrix == null)
                throw new ArgumentNullException(nameof(matrix),
                    $"{nameof(Push)}: Шаблон распознавания отсутствует (null).");
            if (matrix.GetLength(0) * MapWidth != proc.Width)
                throw new ArgumentException(
                    $"{nameof(Push)}: Шаблон распознавания не соответствует входной карте по ширине: ({matrix.GetLength(0) * MapWidth}) против ({proc.Width}).",
                    nameof(matrix));
            if (matrix.GetLength(1) * MapHeight != proc.Height)
                throw new ArgumentException(
                    $"{nameof(Push)}: Шаблон распознавания не соответствует входной карте по высоте: ({matrix.GetLength(1) * MapHeight}) против ({proc.Height}).",
                    nameof(matrix));
            if (IsNull(matrix))
                throw new ArgumentException(
                    $"{nameof(Push)}: Какой-либо элемент шаблона распознавания равен пробелу и ему подобному.",
                    nameof(matrix));
            if (!ResearchByPieces(proc, matrix))
                return null;
            int mx = _processorContainers.GetLength(0);
            int my = _processorContainers.GetLength(1);
            Processor[,] processors = new Processor[mx, my];
            for (int y = 0; y < my; y++)
                for (int x = 0; x < mx; x++)
                    processors[x, y] = GetMapByName(matrix[x, y]);
            return new Processor(CreateMap(processors), proc.Tag);
        }

        /// <summary>
        /// Исследует указанную карту по частям, применяя к ней указанный запрос.
        /// Если в каком-либо запросе происходит ошибка его выполнения, процесс завершается с результатом <see langword="false"/>.
        /// </summary>
        /// <param name="proc">Карта, которую требуется исследовать.</param>
        /// <param name="matrix">Названия карт, которые требуется найти на указанной карте.</param>
        /// <returns>В случае успешного выполнения запроса возвращается значение <see langword="true"/>, в противном случае - <see langword="false"/>.</returns>
        bool ResearchByPieces(Processor proc, char[,] matrix)
        {
            string lastErrorText = null;
            ParallelLoopResult result = Parallel.For(0, _processorContainers.Length, (k, state) =>
            {
                try
                {
                    if (state.IsStopped)
                        return;
                    int mx = _processorContainers.GetLength(0);
                    int x = k % mx, y = k / mx;
                    SignValue[,] mapPiece = GetMapPiece(proc, x * MapWidth, y * MapHeight);
                    if (state.IsStopped)
                        return;
                    Processor processor = new Processor(mapPiece, proc.Tag);
                    if (state.IsStopped)
                        return;
                    SearchResults searchResults = processor.GetEqual(_processorContainers[x, y]);
                    if (state.IsStopped)
                        return;
                    if (!searchResults.FindRelation(matrix[x, y].ToString()))
                        state.Stop();
                }
                catch (Exception ex)
                {
                    state.Stop();
                    lastErrorText = ex.Message;
                }
            });

            if (lastErrorText != null)
                throw new Exception(lastErrorText);

            return result.IsCompleted;
        }
    }
}