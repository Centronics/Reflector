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
    /// Представляет интерфейс управления базой данных, содержащей пути к изображениям, с поля Reflector.
    /// Любые операции сразу отражаются на жёстком диске.
    /// </summary>
    [Serializable]
    public sealed class ReflectorField
    {
        /// <summary>
        /// Содержит путь к базе данных, где хранятся пути к изображениям, находящимся на поле Reflector.
        /// </summary>
        static readonly string SaveToFile = Path.Combine(Application.StartupPath, "ReflectorFieldDataBase.txt");

        /// <summary>
        /// Объект для сериализации / десериализации базы данных.
        /// </summary>
        static readonly XmlSerializer Xml = new XmlSerializer(typeof(ReflectorField));

        /// <summary>
        /// База данных текущего экземпляра.
        /// </summary>
        static ReflectorField _dataBase;

        /// <summary>
        /// Запрещает создание экземпляров этого класса. Этот класс может использоваться только в единственном экземпляре (Singleton).
        /// </summary>
        ReflectorField() { }

        /// <summary>
        /// Коллекция изображений с поля Reflector, находящаяся по координатам X = 0, Y = 0.
        /// </summary>
        public List<string> Bitmaps00 { get; set; } = new List<string>();

        /// <summary>
        /// Коллекция изображений с поля Reflector, находящаяся по координатам X = 1, Y = 0.
        /// </summary>
        public List<string> Bitmaps10 { get; set; } = new List<string>();

        /// <summary>
        /// Коллекция изображений с поля Reflector, находящаяся по координатам X = 2, Y = 0.
        /// </summary>
        public List<string> Bitmaps20 { get; set; } = new List<string>();

        /// <summary>
        /// Коллекция изображений с поля Reflector, находящаяся по координатам X = 0, Y = 1.
        /// </summary>
        public List<string> Bitmaps01 { get; set; } = new List<string>();

        /// <summary>
        /// Коллекция изображений с поля Reflector, находящаяся по координатам X = 1, Y = 1.
        /// </summary>
        public List<string> Bitmaps11 { get; set; } = new List<string>();

        /// <summary>
        /// Коллекция изображений с поля Reflector, находящаяся по координатам X = 2, Y = 1.
        /// </summary>
        public List<string> Bitmaps21 { get; set; } = new List<string>();

        /// <summary>
        /// Коллекция изображений с поля Reflector, находящаяся по координатам X = 0, Y = 2.
        /// </summary>
        public List<string> Bitmaps02 { get; set; } = new List<string>();

        /// <summary>
        /// Коллекция изображений с поля Reflector, находящаяся по координатам X = 1, Y = 2.
        /// </summary>
        public List<string> Bitmaps12 { get; set; } = new List<string>();

        /// <summary>
        /// Коллекция изображений с поля Reflector, находящаяся по координатам X = 2, Y = 2.
        /// </summary>
        public List<string> Bitmaps22 { get; set; } = new List<string>();

        /// <summary>
        /// Возвращает коллекции путей к изображениям, находящихся по указанным координатам, на поле Reflector.
        /// </summary>
        /// <param name="x">Кордината X на поле Reflector.</param>
        /// <param name="y">Кордината Y на поле Reflector.</param>
        /// <returns>В случае успеха, возвращает коллекции путей к изображениям, в противном случае - <see cref="ArgumentException"/>.</returns>
        static List<string> GetNamesList(int x, int y)
        {
            if (x < 0 || x > 2)
                throw new ArgumentException($@"Координата X выходит {x}.", nameof(x));
            if (y < 0 || y > 2)
                throw new ArgumentException($@"Координата Y выходит {y}.", nameof(y));

            Deserialize();

            switch (y * 3 + x)
            {
                case 0:
                    return _dataBase.Bitmaps00;
                case 1:
                    return _dataBase.Bitmaps10;
                case 2:
                    return _dataBase.Bitmaps20;
                case 3:
                    return _dataBase.Bitmaps01;
                case 4:
                    return _dataBase.Bitmaps11;
                case 5:
                    return _dataBase.Bitmaps21;
                case 6:
                    return _dataBase.Bitmaps02;
                case 7:
                    return _dataBase.Bitmaps12;
                case 8:
                    return _dataBase.Bitmaps22;
                default:
                    throw new ArgumentException($@"Некорректные параметры X, Y: {x}, {y}.");
            }
        }

        /// <summary>
        /// Выполняет сериализацию базы данных путей к изображениям поля Reflector в файл ReflectorFieldDataBase.txt, в каталоге EXE-файла программы.
        /// </summary>
        static void Serialize()
        {
            using (FileStream fs = new FileStream(SaveToFile, FileMode.Create, FileAccess.Write))
                Xml.Serialize(fs, _dataBase ?? new ReflectorField());
        }

        /// <summary>
        /// Выполняет десериализацию базы данных путей к изображениям поля Reflector из файла ReflectorFieldDataBase.txt, в каталоге EXE-файла программы.
        /// </summary>
        static void Deserialize()
        {
            if (_dataBase != null)
                return;
            try
            {
                using (FileStream fs = new FileStream(SaveToFile, FileMode.Open, FileAccess.Read, FileShare.Read))
                    _dataBase = (ReflectorField) Xml.Deserialize(fs) ?? new ReflectorField();
            }
            catch (FileNotFoundException)
            {
                _dataBase = new ReflectorField();
            }
        }

        /// <summary>
        /// Получает изображения по указанным координатам, из поля Reflector.
        /// В случае, если база данных не прочитана с жёсткого диска, это будет сделано автоматически.
        /// </summary>
        /// <param name="x">Координата X.</param>
        /// <param name="y">Координата Y.</param>
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
        /// <param name="x">Кордината X на поле Reflector.</param>
        /// <param name="y">Кордината Y на поле Reflector.</param>
        /// <param name="imagePath">Путь, который необходимо сохранить в базе данных.</param>
        public static void Save(int x, int y, string imagePath)
        {
            GetNamesList(x, y).Add(imagePath.ToUpper());
            Serialize();
        }

        /// <summary>
        /// Удаляет указанный путь из базы данных, сохраняя изменение на жёсткий диск.
        /// </summary>
        /// <param name="x">Кордината X на поле Reflector.</param>
        /// <param name="y">Кордината Y на поле Reflector.</param>
        /// <param name="imagePath">Путь, который необходимо удалить из базы данных.</param>
        public static void Delete(int x, int y, string imagePath)
        {
            GetNamesList(x, y).Remove(imagePath.ToUpper());
            Serialize();
        }
    }
}
