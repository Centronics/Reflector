﻿using System;
using System.Drawing;
using System.Windows.Forms;
using DynamicParser;

namespace ReflectorExample.Sources
{
    /// <summary>
    /// Предназначен для создания изображений на <see cref="PictureBox"/> и преобразования их в карты <see cref="Processor"/>.
    /// </summary>
    internal sealed class Painter
    {
        /// <summary>
        /// Предназначена для рисования чёрным цветом.
        /// </summary>
        readonly Pen _blackPen = new Pen(Color.Black, 1.0f);

        /// <summary>
        /// <see cref="PictureBox"/>, на который производится вывод изображения.
        /// </summary>
        readonly PictureBox _pb;

        /// <summary>
        /// Предназначена для рисования белым цветом (стирания).
        /// </summary>
        readonly Pen _whitePen = new Pen(Color.White, 1.0f);

        /// <summary>
        /// Полотно для рисования.
        /// </summary>
        Bitmap _currentBitmap;

        /// <summary>
        /// Поверхность рисования GDI+.
        /// </summary>
        Graphics _grFront;

        /// <summary>
        /// Инициализирует новый экземпляр посредством привязки к нему <see cref="PictureBox"/>, на который будет выводиться создаваемое изображение.
        /// </summary>
        /// <param name="pic"><see cref="PictureBox"/>, на который будет производиться вывод создаваемого изображения.</param>
        public Painter(PictureBox pic)
        {
            _pb = pic ?? throw new ArgumentNullException(nameof(pic), $@"{nameof(PictureBox)} отсутствует (null).");
            CurrentBitmap = new Bitmap(pic.Width, pic.Height);
            Clear();
        }

        /// <summary>
        /// Необходимо для чтения созданного изображения в виде карты, посредством свойства <see cref="CurrentProcessor"/>.
        /// Значение этого свойства не может быть <see cref="string.Empty"/> или <see langword="null"/>, в противном случае, при чтении свойства <see cref="CurrentProcessor"/> будет выброшено исключение.
        /// </summary>
        public string CurrentProcessorName { get; set; }

        /// <summary>
        /// Получает или задаёт текущее изображение в виде карты <see cref="Processor"/>.
        /// При задании значения этого свойства, свойство <see cref="CurrentProcessorName"/> получает значение, взятое из <see cref="Processor.Tag"/>.
        /// Значение свойства <see cref="CurrentProcessorName"/> не может быть <see cref="string.Empty"/> или <see langword="null"/>, в противном случае, при чтении этого свойства будет выброшено исключение.
        /// </summary>
        public Processor CurrentProcessor
        {
            get => new Processor(CurrentBitmap, CurrentProcessorName);

            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(value), @"Карта равна null.");
                Bitmap btm = new Bitmap(value.Width, value.Height);
                for (int y = 0; y < value.Height; y++)
                    for (int x = 0; x < value.Width; x++)
                        btm.SetPixel(x, y, value[x, y].ValueColor);
                CurrentBitmap = btm;
                CurrentProcessorName = value.Tag;
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