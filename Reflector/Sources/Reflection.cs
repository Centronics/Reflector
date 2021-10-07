using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DynamicParser;

namespace DynamicReflector
{
    /// <summary>
    ///     Позволяет распознавать карту с помощью различных вариантов запроса.
    ///     Этот класс реализует функциональность генератора запросов, формируя запросы, которые обрабатываются классом <see cref="Reflector" />.
    /// </summary>
    public sealed class Reflection
    {
        /// <summary>
        ///     Включает в себя все возможные запросы для разбора указанной карты, используется для вызова метода <see cref="Reflector.Push" />.
        /// </summary>
        readonly char[][,] _matrixes;

        /// <summary>
        ///     Предназначен для распознавания указанной карты.
        ///     Каждый элемент массива принимает свой запрос, и отрабатывает его в параллельном режиме.
        ///     Используется в методе <see cref="Push" />.
        /// </summary>
        readonly Reflector[] _reflectors;

        /// <summary>
        ///     Инициализирует внутренние объекты <see cref="Reflector" /> для распознавания указанных карт.
        /// </summary>
        /// <param name="processors">Карты, которые требуется узнать на входной карте.</param>
        public Reflection(ProcessorContainer[,] processors)
        {
            if (processors == null)
                throw new ArgumentNullException(nameof(processors),
                    $"{nameof(Reflection)}: Массив искомых карт равен null.");
            if (processors.GetLength(0) <= 0)
                throw new ArgumentException($"{nameof(Reflection)}: Массив искомых карт пустой (ось X).",
                    nameof(processors));
            if (processors.GetLength(1) <= 0)
                throw new ArgumentException($"{nameof(Reflection)}: Массив искомых карт пустой (ось Y).",
                    nameof(processors));
            _reflectors = new Reflector[(_matrixes = GetMatrixes(processors).ToArray()).Length];
            for (int k = 0; k < _reflectors.Length; k++)
                _reflectors[k] = new Reflector(processors);
            MapWidth = processors[0, 0].Width * processors.GetLength(0);
            MapHeight = processors[0, 0].Height * processors.GetLength(1);
        }

        /// <summary>
        ///     Ширина распознаваемой карты, которая должна подаваться на вход метода <see cref="Push" />.
        /// </summary>
        public int MapWidth { get; }

        /// <summary>
        ///     Высота распознаваемой карты, которая должна подаваться на вход метода <see cref="Push" />.
        /// </summary>
        public int MapHeight { get; }

        /// <summary>
        ///     Возвращает варианты распознавания (восприятия) одной и той же карты, путём подачи на неё различных запросов, или
        ///     пустой массив, в случае их отсутствия.
        ///     Каждый запрос выполняется параллельно, и никак не влияет на другие.
        /// </summary>
        /// <param name="processor">Карта, которую требуется распознать.</param>
        /// <returns>
        ///     Возвращает варианты распознавания (восприятия) одной и той же карты, путём подачи на неё различных запросов,
        ///     или пустой массив, в случае их отсутствия.
        /// </returns>
        public IEnumerable<Processor> Push(Processor processor)
        {
            if (processor == null)
                throw new ArgumentNullException(nameof(processor), $"{nameof(Push)}: Распознаваемая карта равна null.");
            if (processor.Width != MapWidth)
                throw new ArgumentException(
                    $"{nameof(Push)}: Распознаваемая карта не соответствует по ширине: ({processor.Width}), должно быть ({MapWidth}).",
                    nameof(processor));
            if (processor.Height != MapHeight)
                throw new ArgumentException(
                    $"{nameof(Push)}: Распознаваемая карта не соответствует по высоте: ({processor.Height}), должно быть ({MapHeight}).",
                    nameof(processor));

            Processor[] result = new Processor[_reflectors.Length];

            Exception exThrown = null;
            Parallel.For(0, _matrixes.Length, (i, state) =>
            {
                try
                {
                    result[i] = _reflectors[i].Push(processor, _matrixes[i]);
                }
                catch (Exception ex)
                {
                    state.Stop();
                    exThrown = ex;
                }
            });

            if (exThrown != null)
                throw exThrown;

            return result.Where(r => r != null).Distinct(new ProcessorSame());
        }

