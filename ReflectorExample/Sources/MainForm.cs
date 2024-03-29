﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using DynamicParser;
using DynamicReflector;

namespace ReflectorExample.Sources
{
    /// <summary>
    /// Отвечает за создание, хранение и контроль состояния тестируемых компонентов (<see cref="Reflection"/>, <see cref="Reflector"/>, <see cref="Neuron"/>), а также за вывод результата их работы.
    /// </summary>
    public partial class FrmMain : Form
    {
        /// <summary>
        /// Отражает номера текущих отображаемых изображений на поле Reflector.
        /// </summary>
        readonly int[,] _reflectorPartImageCurrentIndex = new int[3, 3];

        /// <summary>
        /// Хранит изображения, содержащиеся на поле Reflector, в виде карт.
        /// </summary>
        readonly List<Processor>[,] _reflectorPartProcessors = new List<Processor>[3, 3];

        /// <summary>
        /// Отвечает за операции над "Исходным изображением" с поля Reflection.
        /// </summary>
        readonly Painter _reflectionSourceImagePainter;

        /// <summary>
        /// Отвечает за операции с изображениями на поле Reflector.
        /// </summary>
        readonly Painter[,] _reflectorPartPainters = new Painter[3, 3];

        /// <summary>
        /// Хранит коллекцию <see cref="Neuron"/>, созданных из изображений на поле Reflector и порождённых в процессе установления связи между существующими <see cref="Neuron"/>.
        /// </summary>
        readonly List<Neuron> _neurons = new List<Neuron>();

        /// <summary>
        /// Служит для резервирования изначального значения поля "Результирующее изображение".
        /// </summary>
        readonly string _commonImageResultString;

        /// <summary>
        ///     Таймер для измерения времени, затраченного на какую-либо операцию.
        /// </summary>
        readonly Stopwatch _stopwatch = new Stopwatch();

        /// <summary>
        /// Служит для резервирования изначальных значений частей рабочего поля Reflector.
        /// </summary>
        readonly string[,] _reflectorPartGroupBoxTextFields = new string[3, 3];

        /// <summary>
        /// Служит для резервирования изначальных значений частей запроса на поле Reflector.
        /// </summary>
        readonly string[,] _reflectorQueryPartTextBoxFields = new string[3, 3];

        /// <summary>
        /// Отражает номер результата в массиве результатов работы компонентов <see cref="Reflector"/> и <see cref="Reflection"/>, на который смотрит пользователь в настоящее время.
        /// </summary>
        int _currentCommonImageResultIndex;

        /// <summary>
        /// Основной объект для распознавания. Обновляется в случае добавления и/или изменения распознаваемых или распознающих карт.
        /// </summary>
        Reflector _reflector;

        /// <summary>
        /// Основной объект для распознавания. Обновляется в случае добавления и/или изменения распознаваемых или распознающих карт.
        /// </summary>
        Reflection _reflection;

        /// <summary>
        /// Содержит результаты работы компонентов <see cref="Reflector"/> и <see cref="Reflection"/> в виде изображений.
        /// </summary>
        Bitmap[] _commonImageResults;

        /// <summary>
        /// Отвечает за автоматическую обработку введённого в текстовое поле текста.
        /// Значение <see langword="true"/> получает для того, чтобы предотвратить повторную обработку текста, который уже находится в обработке.
        /// Другими словами, значение <see langword="true"/> запрещает событию изменения текста в текстовом поле выполняться во время обработки этого события.
        /// </summary>
        bool _txtReflectorQueryPartInProcessing;

        /// <summary>
        ///     Поток, отвечающий за выполнение процедуры распознавания.
        /// </summary>
        Thread _workThread;

        /// <summary>
        /// Инициализирует все значения внутренних переменных, в частности, резервируя их изначальные значения.
        /// </summary>
        public FrmMain()
        {
            InitializeComponent();

            _reflectionSourceImagePainter = new Painter(picReflectionSourceImage);
            _commonImageResultString = grpCommonImageResult.Text;

            for (int y = 0; y < 3; y++)
                for (int x = 0; x < 3; x++)
                {
                    _reflectorPartPainters[x, y] = new Painter(GetReflectorPartPictureBox(x, y));
                    _reflectorPartGroupBoxTextFields[x, y] = GetReflectorPartGroupBox(x, y).Text;
                    _reflectorQueryPartTextBoxFields[x, y] = GetReflectorQueryPartTextBox(x, y).Text;
                }
        }

        /// <summary>
        /// Возвращает <see cref="PictureBox"/>, по указанным координатам, с поля Reflector.
        /// </summary>
        /// <param name="x">Координата X.</param>
        /// <param name="y">Координата Y.</param>
        /// <returns>Возвращает требуемый <see cref="PictureBox"/>.</returns>
        PictureBox GetReflectorPartPictureBox(int x, int y)
        {
            Control[] picBox = (from Control c in grpReflector.Controls
                                where c.GetType() == typeof(PictureBox)
                                where c.Name == $"picReflectorPart{x}{y}"
                                select c).ToArray();
            if (picBox.Length != 1)
                throw new Exception($"Найдены {nameof(PictureBox)} с одинаковыми именами или требуемый элемент отсутствует.");
            return (PictureBox)picBox[0];
        }

        /// <summary>
        /// Получает контейнеры карт с поля Reflector.
        /// </summary>
        ProcessorContainer[,] ReflectorFieldContainers
        {
            get
            {
                ProcessorContainer[,] pcs = new ProcessorContainer[_reflectorPartProcessors.GetLength(0), _reflectorPartProcessors.GetLength(1)];
                for (int y = 0; y < pcs.GetLength(1); y++)
                    for (int x = 0; x < pcs.GetLength(0); x++)
                        try
                        {
                            pcs[x, y] = new ProcessorContainer(_reflectorPartProcessors[x, y]);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(
                                $"{nameof(ReflectorFieldContainers)}: Ошибка в поле с координатами ({x}, {y}): {ex.Message}");
                        }
                return pcs;
            }
        }

        /// <summary>
        /// Получает значение, отражающее, совпадает ли текущее результирующее изображение с исходным (<see langword="true"/>), или нет (<see langword="false"/>).
        /// </summary>
        bool IsSelectedResultImageEqualWithSelectedCommonImageResult
        {
            get
            {
                Bitmap b1 = _reflectionSourceImagePainter.CurrentBitmap;
                Bitmap b2 = _commonImageResults[_currentCommonImageResultIndex];
                if (b2.Width != b1.Width || b2.Height != b1.Height)
                    return false;
                for (int y = 0; y < b1.Height; y++)
                    for (int x = 0; x < b1.Width; x++)
                        if (b1.GetPixel(x, y) != b2.GetPixel(x, y))
                            return false;
                return true;
            }
        }

