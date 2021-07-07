using System;
using System.Collections.Generic;
using System.Linq;
using DynamicParser;

namespace DynamicReflector
{
    /// <summary>
    ///     Генерирует хеш-код массива байт.
    /// </summary>
    public static class HashCreator
    {
        /// <summary>
        ///     Таблица значений хеш-кода.
        /// </summary>
        static readonly int[] Table = new int[256];

        /// <summary>
        ///     Инициализирует таблицу значений хеш-кода.
        /// </summary>
        static HashCreator()
        {
            for (int k = 0; k < Table.Length; k++)
            {
                int num = k;
                for (int i = 0; i < 8; i++)
                    if ((uint)(num & 128) > 0U)
                        num = (num << 1) ^ 49;
                    else
                        num <<= 1;
                Table[k] = num;
            }
        }

        /// <summary>
        ///     Получает хеш заданной карты, без учёта значения свойства <see cref="Processor.Tag"/>.
        ///     Карта не может быть равна <see langword="null" />.
        /// </summary>
        /// <param name="p">Карта, для которой необходимо вычислить значение хеша.</param>
        /// <returns>Возвращает хеш заданной карты.</returns>
        public static int GetHash(Processor p)
        {
            if (p is null)
                throw new ArgumentNullException(nameof(p), $@"Функция {nameof(GetHash)}.");
            return GetProcessorBytes(p).Aggregate(255, (currentValue, currentByte) => Table[unchecked((byte)(currentValue ^ currentByte))]);
        }

        /// <summary>
        ///     Представляет содержимое карты в виде последовательности байт. Поле <see cref="Processor.Tag" /> не учитывается.
        ///     Перечисление строк карты происходит последовательно: от меньшего индекса к большему.
        /// </summary>
        /// <param name="p">Карта, содержимое которой необходимо получить.</param>
        /// <returns>Возвращает содержимое карты в виде последовательности байт.</returns>
        static IEnumerable<byte> GetProcessorBytes(Processor p)
        {
            if (p == null)
                throw new ArgumentNullException(nameof(p), $"{nameof(GetProcessorBytes)}: Карта равна значению null.");
            for (int y = 0; y < p.Height; y++)
                for (int x = 0; x < p.Width; x++)
                {
                    byte[] res = BitConverter.GetBytes(p[x, y].Value);
                    foreach (byte r in res)
                        yield return r;
                }
        }
    }
}