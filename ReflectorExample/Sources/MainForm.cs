using System;
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
        /// Отвечает за операции с исходным изображением.
        /// </summary>
        readonly Painter _reflectionSourcePicturePainter;

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
        readonly string _resultString;

        /// <summary>
        ///     Таймер для измерения времени, затраченного на какую-либо операцию.
        /// </summary>
        readonly Stopwatch _stopwatch = new Stopwatch();

        /// <summary>
        /// Служит для резервирования изначальных значений частей рабочего поля Reflector.
        /// </summary>
        readonly string[,] _reflectorGroupBoxTextFields = new string[3, 3];

        /// <summary>
        /// Служит для резервирования изначальных значений частей запроса на поле Reflector.
        /// </summary>
        readonly string[,] _reflectorQueryFields = new string[3, 3];

        /// <summary>
        /// Отражает номер результата в массиве результатов, на котором в текущий момент находится пользователь.
        /// </summary>
        int _currentResult;

        /// <summary>
        /// Основной объект для распознавания. Обновляется в случае добавления и/или изменения распознаваемых или распознающих карт.
        /// </summary>
        Reflector _reflector;

        /// <summary>
        /// Основной объект для распознавания. Обновляется в случае добавления и/или изменения распознаваемых или распознающих карт.
        /// </summary>
        Reflection _reflection;

        /// <summary>
        /// Содержит результаты работы компонента <see cref="Reflection"/> (карты) в виде изображений.
        /// </summary>
        Bitmap[] _recognizeResults;

        /// <summary>
        /// Отвечает за автоматическую обработку введённого в текстовое поле текста.
        /// Значение <see langword="true"/> получает для того, чтобы предотвратить повторную обработку текста, который уже находится в обработке.
        /// Другими словами, значение <see langword="true"/> запрещает событию изменения текста в текстовом поле выполняться во время обработки этого события.
        /// </summary>
        bool _txtInProcessing;

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
            _reflectorPartPainters[0, 0] = new Painter(picReflectorPart00);
            _reflectorPartPainters[1, 0] = new Painter(picReflectorPart10);
            _reflectorPartPainters[2, 0] = new Painter(picReflectorPart20);
            _reflectorPartPainters[0, 1] = new Painter(picReflectorPart01);
            _reflectorPartPainters[1, 1] = new Painter(picReflectorPart11);
            _reflectorPartPainters[2, 1] = new Painter(picReflectorPart21);
            _reflectorPartPainters[0, 2] = new Painter(picReflectorPart02);
            _reflectorPartPainters[1, 2] = new Painter(picReflectorPart12);
            _reflectorPartPainters[2, 2] = new Painter(picReflectorPart22);
            _reflectionSourcePicturePainter = new Painter(picReflectionSource);
            _reflectorGroupBoxTextFields[0, 0] = grpReflectorPart00.Text;
            _reflectorGroupBoxTextFields[1, 0] = grpReflectorPart10.Text;
            _reflectorGroupBoxTextFields[2, 0] = grpReflectorPart20.Text;
            _reflectorGroupBoxTextFields[0, 1] = grpReflectorPart01.Text;
            _reflectorGroupBoxTextFields[1, 1] = grpReflectorPart11.Text;
            _reflectorGroupBoxTextFields[2, 1] = grpReflectorPart21.Text;
            _reflectorGroupBoxTextFields[0, 2] = grpReflectorPart02.Text;
            _reflectorGroupBoxTextFields[1, 2] = grpReflectorPart12.Text;
            _reflectorGroupBoxTextFields[2, 2] = grpReflectorPart22.Text;
            _reflectorQueryFields[0, 0] = txtReflectorQueryPart00.Text;
            _reflectorQueryFields[1, 0] = txtReflectorQueryPart10.Text;
            _reflectorQueryFields[2, 0] = txtReflectorQueryPart20.Text;
            _reflectorQueryFields[0, 1] = txtReflectorQueryPart01.Text;
            _reflectorQueryFields[1, 1] = txtReflectorQueryPart11.Text;
            _reflectorQueryFields[2, 1] = txtReflectorQueryPart21.Text;
            _reflectorQueryFields[0, 2] = txtReflectorQueryPart02.Text;
            _reflectorQueryFields[1, 2] = txtReflectorQueryPart12.Text;
            _reflectorQueryFields[2, 2] = txtReflectorQueryPart22.Text;
            _resultString = grpResult.Text;
        }

        /// <summary>
        /// Получает карты, содержащиеся на поле Reflector.
        /// </summary>
        ProcessorContainer[,] Containers
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
                                $"{nameof(Containers)}: Ошибка в поле с координатами ({x}, {y}): {ex.Message}");
                        }
                return pcs;
            }
        }

        /// <summary>
        /// Получает значение, отражающее, совпадает ли текущее результирующее изображение с исходным (<see langword="true"/>), или нет (<see langword="false"/>).
        /// </summary>
        bool CompareWithResult
        {
            get
            {
                Bitmap b1 = _reflectionSourcePicturePainter.CurrentBitmap;
                Bitmap b2 = _recognizeResults[_currentResult];
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
        bool EnableButtons
        {
            set
            {
                grpReflectorQuery.Enabled = value;
                grpReflectorPart00.Enabled = value;
                grpReflectorPart01.Enabled = value;
                grpReflectorPart02.Enabled = value;
                grpReflectorPart10.Enabled = value;
                grpReflectorPart20.Enabled = value;
                grpReflectorPart11.Enabled = value;
                grpReflectorPart21.Enabled = value;
                grpReflectorPart12.Enabled = value;
                grpReflectorPart22.Enabled = value;
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
                VerifyPictureBoxSizes();
                for (int y = 0; y < _reflectorPartProcessors.GetLength(1); y++)
                    for (int x = 0; x < _reflectorPartProcessors.GetLength(0); x++)
                    {
                        _reflectorPartProcessors[x, y] = new List<Processor>(ReflectorFieldDataBase.GetProcessors(x, y));
                        if (!VerifyMapsImageSizes(_reflectorPartProcessors[x, y]))
                        {
                            Application.Exit();
                            return;
                        }
                        ReflectorPartPrevButton(x, y);
                    }
                string main = Path.Combine(Application.StartupPath, "main.bmp");
                if (!File.Exists(main))
                    return;
                using (FileStream fs = new FileStream(main, FileMode.Open, FileAccess.Read, FileShare.Read))
                    _reflectionSourcePicturePainter.CurrentBitmap = new Bitmap(fs);
                if (!VerifyMainImageSize(_reflectionSourcePicturePainter.CurrentBitmap))
                    Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $@"{ex.Message} Программа будет закрыта.", @"Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        /// <summary>
        /// Выполняет операцию самоконтроля изначальных параметров работы программы, чтобы не было ошибок при подаче входных данных в тестируемые компоненты.
        /// </summary>
        void VerifyPictureBoxSizes()
        {
            Size main = picReflectorPart00.Size;
            if (picReflectorPart00.Size != main || picReflectorPart10.Size != main || picReflectorPart20.Size != main ||
                picReflectorPart01.Size != main || picReflectorPart11.Size != main || picReflectorPart21.Size != main ||
                picReflectorPart02.Size != main || picReflectorPart12.Size != main || picReflectorPart22.Size != main)
                throw new Exception("Обнаружены поля рисования различных размеров.");
            if (picReflectionSource.Width % main.Width != 0)
                throw new Exception("Ширина основного поля должна быть кратна ширине всех полей для рисования.");
            if (picReflectionSource.Height % main.Height != 0)
                throw new Exception("Высота основного поля должна быть кратна высоте всех полей для рисования.");
        }

        /// <summary>
        /// Получает <see cref="TextBox"/> запроса по указанным координатам на поле Reflector.
        /// </summary>
        /// <param name="x">Координата X на поле Reflector.</param>
        /// <param name="y">Координата Y на поле Reflector.</param>
        /// <returns>Возвращает <see cref="TextBox"/> запроса по указанным координатам. В противном случае выдаёт исключение.</returns>
        TextBox GetReflectorQueryPartTextBox(int x, int y)
        {
            foreach (Control c in from Control c in grpReflectorQuery.Controls where c.GetType() == typeof(TextBox) select c)
            {
                if (!GetControlCoords(out int px, out int py, c.Name, "txtReflectorQuery"))
                    continue;
                if (px != x || py != y)
                    continue;
                return (TextBox)c;
            }
            throw new Exception($"Требуемый {nameof(TextBox)} почему-то отсутствует на поле ({x}, {y}).");
        }

        /// <summary>
        /// Получает часть запроса, по заданным координатам, с поля Reflector.
        /// </summary>
        /// <param name="x">Координата X на поле Reflector.</param>
        /// <param name="y">Координата Y на поле Reflector.</param>
        /// <returns>Возвращает часть запроса по заданным координатам.</returns>
        string GetCurrentReflectorPartOfQuery(int x, int y)
        {
            string pName = GetReflectorQueryPartTextBox(x, y).Text;
            if (string.IsNullOrWhiteSpace(pName))
                throw new ArgumentException($@"Название искомой карты в поле ({x}, {y}) не задано.");
            return pName;
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
        /// <param name="test">Флаг проверки возможности выполнения операции. Значение <see langword="true"/> указывает на то, что необходимо проверить, все ли условия позволяют успешно выполнить операцию, при этом, сама операция выполнена не будет.</param>
        /// <returns>Возвращает значение <see langword="true"/> в случае успеха или успешного прохождения проверки возможности выполнения операции. В противном случае - <see langword="false"/>.</returns>
        bool SaveReflectorPartImage(int x, int y, bool test = false)
        {
            string mapName = GetCurrentReflectorPartOfQuery(x, y);
            string path = GetImagePath(mapName);
            if (File.Exists(path))
            {
                if (!test)
                    MessageBox.Show(this, $@"Ошибка: Файл ({x}, {y}) существует. Операция отменена.", @"Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                return false;
            }
            if (test)
                return true;
            Painter p = _reflectorPartPainters[x, y];
            using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.Read))
                p.CurrentBitmap.Save(fs, ImageFormat.Bmp);
            ReflectorFieldDataBase.Save(x, y, path);
            p.CurrentProcessorName = mapName;
            List<Processor> reflectorPartProcessors = _reflectorPartProcessors[x, y];
            reflectorPartProcessors.Add(p.CurrentProcessor);
            _reflectorPartImageCurrentIndex[x, y] = reflectorPartProcessors.Count - 1;
            DisplayReflectorPartStatus(x, y);
            return true;
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
            List<Processor> proc = _reflectorPartProcessors[x, y];
            for (int k = 0; k < proc.Count; k++)
                if (proc[k].Tag == mapName)
                    proc.RemoveAt(k);
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

        void BtnReflectionSourceClear_Click(object sender, EventArgs e) => _reflectionSourcePicturePainter.Clear();

        /// <summary>
        /// Разбивает исходное изображение на изображения равных размеров, затем распределяет их по полю Reflector, и сохраняет на жёсткий диск, отображая на экране.
        /// </summary>
        /// <param name="sender">Вызывающий объект. Не используется.</param>
        /// <param name="e">Аргументы. Не используется.</param>
        void BtnReflectionSourceAdd_Click(object sender, EventArgs e)
        {
            try
            {
                _reflectionSourcePicturePainter.CurrentProcessorName = "main";
                Bitmap[] btms = ImageSplit(_reflectionSourcePicturePainter.CurrentProcessor, picReflectorPart00.Width, picReflectorPart00.Height).ToArray();
                if (btms.Length != 9)
                {
                    MessageBox.Show(this, $@"Количество карт неверное ({btms.Length}). Должно быть 9.");
                    return;
                }
                for (int y = 0; y < 3; y++)
                    for (int x = 0; x < 3; x++)
                    {
                        if (SaveReflectorPartImage(x, y, true))
                            continue;
                        MessageBox.Show(this,
                            $@"Файл ({x}, {y}) невозможно сохранить, т.к. он уже существует. Задайте другое имя.",
                            @"Файл уже существует.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                for (int y = 0, px = 0; y < 3; y++)
                    for (int x = 0; x < 3; x++)
                    {
                        _reflectorPartPainters[x, y].CurrentProcessor = new Processor(btms[px++], GetCurrentReflectorPartOfQuery(x, y));
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

        static IEnumerable<Bitmap> ImageSplit(Processor prc, int mx, int my)
        {
            if (prc == null)
                throw new ArgumentNullException(nameof(prc), @"Делимая карта равна null.");
            if (mx <= 0)
                throw new ArgumentException($@"Размер делимой части по оси X указан неверно ({mx}).", nameof(mx));
            if (my <= 0)
                throw new ArgumentException($@"Размер делимой части по оси Y указан неверно ({my}).", nameof(my));
            if (prc.Height % my != 0)
                throw new ArgumentException(
                    $@"Высота делимого изображения должна быть кратна высоте делителя: {prc.Height} % {my}.");
            if (prc.Width % mx != 0)
                throw new ArgumentException(
                    $@"Ширина делимого изображения должна быть кратна ширине делителя: {prc.Width} % {mx}.");
            for (int qy = 0; qy < prc.Height; qy += my)
                for (int qx = 0; qx < prc.Width; qx += mx)
                {
                    Bitmap b = new Bitmap(mx, my);
                    for (int y = qy, ry = qy + my, ty = 0; y < ry; y++, ty++)
                        for (int x = qx, rx = qx + mx, tx = 0; x < rx; x++, tx++)
                            b.SetPixel(tx, ty, prc[x, y].ValueColor);
                    yield return b;
                }
        }

        void ResetResults()
        {
            _recognizeResults = null;
            _currentResult = 0;
            BtnNextResult_Click(btnNextReflectionResult, new EventArgs());
            btnPrevReflectionResult.Enabled = btnNextReflectionResult.Enabled = btnSaveReflectionResultImage.Enabled = false;
        }

        void BtnReflectionPush_Click(object sender, EventArgs e) => SafetyExecute(() =>
        {
            if (_workThread?.IsAlive ?? false)
                return;
            ResetResults();
            EnableButtons = false;
            _workThread = new Thread(() => SafetyExecute(() =>
            {
                if (_reflection == null)
                {
                    InvokeFunction(() => btnReflectionPush.Text = @"Подготовка...");
                    _reflection = new Reflection(Containers);
                }
                InvokeFunction(() =>
                {
                    txtReflectionMapWidth.Text = _reflection.MapWidth.ToString();
                    txtReflectionMapHeight.Text = _reflection.MapHeight.ToString();
                });
                _reflectionSourcePicturePainter.CurrentProcessorName = "main";
                WaitableTimer(btnReflectionPush);
                IEnumerable<Processor> processors = _reflection.Push(_reflectionSourcePicturePainter.CurrentProcessor);
                _stopwatch.Stop();
                if ((_recognizeResults = processors?.Select(ProcessorToBitmap).ToArray()) == null)
                    return;
                InvokeFunction(() =>
                {
                    btnSaveReflectionResultImage.Enabled = true;
                    btnPrevReflectionResult.Enabled = btnNextReflectionResult.Enabled = _recognizeResults.Length > 1;
                    BtnPrevResult_Click(btnPrevReflectionResult, new EventArgs());
                });
            }))
            { IsBackground = true, Name = nameof(Reflection), Priority = ThreadPriority.Highest };
            _workThread.Start();
        });

        void BtnReflectorPush_Click(object sender, EventArgs e) => SafetyExecute(() =>
        {
            if (_workThread?.IsAlive ?? false)
                return;
            ResetResults();
            EnableButtons = false;
            _workThread = new Thread(() => SafetyExecute(() =>
            {
                if (_reflector == null)
                {
                    InvokeFunction(() => btnReflectorPush.Text = @"Подготовка...");
                    _reflector = new Reflector(Containers);
                }
                char[,] ch = null;
                InvokeFunction(() =>
                {
                    ch = CurrentReflectorQuery;
                    txtReflectorMapWidth.Text = _reflector.MapWidth.ToString();
                    txtReflectorMapHeight.Text = _reflector.MapHeight.ToString();
                    txtReflectorProcessorWidth.Text = _reflector.ProcessorWidth.ToString();
                    txtReflectorProcessorHeight.Text = _reflector.ProcessorHeight.ToString();
                });
                _reflectionSourcePicturePainter.CurrentProcessorName = "main";
                WaitableTimer(btnReflectorPush);
                Processor p = _reflector.Push(_reflectionSourcePicturePainter.CurrentProcessor, ch);
                _stopwatch.Stop();
                Bitmap result = ProcessorToBitmap(p);
                if ((_recognizeResults = result != null ? new[] { result } : null) == null)
                    return;
                InvokeFunction(() =>
                {
                    btnSaveReflectionResultImage.Enabled = true;
                    btnPrevReflectionResult.Enabled = btnNextReflectionResult.Enabled = false;
                    BtnPrevResult_Click(btnPrevReflectionResult, new EventArgs());
                });
            }))
            { IsBackground = true, Name = nameof(Reflection), Priority = ThreadPriority.Highest };
            _workThread.Start();
        });

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender">Вызывающий объект.</param>
        /// <param name="e">Аргументы. Не используется.</param>
        void BtnNeuronFindRelation_Click(object sender, EventArgs e) => SafetyExecute(() =>
        {
            if (_workThread?.IsAlive ?? false)
                return;
            if (lstNeurons.SelectedIndex < 0)
            {
                MessageBox.Show(this, @"Ошибка! Выберите нейрон, с помощью которого будет создан новый нейрон!", @"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ResetResults();
            EnableButtons = false;
            _workThread = new Thread(() => SafetyExecute(() =>
            {
                int selIndex = -1;
                InvokeFunction(() =>
                {
                    btnNeuronFindRelation.Text = @"Подготовка...";
                    selIndex = lstNeurons.SelectedIndex - 1;
                });

                if (selIndex < 0)
                {
                    Neuron currentNeuron = CurrentNeuron;
                    InvokeFunction(() =>
                    {
                        _neurons.Insert(0, currentNeuron);
                        lstNeurons.Items.Insert(1, $@"({currentNeuron.Processors.Count()}) {DateTime.Now:HH:mm:ss} ({currentNeuron})");
                        lstNeurons.SelectedIndex = 1;
                    });
                    return;
                }

                WaitableTimer((Control)sender);

                Neuron derivedNeuron = _neurons[selIndex].FindRelation(NeuronQuery);

                _stopwatch.Stop();

                if (derivedNeuron == null)
                {
                    InvokeFunction(() => MessageBox.Show(this, $@"{nameof(Neuron)} не создался.",
                        @"Результат", MessageBoxButtons.OK, MessageBoxIcon.Information));
                    return;
                }

                InvokeFunction(() =>
                {
                    _neurons.Insert(0, derivedNeuron);
                    lstNeurons.Items.Insert(1, $@"({_neurons.Count}) {DateTime.Now:HH:mm:ss} ({derivedNeuron})");
                    lstNeurons.SelectedIndex = 1;
                });

                for (int y = 0, j = 0; y < 3; y++)
                    for (int x = 0; x < 3; x++, j++)
                    {
                        Processor p = derivedNeuron.Processors.ElementAt(j);
                        _reflectorPartPainters[x, y].CurrentProcessor = p;
                        GetReflectorQueryPartTextBox(x, y).Text = p.Tag;
                    }

                InvokeFunction(() =>
                {
                    btnSaveReflectionResultImage.Enabled = true;
                    btnPrevReflectionResult.Enabled = btnNextReflectionResult.Enabled = _recognizeResults.Length > 1;
                    BtnPrevResult_Click(btnPrevReflectionResult, new EventArgs());
                });
            }))
            { IsBackground = true, Name = nameof(Reflection), Priority = ThreadPriority.Highest };
            _workThread.Start();
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

        void BtnImageLoad_Click(object sender, EventArgs e)
        {
            try
            {
                if (OpenFile.ShowDialog(this) != DialogResult.OK)
                    return;
                Bitmap b;
                using (FileStream fs = new FileStream(OpenFile.FileName, FileMode.Open, FileAccess.Read,
                    FileShare.Read))
                    b = new Bitmap(fs);
                if (!VerifyMainImageSize(b))
                    return;
                _reflectionSourcePicturePainter.CurrentBitmap = b;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, @"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        bool VerifyMainImageSize(Image b)
        {
            if (b == null)
                throw new ArgumentNullException(nameof(b), @"Требуется задать главное изображение для проверки.");
            if (b.Width != picReflectionSource.Width)
            {
                MessageBox.Show(this,
                    $@"Главное загружаемое изображение не соответствует по ширине ({b.Width} != {picReflectionSource.Width}).");
                return false;
            }
            if (b.Height == picReflectionSource.Height)
                return true;
            MessageBox.Show(this,
                $@"Главное загружаемое изображение не соответствует по высоте ({b.Height} != {picReflectionSource.Height}).");
            return false;
        }

        bool VerifyMapsImageSizes(IEnumerable<Processor> bs)
        {
            if (bs == null)
                throw new ArgumentNullException(nameof(bs), @"Требуется задать хотя бы одно изображение для проверки.");
            foreach (Processor b in bs)
            {
                if (b == null)
                    throw new ArgumentNullException(nameof(bs), @"Требуется задать изображение для проверки.");
                if (b.Width != picReflectorPart00.Width)
                {
                    MessageBox.Show(this,
                        $@"Загружаемое изображение ({b.Tag}) не соответствует по ширине ({b.Width} != {picReflectorPart00.Width}).");
                    return false;
                }
                if (b.Height == picReflectorPart00.Height)
                    continue;
                MessageBox.Show(this,
                    $@"Загружаемое изображение ({b.Tag}) не соответствует по высоте ({b.Height} != {picReflectorPart00.Height}).");
                return false;
            }
            return true;
        }

        void BtnImageSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (SaveFile.ShowDialog(this) != DialogResult.OK)
                    return;
                _reflectionSourcePicturePainter.CurrentBitmap.Save(SaveFile.FileName, ImageFormat.Bmp);
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
        void BtnSaveResultImage_Click(object sender, EventArgs e)
        {
            try
            {
                if (_recognizeResults != null && SaveFile.ShowDialog(this) == DialogResult.OK)
                    _recognizeResults[_currentResult].Save(SaveFile.FileName, ImageFormat.Bmp);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, @"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Отображает следующую результирующую карту.
        /// Поддерживает круговую перемотку.
        /// </summary>
        /// <param name="sender">Вызывающий объект. Не используется.</param>
        /// <param name="e">Аргументы. Не используется.</param>
        void BtnNextResult_Click(object sender, EventArgs e)
        {
            try
            {
                if (_recognizeResults == null)
                {
                    picReflectionResult.Image = null;
                    grpResult.Text = _resultString;
                    return;
                }
                if (_currentResult < _recognizeResults.Length - 1)
                    _currentResult++;
                else
                    _currentResult = 0;
                picReflectionResult.Image = _recognizeResults[_currentResult];
                PrintResultComment();
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
        void BtnPrevResult_Click(object sender, EventArgs e)
        {
            try
            {
                if (_recognizeResults == null)
                {
                    picReflectionResult.Image = null;
                    grpResult.Text = _resultString;
                    return;
                }
                if (_currentResult > 0)
                    _currentResult--;
                else
                    _currentResult = _recognizeResults.Length - 1;
                picReflectionResult.Image = _recognizeResults[_currentResult];
                PrintResultComment();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, @"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Выводит результат работы <see cref="Reflector"/> или <see cref="Reflection"/> в понятной для пользователя форме.
        /// </summary>
        void PrintResultComment() => grpResult.Text =
            $@"{_resultString} ({_recognizeResults.Length}) - {(CompareWithResult ? "Совпадает" : "Различается")} [{
                    _currentResult + 1
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
                    DisplayReflectorPartStatus(x, y);
                    return;
                }
                int index = toEnd ? partProcessors.Count : ++_reflectorPartImageCurrentIndex[x, y];
                if (index >= partProcessors.Count)
                    index = _reflectorPartImageCurrentIndex[x, y] = partProcessors.Count - 1;
                Processor partProcessor = partProcessors[index];
                DisplayReflectorPartStatus(x, y);
                _reflectorPartPainters[x, y].CurrentProcessor = partProcessor;
                GetReflectorQueryPartTextBox(x, y).Text = partProcessor.Tag;
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
                    DisplayReflectorPartStatus(x, y);
                    return;
                }
                int index = --_reflectorPartImageCurrentIndex[x, y];
                if (index < 0)
                    index = _reflectorPartImageCurrentIndex[x, y] = 0;
                Processor partProcessor = partProcessors[index];
                DisplayReflectorPartStatus(x, y);
                _reflectorPartPainters[x, y].CurrentProcessor = partProcessor;
                GetReflectorQueryPartTextBox(x, y).Text = partProcessor.Tag;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, @"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                if (!SaveReflectorPartImage(x, y))
                    return;
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
        /// Отображает статус части объекта <see cref="Reflector"/>, т.е. количество изображений и индекс указанного изображения, начиная с единицы.
        /// </summary>
        /// <param name="x">Координата X.</param>
        /// <param name="y">Координата Y.</param>
        void DisplayReflectorPartStatus(int x, int y)
        {
            Control[] grpBox = (from Control c in grpReflector.Controls
                                where c.GetType() == typeof(GroupBox)
                                where c.Name == $"grpReflectorPart{x}{y}"
                                select c).ToArray();
            if (grpBox.Length != 1)
                throw new Exception(
                    $"Найдены {nameof(GroupBox)} с одинаковыми именами или требуемый элемент отсутствует.");
            int count = _reflectorPartProcessors[x, y].Count;
            grpBox[0].Text = count <= 0 ? _reflectorGroupBoxTextFields[x, y] : $@"{_reflectorGroupBoxTextFields[x, y]} ({count}) [{_reflectorPartImageCurrentIndex[x, y] + 1}]";
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
                    _reflectionSourcePicturePainter.DrawBlackPoint(e.X, e.Y);
                    break;
                case MouseButtons.Right:
                    _reflectionSourcePicturePainter.DrawWhitePoint(e.X, e.Y);
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
            if (_txtInProcessing)
                return;
            _txtInProcessing = true;
            try
            {
                TextBox tb = (TextBox)sender;
                if (!GetControlCoords(out int x, out int y, tb.Name, "txtReflectorQueryPart"))
                    throw new ArgumentException(@"Не могу идентифицировать поле ввода запроса.", nameof(sender));
                int selectionStart = tb.SelectionStart;
                tb.Text = string.IsNullOrWhiteSpace(tb.Text) ? _reflectorQueryFields[x, y] : tb.Text.ToUpper();
                _reflectorQueryFields[x, y] = tb.Text;
                tb.SelectionStart = selectionStart;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, @"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _txtInProcessing = false;
            }
        }

        /// <summary>
        /// Обрабатывает отпускание определённой клавиши над основной формой приложения.
        /// Кнопка <see cref="Keys.Escape"/> завершает работу программы.
        /// Кнопка <see cref="Keys.Delete"/> удаляет выбранный <see cref="Neuron"/> из списка на форме, а так же внутренней коллекции, в случае нахождения фокуса ввода над ним.
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
                case Keys.Delete:
                    if (!lstNeurons.Focused || lstNeurons.SelectedIndex < 1)
                        return;
                    _neurons.RemoveAt(lstNeurons.SelectedIndex - 1);
                    lstNeurons.Items.RemoveAt(lstNeurons.SelectedIndex);
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
            if ((Keys)e.KeyChar == Keys.Escape || (Keys)e.KeyChar == Keys.Enter || (Keys)e.KeyChar == Keys.Tab ||
                (Keys)e.KeyChar == Keys.Pause || (Keys)e.KeyChar == Keys.XButton1 || e.KeyChar == 15)
            {
                e.Handled = true;
                return;
            }

            _txtInProcessing = true;

            try
            {
                ((TextBox)sender).Text = string.Empty;
            }
            finally
            {
                _txtInProcessing = false;
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
                    Invoke((Action)(() => EnableButtons = true));
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
                            p.CurrentProcessorName = GetCurrentReflectorPartOfQuery(x, y);
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
        IEnumerable<(Processor, string)> NeuronQuery
        {
            get
            {
                IEnumerable<(Processor, string)> GetQuery()
                {
                    for (int y = 0; y < 3; y++)
                        for (int x = 0; x < 3; x++)
                        {
                            Painter p = _reflectorPartPainters[x, y];
                            p.CurrentProcessorName = GetCurrentReflectorPartOfQuery(x, y);
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
    }
}