using System;
using System.Collections.Generic;
using System.Linq;

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
            for (int k = 0; k < Table.Length; ++k)
            {
                int num = k;
                for (int i = 0; i < 8; ++i)
                    if ((uint) (num & 128) > 0U)
                        num = (num << 1) ^ 49;
                    else
                        num <<= 1;
                Table[k] = num;
            }
        }

        /// <summary>
        ///     Возвращает значение хеш-кода.
        /// </summary>
        /// <param name="bytes">Последовательность байт, для которой требуется расчёт хеш-кода.</param>
        /// <returns>Возвращает значение хеш-кода.</returns>
        public static int Checksum(IEnumerable<byte> bytes)//Можно использовать и для Мастера, в том числе
        {
            if (bytes == null)
                throw new ArgumentNullException(nameof(bytes),
                    $"{nameof(Checksum)}: Для подсчёта хеша необходимо указать массив байт.");
            return bytes.Aggregate(255, (current, b) => Table[unchecked((byte) (current ^ b))]);
        }
    }
}