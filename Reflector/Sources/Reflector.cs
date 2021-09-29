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
        readonly Dictionary<char, Processor> _processors = new Dictionary<char, Processor>();

        /// <summary>
        ///     Предназначены для процессов распознавания, которые будут происходить параллельно.
        /// </summary>
        readonly ProcessorContainer[,] _processorContainers;

        /// <summary>
        ///     Инициализирует текущий экземпляр класса, добавляя указанные карты в коллекцию класса, создавая её копию.
        ///     Проверяет, чтобы все <see cref="ProcessorContainer" /> были одного размера, и отсутствовали карты с одинаковыми значениями свойств <see cref="Processor.Tag" />.
        ///     Количество карт в каждом массиве <see cref="ProcessorContainer" /> должно быть не менее двух, а их свойства <see cref="Processor.Tag" /> состояли из одного символа.
        /// </summary>
        /// <param name="processors">Карты, которые требуется распознать.</param>
        public Reflector(ProcessorContainer[,] processors)
        {
            CheckContainers(processors);

            int mx = processors.GetLength(0), my = processors.GetLength(1);
            _processorContainers = new ProcessorContainer[mx, my];

            for (int y = 0; y < my; y++)
                for (int x = 0; x < mx; x++)
                    AddToCache(_processorContainers[x, y] = CopyContainer(processors[x, y]));

            MapWidth = processors[0, 0].Width;
            MapHeight = processors[0, 0].Height;
        }

        /// <summary>
        ///     Размер добавленных карт для распознавания, по высоте.
        /// </summary>
        public int MapHeight { get; }

        /// <summary>
        ///     Размер добавленных карт для распознавания, по ширине.
        /// </summary>
        public int MapWidth { get; }

        /// <summary>
        ///     Размер, которому должна соответствовать входная распознаваемая карта, по ширине.
        /// </summary>
        public int ProcessorWidth => _processorContainers.GetLength(0) * MapWidth;

        /// <summary>
        ///     Размер, которому должна соответствовать входная распознаваемая карта, по высоте.
        /// </summary>
        public int ProcessorHeight => _processorContainers.GetLength(1) * MapHeight;

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
        ///     Добавляет указанные карты в коллекцию, проверяя их на предмет совпадающих значений свойств <see cref="Processor.Tag" />.
        ///     Для ускорения поиска, добавление карт производится в общую коллекцию.
        /// </summary>
        /// <param name="pc">Коллекция добавляемых карт.</param>
        void AddToCache(ProcessorContainer pc)
        {
            if (pc == null)
                throw new ArgumentNullException(nameof(pc),
                    $"{nameof(AddToCache)}: Коллекция добавляемых карт отсутствует (null).");

            for (int k = 0; k < pc.Count; k++)
            {
                Processor p = pc[k];
                char tag = char.ToUpper(p.Tag[0]);

                try
                {
                    _processors.Add(tag, p);
                }
                catch (ArgumentException)
                {
                    throw new ArgumentException(
                        $"{nameof(AddToCache)}: Обнаружены повторяющиеся карты: карта с таким названием ({tag}) уже была добавлена.",
                        nameof(pc));
                }
            }
        }

        /// <summary>
        ///     Проверяет, чтобы все <see cref="ProcessorContainer" /> были одного размера.
        ///     Количество карт в каждом массиве <see cref="ProcessorContainer" /> должно быть не менее двух, а их свойства <see cref="Processor.Tag" /> состояли из одного символа.
        /// </summary>
        /// <param name="processors">Проверяемые карты.</param>
        static void CheckContainers(ProcessorContainer[,] processors)
        {
            if (processors == null)
                throw new ArgumentNullException(nameof(processors),
                    $"{nameof(CheckContainers)}: Проверяемые карты отсутствуют (null).");
            if (processors.GetLength(0) <= 0)
                throw new ArgumentException($"{nameof(CheckContainers)}: Массив проверяемых карт пустой (ось X).",
                    nameof(processors));
            if (processors.GetLength(1) <= 0)
                throw new ArgumentException($"{nameof(CheckContainers)}: Массив проверяемых карт пустой (ось Y).",
                    nameof(processors));
            ProcessorContainer fpc = processors[0, 0];
            if (fpc == null)
                throw new ArgumentNullException(nameof(processors),
                    $"{nameof(CheckContainers)}: Первый проверяемый массив карт равен null.");
            if (fpc.Count < 2)
                throw new ArgumentException(
                    $"{nameof(CheckContainers)}: В первом проверяемом массиве менее двух карт ({fpc.Count}).",
                    nameof(processors));
            for (int y = 0, my = processors.GetLength(1); y < my; y++)
                for (int x = 0, mx = processors.GetLength(0); x < mx; x++)
                {
                    ProcessorContainer pc = processors[x, y];
                    if (pc == null)
                        throw new ArgumentNullException(nameof(processors),
                            $"{nameof(CheckContainers)}: Обнаружен контейнер, равный null.");
                    if (pc.Count < 2)
                        throw new ArgumentException(
                            $"{nameof(CheckContainers)}: Обнаружен контейнер, в котором менее двух карт ({pc.Count}).",
                            nameof(processors));
                    for (int k = 0; k < pc.Count; k++)
                        if (pc[k].Tag.Length != 1)
                            throw new ArgumentException(
                                $"{nameof(CheckContainers)}: Обнаружен контейнер ({x}, {y}), в котором название карты состоит более или менее, чем из одного символа ({pc[k].Tag.Length}): ({pc[k].Tag}).",
                                nameof(processors));
                    if (pc.Width != fpc.Width || pc.Height != fpc.Height)
                        throw new ArgumentException($"{nameof(CheckContainers)}: Проверяемые карты не прошли проверку размера.", nameof(processors));
                }
        }

        /// <summary>
        ///     Объединяет указанные карты в единую карту, в соответствии с расположением карт в указанном массиве.
        ///     При этом важно, чтобы все указанные карты были одного размера.
        ///     Карты со значением <see langword="null" /> должны отсутствовать.
        /// </summary>
        /// <param name="processors">Карты, которые необходимо объединить.</param>
        /// <returns>Возвращает итоговую карту в виде массива <see cref="SignValue" />.</returns>
        SignValue[,] MergeMap(Processor[,] processors)
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
        /// <returns>Возвращает указанную часть карты, в виде массива <see cref="SignValue" />.</returns>
        SignValue[,] GetMapPiece(Processor processor, int x, int y)
        {
            SignValue[,] sv = new SignValue[MapWidth, MapHeight];
            for (int cy = y, y1 = 0, my = y + MapHeight; cy < my; cy++, y1++)
                for (int cx = x, x1 = 0, mx = x + MapWidth; cx < mx; cx++, x1++)
                    sv[x1, y1] = processor[cx, cy];
            return sv;
        }

        /// <summary>
        ///     Распознаёт указанную карту, в соответствии с указанным шаблоном.
        ///     В случае нахождения результатов, возвращает карту, составленную из тех карт, названия которых были указаны в
        ///     параметре matrix, в противном случае, возвращает значение <see langword="null" />.
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
        ///     В случае нахождения результатов, возвращает карту, составленную из тех карт, названия которых были указаны в
        ///     параметре matrix. В противном случае, возвращает значение <see langword="null" />.
        /// </returns>
        public Processor Push(Processor proc, char[,] matrix)
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
            if (!ResearchByPieces(proc, matrix))
                return null;
            int mx = _processorContainers.GetLength(0);
            int my = _processorContainers.GetLength(1);
            Processor[,] processors = new Processor[mx, my];
            for (int y = 0; y < my; y++)
                for (int x = 0; x < mx; x++)
                    processors[x, y] = _processors[char.ToUpper(matrix[x, y])];
            return new Processor(MergeMap(processors), proc.Tag);
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
            Exception exThrown = null;
            ParallelLoopResult result = Parallel.For(0, _processorContainers.Length, (k, state) =>
            {
                try
                {
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
                    exThrown = ex;
                }
            });

            if (exThrown != null)
                throw exThrown;

            return result.IsCompleted;
        }
    }
}