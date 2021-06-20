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

namespace ReflectorExample
{
    public partial class FrmMain : Form
    {
        readonly int[,] _imageCounter = new int[3, 3];
        readonly List<Processor>[,] _pcs = new List<Processor>[3, 3];
        readonly Painter _reflectionPainter;
        readonly Painter[,] _reflectorPainters = new Painter[3, 3];
        readonly List<Neuron> _neurons = new List<Neuron>();
        readonly string _resultString;

        /// <summary>
        ///     Таймер для измерения времени, затраченного на распознавание.
        /// </summary>
        readonly Stopwatch _stopwatch = new Stopwatch();

        readonly string[,] _strings = new string[3, 3];
        int _currentResult;
        Reflection _reflection;
        Bitmap[] _recognizeResults;
        Reflector _reflector;
        SaveLoad _saveLoad;

        bool _txtInProcessing;

        /// <summary>
        ///     Поток, отвечающий за выполнение процедуры распознавания.
        /// </summary>
        Thread _workThread;

        public FrmMain()
        {
            InitializeComponent();
            _reflectorPainters[0, 0] = new Painter(pic00);
            _reflectorPainters[1, 0] = new Painter(pic10);
            _reflectorPainters[2, 0] = new Painter(pic20);
            _reflectorPainters[0, 1] = new Painter(pic01);
            _reflectorPainters[1, 1] = new Painter(pic11);
            _reflectorPainters[2, 1] = new Painter(pic21);
            _reflectorPainters[0, 2] = new Painter(pic02);
            _reflectorPainters[1, 2] = new Painter(pic12);
            _reflectorPainters[2, 2] = new Painter(pic22);
            _reflectionPainter = new Painter(picReflection);
            _strings[0, 0] = grp00.Text;
            _strings[1, 0] = grp10.Text;
            _strings[2, 0] = grp20.Text;
            _strings[0, 1] = grp01.Text;
            _strings[1, 1] = grp11.Text;
            _strings[2, 1] = grp21.Text;
            _strings[0, 2] = grp02.Text;
            _strings[1, 2] = grp12.Text;
            _strings[2, 2] = grp22.Text;
            _resultString = grpResult.Text;
        }

        ProcessorContainer[,] Containers
        {
            get
            {
                ProcessorContainer[,] pcs = new ProcessorContainer[_pcs.GetLength(0), _pcs.GetLength(1)];
                for (int y = 0; y < pcs.GetLength(1); y++)
                    for (int x = 0; x < pcs.GetLength(0); x++)
                        try
                        {
                            pcs[x, y] = new ProcessorContainer(_pcs[x, y]);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(
                                $"{nameof(Containers)}: Ошибка в поле с координатами ({x}, {y}): {ex.Message}");
                        }
                return pcs;
            }
        }

