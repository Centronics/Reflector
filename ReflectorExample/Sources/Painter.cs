using System;
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
        /// Определяет значение белого цвета для этого класса.
        /// </summary>
        readonly Color _whiteColor = Color.White;

        /// <summary>
        /// Определяет значение чёрного цвета для этого класса.
        /// </summary>
        readonly Color _blackColor = Color.Black;

        /// <summary>
        /// Предназначена для рисования чёрным цветом.
        /// </summary>
        readonly Pen _blackPen;

        /// <summary>
        /// <see cref="PictureBox"/>, на который производится вывод изображения.
        /// </summary>
        readonly PictureBox _pb;

        /// <summary>
        /// Предназначена для рисования белым цветом (может использоваться для стирания).
        /// </summary>
        readonly Pen _whitePen;

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
            _blackPen = new Pen(_blackColor, 1.0f);
            _whitePen = new Pen(_whiteColor, 1.0f);
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
                CurrentBitmap = ProcessorToBitmap(value);
                CurrentProcessorName = value?.Tag;
            }
        }

        /// <summary>
        /// Преобразует указанную карту в изображение.
        /// Поле <see cref="Processor.Tag"/> игнорируется.
        /// </summary>
        /// <param name="processor">Карта, которую треуется преобразовать.</param>
        /// <returns>Возвращает изображение, содержащее данные с карты. Если она равна <see langword="null"/>, возвращается <see langword="null"/>.</returns>
        public static Bitmap ProcessorToBitmap(Processor processor)
        {
            if (processor == null)
                return null;
            Bitmap result = new Bitmap(processor.Width, processor.Height);
            for (int y = 0; y < processor.Height; y++)
                for (int x = 0; x < processor.Width; x++)
                    result.SetPixel(x, y, processor[x, y].ValueColor);
            return result;
        }

        /// <summary>
        /// Создаёт полную копию указанного изображения.
        /// </summary>
        /// <param name="what">Изображение, которое требуется скопировать.</param>
        /// <returns>Возвращает полную копию указанного изображения. Если оно равно <see langword="null"/>, возвращается <see langword="null"/>.</returns>
        public static Bitmap BitmapCopy(Bitmap what)
        {
            if (what == null)
                return null;
            Bitmap result = new Bitmap(what.Width, what.Height);
            for (int y = 0; y < what.Height; y++)
                for (int x = 0; x < what.Width; x++)
                    result.SetPixel(x, y, what.GetPixel(x, y));
            return result;
        }

        /// <summary>
        /// Получает или задаёт изображение, с которым ведётся работа в настоящее время.
        /// </summary>
        public Bitmap CurrentBitmap
        {
            get => _currentBitmap;
            set
            {
                if (value == null)
                {
                    Clear();
                    return;
                }
                _currentBitmap?.Dispose();
                _currentBitmap = BitmapCopy(value);
                _grFront = Graphics.FromImage(_currentBitmap);
                _currentBitmap.SetPixel(0, 0, _currentBitmap.GetPixel(0, 0)); //Необходим для устранения "Ошибки общего вида в GDI+" при попытке сохранения загруженного файла.
                _pb.Image = _currentBitmap;
                _pb.Refresh();
            }
        }

        /// <summary>
        /// Очищает белым цветом текущее изображение.
        /// </summary>
        public void Clear()
        {
            _grFront.Clear(_whiteColor);
            _pb.Refresh();
        }

        /// <summary>
        /// Рисует чёрную точку на текущем изображении, по указанным координатам.
        /// </summary>
        /// <param name="x">Координата X на поле Reflector от левого верхнего угла.</param>
        /// <param name="y">Координата Y на поле Reflector от левого верхнего угла.</param>
        public void DrawBlackPoint(int x, int y)
        {
            _grFront.DrawRectangle(_blackPen, x, y, 1, 1);
            _pb.Refresh();
        }

        /// <summary>
        /// Рисует белую точку на текущем изображении, по указанным координатам.
        /// </summary>
        /// <param name="x">Координата X на поле Reflector от левого верхнего угла.</param>
        /// <param name="y">Координата Y на поле Reflector от левого верхнего угла.</param>
        public void DrawWhitePoint(int x, int y)
        {
            _grFront.DrawRectangle(_whitePen, x, y, 1, 1);
            _pb.Refresh();
        }
    }
}