        /// <summary>
        /// Предназначено для отключения элементов управления на время выполнения операции, и включения их после её завершения.
        /// </summary>
        bool IsButtonsEnabled
        {
            set
            {
                grpReflectorPart00.Enabled = value;
                grpReflectorPart01.Enabled = value;
                grpReflectorPart02.Enabled = value;
                grpReflectorPart10.Enabled = value;
                grpReflectorPart20.Enabled = value;
                grpReflectorPart11.Enabled = value;
                grpReflectorPart21.Enabled = value;
                grpReflectorPart12.Enabled = value;
                grpReflectorPart22.Enabled = value;
                grpReflectorParameters.Enabled = value;
                grpReflectorQuery.Enabled = value;
                grpNeuron.Enabled = value;
            }
        }

        /// <summary>
        /// Выполняет операции по подготовке к работе.
        /// Делает необходимые проверки, загружает сохранённые данные с жёсткого диска.
        /// </summary>
        /// <param name="sender">Вызывающий объект. Не используется.</param>
        /// <param name="e">Аргументы. Не используется.</param>
        void FrmMain_Shown(object sender, EventArgs e)
        {
            try
            {
                CheckImageBoxSizes();

                for (int y = 0; y < _reflectorPartProcessors.GetLength(1); y++)
                    for (int x = 0; x < _reflectorPartProcessors.GetLength(0); x++)
                        ViewSelectedReflectorPart(x, y, CheckReflectorLoadedProcessorSizes(_reflectorPartProcessors[x, y] = new List<Processor>(ReflectorFieldDataBase.GetProcessors(x, y))));

                LoadReflectionSourceImage();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $@"{ex.Message} Программа будет закрыта.", @"Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        /// <summary>
        /// Загружает "Исходное изображение", которое располагается на поле Reflection.
        /// Проверяет его размеры.
        /// В случае отсутствия файла с изображением на жёстком диске, метод не производит каких-либо действий.
        /// </summary>
        void LoadReflectionSourceImage()
        {
            try
            {
                using (FileStream fs = new FileStream(GetImagePath("main"), FileMode.Open, FileAccess.Read, FileShare.Read))
                    _reflectionSourceImagePainter.CurrentBitmap = CheckReflectionSourceImageSize(new Bitmap(fs));
            }
            catch (FileNotFoundException)
            {
                //ignored
            }
        }

        /// <summary>
        /// Выполняет операцию самоконтроля изначальных параметров работы программы, чтобы не было ошибок при подаче входных данных в тестируемые компоненты.
        /// </summary>
        void CheckImageBoxSizes()
        {
            Size checkSize = new Size(100, 50);
            if (picReflectorPart00.Size != checkSize || picReflectorPart10.Size != checkSize || picReflectorPart20.Size != checkSize ||
                picReflectorPart01.Size != checkSize || picReflectorPart11.Size != checkSize || picReflectorPart21.Size != checkSize ||
                picReflectorPart02.Size != checkSize || picReflectorPart12.Size != checkSize || picReflectorPart22.Size != checkSize)
                throw new Exception("Обнаружены поля для рисования различных размеров.");
            if (picReflectionSourceImage.Width % checkSize.Width != 0)
                throw new Exception("Ширина исходного изображения должна быть кратна ширине всех полей для рисования.");
            if (picReflectionSourceImage.Height % checkSize.Height != 0)
                throw new Exception("Высота исходного изображения должна быть кратна высоте всех полей для рисования.");
            if (picReflectionSourceImage.Width / checkSize.Width != 3)
                throw new Exception("Количество полей для рисования (по ширине) должно быть три.");
            if (picReflectionSourceImage.Height / checkSize.Height != 3)
                throw new Exception("Количество полей для рисования (по высоте) должно быть три.");
            if (picCommonImageResult.Width != picReflectionSourceImage.Width)
                throw new Exception("Ширина результирующего изображения должна совпадать с шириной исходного изображения.");
            if (picCommonImageResult.Height != picReflectionSourceImage.Height)
                throw new Exception("Высота результирующего изображения должна совпадать с высотой исходного изображения.");
        }

        /// <summary>
        /// Получает <see cref="TextBox"/> запроса, по указанным координатам, с поля Reflector.
        /// </summary>
        /// <param name="x">Координата X на поле Reflector.</param>
        /// <param name="y">Координата Y на поле Reflector.</param>
        /// <returns>Возвращает <see cref="TextBox"/> запроса по указанным координатам. В противном случае выдаёт исключение.</returns>
        TextBox GetReflectorQueryPartTextBox(int x, int y)
        {
            foreach (Control c in from Control c in grpReflectorQuery.Controls where c.GetType() == typeof(TextBox) select c)
                if (GetControlCoords(out int px, out int py, c.Name, "txtReflectorQueryPart") && px == x && py == y)
                    return (TextBox)c;
            throw new Exception($"Требуемый {nameof(TextBox)} почему-то отсутствует на поле ({x}, {y}).");
        }

        /// <summary>
        /// Получает часть запроса, по заданным координатам, с поля Reflector.
        /// </summary>
        /// <param name="x">Координата X на поле Reflector.</param>
        /// <param name="y">Координата Y на поле Reflector.</param>
        /// <returns>Возвращает часть запроса по заданным координатам.</returns>
        string GetCurrentReflectorQueryPartString(int x, int y)
        {
            string partOfQuery = GetReflectorQueryPartTextBox(x, y).Text;
            if (string.IsNullOrWhiteSpace(partOfQuery))
                throw new ArgumentException($@"Название искомой карты в поле ({x}, {y}) не задано.");
            return partOfQuery;
        }

        /// <summary>
        /// Получает полный путь к изображению карты с заданным именем.
        /// </summary>
        /// <param name="name">Название карты, путь к которой требуется получить.</param>
        /// <returns>Возвращает полный путь к изображению карты с заданным именем.</returns>
        static string GetImagePath(string name) => Path.Combine(Application.StartupPath, $@"{name}.bmp");

        /// <summary>
        /// Сохраняет карту с поля Reflector, в виде изображения, на жёсткий диск, и запоминает её в конце соответствующего массива карт.
        /// </summary>
        /// <param name="x">Координата X на поле Reflector.</param>
        /// <param name="y">Координата Y на поле Reflector.</param>
        void SaveReflectorPartImage(int x, int y)
        {
            string mapName = GetCurrentReflectorQueryPartString(x, y);
            string path = GetImagePath(mapName);
            Painter p = _reflectorPartPainters[x, y];

            using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.Read))
            {
                ReflectorFieldDataBase.Save(x, y, path);
                p.CurrentBitmap.Save(fs, ImageFormat.Bmp);
            }

            p.CurrentProcessorName = mapName;
            List<Processor> reflectorPartProcessors = _reflectorPartProcessors[x, y];
            reflectorPartProcessors.Add(p.CurrentProcessor);
            _reflectorPartImageCurrentIndex[x, y] = reflectorPartProcessors.Count - 1;
            DisplayReflectorPartStatusOnGroupBox(x, y);
        }

