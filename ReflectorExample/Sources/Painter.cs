using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;
using DynamicParser;

namespace ReflectorExample
{
    sealed class Painter
    {
        readonly Pen _blackPen = new Pen(Color.Black, 1.0f);
        readonly PictureBox _pb;
        readonly Pen _whitePen = new Pen(Color.White, 1.0f);
        Bitmap _currentBitmap;
        Graphics _grFront;

        public Painter(PictureBox pic)
        {
            if (pic == null)
                throw new ArgumentNullException(nameof(pic), $@"{nameof(PictureBox)} отсутствует (null).");
            _pb = pic;
            CurrentBitmap = new Bitmap(pic.Width, pic.Height);
            Clear();
        }

        public string CurrentProcessorName { get; set; }

        public Processor CurrentProcessor
        {
            get
            {
                if (CurrentProcessorName == null)
                    throw new ArgumentException("Название карты должно быть указано перед попыткой её получить.");
                return new Processor(CurrentBitmap, CurrentProcessorName);
            }

            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(value), @"Карта равна null.");
                Bitmap btm = new Bitmap(value.Width, value.Height);
                for (int y = 0; y < value.Height; y++)
                for (int x = 0; x < value.Width; x++)
                    btm.SetPixel(x, y, value[x, y].ValueColor);
                CurrentBitmap = btm;
            }
        }

        public Bitmap CurrentBitmap
        {
            get { return _currentBitmap; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(value), @"Изображение должно быть указано (null).");
                _currentBitmap?.Dispose();
                _currentBitmap = value;
                _grFront = Graphics.FromImage(_currentBitmap);
                _currentBitmap.SetPixel(0, 0,
                    _currentBitmap.GetPixel(0,
                        0)); //Необходим для устранения "Ошибки общего вида в GDI+" при попытке сохранения загруженного файла.
                _pb.Image = _currentBitmap;
                _pb.Refresh();
            }
        }

        public void Clear()
        {
            _grFront.Clear(Color.White);
            _pb.Refresh();
        }

        public void DrawPointBlack(int x, int y)
        {
            _grFront.DrawRectangle(_blackPen, x, y, 1, 1);
            _pb.Refresh();
        }

        public void DrawPointWhite(int x, int y)
        {
            _grFront.DrawRectangle(_whitePen, x, y, 1, 1);
            _pb.Refresh();
        }
    }

    public sealed class SaveLoad
    {
        readonly Bitmaps _current;

        readonly string _saveToFile = Path.Combine(Application.StartupPath, "load.txt");
        readonly XmlSerializer _xml = new XmlSerializer(typeof(Bitmaps));

        public SaveLoad()
        {
            if (!File.Exists(_saveToFile))
            {
                _current = new Bitmaps();
                return;
            }
            using (FileStream fs = new FileStream(_saveToFile, FileMode.Open, FileAccess.Read, FileShare.Read))
                _current = (Bitmaps) _xml.Deserialize(fs) ?? new Bitmaps();
        }

        public List<string> GetNamesList(int x, int y)
        {
            // ReSharper disable once ConvertIfStatementToSwitchStatement
            if (x == 0 && y == 0)
                return _current.Bitmaps00;
            if (x == 1 && y == 0)
                return _current.Bitmaps10;
            if (x == 2 && y == 0)
                return _current.Bitmaps20;
            if (x == 0 && y == 1)
                return _current.Bitmaps01;
            if (x == 1 && y == 1)
                return _current.Bitmaps11;
            if (x == 2 && y == 1)
                return _current.Bitmaps21;
            if (x == 0 && y == 2)
                return _current.Bitmaps02;
            if (x == 1 && y == 2)
                return _current.Bitmaps12;
            if (x == 2 && y == 2)
                return _current.Bitmaps22;
            throw new ArgumentException($@"Некорректные параметры X, Y: {x}, {y}.");
        }

        public void Save(int x, int y, string imagePath, Bitmap btm)
        {
            if (string.IsNullOrWhiteSpace(imagePath))
                throw new ArgumentException("Не могу сохранить безымянный файл.");
            using (FileStream fs = new FileStream(imagePath, FileMode.Create, FileAccess.Write, FileShare.Read))
                btm.Save(fs, ImageFormat.Bmp);
            GetNamesList(x, y).Add(imagePath.ToUpper());
            Serialize();
        }

        public void Delete(int x, int y, string imagePath)
        {
            if (string.IsNullOrWhiteSpace(imagePath))
                throw new ArgumentException("Не могу удалить безымянный файл.");
            if (GetNamesList(x, y).RemoveAll(s => s == imagePath.ToUpper()) <= 0)
                return;
            File.Delete(imagePath);
            Serialize();
        }

        public IEnumerable<Processor> GetProcessors(int x, int y)
        {
            foreach (string name in GetNamesList(x, y).Where(s => !string.IsNullOrWhiteSpace(s)))
                using (FileStream fs = new FileStream(name, FileMode.Open, FileAccess.Read, FileShare.Read))
                    yield return new Processor(new Bitmap(fs), Path.GetFileNameWithoutExtension(name));
        }

        void Serialize()
        {
            using (FileStream fs = new FileStream(_saveToFile, FileMode.Create, FileAccess.Write, FileShare.Read))
                _xml.Serialize(fs, _current);
        }

        [Serializable]
        public sealed class Bitmaps
        {
            public List<string> Bitmaps00 { get; set; } = new List<string>();

            public List<string> Bitmaps10 { get; set; } = new List<string>();

            public List<string> Bitmaps20 { get; set; } = new List<string>();

            public List<string> Bitmaps01 { get; set; } = new List<string>();

            public List<string> Bitmaps11 { get; set; } = new List<string>();

            public List<string> Bitmaps21 { get; set; } = new List<string>();

            public List<string> Bitmaps02 { get; set; } = new List<string>();

            public List<string> Bitmaps12 { get; set; } = new List<string>();

            public List<string> Bitmaps22 { get; set; } = new List<string>();
        }
    }
}