        bool CompareWithResult
        {
            get
            {
                Bitmap b1 = _reflectionPainter.CurrentBitmap;
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

        // ReSharper disable once FunctionComplexityOverflow
        bool EnableButtons
        {
            set =>
                picReflection.Enabled = grpResult.Enabled = grpQuery.Enabled = grp00.Enabled =
                    grp01.Enabled = grp02.Enabled = grp10.Enabled = grp20.Enabled =
                        grp11.Enabled = grp21.Enabled = grp12.Enabled = grp22.Enabled = btnImageLoad.Enabled =
                            btnImageSave.Enabled = btnReflectionAdd.Enabled =
                                btnReflector.Enabled = chkAnyNames.Enabled = btnClearReflection.Enabled = grpNeuron.Enabled = value;
        }

        void FrmMain_Shown(object sender, EventArgs e)
        {
            try
            {
                VerifyPictureBoxSizes();
                _saveLoad = new SaveLoad();
                for (int y = 0; y < _pcs.GetLength(1); y++)
                    for (int x = 0; x < _pcs.GetLength(0); x++)
                    {
                        _pcs[x, y] = new List<Processor>(_saveLoad.GetProcessors(x, y));
                        if (!VerifyMapsImageSizes(_pcs[x, y]))
                        {
                            Application.Exit();
                            return;
                        }
                        PrevButton(x, y);
                    }
                string main = Path.Combine(Application.StartupPath, "main.bmp");
                if (!File.Exists(main))
                    return;
                using (FileStream fs = new FileStream(main, FileMode.Open, FileAccess.Read, FileShare.Read))
                    _reflectionPainter.CurrentBitmap = new Bitmap(fs);
                if (!VerifyMainImageSize(_reflectionPainter.CurrentBitmap))
                    Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $@"{ex.Message} Программа будет закрыта.", @"Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        void chkAnyNames_CheckedChanged(object sender, EventArgs e)
        {
            bool ch = ((CheckBox)sender).Checked;
            for (int y = 0; y < 3; y++)
                for (int x = 0; x < 3; x++)
                    GetTextBox(x, y).MaxLength = ch ? 32767 : 1;
        }

        void VerifyPictureBoxSizes()
        {
            Size main = pic00.Size;
            if (pic00.Size != main || pic10.Size != main || pic20.Size != main ||
                pic01.Size != main || pic11.Size != main || pic21.Size != main ||
                pic02.Size != main || pic12.Size != main || pic22.Size != main)
                throw new Exception("Обнаружены поля рисования различных размеров.");
            if (picReflection.Width % main.Width != 0)
                throw new Exception("Ширина основного поля должна быть кратна ширине всех полей для рисования.");
            if (picReflection.Height % main.Height != 0)
                throw new Exception("Высота основного поля должна быть кратна высоте всех полей для рисования.");
        }

        TextBox GetTextBox(int x, int y)
        {
            foreach (Control c in from Control c in grpQuery.Controls where c.GetType() == typeof(TextBox) select c)
            {
                if (!GetControlCoords(out int px, out int py, c.Name, "txt"))
                    continue;
                if (px != x || py != y)
                    continue;
                return (TextBox)c;
            }
            throw new Exception($"Требуемый {nameof(TextBox)} почему-то отсутствует на поле ({x}, {y}).");
        }

        string GetCurrentName(int x, int y)
        {
            string pName = GetTextBox(x, y).Text;
            if (string.IsNullOrWhiteSpace(pName))
                throw new ArgumentException($@"Название карты в соответствующем поле ({x}, {y}) не указано.");
            if (pName.Length <= 0)
                throw new ArgumentException(
                    $"Название карты должно быть указано в соответствующем поле ({x}, {y}) \"запроса\" и его длина может быть равна только одному символу.");
            return pName;
        }

        static string GetImagePath(string name) => Path.Combine(Application.StartupPath, $@"{name}.bmp");

        bool SaveImage(int x, int y, bool test = false)
        {
            string mapName = GetCurrentName(x, y);
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
            Painter p = _reflectorPainters[x, y];
            _saveLoad.Save(x, y, path, p.CurrentBitmap);
            p.CurrentProcessorName = mapName;
            _pcs[x, y].Add(p.CurrentProcessor);
            _imageCounter[x, y] = _pcs[x, y].Count - 1;
            DisplayCountMapsOnControl(x, y, _pcs[x, y].Count - 1);
            return true;
        }

        void DeleteImage(int x, int y)
        {
            string mapName = GetCurrentName(x, y);
            _saveLoad.Delete(x, y, GetImagePath(mapName));
            List<Processor> proc = _pcs[x, y];
            for (int k = 0; k < proc.Count; k++)
                if (proc[k].Tag == mapName)
                    proc.RemoveAt(k);
            PrevButton(x, y);
        }

        bool GetControlCoords(out int x, out int y, string name, string startsWith)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name), @"Имя элемента управления неизвестно.");
            if (string.IsNullOrWhiteSpace(startsWith))
                throw new ArgumentNullException(nameof(startsWith), @"Начало имени отсутствует.");
            if (!name.StartsWith(startsWith))
            {
                x = -1;
                y = -1;
                return false;
            }
            if (!int.TryParse(name.Substring(startsWith.Length, 1), out x))
                throw new Exception("Не могу получить координату X.");
            if (!int.TryParse(name.Substring(startsWith.Length + 1, 1), out y))
                throw new Exception("Не могу получить координату Y.");
            return true;
        }

        void PicMouseMoveDown(object sender, MouseEventArgs e)
        {
            if (!GetControlCoords(out int x, out int y, ((PictureBox)sender).Name, "pic"))
                return;
            // ReSharper disable once SwitchStatementMissingSomeCases
            switch (e.Button)
            {
                case MouseButtons.Left:
                    _reflectorPainters[x, y].DrawPointBlack(e.X, e.Y);
                    break;
                case MouseButtons.Right:
                    _reflectorPainters[x, y].DrawPointWhite(e.X, e.Y);
                    break;
            }
        }

        char[,] GetCurrentQuery()
        {
            char[,] ch = new char[3, 3];
            for (int y = 0; y < 3; y++)
                for (int x = 0; x < 3; x++)
                {
                    string s = GetTextBox(x, y).Text;
                    if (s.Length != 1)
                    {
                        MessageBox.Show($@"В клетке {x}, {y} должен присутствовать запрос из одной буквы или цифры.");
                        return null;
                    }
                    ch[x, y] = s[0];
                }
            return ch;
        }

        void btnClearReflection_Click(object sender, EventArgs e)
        {
            _reflectionPainter.Clear();
        }

        void btnReflectionAdd_Click(object sender, EventArgs e)
        {
            try
            {
                _reflectionPainter.CurrentProcessorName = "main";
                Bitmap[] btms = ImageSplit(_reflectionPainter.CurrentProcessor, pic00.Width, pic00.Height).ToArray();
                if (btms.Length != 9)
                {
                    MessageBox.Show(this, $@"Количество карт неверное ({btms.Length}). Должно быть 9.");
                    return;
                }
                for (int y = 0; y < 3; y++)
                    for (int x = 0; x < 3; x++)
                    {
                        if (SaveImage(x, y, true))
                            continue;
                        MessageBox.Show(this,
                            $@"Файл ({x}, {y}) невозможно сохранить, т.к. он уже существует. Задайте другое имя.",
                            @"Файл уже существует.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                for (int y = 0, px = 0; y < 3; y++)
                    for (int x = 0; x < 3; x++)
                    {
                        _reflectorPainters[x, y].CurrentProcessor = new Processor(btms[px++], GetCurrentName(x, y));
                        SaveImage(x, y);
                        NextButton(x, y, true);
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
            btnNextResult_Click(btnNextResult, new EventArgs());
            btnPrevResult.Enabled = btnNextResult.Enabled = btnSaveResultImage.Enabled = false;
        }

        void btnReflection_Click(object sender, EventArgs e)
        {
            SafetyExecute(() =>
            {
                if (_workThread?.IsAlive ?? false)
                    return;
                ResetResults();
                EnableButtons = false;
                _workThread = new Thread(() => SafetyExecute(() =>
                    {
                        WaitableTimer(btnReflection);
                        if (_reflection == null)
                            _reflection = new Reflection(Containers);
                        InvokeFunction(() =>
                        {
                            txtReflectionMapWidth.Text = _reflection.MapWidth.ToString();
                            txtReflectionMapHeight.Text = _reflection.MapHeight.ToString();
                        });
                        _reflectionPainter.CurrentProcessorName = "main";
                        Processor[] prs = _reflection.Push(_reflectionPainter.CurrentProcessor)?.ToArray();
                        if (prs == null)
                        {
                            InvokeFunction(() => MessageBox.Show(this, $@"{nameof(Reflection)}: Результатов нет.",
                                @"Результат", MessageBoxButtons.OK, MessageBoxIcon.Information));
                            return;
                        }
                        if (prs.Length <= 0)
                        {
                            InvokeFunction(() => MessageBox.Show(this, @"Ошибка! Результатов нет!", @"Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error));
                            return;
                        }
                        _recognizeResults = new Bitmap[prs.Length];
                        for (int k = 0; k < prs.Length; k++)
                        {
                            Processor p = prs[k];
                            Bitmap btm = new Bitmap(p.Width, p.Height);
                            for (int y = 0; y < p.Height; y++)
                                for (int x = 0; x < p.Width; x++)
                                    btm.SetPixel(x, y, p[x, y].ValueColor);
                            _recognizeResults[k] = btm;
                        }
                        InvokeFunction(() =>
                        {
                            btnSaveResultImage.Enabled = true;
                            btnPrevResult.Enabled = btnNextResult.Enabled = _recognizeResults.Length > 1;
                            btnPrevResult_Click(btnPrevResult, new EventArgs());
                        });
                    }))
                { IsBackground = true, Name = nameof(Reflection), Priority = ThreadPriority.Highest };
                _workThread.Start();
            });
        }

        void btnReflector_Click(object sender, EventArgs e)
        {
            SafetyExecute(() =>
            {
                if (_workThread?.IsAlive ?? false)
                    return;
                ResetResults();
                if (_reflector == null)
                    _reflector = new Reflector(Containers);
                txtReflectorMapWidth.Text = _reflector.MapWidth.ToString();
                txtReflectorMapHeight.Text = _reflector.MapHeight.ToString();
                txtReflectorProcessorWidth.Text = _reflector.ProcessorWidth.ToString();
                txtReflectorProcessorHeight.Text = _reflector.ProcessorHeight.ToString();
                _reflectionPainter.CurrentProcessorName = "main";
                char[,] ch = GetCurrentQuery();
                if (ch == null)
                    return;
                _stopwatch.Restart();
                Processor p;
                try
                {
                    p = _reflector.Push(_reflectionPainter.CurrentProcessor, ch);
                }
                finally
                {
                    _stopwatch.Stop();
                }
                btnReflector.Text =
                    $@"{_stopwatch.Elapsed.Hours:00}:{_stopwatch.Elapsed.Minutes:00}:{_stopwatch.Elapsed.Seconds:00}:{
                            _stopwatch.Elapsed.Milliseconds:000}";
                if (p == null)
                {
                    MessageBox.Show(this, $@"{nameof(Reflector)}: Результатов нет.", @"Результат", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }
                _recognizeResults = new Bitmap[1];
                Bitmap btm = new Bitmap(p.Width, p.Height);
                for (int y = 0; y < btm.Height; y++)
                    for (int x = 0; x < btm.Width; x++)
                        btm.SetPixel(x, y, p[x, y].ValueColor);
                _recognizeResults[0] = btm;
                btnSaveResultImage.Enabled = true;
                btnPrevResult.Enabled = btnNextResult.Enabled = false;
                btnPrevResult_Click(btnPrevResult, new EventArgs());
            });
        }

        void btnImageLoad_Click(object sender, EventArgs e)
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
                _reflectionPainter.CurrentBitmap = b;
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
            if (b.Width != picReflection.Width)
            {
                MessageBox.Show(this,
                    $@"Главное загружаемое изображение не соответствует по ширине ({b.Width} != {picReflection.Width}).");
                return false;
            }
            if (b.Height == picReflection.Height)
                return true;
            MessageBox.Show(this,
                $@"Главное загружаемое изображение не соответствует по высоте ({b.Height} != {picReflection.Height}).");
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
                if (b.Width != pic00.Width)
                {
                    MessageBox.Show(this,
                        $@"Загружаемое изображение ({b.Tag}) не соответствует по ширине ({b.Width} != {pic00.Width}).");
                    return false;
                }
                if (b.Height == pic00.Height)
                    continue;
                MessageBox.Show(this,
                    $@"Загружаемое изображение ({b.Tag}) не соответствует по высоте ({b.Height} != {pic00.Height}).");
                return false;
            }
            return true;
        }

        void btnImageSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (SaveFile.ShowDialog(this) != DialogResult.OK)
                    return;
                _reflectionPainter.CurrentBitmap.Save(SaveFile.FileName, ImageFormat.Bmp);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, @"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void btnSaveResultImage_Click(object sender, EventArgs e)
        {
            try
            {
                if (_recognizeResults == null || SaveFile.ShowDialog(this) != DialogResult.OK)
                    return;
                Bitmap btm = _recognizeResults[_currentResult];
                if (btm == null)
                    return;
                btm.Save(SaveFile.FileName, ImageFormat.Bmp);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, @"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void btnNextResult_Click(object sender, EventArgs e)
        {
            try
            {
                if (_recognizeResults == null)
                {
                    picResult.Image = null;
                    grpResult.Text = _resultString;
                    return;
                }
                if (_currentResult < _recognizeResults.Length - 1)
                    _currentResult++;
                else
                    _currentResult = 0;
                picResult.Image = _recognizeResults[_currentResult];
                PrintResultComment();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, @"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void btnPrevResult_Click(object sender, EventArgs e)
        {
            try
            {
                if (_recognizeResults == null)
                {
                    picResult.Image = null;
                    grpResult.Text = _resultString;
                    return;
                }
                if (_currentResult > 0)
                    _currentResult--;
                else
                    _currentResult = _recognizeResults.Length - 1;
                picResult.Image = _recognizeResults[_currentResult];
                PrintResultComment();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, @"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void PrintResultComment() => grpResult.Text =
            $@"{_resultString} ({_recognizeResults.Length}) - {(CompareWithResult ? "Совпадает" : "Различается")} [{
                    _currentResult + 1
                }]";

        void NextButton(int x, int y, bool toEnd)
        {
            try
            {
                int count = _pcs[x, y].Count;
                int index = toEnd ? count : _imageCounter[x, y] += 1;
                if (index >= count)
                {
                    _imageCounter[x, y] = count > 0 ? count - 1 : 0;
                    index = _imageCounter[x, y];
                }
                List<Processor> lst = _pcs[x, y];
                if (lst.Count <= 0)
                    return;
                Processor p = lst[index];
                DisplayCountMapsOnControl(x, y, index);
                _reflectorPainters[x, y].CurrentProcessor = p;
                GetTextBox(x, y).Text = p.Tag;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, @"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void PrevButton(int x, int y)
        {
            try
            {
                int index = _imageCounter[x, y] -= 1;
                if (index < 0)
                {
                    _imageCounter[x, y] = 0;
                    index = 0;
                }
                List<Processor> lst = _pcs[x, y];
                if (lst.Count <= 0)
                {
                    _imageCounter[x, y] = 0;
                    DisplayCountMapsOnControl(x, y);
                    return;
                }
                Processor p = lst[index];
                DisplayCountMapsOnControl(x, y, index);
                _reflectorPainters[x, y].CurrentProcessor = p;
                GetTextBox(x, y).Text = p.Tag;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, @"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void PrevNextButtonClick(object sender, EventArgs e)
        {
            try
            {
                string name = ((Button)sender).Name;
                if (!GetControlCoords(out int x, out int y, name, "btnNext"))
                    if (GetControlCoords(out x, out y, name, "btnPrev"))
                        PrevButton(x, y);
                    else
                        throw new Exception("Нажата неизвестная кнопка.");
                else
                    NextButton(x, y, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, @"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void OkButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (!GetControlCoords(out int x, out int y, ((Button)sender).Name, "btnOK"))
                    return;
                if (!SaveImage(x, y))
                    return;
                _reflection = null;
                _reflector = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, @"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void DelButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (!GetControlCoords(out int x, out int y, ((Button)sender).Name, "btnDel"))
                    return;
                DeleteImage(x, y);
                _reflection = null;
                _reflector = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, @"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                if (!GetControlCoords(out int x, out int y, ((Button)sender).Name, "btnClear"))
                    return;
                _reflectorPainters[x, y].Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, @"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void DisplayCountMapsOnControl(int x, int y, int index = -1)
        {
            string sname = $"grp{x}{y}";
            Control[] grpBox = (from Control c in grpReflectorNeuron.Controls
                                where c.GetType() == typeof(GroupBox)
                                where c.Name == sname
                                select c).ToArray();
            if (grpBox.Length != 1)
                throw new Exception(
                    $"Найдены {nameof(GroupBox)} с одинаковыми именами или требуемый элемент отсутствует.");
            grpBox[0].Text = index < 0 ? _strings[x, y] : $@"{_strings[x, y]} ({_pcs[x, y].Count}) [{index + 1}]";
        }

        void picReflection_MouseMoveDown(object sender, MouseEventArgs e)
        {
            // ReSharper disable once SwitchStatementMissingSomeCases
            switch (e.Button)
            {
                case MouseButtons.Left:
                    _reflectionPainter.DrawPointBlack(e.X, e.Y);
                    break;
                case MouseButtons.Right:
                    _reflectionPainter.DrawPointWhite(e.X, e.Y);
                    break;
            }
        }

        void txt_TextChanged(object sender, EventArgs e)
        {
            if (_txtInProcessing)
                return;
            _txtInProcessing = true;
            TextBox tb = (TextBox)sender;
            int selectionStart = tb.SelectionStart;
            tb.Text = tb.Text.ToUpper();
            tb.SelectionStart = selectionStart;
            _txtInProcessing = false;
        }

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
                    if (lstNeurons.SelectedIndex < 1)
                        return;
                    _neurons.RemoveAt(lstNeurons.SelectedIndex - 1);
                    lstNeurons.Items.RemoveAt(lstNeurons.SelectedIndex);
                    return;
            }
        }

        void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Escape || (Keys)e.KeyChar == Keys.Enter || (Keys)e.KeyChar == Keys.Tab ||
                (Keys)e.KeyChar == Keys.Pause || (Keys)e.KeyChar == Keys.XButton1 || e.KeyChar == 15)
            {
                e.Handled = true;
                return;
            }
            if (chkAnyNames.Checked)
                return;
            ((TextBox)sender).Text = string.Empty;
        }

        void WaitableTimer(Control btnWriteText)
        {
            new Thread(() => SafetyExecute(() =>
            {
                _stopwatch.Restart();
                try
                {
                    while (true)
                    {
                        InvokeFunction(() =>
                            btnWriteText.Text =
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
        /// <param name="catchAction">Функция, которая должна быть выполнена в блоке catch.</param>
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
        ///     Представляет обёртку для выполнения функций с применением блоков try-catch, а также выдачей сообщений обо всех
        ///     ошибках.
        /// </summary>
        /// <param name="funcAction">Функция, которая должна быть выполнена.</param>
        /// <param name="finallyAction">Функция, которая должна быть выполнена в блоке finally.</param>
        /// <param name="catchAction">Функция, которая должна быть выполнена в блоке catch.</param>
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

        Neuron CurrentNeuron
        {
            get
            {
                IEnumerable<Processor> GetProcessors()
                {
                    for (int y = 0; y < 3; y++)
                        for (int x = 0; x < 3; x++)
                        {
                            Painter p = _reflectorPainters[x, y];
                            p.CurrentProcessorName = GetCurrentName(x, y);
                            yield return p.CurrentProcessor;
                        }
                }

                return new Neuron(new ProcessorContainer(GetProcessors().ToArray()));
            }
        }

        IEnumerable<(Processor, string)> NeuronQuery
        {
            get
            {
                IEnumerable<(Processor, string)> GetQuery()
                {
                    for (int y = 0; y < 3; y++)
                        for (int x = 0; x < 3; x++)
                        {
                            Painter p = _reflectorPainters[x, y];
                            p.CurrentProcessorName = GetCurrentName(x, y);
                            yield return (p.CurrentProcessor, p.CurrentProcessorName[0].ToString());
                        }
                }

                return GetQuery();
            }
        }

        void BtnFindRelation_Click(object sender, EventArgs e) => SafetyExecute(() =>
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
                WaitableTimer((Control)sender);

                int selIndex = -1;
                InvokeFunction(() => selIndex = lstNeurons.SelectedIndex - 1);

                if (selIndex < 0)
                {
                    Neuron n = CurrentNeuron;
                    InvokeFunction(() =>
                    {
                        _neurons.Insert(0, n);
                        lstNeurons.Items.Insert(1, $@"({n.Count}) {DateTime.Now:HH:mm:ss}");
                        lstNeurons.SetItemCheckState(1, CheckState.Indeterminate);
                        lstNeurons.SelectedIndex = 1;
                        txtNeuronString.Text = n.ToString();
                    });
                    return;
                }

                Neuron workNeuron = _neurons[selIndex];
                Neuron neuron = workNeuron.FindRelation(NeuronQuery);

                if (neuron == null)
                {
                    InvokeFunction(() => MessageBox.Show(this, $@"{nameof(Neuron)} не создался.",
                        @"Результат", MessageBoxButtons.OK, MessageBoxIcon.Information));
                    return;
                }

                if (neuron.Count != workNeuron.Count)
                {
                    InvokeFunction(() => MessageBox.Show(this, $@"{nameof(Neuron)}: Количество карт различается в порождённом {nameof(Neuron)
                            } ({neuron.Count}) и базовом (родительском) {nameof(Neuron)} ({workNeuron.Count}).",
                        @"Результат", MessageBoxButtons.OK, MessageBoxIcon.Information));
                    return;
                }

                InvokeFunction(() =>
                {
                    _neurons.Insert(0, neuron);
                    lstNeurons.Items.Insert(1, $@"({_neurons.Count}) {DateTime.Now:HH:mm:ss}");
                    lstNeurons.SetItemCheckState(1, CheckState.Indeterminate);
                    lstNeurons.SelectedIndex = 1;
                    txtNeuronString.Text = neuron.ToString();
                });

                for (int y = 0, j = 0; y < 3; y++)
                    for (int x = 0; x < 3; x++, j++)
                    {
                        Processor p = neuron[j];
                        _reflectorPainters[x, y].CurrentProcessor = p;
                        GetTextBox(x, y).Text = p.Tag;
                    }

                InvokeFunction(() =>
                {
                    btnSaveResultImage.Enabled = true;
                    btnPrevResult.Enabled = btnNextResult.Enabled = _recognizeResults.Length > 1;
                    btnPrevResult_Click(btnPrevResult, new EventArgs());
                });
            }))
            { IsBackground = true, Name = nameof(Reflection), Priority = ThreadPriority.Highest };
            _workThread.Start();
        });

        void BtnCheckRelation_Click(object sender, EventArgs e) => SafetyExecute(() =>
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
                WaitableTimer((Control)sender);

                int selIndex = -1;
                InvokeFunction(() => selIndex = lstNeurons.SelectedIndex - 1);

                if (selIndex < 0)
                {
                    Neuron n = CurrentNeuron;
                    InvokeFunction(() =>
                    {
                        _neurons.Insert(0, n);
                        lstNeurons.Items.Insert(1, $@"({n.Count}) {DateTime.Now:HH:mm:ss}");
                        lstNeurons.SetItemCheckState(1, CheckState.Indeterminate);
                        lstNeurons.SelectedIndex = 1;
                        txtNeuronString.Text = n.ToString();
                    });
                    return;
                }

                bool result = true; //_neurons[selIndex].CheckRelation(NeuronQuery);

                InvokeFunction(() =>
                {
                    lstNeurons.SetItemChecked(selIndex + 1, result);
                    btnSaveResultImage.Enabled = true;
                    btnPrevResult.Enabled = btnNextResult.Enabled = _recognizeResults.Length > 1;
                    btnPrevResult_Click(btnPrevResult, new EventArgs());
                });
            }))
            {
                IsBackground = true,
                Name = nameof(Reflection),
                Priority = ThreadPriority.Highest
            };
            _workThread.Start();
        });

        void LstNeurons_DoubleClick(object sender, EventArgs e) => SafetyExecute(() => lstNeurons.SetItemCheckState(lstNeurons.SelectedIndex, lstNeurons.GetItemCheckState(lstNeurons.SelectedIndex)));

        void LstNeurons_SelectedIndexChanged(object sender, EventArgs e) => lstNeurons.SetItemCheckState(lstNeurons.SelectedIndex, lstNeurons.GetItemCheckState(lstNeurons.SelectedIndex));

        /*if (chkboxlist.SelectedItem!=null) //КАК ВАРИАНТ
{chkboxlist.SelectedItem.Enabled = false;}*/

        // ИЛИ

        /*private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e) {
        if (e.Index == 0) e.NewValue = e.CurrentValue;
    }
        
         ИЛИ

        checkedListBox1.SetItemCheckState(0, CheckState.Indeterminate);

        ИЛИ

        _myCheckedListBox.ItemChecking += (s, e) => e.Cancel = true;

         */

    }
}