        /// <summary>
        ///     Возвращает все возможные варианты запросов для распознавания какой-либо карты.
        /// </summary>
        /// <param name="processors">Массив карт для чтения первых символов их названий, остальные символы игнорируются.</param>
        /// <returns>Возвращает все возможные варианты запросов для распознавания какой-либо карты.</returns>
        static IEnumerable<char[,]> GetMatrixes(ProcessorContainer[,] processors)
        {
            if (processors == null)
                throw new ArgumentNullException(nameof(processors), $"{nameof(GetMatrixes)}: Массив карт равен null.");
            int mx = processors.GetLength(0), my = processors.GetLength(1);
            if (mx <= 0)
                throw new ArgumentException($"{nameof(GetMatrixes)}: Массив карт пустой (ось X).", nameof(processors));
            if (my <= 0)
                throw new ArgumentException($"{nameof(GetMatrixes)}: Массив карт пустой (ось Y).", nameof(processors));
            int[] count = new int[processors.Length];
            do
            {
                char[,] ch = new char[mx, my];
                for (int y = 0, cy = my - 1; y < my; y++, cy--)
                    for (int x = 0, cx = mx - 1; x < mx; x++, cx--)
                    {
                        ProcessorContainer pc = processors[x, y];
                        if (pc == null)
                            throw new ArgumentNullException(nameof(processors),
                                $"{nameof(GetMatrixes)}: Элемент массива карт отсутствует (null).");
                        ch[x, y] = pc[count[cy * mx + cx]].Tag[0];
                    }
                yield return ch;
            } while (ChangeCount(count, processors));
        }

        /// <summary>
        ///     Увеличивает значение младших разрядов счётчика, если это возможно.
        ///     Если увеличение было произведено, возвращается значение <see langword="true" />, в противном случае -
        ///     <see langword="false" />.
        /// </summary>
        /// <param name="count">Массив-счётчик.</param>
        /// <param name="processors">
        ///     Требуется для уточнения количества карт в каждом элементе массива, и определения предела
        ///     увеличения значения каждого разряда массива-счётчика.
        /// </param>
        /// <returns>
        ///     Если увеличение было произведено, возвращается значение <see langword="true" />, в противном случае -
        ///     <see langword="false" />.
        /// </returns>
        static bool ChangeCount(int[] count, ProcessorContainer[,] processors)
        {
            if (count == null)
                throw new ArgumentNullException(nameof(count), $"{nameof(ChangeCount)}: Массив-счётчик равен null.");
            if (count.Length <= 0)
                throw new ArgumentException(
                    $"{nameof(ChangeCount)}: Длина массива-счётчика некорректна ({count.Length}).", nameof(count));
            if (processors == null)
                throw new ArgumentNullException(nameof(processors), $"{nameof(ChangeCount)}: Массив карт равен null.");
            int mx = processors.GetLength(0), my = processors.GetLength(1);
            if (mx <= 0)
                throw new ArgumentException($"{nameof(ChangeCount)}: Массив карт пустой (ось X).", nameof(processors));
            if (my <= 0)
                throw new ArgumentException($"{nameof(ChangeCount)}: Массив карт пустой (ось Y).", nameof(processors));
            if (count.Length != processors.Length)
                throw new ArgumentException(
                    $"{nameof(ChangeCount)}: Длина массива-счётчика не соответствует длине массива карт.",
                    nameof(processors));
            for (int k = count.Length - 1; k >= 0; k--)
            {
                int cx = k % mx, cy = k / mx, ix = mx - (cx + 1), iy = my - (cy + 1);
                if (count[k] >= processors[ix, iy].Count - 1)
                    continue;
                count[k]++;
                for (int x = k + 1; x < count.Length; x++)
                    count[x] = 0;
                return true;
            }
            return false;
        }

        /// <inheritdoc />
        /// <summary>
        ///     Служит для сравнения карт (<see cref="Processor" />) без учёта значения свойства <see cref="Processor.Tag" />.
        /// </summary>
        public class ProcessorSame : EqualityComparer<Processor>
        {
            /// <inheritdoc />
            /// <summary>
            ///     Служит для сравнения карт без учёта значения свойства <see cref="Processor.Tag" />.
            /// </summary>
            /// <param name="p1">Первая карта.</param>
            /// <param name="p2">Вторая карта.</param>
            /// <returns>В случае равенства возвращается значение <see langword="true" />, в противном случае - <see langword="false" />.</returns>
            public override bool Equals(Processor p1, Processor p2)
            {
                if (p1 == null && p2 == null)
                    return true;
                if (p1 == null || p2 == null)
                    return false;
                if (p1.Width != p2.Width)
                    return false;
                if (p1.Height != p2.Height)
                    return false;
                for (int y = 0; y < p1.Height; y++)
                    for (int x = 0; x < p1.Width; x++)
                        if (p1[x, y] != p2[x, y])
                            return false;
                return true;
            }

            /// <inheritdoc />
            public override int GetHashCode(Processor obj) => HashCreator.GetHash(obj);
        }
    }
}