        /// <summary>
        /// Удаляет указанное изображение (карту) с поля Reflector, из базы данных, а так же сам файл с изображением, на жёстком диске.
        /// Требует, чтобы имя карты было указано в <see cref="Painter.CurrentProcessorName"/>.
        /// </summary>
        /// <param name="x">Координата X на поле Reflector.</param>
        /// <param name="y">Координата Y на поле Reflector.</param>
        void DeleteReflectorPartImage(int x, int y)
        {
            string mapName = _reflectorPartPainters[x, y].CurrentProcessorName;
            if (string.IsNullOrWhiteSpace(mapName))
                throw new ArgumentException("Для удаления карты необходимо сначала сохранить её.");

            string path = GetImagePath(mapName);
            File.Delete(path);
            ReflectorFieldDataBase.Delete(x, y, path);
            List<Processor> reflectorPartProcessors = _reflectorPartProcessors[x, y];

            for (int k = 0; k < reflectorPartProcessors.Count; k++)
                if (reflectorPartProcessors[k].Tag == mapName)
                {
                    reflectorPartProcessors.RemoveAt(k);
                    break;
                }

            ReflectorPartPrevButton(x, y);
        }

        /// <summary>
        /// Получает координаты указанного элемента управления.
        /// </summary>
        /// <param name="x">Возвращаемая координата X.</param>
        /// <param name="y">Возвращаемая координата Y.</param>
        /// <param name="name">Название элемента управления, которое необходимо преобразовать.</param>
        /// <param name="startsWith">Часть названия элемента управления, с которой оно должно начинаться.</param>
        /// <returns>Возвращает значение <see langword="true"/> в случае успешного получения данных. В противном случае - <see langword="false"/>.</returns>
        static bool GetControlCoords(out int x, out int y, string name, string startsWith)
        {
            y = x = -1;
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name), @"Имя элемента управления неизвестно.");
            if (string.IsNullOrWhiteSpace(startsWith))
                throw new ArgumentNullException(nameof(startsWith), @"Начало имени отсутствует.");
            return name.StartsWith(startsWith) && int.TryParse(name.Substring(startsWith.Length, 1), out x) && int.TryParse(name.Substring(startsWith.Length + 1, 1), out y);
        }

        /// <summary>
        /// Обрабатывает событие перемещения курсора и одновременного нажатия какой-либо кнопки мыши над поверхностью для рисования, на поле Reflector.
        /// Рисует точку, по указанным координатам, в соответствующей части на поле Reflector.
        /// В случае нажатия ПКМ цвет точки белый.
        /// В случае нажатия ЛКМ цвет точки чёрный.
        /// </summary>
        /// <param name="sender">Вызывающий объект.</param>
        /// <param name="e">Аргументы.</param>
        void PicReflectorPart_MouseMoveDown(object sender, MouseEventArgs e)
        {
            if (!GetControlCoords(out int x, out int y, ((PictureBox)sender).Name, "picReflectorPart"))
                throw new ArgumentException(@"Не могу идентифицировать поле ввода части изображения.", nameof(sender));
            // ReSharper disable once SwitchStatementMissingSomeCases
            switch (e.Button)
            {
                case MouseButtons.Left:
                    _reflectorPartPainters[x, y].DrawBlackPoint(e.X, e.Y);
                    break;
                case MouseButtons.Right:
                    _reflectorPartPainters[x, y].DrawWhitePoint(e.X, e.Y);
                    break;
            }
        }

        /// <summary>
        /// Возвращает запрос с поля Reflector.
        /// </summary>
        char[,] CurrentReflectorQuery
        {
            get
            {
                char[,] ch = new char[3, 3];
                for (int y = 0; y < 3; y++)
                    for (int x = 0; x < 3; x++)
                        ch[x, y] = GetReflectorQueryPartTextBox(x, y).Text[0];

                return ch;
            }
        }

        /// <summary>
        /// Очищает белым цветом "Исходное изображение" с поля Reflection.
        /// </summary>
        /// <param name="sender">Вызывающий объект. Не используется.</param>
        /// <param name="e">Аргументы. Не используется.</param>
        void BtnReflectionSourceImageClear_Click(object sender, EventArgs e) => _reflectionSourceImagePainter.Clear();

        /// <summary>
        /// Разбивает исходное изображение на изображения равных размеров, затем распределяет их по полю Reflector, и сохраняет на жёсткий диск, отображая на экране.
        /// </summary>
        /// <param name="sender">Вызывающий объект. Не используется.</param>
        /// <param name="e">Аргументы. Не используется.</param>
        void BtnReflectionSourceImageAdd_Click(object sender, EventArgs e)
        {
            try
            {
                _reflectionSourceImagePainter.CurrentProcessorName = "main";
                Bitmap[,] btms = ImageSplit(_reflectionSourceImagePainter.CurrentProcessor, picReflectorPart00.Width, picReflectorPart00.Height);
                for (int y = 0; y < 3; y++)
                    for (int x = 0; x < 3; x++)
                    {
                        _reflectorPartPainters[x, y].CurrentProcessor = new Processor(btms[x, y], GetCurrentReflectorQueryPartString(x, y));
                        SaveReflectorPartImage(x, y);
                        ReflectorPartNextButton(x, y, true);
                    }
                _reflection = null;
                _reflector = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, @"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Предназначен для разделения указанной карты на равные части.
        /// </summary>
        /// <param name="divProc">Карта, которую требуется разделить.</param>
        /// <param name="partWidth">Размер делимой части по ширине.</param>
        /// <param name="partHeight">Размер делимой части по высоте.</param>
        /// <returns>Возвращает двумерный массив, содержащий части карты, в соответствии с их расположением на разделяемой карте.</returns>
        static Bitmap[,] ImageSplit(Processor divProc, int partWidth, int partHeight)
        {
            if (divProc == null)
                throw new ArgumentNullException(nameof(divProc), @"Делимая карта равна null.");
            if (partWidth <= 0)
                throw new ArgumentException($@"Размер части по ширине указан неверно ({partWidth}).", nameof(partWidth));
            if (partHeight <= 0)
                throw new ArgumentException($@"Размер части по высоте указан неверно ({partHeight}).", nameof(partHeight));
            if (divProc.Width % partWidth != 0)
                throw new ArgumentException($@"Ширина делимой карты должна быть кратна ширине её части: {divProc.Width} % {partWidth}.", nameof(partWidth));
            if (divProc.Height % partHeight != 0)
                throw new ArgumentException($@"Высота делимой карты должна быть кратна высоте её части: {divProc.Height} % {partHeight}.", nameof(partHeight));

            Bitmap[,] result = new Bitmap[divProc.Width / partWidth, divProc.Height / partHeight];

            for (int qy = 0; qy < divProc.Height; qy += partHeight)
                for (int qx = 0; qx < divProc.Width; qx += partWidth)
                {
                    Bitmap r = new Bitmap(partWidth, partHeight);

                    for (int y = qy, ry = qy + partHeight, ty = 0; y < ry; y++, ty++)
                        for (int x = qx, rx = qx + partWidth, tx = 0; x < rx; x++, tx++)
                            r.SetPixel(tx, ty, divProc[x, y].ValueColor);

                    result[qx / partWidth, qy / partHeight] = r;
                }

            return result;
        }

        /// <summary>
        /// Производит полную очистку результатов выполнения запроса.
        /// Актуализирует состояние пользовательского интерфейса.
        /// Блокирует кнопки перемотки и сохранения.
        /// </summary>
        void ResetCommonImageResults()
        {
            _commonImageResults = null;
            _currentCommonImageResultIndex = 0;
            btnPrevCommonImageResult.Enabled = btnNextCommonImageResult.Enabled = btnSaveCommonImageResult.Enabled = false;
            picCommonImageResult.Image = null;
            grpCommonImageResult.Text = _commonImageResultString;
        }

        /// <summary>
        /// Обрабатывает запрос (с помощью класса <see cref="Reflection"/>) на составление результирующих карт, из карт, которые располагаются (не только отображаются в текущий момент) на поле Reflector.
        /// Возвращаются все карты, которые можно составить из карт, содержащихся на поле Reflector, используя различные запросы.
        /// Результаты отображаются на панели "Результат выполнения запроса".
        /// </summary>
        /// <param name="sender">Вызывающий объект. Не используется.</param>
        /// <param name="e">Аргументы. Не используется.</param>
        void BtnReflectionPush_Click(object sender, EventArgs e) => SafetyExecute(() =>
        {
            if (_workThread?.IsAlive ?? false)
                return;

            if (_reflection == null)
                _reflection = new Reflection(ReflectorFieldContainers);

            txtCommonImageWidth.Text = _reflection.MapWidth.ToString();
            txtCommonImageHeight.Text = _reflection.MapHeight.ToString();

            ResetCommonImageResults();
            IsButtonsEnabled = false;

            _workThread = new Thread(() => SafetyExecute(() =>
            {
                _reflectionSourceImagePainter.CurrentProcessorName = "main";
                WaitableTimer(btnReflectionPush);
                IEnumerable<Processor> processors = _reflection.Push(_reflectionSourceImagePainter.CurrentProcessor);
                _stopwatch.Stop();
                if ((_commonImageResults = processors?.Select(ProcessorToBitmap).ToArray()) == null)
                    return;
                InvokeFunction(() =>
                {
                    btnSaveCommonImageResult.Enabled = true;
                    btnPrevCommonImageResult.Enabled = btnNextCommonImageResult.Enabled = _commonImageResults.Length > 1;
                    ViewSelectedCommonResult(0);
                });
            }))
            {
                IsBackground = true,
                Name = nameof(Reflection),
                Priority = ThreadPriority.Highest
            };

            _workThread.Start();
        });

        /// <summary>
        /// Обрабатывает запрос (с помощью класса <see cref="Reflector"/>) на составление результирующей карты, из карт, которые располагаются (не только отображаются в текущий момент) на поле Reflector, в случае, если исходную карту возможно распознать посредством указанного запроса.
        /// Результаты отображаются на панели "Результат выполнения запроса".
        /// </summary>
        /// <param name="sender">Вызывающий объект. Не используется.</param>
        /// <param name="e">Аргументы. Не используется.</param>
        void BtnReflectorPush_Click(object sender, EventArgs e) => SafetyExecute(() =>
        {
            if (_workThread?.IsAlive ?? false)
                return;

            if (_reflector == null)
                _reflector = new Reflector(ReflectorFieldContainers);

            char[,] ch = CurrentReflectorQuery;
            txtReflectorMapWidth.Text = _reflector.MapWidth.ToString();
            txtReflectorMapHeight.Text = _reflector.MapHeight.ToString();
            txtReflectorProcessorWidth.Text = _reflector.ProcessorWidth.ToString();
            txtReflectorProcessorHeight.Text = _reflector.ProcessorHeight.ToString();

            ResetCommonImageResults();
            IsButtonsEnabled = false;

            _workThread = new Thread(() => SafetyExecute(() =>
            {
                _reflectionSourceImagePainter.CurrentProcessorName = "main";
                WaitableTimer(btnReflectorPush);
                Processor p = _reflector.Push(_reflectionSourceImagePainter.CurrentProcessor, ch);
                _stopwatch.Stop();
                Bitmap result = ProcessorToBitmap(p);
                if ((_commonImageResults = result != null ? new[] { result } : null) == null)
                    return;
                InvokeFunction(() =>
                {
                    btnSaveCommonImageResult.Enabled = true;
                    btnPrevCommonImageResult.Enabled = btnNextCommonImageResult.Enabled = false;
                    ViewSelectedCommonResult(0);
                });
            }))
            {
                IsBackground = true,
                Name = nameof(Reflector),
                Priority = ThreadPriority.Highest
            };

            _workThread.Start();
        });

        /// <summary>
        /// Отвечает за операции с <see cref="Neuron"/>: как за создание нового, так и за порождение нового из уже существующего.
        /// Схема работы следующая: нарисовав что-либо на поле Reflector, можно создать новый <see cref="Neuron"/>, выбрав соответствующий пункт в списке существующих <see cref="Neuron"/>.
        /// Чтобы увидеть содержимое <see cref="Neuron"/>, надо выбрать его в спике существующих <see cref="Neuron"/>.
        /// Если в процессе порождения нового <see cref="Neuron"/> произойдёт какая-либо ошибка, он не будет добавлен в список.
        /// </summary>
        /// <param name="sender">Вызывающий объект. Не используется.</param>
        /// <param name="e">Аргументы. Не используется.</param>
        void BtnNeuronFindRelation_Click(object sender, EventArgs e) => SafetyExecute(() =>
        {
            string GetNeuronString() => $@"(№{_neurons.Count + 1}) {DateTime.Now:HH:mm:ss}";

            void AddNeuronInfoToListBox(string neuronString) => InvokeFunction(() => lstNeurons.Items.Insert(1, neuronString));

            if (_workThread?.IsAlive ?? false)
                return;

            int selIndex = lstNeurons.SelectedIndex - 1;

            if (selIndex < -1)
            {
                MessageBox.Show(this, @"Ошибка! Выберите нейрон, с помощью которого будет создан новый нейрон!", @"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (selIndex == -1)
            {
                string newNeuronString = GetNeuronString();
                _neurons.Insert(0, CurrentNeuron);
                AddNeuronInfoToListBox(newNeuronString);
                return;
            }

            Neuron parentNeuron = _neurons[selIndex];

            IEnumerable<(Processor, string)> enNeuronQuery = CurrentNeuronQuery;

            if (enNeuronQuery == null)
                throw new Exception(@"Неизвестная ошибка при чтении запроса.");

            (Processor, string)[] neuronQuery = enNeuronQuery.ToArray();

            ResetCommonImageResults();
            IsButtonsEnabled = false;

            _workThread = new Thread(() => SafetyExecute(() =>
            {
                WaitableTimer(btnNeuronFindRelation);

                Neuron derivedNeuron = parentNeuron.FindRelation(neuronQuery);

                _stopwatch.Stop();

                if (derivedNeuron == null)
                    return;

                string derivedNeuronString = GetNeuronString();

                IEnumerable<Processor> enDerivedNeuronProcessors = derivedNeuron.Processors;
                if (enDerivedNeuronProcessors == null)
                    throw new Exception($@"Ошибка при получении содержимого порождённого {nameof(Neuron)}. Он будет отсутствовать в списке.");

                int neuronProcessorsCount = enDerivedNeuronProcessors.Count();
                if (neuronProcessorsCount != 9)
                    throw new Exception($@"Количество карт в порождённом {nameof(Neuron)} отличается от 9, и равно {neuronProcessorsCount}. Он будет отсутствовать в списке.");

                _neurons.Insert(0, derivedNeuron);

                AddNeuronInfoToListBox(derivedNeuronString);
            }))
            {
                IsBackground = true,
                Name = nameof(Reflection),
                Priority = ThreadPriority.Highest
            };

            _workThread.Start();
        });

        /// <summary>
        /// Отображает содержимое выбранного <see cref="Neuron"/> на форме.
        /// </summary>
        /// <param name="sender">Вызывающий объект. Не используется.</param>
        /// <param name="e">Аргументы. Не используется.</param>
        void LstNeurons_SelectedIndexChanged(object sender, EventArgs e) => SafetyExecute(() =>
        {
            int selIndex = lstNeurons.SelectedIndex - 1;
            if (selIndex < 0)
                return;
            Processor[] neuronProcessors = _neurons[selIndex].Processors.ToArray();
            for (int y = 0, index = 0; y < 3; y++)
                for (int x = 0; x < 3; x++, index++)
                {
                    Processor processor = neuronProcessors[index];
                    _reflectorPartPainters[x, y].CurrentProcessor = processor;
                    GetReflectorQueryPartTextBox(x, y).Text = processor.Tag;
                }
        });

        /// <summary>
        /// Преобразует карту в изображение.
        /// </summary>
        /// <param name="p">Преобразуемая карта.</param>
        /// <returns>Возвращает изображение, полученное путём копирования на него содержимого преобразуемой карты, или <see langword="null"/>, в случае, когда преобразуемая карта равна <see langword="null"/>.</returns>
        static Bitmap ProcessorToBitmap(Processor p)
        {
            if (p == null)
                return null;
            Bitmap result = new Bitmap(p.Width, p.Height);
            for (int y = 0; y < result.Height; y++)
                for (int x = 0; x < result.Width; x++)
                    result.SetPixel(x, y, p[x, y].ValueColor);
            return result;
        }

        /// <summary>
        /// Предоставляет пользователю возможность выбрать файл изображения для загрузки его как "Исходное изображение", на поле Reflection.
        /// Далее выполняется проверка размеров изображения.
        /// </summary>
        /// <param name="sender">Вызывающий объект. Не используется.</param>
        /// <param name="e">Аргументы. Не используется.</param>
        void BtnReflectionSourceImageLoad_Click(object sender, EventArgs e)
        {
            try
            {
                if (OpenFile.ShowDialog(this) != DialogResult.OK)
                    return;
                using (FileStream fs = new FileStream(OpenFile.FileName, FileMode.Open, FileAccess.Read, FileShare.Read))
                    _reflectionSourceImagePainter.CurrentBitmap = CheckReflectionSourceImageSize(new Bitmap(fs));
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, @"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Проверяет размеры изображения, загружаемого как "Исходное изображение", на поле Reflection.
        /// </summary>
        /// <param name="bitmap">Изображение, которое требуется проверить.</param>
        /// <returns>Возвращает проверяемое изображение.</returns>
        Bitmap CheckReflectionSourceImageSize(Bitmap bitmap)
        {
            if (bitmap == null)
                throw new ArgumentNullException(nameof(bitmap), @"Требуется задать главное изображение для проверки.");
            if (bitmap.Width != picReflectionSourceImage.Width)
                throw new ArgumentException($@"Главное загружаемое изображение не соответствует по ширине ({bitmap.Width} != {picReflectionSourceImage.Width}).", nameof(bitmap));
            if (bitmap.Height != picReflectionSourceImage.Height)
                throw new ArgumentException($@"Главное загружаемое изображение не соответствует по высоте ({bitmap.Height} != {picReflectionSourceImage.Height}).", nameof(bitmap));
            return bitmap;
        }

        /// <summary>
        /// Проверяет размеры загружаемых карт, предназначенных для поля Reflector.
        /// В том числе, проверяет их на значение <see langword="null"/>.
        /// </summary>
        /// <param name="processors">Проверяемые карты.</param>
        /// <returns>Возвращает первый элемент коллекции или <see langword="null"/>, если коллекция пуста.</returns>
        Processor CheckReflectorLoadedProcessorSizes(ICollection<Processor> processors)
        {
            if (processors == null)
                throw new ArgumentNullException(nameof(processors), @"Требуется задать хотя бы одну карту для проверки.");

            foreach (Processor processor in processors)
            {
                if (processor == null)
                    throw new ArgumentNullException(nameof(processors), @"Требуется задать карту для проверки (null).");
                if (processor.Width != picReflectorPart00.Width)
                    throw new ArgumentException($@"Загружаемая карта ({processor.Tag}) не соответствует по ширине ({processor.Width} != {picReflectorPart00.Width}).", nameof(processors));
                if (processor.Height != picReflectorPart00.Height)
                    throw new ArgumentException($@"Загружаемая карта ({processor.Tag}) не соответствует по высоте ({processor.Height} != {picReflectorPart00.Height}).", nameof(processors));
            }

            return processors.FirstOrDefault();
        }

        /// <summary>
        /// Сохраняет исходное изображение с поля Reflection.
        /// </summary>
        /// <param name="sender">Вызывающий объект. Не используется.</param>
        /// <param name="e">Аргументы. Не используется.</param>
        void BtnReflectionSourceImageSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (SaveFile.ShowDialog(this) == DialogResult.OK)
                    _reflectionSourceImagePainter.CurrentBitmap.Save(SaveFile.FileName, ImageFormat.Bmp);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, @"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Сохраняет текущую результирующую карту, в виде изображения, на жёсткий диск.
        /// </summary>
        /// <param name="sender">Вызывающий объект. Не используется.</param>
        /// <param name="e">Аргументы. Не используется.</param>
        void BtnSaveCommonImageResult_Click(object sender, EventArgs e)
        {
            try
            {
                if (_commonImageResults != null && SaveFile.ShowDialog(this) == DialogResult.OK)
                    _commonImageResults[_currentCommonImageResultIndex].Save(SaveFile.FileName, ImageFormat.Bmp);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, @"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Отображает результат выполнения запроса с указанным индексом.
        /// Указанный индекс записывается в переменную <see cref="_currentCommonImageResultIndex"/>.
        /// </summary>
        /// <param name="index">Если меньше ноля, отображается текущий выбранный результат, в противном случае будет совершён переход к результату с указанным индексом.</param>
        void ViewSelectedCommonResult(int index = -1)
        {
            if (index < 0)
                index = _currentCommonImageResultIndex;

            picCommonImageResult.Image = _commonImageResults[_currentCommonImageResultIndex = index];
            PrintResultComment();
        }

        /// <summary>
        /// Отображает следующую результирующую карту.
        /// Поддерживает круговую перемотку.
        /// </summary>
        /// <param name="sender">Вызывающий объект. Не используется.</param>
        /// <param name="e">Аргументы. Не используется.</param>
        void BtnNextCommonImageResult_Click(object sender, EventArgs e)
        {
            try
            {
                _currentCommonImageResultIndex = _currentCommonImageResultIndex < _commonImageResults.Length - 1
                    ? ++_currentCommonImageResultIndex
                    : 0;

                ViewSelectedCommonResult();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, @"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Отображает предыдущую результирующую карту.
        /// Поддерживает круговую перемотку.
        /// </summary>
        /// <param name="sender">Вызывающий объект. Не используется.</param>
        /// <param name="e">Аргументы. Не используется.</param>
        void BtnPrevCommonImageResult_Click(object sender, EventArgs e)
        {
            try
            {
                _currentCommonImageResultIndex = _currentCommonImageResultIndex > 0
                    ? --_currentCommonImageResultIndex
                    : _commonImageResults.Length - 1;

                ViewSelectedCommonResult();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, @"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Выводит результат работы <see cref="Reflector"/> или <see cref="Reflection"/> в понятной для пользователя форме.
        /// </summary>
        void PrintResultComment() => grpCommonImageResult.Text =
            $@"{_commonImageResultString} ({_commonImageResults.Length}) - {(IsSelectedResultImageEqualWithSelectedCommonImageResult ? "Совпадает" : "Различается")} [{
                    _currentCommonImageResultIndex + 1
                }]";

        /// <summary>
        /// Предназначен для перемотки изображений, созданных на поле Reflector, вперёд.
        /// Не поддерживает круговую перемотку.
        /// </summary>
        /// <param name="x">Координата изображения X.</param>
        /// <param name="y">Координата изображения Y.</param>
        /// <param name="toEnd">Значение <see langword="true"/> указывает на необходимость показать последнее изображение.</param>
        void ReflectorPartNextButton(int x, int y, bool toEnd)
        {
            try
            {
                List<Processor> partProcessors = _reflectorPartProcessors[x, y];
                if (partProcessors.Count <= 0)
                {
                    DisplayReflectorPartStatusOnGroupBox(x, y);
                    return;
                }
                int index = toEnd ? partProcessors.Count : ++_reflectorPartImageCurrentIndex[x, y];
                if (index >= partProcessors.Count)
                    index = _reflectorPartImageCurrentIndex[x, y] = partProcessors.Count - 1;
                ViewSelectedReflectorPart(x, y, partProcessors[index]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, @"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Предназначен для перемотки изображений, созданных на поле Reflector, назад.
        /// Не поддерживает круговую перемотку.
        /// </summary>
        /// <param name="x">Координата изображения X.</param>
        /// <param name="y">Координата изображения Y.</param>
        void ReflectorPartPrevButton(int x, int y)
        {
            try
            {
                List<Processor> partProcessors = _reflectorPartProcessors[x, y];
                if (partProcessors.Count <= 0)
                {
                    DisplayReflectorPartStatusOnGroupBox(x, y);
                    return;
                }
                int index = --_reflectorPartImageCurrentIndex[x, y];
                if (index < 0)
                    index = _reflectorPartImageCurrentIndex[x, y] = 0;
                ViewSelectedReflectorPart(x, y, partProcessors[index]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, @"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Отображает содержимое указанной карты, по указанным координатам, на поле Reflector.
        /// </summary>
        /// <param name="x">Координата X.</param>
        /// <param name="y">Координата Y.</param>
        /// <param name="partProcessor">Карта, содержимое которой требуется отобразить на поле Reflector, по указанным координатам.</param>
        void ViewSelectedReflectorPart(int x, int y, Processor partProcessor)
        {
            _reflectorPartPainters[x, y].CurrentProcessor = partProcessor;
            GetReflectorQueryPartTextBox(x, y).Text = partProcessor == null ? _reflectorQueryPartTextBoxFields[x, y] : partProcessor.Tag;
            DisplayReflectorPartStatusOnGroupBox(x, y);
        }

        /// <summary>
        /// Презназначена для перемотки изображений, созданных на поле Reflector.
        /// Определяет нажатую кнопку, её координаты и направление.
        /// </summary>
        /// <param name="sender">Вызывающий объект (нажатая кнопка).</param>
        /// <param name="e">Игнорируется.</param>
        void BtnPrevNextReflectorPartButton_Click(object sender, EventArgs e)
        {
            try
            {
                string name = ((Button)sender).Name;
                if (!GetControlCoords(out int x, out int y, name, "btnNextReflectorPart"))
                    if (GetControlCoords(out x, out y, name, "btnPrevReflectorPart"))
                        ReflectorPartPrevButton(x, y);
                    else
                        throw new Exception("Нажата неизвестная кнопка.");
                else
                    ReflectorPartNextButton(x, y, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, @"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Отвечает за сохранение созданного изображения на жёсткий диск.
        /// Срабатывает при нажатии кнопки "ОК" на каком-либо изображении поля Reflector.
        /// </summary>
        /// <param name="sender">Вызывающий объект.</param>
        /// <param name="e">Аргументы. Не используется.</param>
        void OkButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (!GetControlCoords(out int x, out int y, ((Button)sender).Name, "btnOKReflectorPart"))
                    throw new ArgumentException(@"Не могу идентифицировать поле ввода запроса.", nameof(sender));
                SaveReflectorPartImage(x, y);
                _reflection = null;
                _reflector = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, @"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Отвечает за удаление указанного изображения (карты) с поля Reflector, из базы данных, а так же самого файла с изображением, на жёстком диске.
        /// Срабатывает при нажатии кнопки "Удалить" на каком-либо изображении поля Reflector.
        /// Вынуждает заново создать все объекты для распознавания.
        /// </summary>
        /// <param name="sender">Вызывающий объект.</param>
        /// <param name="e">Аргументы. Не используется.</param>
        void BtnDelReflectorPart_Click(object sender, EventArgs e)
        {
            try
            {
                if (!GetControlCoords(out int x, out int y, ((Button)sender).Name, "btnDelReflectorPart"))
                    throw new ArgumentException(@"Не могу идентифицировать поле ввода запроса.", nameof(sender));
                DeleteReflectorPartImage(x, y);
                _reflection = null;
                _reflector = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, @"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Отвечает за очистку (стирание) указанного изображения на поле Reflector.
        /// </summary>
        /// <param name="sender">Вызывающий объект.</param>
        /// <param name="e">Аргументы. Не используется.</param>
        void BtnClearReflectorPart_Click(object sender, EventArgs e)
        {
            try
            {
                if (!GetControlCoords(out int x, out int y, ((Button)sender).Name, "btnClearReflectorPart"))
                    throw new ArgumentException(@"Не могу идентифицировать поле ввода запроса.", nameof(sender));
                _reflectorPartPainters[x, y].Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, @"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Возвращает <see cref="GroupBox"/>, по указанным координатам, с поля Reflector.
        /// </summary>
        /// <param name="x">Координата X.</param>
        /// <param name="y">Координата Y.</param>
        /// <returns>Возвращает требуемый <see cref="GroupBox"/>.</returns>
        GroupBox GetReflectorPartGroupBox(int x, int y)
        {
            Control[] grpBox = (from Control c in grpReflector.Controls
                                where c.GetType() == typeof(GroupBox)
                                where c.Name == $"grpReflectorPart{x}{y}"
                                select c).ToArray();
            if (grpBox.Length != 1)
                throw new Exception($"Найдены {nameof(GroupBox)} с одинаковыми именами или требуемый элемент отсутствует.");
            return (GroupBox)grpBox[0];
        }

        /// <summary>
        /// Отображает статус указанной части объекта <see cref="Reflector"/>, т.е. количество изображений и индекс указанного изображения, начиная с единицы.
        /// Статус отображается на <see cref="GroupBox"/> по указанным координатам.
        /// </summary>
        /// <param name="x">Координата X.</param>
        /// <param name="y">Координата Y.</param>
        void DisplayReflectorPartStatusOnGroupBox(int x, int y)
        {
            int count = _reflectorPartProcessors[x, y].Count;
            GetReflectorPartGroupBox(x, y).Text = count <= 0 ? _reflectorPartGroupBoxTextFields[x, y] : $@"{_reflectorPartGroupBoxTextFields[x, y]} ({count}) [{_reflectorPartImageCurrentIndex[x, y] + 1}]";
        }

        /// <summary>
        /// Предназначен для рисования (или стирания) как линий, так и отдельных точек исходного изображения.
        /// По нажатию ЛКМ производится рисование, по нажатию ПКМ - стирание.
        /// </summary>
        /// <param name="sender">Вызывающий объект. Не используется.</param>
        /// <param name="e">Аргументы.</param>
        void PicReflection_MouseDown_MouseMove(object sender, MouseEventArgs e)
        {
            // ReSharper disable once SwitchStatementMissingSomeCases
            switch (e.Button)
            {
                case MouseButtons.Left:
                    _reflectionSourceImagePainter.DrawBlackPoint(e.X, e.Y);
                    break;
                case MouseButtons.Right:
                    _reflectionSourceImagePainter.DrawWhitePoint(e.X, e.Y);
                    break;
            }
        }

        /// <summary>
        /// Отвечает за то, чтобы гарантировать, что поле для ввода части запроса никогда не будет пустым, и не будет состоять из белого поля.
        /// В случае, когда в него записывается пустое место или удаляется символ, происходит замена его на символ, который был до изменения.
        /// Помимо этого, происходит проверка на то, чтобы запрос всегда вводился в верхнем регистре, иначе регистр вводимого символа будет исправлен автоматически.
        /// Так же сохраняется положение курсора.
        /// </summary>
        /// <param name="sender">Вызывающий объект.</param>
        /// <param name="e">Аргументы. Не используется.</param>
        void TxtReflectorQueryPart_TextChanged(object sender, EventArgs e)
        {
            if (_txtReflectorQueryPartInProcessing)
                return;
            _txtReflectorQueryPartInProcessing = true;
            try
            {
                TextBox tb = (TextBox)sender;
                if (!GetControlCoords(out int x, out int y, tb.Name, "txtReflectorQueryPart"))
                    throw new ArgumentException(@"Не могу идентифицировать поле ввода запроса.", nameof(sender));
                int selectionStart = tb.SelectionStart;
                tb.Text = string.IsNullOrWhiteSpace(tb.Text) ? _reflectorQueryPartTextBoxFields[x, y] : tb.Text.ToUpper();
                tb.SelectionStart = selectionStart;
                _reflectorQueryPartTextBoxFields[x, y] = tb.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, @"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _txtReflectorQueryPartInProcessing = false;
            }
        }

        /// <summary>
        /// Обрабатывает отпускание определённой клавиши над основной формой приложения.
        /// Кнопка <see cref="Keys.Escape"/> завершает работу программы.
        /// </summary>
        /// <param name="sender">Вызывающий объект. Не используется.</param>
        /// <param name="e">Аргументы.</param>
        void FrmMain_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control || e.Alt || e.Shift)
                return;

            switch (e.KeyCode)
            {
                case Keys.Escape:
                    Application.Exit();
                    return;
            }
        }

        /// <summary>
        /// Предотвращает появление звука некорректного ввода в поле запроса, в случае нажатия служебных клавиш.
        /// Очищает поле ввода части запроса перед вставкой нового символа в него.
        /// </summary>
        /// <param name="sender">Вызывающий объект.</param>
        /// <param name="e">Аргументы.</param>
        void TxtReflectorQueryPart_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
                return;
            }

            _txtReflectorQueryPartInProcessing = true;

            try
            {
                ((TextBox)sender).Text = string.Empty;
            }
            finally
            {
                _txtReflectorQueryPartInProcessing = false;
            }
        }

        /// <summary>
        /// Запускает таймер, отсчитывающий время, затраченное на выполнение какой-либо операции.
        /// Показание времени отображается в виде 00:00:00. Обновление показаний производится каждые 100 мс.
        /// В момент завершения задачи таймер останавливается, не сбрасывая текущее значение, помимо этого, активируются кнопки управления.
        /// </summary>
        /// <param name="ctlTextWrite">Элемент управления, на который выводить время выполнения.</param>
        void WaitableTimer(Control ctlTextWrite)
        {
            new Thread(() => SafetyExecute(() =>
            {
                _stopwatch.Restart();
                try
                {
                    while (true)
                    {
                        InvokeFunction(() =>
                            ctlTextWrite.Text =
                                $@"{_stopwatch.Elapsed.Hours:00}:{_stopwatch.Elapsed.Minutes:00}:{
                                        _stopwatch.Elapsed.Seconds:00}");
                        Thread.Sleep(100);
                        if (_workThread?.IsAlive != true)
                            return;
                    }
                }
                finally
                {
                    _stopwatch.Stop();
                    Invoke((Action)(() => IsButtonsEnabled = true));
                }
            }))
            {
                IsBackground = true,
                Name = nameof(WaitableTimer)
            }.Start();
        }

        /// <summary>
        ///     Выполняет метод с помощью метода Invoke.
        /// </summary>
        /// <param name="funcAction">Функция, которую необходимо выполнить.</param>
        /// <param name="catchAction">Функция, которая должна быть выполнена в блоке <see langword="catch"/>.</param>
        void InvokeFunction(Action funcAction, Action catchAction = null)
        {
            if (funcAction == null)
                return;
            try
            {
                void Act()
                {
                    try
                    {
                        funcAction();
                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            MessageBox.Show(this, ex.Message, @"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            catchAction?.Invoke();
                        }
                        catch (Exception ex1)
                        {
                            MessageBox.Show(this, ex1.Message, @"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }

                if (InvokeRequired)
                    Invoke((Action)Act);
                else
                    Act();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        ///     Представляет обёртку для выполнения функций с применением блоков <see langword="try"/>-<see langword="catch"/>, а также выдачей сообщений обо всех
        ///     ошибках.
        /// </summary>
        /// <param name="funcAction">Функция, которая должна быть выполнена.</param>
        /// <param name="finallyAction">Функция, которая должна быть выполнена в блоке <see langword="finally"/>.</param>
        /// <param name="catchAction">Функция, которая должна быть выполнена в блоке <see langword="catch"/>.</param>
        void SafetyExecute(Action funcAction, Action finallyAction = null, Action catchAction = null)
        {
            try
            {
                funcAction?.Invoke();
            }
            catch (Exception ex)
            {
                try
                {
                    InvokeFunction(
                        () =>
                            MessageBox.Show(this, ex.Message, @"Ошибка", MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation));
                    catchAction?.Invoke();
                }
                catch
                {
                    InvokeFunction(
                        () =>
                            MessageBox.Show(this, ex.Message, @"Ошибка", MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation));
                }
            }
            finally
            {
                try
                {
                    finallyAction?.Invoke();
                }
                catch (Exception ex)
                {
                    InvokeFunction(
                        () =>
                            MessageBox.Show(this, ex.Message, @"Ошибка", MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation));
                }
            }
        }

        /// <summary>
        /// Получает новый <see cref="Neuron"/> из частей, находящихся на поле Reflector.
        /// Он получается из текущих изображений на поле Reflector.
        /// Названия карт берутся из текущих букв запроса, относящихся к конкретным изображениям.
        /// </summary>
        Neuron CurrentNeuron
        {
            get
            {
                IEnumerable<Processor> GetProcessors()
                {
                    for (int y = 0; y < 3; y++)
                        for (int x = 0; x < 3; x++)
                        {
                            Painter p = _reflectorPartPainters[x, y];
                            p.CurrentProcessorName = GetCurrentReflectorQueryPartString(x, y);
                            yield return p.CurrentProcessor;
                        }
                }

                return new Neuron(new ProcessorContainer(GetProcessors().ToArray()));
            }
        }

        /// <summary>
        /// Получает новый запрос для <see cref="Neuron"/> из частей, находящихся на поле Reflector.
        /// Он получается из текущих изображений на поле Reflector.
        /// Названия карт берутся из текущих букв запроса, относящихся к конкретным изображениям.
        /// </summary>
        IEnumerable<(Processor, string)> CurrentNeuronQuery
        {
            get
            {
                IEnumerable<(Processor, string)> GetQuery()
                {
                    for (int y = 0; y < 3; y++)
                        for (int x = 0; x < 3; x++)
                        {
                            Painter p = _reflectorPartPainters[x, y];
                            p.CurrentProcessorName = GetCurrentReflectorQueryPartString(x, y);
                            yield return (p.CurrentProcessor, p.CurrentProcessorName);
                        }
                }

                return GetQuery();
            }
        }

        /// <summary>
        /// Отвечает за установку параметров отображения элемента списка, с целью отображения его по центру.
        /// </summary>
        /// <param name="sender">Вызывающий объект. Не используется.</param>
        /// <param name="e">Аргументы.</param>
        void LstNeurons_DrawItem(object sender, DrawItemEventArgs e) => TextRenderer.DrawText(e.Graphics, lstNeurons.Items[e.Index].ToString(), e.Font, e.Bounds, e.ForeColor, e.BackColor, TextFormatFlags.HorizontalCenter);

        /// <summary>
        /// Предотвращает реакцию на нажатие клавиши <see cref="Keys.Delete"/> для единообразия эффектов от нажатий клавиш <see cref="Keys.Delete"/> и <see cref="Keys.Back"/>.
        /// </summary>
        /// <param name="sender">Вызывающий объект. Не используется.</param>
        /// <param name="e">Аргументы.</param>
        void TxtReflectorQueryPart_KeyDown(object sender, KeyEventArgs e) => e.Handled = e.KeyCode == Keys.Delete;
    }
}