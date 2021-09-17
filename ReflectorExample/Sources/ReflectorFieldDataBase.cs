using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using DynamicParser;

namespace ReflectorExample.Sources
{
    /// <summary>
    /// Представляет интерфейс управления базой данных, содержащей пути к изображениям, которые находятся на поле Reflector.
    /// Любые операции сразу отражаются на жёстком диске.
    /// </summary>
    [Serializable]
    public sealed class ReflectorFieldDataBase
    {
        /// <summary>
        /// Содержит путь к базе данных, где хранятся пути к изображениям, которые находятся на поле Reflector.
        /// </summary>
        static readonly string SaveToFile = Path.Combine(Application.StartupPath, "ReflectorFieldDataBase.txt");

        /// <summary>
        /// Объект для сериализации / десериализации базы данных.
        /// </summary>
        static readonly XmlSerializer Serializer = new XmlSerializer(typeof(ReflectorFieldDataBase));

        /// <summary>
        /// База данных, которая предназначена для использования только в единственном экземпляре (Singleton).
        /// </summary>
        static ReflectorFieldDataBase _dataBase;

        /// <summary>
        /// Запрещает создание экземпляров этого класса. Этот класс может использоваться только в единственном экземпляре (Singleton).
        /// </summary>
        ReflectorFieldDataBase() { }

        /// <summary>
        /// Коллекция изображений с поля Reflector, находящаяся по координатам X = 0, Y = 0.
        /// </summary>
        public List<string> BitPaths00 { get; set; } = new List<string>();

        /// <summary>
        /// Коллекция изображений с поля Reflector, находящаяся по координатам X = 1, Y = 0.
        /// </summary>
        public List<string> BitPaths10 { get; set; } = new List<string>();

        /// <summary>
        /// Коллекция изображений с поля Reflector, находящаяся по координатам X = 2, Y = 0.
        /// </summary>
        public List<string> BitPaths20 { get; set; } = new List<string>();

        /// <summary>
        /// Коллекция изображений с поля Reflector, находящаяся по координатам X = 0, Y = 1.
        /// </summary>
        public List<string> BitPaths01 { get; set; } = new List<string>();

        /// <summary>
        /// Коллекция изображений с поля Reflector, находящаяся по координатам X = 1, Y = 1.
        /// </summary>
        public List<string> BitPaths11 { get; set; } = new List<string>();

        /// <summary>
        /// Коллекция изображений с поля Reflector, находящаяся по координатам X = 2, Y = 1.
        /// </summary>
        public List<string> BitPaths21 { get; set; } = new List<string>();

        /// <summary>
        /// Коллекция изображений с поля Reflector, находящаяся по координатам X = 0, Y = 2.
        /// </summary>
        public List<string> BitPaths02 { get; set; } = new List<string>();

        /// <summary>
        /// Коллекция изображений с поля Reflector, находящаяся по координатам X = 1, Y = 2.
        /// </summary>
        public List<string> BitPaths12 { get; set; } = new List<string>();

        /// <summary>
        /// Коллекция изображений с поля Reflector, находящаяся по координатам X = 2, Y = 2.
        /// </summary>
        public List<string> BitPaths22 { get; set; } = new List<string>();

        /// <summary>
        /// Возвращает коллекции путей к изображениям, находящихся по указанным координатам, на поле Reflector.
        /// </summary>
        /// <param name="x">Координата X на поле Reflector.</param>
        /// <param name="y">Координата Y на поле Reflector.</param>
        /// <returns>В случае успеха, возвращает коллекции путей к изображениям, в противном случае возникает исключение <see cref="ArgumentException"/>.</returns>
        static List<string> GetNamesList(int x, int y)
        {
            if (x < 0 || x > 2)
                throw new ArgumentException($@"Координата X выходит за пределы поля Reflector {x}.", nameof(x));
            if (y < 0 || y > 2)
                throw new ArgumentException($@"Координата Y выходит за пределы поля Reflector {y}.", nameof(y));

            Deserialize();

            switch (y * 3 + x)
            {
                case 0:
                    return _dataBase.BitPaths00;
                case 1:
                    return _dataBase.BitPaths10;
                case 2:
                    return _dataBase.BitPaths20;
                case 3:
                    return _dataBase.BitPaths01;
                case 4:
                    return _dataBase.BitPaths11;
                case 5:
                    return _dataBase.BitPaths21;
                case 6:
                    return _dataBase.BitPaths02;
                case 7:
                    return _dataBase.BitPaths12;
                case 8:
                    return _dataBase.BitPaths22;
                default:
                    throw new ArgumentException($@"Некорректные параметры X, Y: {x}, {y}.");
            }
        }

        /// <summary>
        /// Выполняет сериализацию базы данных путей к изображениям на поле Reflector в файл ReflectorFieldDataBase.txt, в каталоге исполняемого файла программы.
        /// </summary>
        static void Serialize()
        {
            using (FileStream fs = new FileStream(SaveToFile, FileMode.Create, FileAccess.Write))
                Serializer.Serialize(fs, _dataBase ?? new ReflectorFieldDataBase());
        }

        /// <summary>
        /// Выполняет десериализацию базы данных путей к изображениям на поле Reflector из файла ReflectorFieldDataBase.txt, в каталоге EXE-файла программы.
        /// </summary>
        static void Deserialize()
        {
            if (_dataBase != null)
                return;
            try
            {
                using (FileStream fs = new FileStream(SaveToFile, FileMode.Open, FileAccess.Read, FileShare.Read))
                    _dataBase = (ReflectorFieldDataBase) Serializer.Deserialize(fs) ?? new ReflectorFieldDataBase();
            }
            catch (FileNotFoundException)
            {
                _dataBase = new ReflectorFieldDataBase();
            }
        }

        /// <summary>
        /// Получает изображения, по указанным координатам, предназначенные для поля Reflector.
        /// База данных автоматически подгружается с жёсткого диска.
        /// </summary>
        /// <param name="x">Координата X на поле Reflector.</param>
        /// <param name="y">Координата Y на поле Reflector.</param>
        /// <returns>Возвращает последовательность изображений.</returns>
        public static IEnumerable<Processor> GetProcessors(int x, int y)
        {
            foreach (string imagePath in GetNamesList(x, y))
                using (FileStream fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                    yield return new Processor(new Bitmap(fs), Path.GetFileNameWithoutExtension(imagePath));
        }

        /// <summary>
        /// Записывает указанный путь в базу данных, сохраняя изменение на жёсткий диск.
        /// </summary>
        /// <param name="x">Координата X на поле Reflector.</param>
        /// <param name="y">Координата Y на поле Reflector.</param>
        /// <param name="imagePath">Путь, который необходимо сохранить в базе данных.</param>
        public static void Save(int x, int y, string imagePath)
        {
            GetNamesList(x, y).Add(imagePath.ToUpper());
            Serialize();
        }

        /// <summary>
        /// Удаляет указанный путь из базы данных, сохраняя изменение на жёсткий диск.
        /// </summary>
        /// <param name="x">Координата X на поле Reflector.</param>
        /// <param name="y">Координата Y на поле Reflector.</param>
        /// <param name="imagePath">Путь, который необходимо удалить из базы данных.</param>
        public static void Delete(int x, int y, string imagePath)
        {
            GetNamesList(x, y).Remove(imagePath.ToUpper());
            Serialize();
        }
    }
}
