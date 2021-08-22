using System;
using System.Drawing;
using System.Windows.Forms;
using DynamicParser;

namespace ReflectorExample.Sources
{
    internal sealed class Painter
    {
        readonly Pen _blackPen = new Pen(Color.Black, 1.0f);
        readonly PictureBox _pb;
        readonly Pen _whitePen = new Pen(Color.White, 1.0f);
        Bitmap _currentBitmap;
        Graphics _grFront;

        public Painter(PictureBox pic)
        {
            _pb = pic ?? throw new ArgumentNullException(nameof(pic), $@"{nameof(PictureBox)} отсутствует (null).");
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
            get => _currentBitmap;
            set
            {
                _currentBitmap?.Dispose();
                _currentBitmap = value ?? throw new ArgumentNullException(nameof(value), @"Изображение должно быть указано (null).");
                _grFront = Graphics.FromImage(_currentBitmap);
                _currentBitmap.SetPixel(0, 0, _currentBitmap.GetPixel(0, 0)); //Необходим для устранения "Ошибки общего вида в GDI+" при попытке сохранения загруженного файла.
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
}