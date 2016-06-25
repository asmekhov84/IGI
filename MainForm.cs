using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace IGI
{
    public enum ReadDir { rdRows = 0, rdCols = 1 }; // направление чтения данных
    public enum InterpMethod { imLinear = 0, imQuadratic = 1}; // метод интерполяции
    public enum ColorMode { cmOneColor, cmColorByValue, cmColorByDer, cmColorByDerX, cmColorByDerY } // метод окрашивания поверхности

    // структура с данными для отрисовки поверхности
    public struct Plot
    {
        public const float AXIS_LEN = 1000; // длина координатных осей
        public bool isGLLoaded; // флаг завершения инициализации библиотеки OpenGL
        public Vector3 CS0; // положение начала координат локальной СК в мировой СК
        public Vector3 scale; // масштабные коэффициенты по осям
        public Point lastMousePos; // последняя сохраненная координата курсора мыши
        public bool isShift, isControl; // флаги удержания клавиш Shift и Control
        public List<Point> selIntPoints; // список выбранных точек интерполированной поверхности
        public List<int> selSrcPoints; // список выбранных точек из исходного набора
        public float dist; // расстояние до объекта
        public double alpha, beta; // положение камеры относительно объекта в сферической системе координат
        public Vector3 target; // положение цели
        public TextRenderer textRenderer; // класс с методами для отображения текста
        public Font fntAxisName, fntAxisCoord, fntPntCoord; // шрифты для отображения текстовой информации
    }

    // структура с данными интерполяции
    public struct Data
    {
        public int srcN; // количество точек в исходном наборе данных для нерегулярной сетки
        public double[,] srcXYZ; // значения аргументов и функции на исходной нерегулярной сетке, Nx3
        public int intNX; // количество значений аргумента X в интерполированном наборе данных
        public int intNY; // количество значений аргумента Y в интерполированном наборе данных
        public double[] intX; // значения аргумента X для интерполяции, X={xi}, i=1..M
        public double[] intY; // значения аргумента Y для интерполяции, Y={yj}, j=1..N
        public double[,] intZ; // интерполированные значения Z (от исходных srcXYZ), Z={zij}, i=1..M, j=1..N
        public double[] int2Z; // интерполированные значения Z (от intZ по исходным аргументам из srcXYZ) - проекции исходных точек на интерполированную поверхность
        public double[,] derZX; // частные производные от интерполированных значений Z по X
        public double[,] derZY; // частные производные от интерполированных значений Z по Y
        public double minDZX, maxDZX, minDZY, maxDZY; // манимальные и максимальные значения производной по X и Y
        public double[] diffs; // процентные отклонения исходных данных от полученных интерполяцией
        public double minIX, maxIX, minIY, maxIY; // область определения интерполированной функции
        public double minIZ, maxIZ; // область значений интерполированной функции
        public int maxPosDiffNum, maxNegDiffNum; // номера точек из исходного набора с максимальным положительным и максимальным отрицательным отклонением от интерполированной поверхности
        public double maxPosDiff, maxNegDiff, avgSqrDiff; // максимальное положительное, отрицательное и ср. квадратичное отклонения исходных данных от интерполированных
        public RectangleF srcDataBoundsRect; // область определения интерполированных значений (прямоугольник)
    }

    public partial class MainForm : Form
    {
        private const string CONFIG_FILE_NAME = ".\\autosave.cfg";
        private Plot plot = new Plot(); // данные для отрисовки поверхности
        private Data data = new Data(); // данные интерполяции

        // инициализация элементов управления формы
        public MainForm()
        {
            InitializeComponent();
            this.Text = "IGI " + Assembly.GetExecutingAssembly().GetName().Version.ToString() + " - Интерполяция функции на нерегулярной сетке";
            cbxIrregReadMode.SelectedIndex = (int)ReadDir.rdCols;
            cbxIrregInterpMethod.SelectedIndex = (int)InterpMethod.imQuadratic;
            if (System.IO.File.Exists(CONFIG_FILE_NAME) == true) LoadConfigData(CONFIG_FILE_NAME);
            plot.selIntPoints = new List<Point>();
            plot.selSrcPoints = new List<int>();
            plot.dist = 0.5f;
            plot.target = new Vector3(Plot.AXIS_LEN / 2.0f, Plot.AXIS_LEN / 2.0f, Plot.AXIS_LEN / 2.0f); // координата цели определяется как центр куба
            chkShowGraph.CheckedChanged += new EventHandler(PlotParamsChanged);
            chkShowSourcePoints.CheckedChanged += new EventHandler(PlotParamsChanged);
            rbtDrawSurface.CheckedChanged += new EventHandler(PlotParamsChanged);
            rbtColorByDer.CheckedChanged += new EventHandler(PlotParamsChanged);
        }

#region обработчики команд элементов управления формы

        // загрузка файла исходных данных
        private void tmiFileLoadSourceData_Click(object sender, EventArgs e)
        {
            ofdOpenFile.Title = "Загрузка файла исходных данных";
            ofdOpenFile.Filter = "Текстовые файлы, CSV|*.txt;*.csv|Все файлы|*.*";
            if (ofdOpenFile.ShowDialog() == System.Windows.Forms.DialogResult.OK) LoadSourceData(ofdOpenFile.FileName);
        }

        // загрузка файла данных осей
        private void tmiFileLoadAxisData_Click(object sender, EventArgs e)
        {
            ofdOpenFile.Title = "Загрузка файла данных осей";
            ofdOpenFile.Filter = "Текстовые файлы, CSV|*.txt;*.csv|Все файлы|*.*";
            if (ofdOpenFile.ShowDialog() == System.Windows.Forms.DialogResult.OK) LoadAxisData(ofdOpenFile.FileName);
        }
        
        // загрузка файла конфигурации
        private void tmiFileLoadConfigData_Click(object sender, EventArgs e)
        {
            ofdOpenFile.Title = "Загрузка файла параметров расчета";
            ofdOpenFile.Filter = "Файлы конфигурации (CFG)|*.cfg";
            if (ofdOpenFile.ShowDialog() == System.Windows.Forms.DialogResult.OK) LoadConfigData(ofdOpenFile.FileName);
        }
        
        // сохранение файла параметров расчета
        private void tmiFileSaveConfigData_Click(object sender, EventArgs e)
        {
            sfdSaveFile.Title = "Сохранение файла параметров расчета";
            sfdSaveFile.Filter = "Файлы конфигурации (CFG)|*.cfg";
            sfdSaveFile.FileName = "config.cfg";
            if (sfdSaveFile.ShowDialog() == System.Windows.Forms.DialogResult.OK) SaveConfigData(sfdSaveFile.FileName);
        }

        // сохранение файла результатов расчета
        private void tmiFileSaveResultsData_Click(object sender, EventArgs e)
        {
            sfdSaveFile.Title = "Сохранение файла результатов расчета";
            sfdSaveFile.Filter = "Текстовые файлы, CSV|*.txt;*.csv|Все файлы|*.*";
            sfdSaveFile.FileName = "results.txt";
            if (sfdSaveFile.ShowDialog() == System.Windows.Forms.DialogResult.OK) SaveResultsData(sfdSaveFile.FileName);
        }

        // завершение работы приложения
        private void tmiFileExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // открытие файла справки
        private void tmiHelpOpenFile_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(".\\help.txt") == true) System.Windows.Forms.Help.ShowHelp(null, ".\\help.txt");
            else MessageBox.Show("Файл справки не найден.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        // открытие диалога "О программе"
        private void tmiHelpAbout_Click(object sender, EventArgs e)
        {
            AboutBox dlgAbout = new AboutBox();
            dlgAbout.ShowDialog();
        }

        // вызывается при изменении направления чтения нерегулярного набора исходных данных
        private void cbxReadMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxIrregReadMode.SelectedIndex == 0)
            {
                lblIrregSkipWhat.Text = "столбцов";
                gbxIrregDataPosition.Text = "Номера строк";
            }
            else
            {
                lblIrregSkipWhat.Text = "строк";
                gbxIrregDataPosition.Text = "Номера столбцов";
            }
        }

        // вызывается при изменении направления чтения регулярного набора исходных данных
        private void IrregReadDirChange(object sender, EventArgs e)
        {
            if (rbtRegXRow.Checked == true)
            {
                lblRegXPos.Text = "номер строки";
                grpRegXRange.Text = "диапазон столбцов";
            }
            else
            {
                lblRegXPos.Text = "номер столбца";
                grpRegXRange.Text = "диапазон строк";
            }
            if (rbtRegYRow.Checked == true)
            {
                lblRegYPos.Text = "номер строки";
                grpRegYRange.Text = "диапазон столбцов";
            }
            else
            {
                lblRegYPos.Text = "номер столбца";
                grpRegYRange.Text = "диапазон строк";
            }
        }

        // функция проверяет корректность введенных исходных данных, записывает их в структуру data и выполеняет расчет
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            bool ok = false;
            EraseData();
            // исходные данные считываются в зависимости от выбранного типа сетки
            if (tctGridType.SelectedIndex == 0) ok = ReadSourceIrregularData(); // выбрана нерегулярная сетка
            else ok = ReadSourceRegularData(); // выбрана регулярная сетка
            if (!ok)
            {
                EraseData();
                return;
            }
            ok = ReadAxisData();
            if (!ok)
            {
                EraseData();
                return;
            }
            // вызов функции интерполяции
            DoInterpolate();
            glControl.Invalidate();
            tblResults.RowCount = data.intNX;
            tblResults.ColumnCount = data.intNY;
        }

        // вызывается при переключении вкладки
        private void tctMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tctMain.SelectedIndex == 2) // выбрана вкладка с таблицей результатов
            {
                if (data.intX == null || data.intY == null || data.intZ == null) return;
                if (data.intNX * data.intNY > 1000)
                {
                    if (MessageBox.Show("Количество элементов в таблице результатов очень велико. На их отображение может потребоваться много времени, в течение которого вы не сможете взаимодействовать с приложением. Показать таблицу результатов?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }
                }
                int p;
                tblResults.Hide();
                pbrResultsTableProgress.Show();
                // вывод результатов
                for (int i = 0; i < data.intNX; i++)
                {
                    for (int j = 0; j < data.intNY; j++)
                    {
                        tblResults.Rows[i].HeaderCell.Value = data.intX[i].ToString();
                        tblResults.Columns[j].HeaderCell.Value = data.intY[j].ToString();
                        tblResults.Rows[i].Cells[j].Value = data.intZ[i, j];
                        p = (int)((double)(i * data.intNY + j + 1) / (double)(data.intNX * data.intNY) * 100.0);
                        pbrResultsTableProgress.Value = p;
                        Application.DoEvents();
                    }
                }
                tblResults.Show();
                pbrResultsTableProgress.Hide();
            }
        }

        // вызывается при изменении содержимого таблицы
        private void tblResults_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex, j = e.ColumnIndex;
            if (i < 0 || j < 0 || i > tblResults.RowCount - 1 || j > tblResults.ColumnCount - 1) return;
            string str = tblResults.Rows[i].Cells[j].Value.ToString();
            double val = 0;
            try
            {
                val = Convert.ToDouble(str);
            }
            catch (Exception)
            {
                return;
            }
            data.intZ[i, j] = val;
            // пересчет отклонений интерполированных точек от исходных
            UpdateInterpData();
        }

        // функция вызывается в момент закрытия формы
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (System.IO.File.Exists(tbxSrcDataFilePath.Text) && System.IO.File.Exists(tbxAxisFileName.Text))
                SaveConfigData(CONFIG_FILE_NAME);
        }

        // функция вызывается при изменении параметров интерполяции
        private void InterpParamsChanged(object sender, EventArgs e)
        {
            if (chkAutoUpdate.Checked == true)
            {
                DoInterpolate();
                glControl.Refresh();
            }
        }

        // функция вызывается при изменении параметров отрисовки
        private void DrawingParamsChanged(object sender, EventArgs e)
        {
            glControl.Refresh();
        }

        // функция вызывается при выборе рисования сетки либо поверхности
        private void PlotParamsChanged(object sender, EventArgs e)
        {
            if (chkShowSourcePoints.Checked == false)
            {
                chkShowHiddenPoints.Checked = false;
                chkShowHiddenPoints.Enabled = false;
            }
            else chkShowHiddenPoints.Enabled = true;
            if (!(chkShowSourcePoints.Checked && chkShowGraph.Checked))
            {
                chkShowPointsProjections.Checked = false;
                chkShowPointsProjections.Enabled = false;
            }
            else chkShowPointsProjections.Enabled = true;
            if (rbtDrawSurface.Checked && rbtColorByDer.Checked)
            {
                pnlColorByDerType.Enabled = true;
                rbtColorByDerX.Checked = true;
            }
            else
            {
                pnlColorByDerType.Enabled = false;
                rbtColorByDerX.Checked = false;
            }
        }

        // функция изменяет значения для выбранных узлов интерполированной сетки
        private void glControl_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == '+' || e.KeyChar == '-')
            {
                if (data.intZ == null) return;
                double delta, perc;
                if (e.KeyChar == '+')
                {
                    if (plot.isShift) perc = 0.05;
                    else perc = 0.01;
                }
                else
                {
                    if (plot.isShift) perc = -0.05;
                    else perc = -0.01;
                }
                delta = (data.maxIZ - data.minIZ) * perc;
                foreach (Point pnt in plot.selIntPoints) data.intZ[pnt.X, pnt.Y] += delta;
                // пересчет отклонений интерполированных точек от исходных
                UpdateInterpData();
            }
            // принудительная перерисовка поверхности
            glControl.Refresh();
        }

        // функция удаляет выбранные точки из исходного набора данных и производит повторную интерполяцию
        private void glControl_KeyDown(object sender, KeyEventArgs e)
        {
            plot.isShift = e.Shift;
            plot.isControl = e.Control;
            if (e.KeyCode == Keys.Delete)
            {
                if (data.srcXYZ == null) return;
                double[,] tmp = new double[data.srcN, 3];
                for (int i = 0; i < data.srcN; i++)
                {
                    tmp[i, 0] = data.srcXYZ[i, 0];
                    tmp[i, 1] = data.srcXYZ[i, 1];
                    tmp[i, 2] = data.srcXYZ[i, 2];
                }
                plot.selSrcPoints.Sort();
                int remCnt = 0; // количество удаленных точек
                foreach (int pnt in plot.selSrcPoints)
                {
                    for (int i = pnt - remCnt; i < data.srcN - 1; i++)
                    {
                        tmp[i, 0] = tmp[i + 1, 0];
                        tmp[i, 1] = tmp[i + 1, 1];
                        tmp[i, 2] = tmp[i + 1, 2];
                    }
                    data.srcN--;
                    remCnt++;
                }
                plot.selSrcPoints.Clear();
                data.srcXYZ = null;
                data.srcXYZ = new double[data.srcN, 3];
                for (int i = 0; i < data.srcN; i++)
                {
                    data.srcXYZ[i, 0] = tmp[i, 0];
                    data.srcXYZ[i, 1] = tmp[i, 1];
                    data.srcXYZ[i, 2] = tmp[i, 2];
                }
                DoInterpolate();
            }
            if (e.KeyCode == Keys.Escape)
            {
                plot.selIntPoints.Clear();
                plot.selSrcPoints.Clear();
            }
            if (e.KeyCode == Keys.NumPad1)
            {
                plot.alpha = 0;
                plot.beta = 0;
                UpdateCameraPosition();
            }
            if (e.KeyCode == Keys.NumPad2)
            {
                plot.alpha = 0;
                plot.beta = MathHelper.PiOver2;
                UpdateCameraPosition();
            }
            if (e.KeyCode == Keys.NumPad3)
            {
                plot.alpha = -MathHelper.PiOver2;
                plot.beta = 0;
                UpdateCameraPosition();
            }
        }

        // функция добавляет выбраные точки в список
        private void glControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != System.Windows.Forms.MouseButtons.Left) return;
            Vector3 wpnt = new Vector3(); // координаты точки в мировой СК
            Point spnt = new Point(); // координаты точки на экране
            if (data.intX != null && data.intY != null && data.intZ != null)
            {
                for (int i = 0; i < data.intNX; i++)
                {
                    wpnt.X = (float)(data.intX[i] - plot.CS0.X) * plot.scale.X * plot.dist;
                    for (int j = 0; j < data.intNY; j++)
                    {
                        wpnt.Y = (float)(data.intY[j] - plot.CS0.Y) * plot.scale.Y * plot.dist;
                        wpnt.Z = (float)(data.intZ[i, j] - plot.CS0.Z) * plot.scale.Z * plot.dist;
                        spnt = WorldToScreenCoordinates(wpnt);
                        if (Math.Sqrt((spnt.X - e.X) * (spnt.X - e.X) + (spnt.Y - e.Y) * (spnt.Y - e.Y)) < 15)
                        {
                            plot.selIntPoints.Add(new Point(i, j));
                            return;
                        }
                    }
                }
            }
            if (data.srcXYZ != null)
            {
                for (int i = 0; i < data.srcN; i++)
                {
                    wpnt.X = (float)data.srcXYZ[i, 0];
                    wpnt.Y = (float)data.srcXYZ[i, 1];
                    if (data.srcDataBoundsRect.Contains(wpnt.X, wpnt.Y) || chkShowHiddenPoints.Checked)
                    {
                        wpnt.Z = (float)data.srcXYZ[i, 2];
                        wpnt = (wpnt - plot.CS0) * plot.scale * plot.dist;
                        spnt = WorldToScreenCoordinates(wpnt);
                        if (Math.Sqrt((spnt.X - e.X) * (spnt.X - e.X) + (spnt.Y - e.Y) * (spnt.Y - e.Y)) < 15)
                        {
                            plot.selSrcPoints.Add(i);
                            return;
                        }
                    }
                }
            }
        }

        private void glControl_MouseMove(object sender, MouseEventArgs e)
        {
            plot.dist += e.Delta * 0.001f;
            plot.dist = Math.Max(0.25f, Math.Min(2.0f, plot.dist));
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (Math.Abs(e.X - plot.lastMousePos.X) > 10)
                {
                    plot.alpha -= Math.Sign(e.X - plot.lastMousePos.X) * 0.1f;
                    plot.lastMousePos.X = e.X;
                }
                if (Math.Abs(e.Y - plot.lastMousePos.Y) > 10)
                {
                    plot.beta -= Math.Sign(e.Y - plot.lastMousePos.Y) * 0.1f;
                    plot.lastMousePos.Y = e.Y;
                }
            }
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                float tx = 0, ty = 0;
                if (Math.Abs(e.X - plot.lastMousePos.X) > 10)
                {
                    tx = Math.Sign(e.X - plot.lastMousePos.X) * 20.0f;
                    plot.lastMousePos.X = e.X;
                }
                if (Math.Abs(e.Y - plot.lastMousePos.Y) > 10)
                {
                    ty = Math.Sign(plot.lastMousePos.Y - e.Y) * 20.0f;
                    plot.lastMousePos.Y = e.Y;
                }
                GL.MatrixMode(MatrixMode.Projection);
                GL.Translate(tx, ty, 0);
            }
            UpdateCameraPosition();
        }

#endregion

#region функции файлового ввода/вывода

        // загрузка файла исходных данных и вывод значений в таблицу
        private bool LoadSourceData(string fileName)
        {
            // создание потока чтения
            System.IO.Stream stream = null;
            try
            {
                stream = System.IO.File.OpenRead(fileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удается загрузить файл исходных данных. " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            // создание экземпляра StreamReader
            System.IO.StreamReader reader = null;
            try
            {
                reader = new System.IO.StreamReader(stream);
            }
            catch (Exception ex)
            {
                if (stream != null) stream.Dispose();
                MessageBox.Show("Не удается загрузить файл исходных данных. " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            // чтение файла данных в список строк
            List<string> lines = new List<string>();
            string str;
            try
            {
                while (!reader.EndOfStream)
                {
                    try
                    {
                        str = reader.ReadLine();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Не удается загрузить файл исходных данных. " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    str = CorrectDecimalSeparators(str); // замена десятичных разделителей на корректные
                    str = TabulateStr(str);
                    lines.Add(str);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удается загрузить файл исходных данных. " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                if (reader != null) reader.Dispose();
                if (stream != null) stream.Dispose();
            }
            // проверка корректности данных и преобразование списка строк в таблицу
            int rowCnt = lines.Count(), colCnt = -1;
            if (rowCnt <= 0)
            {
                MessageBox.Show("Файл не содержит данных.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            string[] splStr;
            string[][] vals = new string[rowCnt][];
            for (int i = 0; i < rowCnt; i++)
            {
                splStr = lines[i].Split('\t'); // разделение строки на массив строк
                if (splStr.Length > colCnt) colCnt = splStr.Length;
                vals[i] = splStr;
            }
            if (colCnt < 3 || rowCnt < 3)
            {
                MessageBox.Show("Файл данных содержит недостаточно элементов для корректной работы программы.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            tblSource.Rows.Clear();
            tblSource.RowCount = rowCnt;
            tblSource.ColumnCount = colCnt;
            for (int i = 0; i < rowCnt; i++)
            {
                tblSource.Rows[i].HeaderCell.Value = System.Convert.ToString(i + 1);
                for (int j = 0; j < colCnt; j++)
                {
                    tblSource.Columns[j].HeaderCell.Value = System.Convert.ToString(j + 1);
                    tblSource.Rows[i].SetValues(vals[i]);
                }
            }
            tbxSrcDataFilePath.Text = fileName;
            return true;
        }

        // загрузка файла осей и вывод значений в двух таблицах
        private bool LoadAxisData(string fileName)
        {
            // создание потока чтения
            System.IO.Stream stream = null;
            try
            {
                stream = System.IO.File.OpenRead(fileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удается загрузить файл осей. " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            // создание экземпляра StreamReader
            System.IO.StreamReader reader = null;
            try
            {
                reader = new System.IO.StreamReader(stream);
            }
            catch (Exception ex)
            {
                if (stream != null) stream.Dispose();
                MessageBox.Show("Не удается загрузить файл осей. " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            // считывание значений осей
            string str1, str2;
            try
            {
                str1 = reader.ReadLine();
                str2 = reader.ReadLine();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удается загрузить файл осей. " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                if (reader != null) reader.Dispose();
                if (stream != null) stream.Dispose();
            }
            // замена десятичных разделитетей на корректные и удаление лишних разделителей
            str1 = CorrectDecimalSeparators(str1);
            str2 = CorrectDecimalSeparators(str2);
            str1 = TabulateStr(str1);
            str2 = TabulateStr(str2);
            // проверка корректности данных
            string[] axis1, axis2;
            axis1 = str1.Split('\t');
            axis2 = str2.Split('\t');
            if (axis1.Length < 1 || axis2.Length < 1)
            {
                MessageBox.Show("Файл не содержит данных или имеет неверный формат.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            // вывод данных в таблицы
            tblXAxis.RowCount = 1;
            tblXAxis.ColumnCount = axis1.Length;
            for (int i = 0; i < tblXAxis.ColumnCount; i++) tblXAxis.Columns[i].HeaderCell.Value = Convert.ToString(i + 1);
            tblXAxis.Rows[0].SetValues(axis1);
            tblYAxis.RowCount = 1;
            tblYAxis.ColumnCount = axis2.Length;
            for (int i = 0; i < tblYAxis.ColumnCount; i++) tblYAxis.Columns[i].HeaderCell.Value = Convert.ToString(i + 1);
            tblYAxis.Rows[0].SetValues(axis2);
            tbxAxisFileName.Text = fileName;
            return true;
        }

        // загрузка файла конфигурации
        private void LoadConfigData(string fileName)
        {
            // создание потока чтения
            System.IO.Stream stream = null;
            try
            {
                stream = System.IO.File.OpenRead(fileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удается загрузить файл конфигурации. " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // создание экземпляра класса StreamReader
            System.IO.StreamReader reader = null;
            try
            {
                reader = new System.IO.StreamReader(stream);
            }
            catch (Exception ex)
            {
                if (stream != null) stream.Dispose();
                MessageBox.Show("Не удается загрузить файл конфигурации. " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // чтение параметров из файла конфигурации
            string srcDataFileName, axisDataFileName, s;
            ReadDir readDir;
            InterpMethod intMethod;
            decimal skipCount, posX, posY, posZ, regXPos, regXRangeA, regXRangeB,
                regYPos, regYRangeA, regYRangeB, regZRowA, regZRowB, regZColA, regZColB;
            int gridType;
            bool regXRow, regYRow;
            try
            {
                srcDataFileName = reader.ReadLine();
                axisDataFileName = reader.ReadLine();
                s = reader.ReadLine();
                gridType = Convert.ToInt16(s);
                if (gridType == 0)
                {
                    s = reader.ReadLine();
                    readDir = (ReadDir)Convert.ToInt16(s);
                    s = reader.ReadLine();
                    skipCount = Convert.ToInt16(s);
                    s = reader.ReadLine();
                    posX = Convert.ToInt16(s);
                    s = reader.ReadLine();
                    posY = Convert.ToInt16(s);
                    s = reader.ReadLine();
                    posZ = Convert.ToInt16(s);
                    s = reader.ReadLine();
                    intMethod = (InterpMethod)Convert.ToInt16(s);
                    tctGridType.SelectedIndex = gridType;
                    cbxIrregReadMode.SelectedIndex = (int)readDir;
                    nudIrregSkipCount.Value = skipCount;
                    nudIrregXPos.Value = posX;
                    nudIrregYPos.Value = posY;
                    nudIrregZPos.Value = posZ;
                    cbxIrregInterpMethod.SelectedIndex = (int)intMethod;
                }
                else
                {
                    s = reader.ReadLine();
                    regXRow = Convert.ToBoolean(s);
                    s = reader.ReadLine();
                    regXPos = Convert.ToInt16(s);
                    s = reader.ReadLine();
                    regXRangeA = Convert.ToInt16(s);
                    s = reader.ReadLine();
                    regXRangeB = Convert.ToInt16(s);
                    s = reader.ReadLine();
                    regYRow = Convert.ToBoolean(s);
                    s = reader.ReadLine();
                    regYPos = Convert.ToInt16(s);
                    s = reader.ReadLine();
                    regYRangeA = Convert.ToInt16(s);
                    s = reader.ReadLine();
                    regYRangeB = Convert.ToInt16(s);
                    s = reader.ReadLine();
                    regZRowA = Convert.ToInt16(s);
                    s = reader.ReadLine();
                    regZRowB = Convert.ToInt16(s);
                    s = reader.ReadLine();
                    regZColA = Convert.ToInt16(s);
                    s = reader.ReadLine();
                    regZColB = Convert.ToInt16(s);
                    s = reader.ReadLine();
                    tctGridType.SelectedIndex = gridType;
                    if (regXRow == true) rbtRegXRow.Checked = true;
                    else rbtRegXCol.Checked = true;
                    nudRegXPos.Value = regXPos;
                    nudRegXRangeA.Value = regXRangeA;
                    nudRegXRangeB.Value = regXRangeB;
                    if (regYRow == true) rbtRegYRow.Checked = true;
                    else rbtRegYCol.Checked = true;
                    nudRegYPos.Value = regYPos;
                    nudRegYRangeA.Value = regYRangeA;
                    nudRegYRangeB.Value = regYRangeB;
                    nudRegZRowA.Value = regZRowA;
                    nudRegZRowB.Value = regZRowB;
                    nudRegZColA.Value = regZColA;
                    nudRegZColB.Value = regZColB;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            finally
            {
                if (reader != null) reader.Dispose();
                if (stream != null) stream.Dispose();
            }

            if (LoadSourceData(srcDataFileName) == false) return;
            if (LoadAxisData(axisDataFileName) == false) return;
        }

        // сохранение файла конфигурации
        private void SaveConfigData(string fileName)
        {
            // создание потока записи
            System.IO.Stream stream;
            try
            {
                stream = System.IO.File.OpenWrite(fileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            // создание экземпляра класса StreamWriter
            System.IO.StreamWriter writer;
            try
            {
                writer = new System.IO.StreamWriter(stream);
            }
            catch (Exception ex)
            {
                if (stream != null) stream.Dispose();
                MessageBox.Show(ex.Message);
                return;
            }
            // запись данных конфигурации в файл
            try
            {
                writer.WriteLine(tbxSrcDataFilePath.Text);
                writer.WriteLine(tbxAxisFileName.Text);
                writer.WriteLine(tctGridType.SelectedIndex);
                if (tctGridType.SelectedIndex == 0)
                {
                    writer.WriteLine(cbxIrregReadMode.SelectedIndex);
                    writer.WriteLine(nudIrregSkipCount.Value);
                    writer.WriteLine(nudIrregXPos.Value);
                    writer.WriteLine(nudIrregYPos.Value);
                    writer.WriteLine(nudIrregZPos.Value);
                    writer.WriteLine(cbxIrregInterpMethod.SelectedIndex);
                }
                else
                {
                    writer.WriteLine(rbtRegXRow.Checked);
                    writer.WriteLine(nudRegXPos.Value);
                    writer.WriteLine(nudRegXRangeA.Value);
                    writer.WriteLine(nudRegXRangeB.Value);
                    writer.WriteLine(rbtRegYRow.Checked);
                    writer.WriteLine(nudRegYPos.Value);
                    writer.WriteLine(nudRegYRangeA.Value);
                    writer.WriteLine(nudRegYRangeB.Value);
                    writer.WriteLine(nudRegZRowA.Value);
                    writer.WriteLine(nudRegZRowB.Value);
                    writer.WriteLine(nudRegZColA.Value);
                    writer.WriteLine(nudRegZColB.Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            finally
            {
                if(writer != null) writer.Dispose();
                if(stream != null) stream.Dispose();
            }
        }

        // сохранение результатов вычислений
        private void SaveResultsData(string fileName)
        {
            if (data.intX == null || data.intY == null || data.intZ == null)
            {
                MessageBox.Show("Таблица результатов не содержит данных", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // создание потока записи
            System.IO.Stream stream = null;
            try
            {
                stream = System.IO.File.OpenWrite(fileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            // создание экземпляра класса StreamWriter
            System.IO.StreamWriter writer = null;
            try
            {
                writer = new System.IO.StreamWriter(stream);
            }
            catch (Exception ex)
            {
                if (stream != null) stream.Dispose();
                MessageBox.Show(ex.Message);
                return;
            }
            // запись результатов в файл
            string s = "   X\\Y  \t";
            for (int j = 0; j < data.intNY; j++)
            {
                s += data.intY[j].ToString("F8");
                if (j < data.intNY - 1) s += "\t";
            }
            try
            {
                writer.WriteLine(s);
                for (int i = 0; i < data.intNX; i++)
                {

                    s = data.intX[i].ToString("F8") + "\t";
                    for (int j = 0; j < data.intNY; j++)
                    {
                        s += data.intZ[i, j].ToString("F8");
                        if (j < data.intNY - 1) s += "\t";
                    }
                    writer.WriteLine(s);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            finally
            {
                if (writer != null) writer.Dispose();
                if (stream != null) stream.Dispose();
            }
        }

#endregion

#region функции для считывания исходных данных

        // чтение исходных данных для нерегулярной сетки
        private bool ReadSourceIrregularData()
        {
            // определение диапазонов данных
            ReadDir rm = (ReadDir)cbxIrregReadMode.SelectedIndex;
            int sc =         (int)nudIrregSkipCount.Value; // количество пропускаемых строк (столбцов)
            int posX =       (int)nudIrregXPos.Value - 1;
            int posY =       (int)nudIrregYPos.Value - 1;
            int posZ =       (int)nudIrregZPos.Value - 1;
            // проверка корректности диапазонов
            if (tblSource.RowCount < 3 || tblSource.ColumnCount < 3)
            {
                MessageBox.Show("Таблица исходных данных содержит недостаточно элементов для корректной работы программы.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (rm == ReadDir.rdRows && sc > tblSource.ColumnCount - 1 || rm == ReadDir.rdCols && sc > tblSource.RowCount - 1)
            {
                MessageBox.Show("Количество пропускаемых строк/столбцов слишком велико.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            int maxN = (rm == ReadDir.rdRows) ? tblSource.RowCount - 1 : tblSource.ColumnCount - 1;       
            if (posX > maxN || posY > maxN || posZ > maxN)
            {
                MessageBox.Show("Номера строк/столбцов выходят за пределы таблицы.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (posX == posY || posY == posZ || posZ == posX)
            {
                MessageBox.Show("Номера строк/столбцов совпадают.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            // чтение исходных данных из таблицы в переменную data
            data.srcN = ((rm == ReadDir.rdCols) ? tblSource.RowCount : tblSource.ColumnCount) - (int)sc;
            data.srcXYZ = new double[data.srcN, 3];
            data.int2Z = new double[data.srcN];
            data.diffs = new double[data.srcN];
            string sx, sy, sz;
            for (int i = 0; i < data.srcN; i++)
            {
                try
                {
                    if (rm == ReadDir.rdCols) // чтение по столбцам
                    {
                        sx = tblSource.Rows[i + sc].Cells[posX].Value.ToString();
                        sy = tblSource.Rows[i + sc].Cells[posY].Value.ToString();
                        sz = tblSource.Rows[i + sc].Cells[posZ].Value.ToString();
                    }
                    else
                    {
                        sx = tblSource.Rows[posX].Cells[i + sc].Value.ToString();
                        sy = tblSource.Rows[posY].Cells[i + sc].Value.ToString();
                        sz = tblSource.Rows[posZ].Cells[i + sc].Value.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Некорректные значения в таблице исходных данных. Возможно, некоторые ячейки не содержат значений. Дополнительная информация: \n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false; 
                }
                try
                {
                    data.srcXYZ[i, 0] = System.Convert.ToDouble(sx);
                    data.srcXYZ[i, 1] = System.Convert.ToDouble(sy);
                    data.srcXYZ[i, 2] = System.Convert.ToDouble(sz);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Некорректные значения в таблице исходных данных. Возможно, некоторые ячейки содержат нечисловые значения. Дополнительная информация: \n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }

        // чтение исходных данных для регулярной сетки
        private bool ReadSourceRegularData()
        {
            int posX, posY, rngXA, rngXB, rngYA, rngYB, rngZRA, rngZRB, rngZCA, rngZCB, maxNX, maxNY;
            // определение диапазонов данных
            posX =   (int)nudRegXPos.Value - 1;
            rngXA =  (int)nudRegXRangeA.Value - 1;
            rngXB =  (int)nudRegXRangeB.Value - 1;
            posY =   (int)nudRegYPos.Value - 1;
            rngYA =  (int)nudRegYRangeA.Value - 1;
            rngYB =  (int)nudRegYRangeB.Value - 1;
            rngZRA = (int)nudRegZRowA.Value - 1;
            rngZRB = (int)nudRegZRowB.Value - 1;
            rngZCA = (int)nudRegZColA.Value - 1;
            rngZCB = (int)nudRegZColB.Value - 1;
            // проверка корректности диапазонов
            if (tblSource.RowCount < 3 || tblSource.ColumnCount < 3)
            {
                MessageBox.Show("Таблица исходных данных содержит недостаточно элементов для корректной работы программы.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (rbtRegXCol.Checked) maxNX = tblSource.ColumnCount - 1; // чтение X по столбцу
            else maxNX = tblSource.RowCount - 1;
            if (rbtRegYCol.Checked) maxNY = tblSource.ColumnCount - 1; // чтение Y по столбцу
            else maxNY = tblSource.RowCount - 1;
            if (posX > maxNX || posY > maxNY)
            {
                MessageBox.Show("Номера строк/столбцов одного из аргументов выходят за пределы таблицы.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (rngXA >= rngXB || rngYA >= rngYB)
            {
                MessageBox.Show("Нижняя граница диапазона строк/столбцов одного из аргументов больше или равна верхней.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false; 
            }
            if (rbtRegXCol.Checked) maxNX = tblSource.RowCount - 1; // чтение X по столбцу
            else maxNX = tblSource.ColumnCount - 1;
            if (rbtRegYCol.Checked) maxNY = tblSource.RowCount - 1; // чтение Y по столбцу
            else maxNY = tblSource.ColumnCount - 1;
            if (rngXB > maxNX || rngYB > maxNY)
            {
                MessageBox.Show("Верхняя граница диапазона строк/столбцов одного из аргументов выходит за пределы таблицы.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (rngZRA >= rngZRB || rngZCA >= rngZCB)
            {
                MessageBox.Show("Нижняя граница диапазона строк или столбцов значений функции больше или равна верхней.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (rngZRB > tblSource.RowCount - 1 || rngZCB > tblSource.ColumnCount - 1)
            {
                MessageBox.Show("Верхняя граница диапазона строк или столбцов значений функции выходит за пределы таблицы.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            int srcNX = rngXB - rngXA + 1, srcNY = rngYB - rngYA + 1;
            if (rbtRegReadXY.Checked && srcNX != rngZRB - rngZRA + 1)
            {
                MessageBox.Show("Количество элементов аргумента X должно быть равно длине диапазона строк значений функции.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (rbtRegReadXY.Checked && srcNY != rngZCB - rngZCA + 1)
            {
                MessageBox.Show("Количество элементов аргумента Y должно быть равно длине диапазона столбцов значений функции.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (rbtRegReadYX.Checked && srcNX != rngZCB - rngZCA + 1)
            {
                MessageBox.Show("Количество элементов аргумента X должно быть равно длине диапазона столбцов значений функции.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (rbtRegReadYX.Checked && srcNY != rngZRB - rngZRA + 1)
            {
                MessageBox.Show("Количество элементов аргумента Y должно быть равно длине диапазона строк значений функции.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            // чтение значений
            data.srcN = srcNX * srcNY;
            data.srcXYZ = new double[data.srcN, 3];
            data.int2Z = new double[data.srcN];
            data.diffs = new double[data.srcN];
            int k = 0;
            string sx, sy, sz;
            for (int i = 0; i < srcNX; i++)
            {
                for (int j = 0; j < srcNY; j++)
                {
                    try
                    {
                        if (rbtRegXCol.Checked) sx = tblSource.Rows[i + rngXA].Cells[posX].Value.ToString();
                        else sx = tblSource.Rows[posX].Cells[i + rngXA].Value.ToString();
                        if (rbtRegYCol.Checked) sy = tblSource.Rows[j + rngYA].Cells[posY].Value.ToString();
                        else sy = tblSource.Rows[posY].Cells[j + rngYA].Value.ToString();
                        if(rbtRegReadXY.Checked) sz = tblSource.Rows[i + rngZRA].Cells[j + rngZCA].Value.ToString();
                        else sz = tblSource.Rows[j + rngZRA].Cells[i + rngZCA].Value.ToString();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Некорректные значения в таблице исходных данных. Возможно, некоторые ячейки не содержат значений. Дополнительная информация: \n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false; 
                    }
                    try
                    {
                        data.srcXYZ[k, 0] = System.Convert.ToDouble(sx);
                        data.srcXYZ[k, 1] = System.Convert.ToDouble(sy);
                        data.srcXYZ[k, 2] = System.Convert.ToDouble(sz);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Некорректные значения в таблице исходных данных. Возможно, некоторые ячейки содержат нечисловые значения. Дополнительная информация: \n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    k++;
                }
            }
            return true;
        }

        // чтение данных осей
        private bool ReadAxisData()
        {
            // проверка корректности данных
            if (tblXAxis.ColumnCount < 1 || tblYAxis.ColumnCount < 1)
            {
                MessageBox.Show("Таблица данных осей содержит недостаточно элементов для корректной работы программы.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            // чтение данных осей из таблицы в переменные intX, intY
            data.intNX = tblXAxis.ColumnCount;
            data.intNY = tblYAxis.ColumnCount;
            data.intX = new double[data.intNX];
            data.intY = new double[data.intNY];
            data.intZ = new double[data.intNX, data.intNY];
            data.derZX = new double[data.intNX, data.intNY];
            data.derZY = new double[data.intNX, data.intNY];
            try
            {
                for (int i = 0; i < data.intNX; i++) data.intX[i] = Convert.ToDouble(tblXAxis.Rows[0].Cells[i].Value);
                for (int i = 0; i < data.intNY; i++) data.intY[i] = Convert.ToDouble(tblYAxis.Rows[0].Cells[i].Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Некорректные значения в таблице данных осей. Возможно, некоторые ячейки содержат нечисловые значения. Дополнительная информация: \n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

#endregion

#region функции для работы со строковыми данными

        // функция заменяет десятичные разделители в строке на корректные
        public static string CorrectDecimalSeparators(string str)
        {
            string tmp = Convert.ToString(1.1);
            char sep = tmp[1], rep = (sep == ',') ? '.' : ',';
            return str.Replace(rep, sep); // замена десятичных разделителей на корректные
        }

        //  функция очищает строку от лишних разделителей и заменяет их на символ табуляции
        public static string TabulateStr(string str)
        {
            if (str == null) return "";
            const string SEP = " ;\t"; // все возможные разделители строки
            int i = 0, j = 0;
            while (i < str.Length)
            {
                if (SEP.Contains(str[i]))
                {
                    j = i;
                    while (j < str.Length - 1)
                    {
                        if (SEP.Contains(str[j + 1])) j++;
                        else break;
                    }
                    str = str.Remove(i, j - i + 1);
                    if (i > 0 && i < str.Length)
                    {
                        str = str.Insert(i, "\t");
                        i++;
                    }
                }
                else i++;
            }
            return str;
        }

#endregion

#region функции для работы с числовыми данными

        void EraseData()
        {
            data.srcXYZ = null;
            data.srcN = 0;
            data.intX = data.intY = null;
            data.intZ = null;
            data.intNX = data.intNY = 0;
            data.diffs = null;
            data.int2Z = null;
            data.minIX = data.minIY = data.minIZ = 0;
            data.maxIX = data.maxIY = data.maxIZ = 0;
            data.maxNegDiffNum = data.maxPosDiffNum = 0;
            data.maxNegDiff = data.maxPosDiff = 0;
            plot.selIntPoints.Clear();
            plot.selSrcPoints.Clear();
        }

        // функция пересчитывает данные, зависящие от интерполированных значений
        private void UpdateInterpData()
        {
            // нахождение частных производных от интерполированной функции
            if (data.derZX == null || data.derZY == null) return;
            for (int i = 0; i < data.intNX; i++)
            {
                for (int j = 0; j < data.intNY; j++)
                {
                    if(i + 1 < data.intNX)
                        data.derZX[i, j] = (data.intZ[i + 1, j] - data.intZ[i, j]) / (data.intX[i + 1] - data.intX[i]);
                    if (j + 1 < data.intNY)
                        data.derZY[i, j] = (data.intZ[i, j + 1] - data.intZ[i, j]) / (data.intY[j + 1] - data.intY[j]); 
                }
            }
            if (data.intX == null || data.intY == null || data.intZ == null || data.srcXYZ == null || data.diffs == null || data.int2Z == null) return;
            // определение минимальных и максимальных значений интерполированной функции и ее частных производных
            data.minIZ = data.maxIZ = data.intZ[0, 0];
            data.minDZX = data.maxDZX = data.derZX[0, 0];
            data.minDZY = data.maxDZY = data.derZY[0, 0];
            for (int i = 0; i < data.intNX; i++)
            {
                for (int j = 0; j < data.intNY; j++)
                {
                    if (data.intZ[i, j] < data.minIZ) data.minIZ = data.intZ[i, j];
                    if (data.intZ[i, j] > data.maxIZ) data.maxIZ = data.intZ[i, j];
                    if (data.derZX[i, j] < data.minDZX) data.minDZX = data.derZX[i, j];
                    if (data.derZX[i, j] > data.maxDZX) data.maxDZX = data.derZX[i, j];
                    if (data.derZY[i, j] < data.minDZY) data.minDZY = data.derZY[i, j];
                    if (data.derZY[i, j] > data.maxDZY) data.maxDZY = data.derZY[i, j];
                }
            }
            data.minIX = data.intX.Min();
            data.maxIX = data.intX.Max();
            data.minIY = data.intY.Min();
            data.maxIY = data.intY.Max();
            data.srcDataBoundsRect = new RectangleF((float)data.minIX, (float)data.minIY, (float)(data.maxIX - data.minIX), (float)(data.maxIY - data.minIY));
            // положение начала координат опрделяется минимальными координатами поверхности
            plot.CS0 = new Vector3((float)data.minIX, (float)data.minIY, (float)data.minIZ);
            // вычистение масштабных коэффициентов для осей
            plot.scale = new Vector3(Plot.AXIS_LEN / (float)(data.maxIX - data.minIX), Plot.AXIS_LEN / (float)(data.maxIY - data.minIY), Plot.AXIS_LEN / (float)(data.maxIZ - data.minIZ));
            // нахождение интерполированных значений в исходных точках на регуляризованной поверхности
            alglib.spline2dinterpolant linInt;
            alglib.spline2dbuildbilinear(data.intY, data.intX, data.intZ, data.intNX, data.intNY, out linInt);
            for (int i = 0; i < data.srcN; i++)
            {
                data.int2Z[i] = alglib.spline2dcalc(linInt, data.srcXYZ[i, 1], data.srcXYZ[i, 0]);
            }
            // вычисление отклонений исходных данных от полученных интерполяцией
            double x, y, z, iz;
            int cnt = 0;
            data.maxPosDiff = 0;
            data.maxNegDiff = 0;
            data.avgSqrDiff = 0;
            data.maxPosDiffNum = 0;
            data.maxNegDiffNum = 0;
            for (int i = 0; i < data.srcN; i++)
            {
                x = data.srcXYZ[i, 0];
                y = data.srcXYZ[i, 1];
                z = data.srcXYZ[i, 2];
                iz = data.int2Z[i];
                if (data.srcDataBoundsRect.Contains((float)x, (float)y))
                {
                    data.diffs[i] = (z - iz) / (data.maxIZ - data.minIZ) * 100;
                    if (data.diffs[i] > data.maxPosDiff)
                    {
                        data.maxPosDiff = data.diffs[i];
                        data.maxPosDiffNum = i;
                    }
                    if (data.diffs[i] < data.maxNegDiff)
                    {
                        data.maxNegDiff = data.diffs[i];
                        data.maxNegDiffNum = i;
                    }
                    data.avgSqrDiff += Math.Abs(z - iz);
                    cnt++;
                }
            }
            data.avgSqrDiff = data.avgSqrDiff / (data.maxIZ - data.minIZ) * 100 / cnt;
            // вывод максимальных отклонений на форму
            lblDifferences.Text = "макс. полож. откл: " + data.maxPosDiff.ToString("F2") + "%\n" +
                               "макс. отриц. откл: " + data.maxNegDiff.ToString("F2") + "%\n" +
                               "сред. откл: " + data.avgSqrDiff.ToString("F2") + "%";
        }

        // интерполяция исходных данных на нерегулярной сетке (библиотека ALGLIB)
        private void DoInterpolate()
        {
            if (data.srcXYZ == null) return;
            alglib.idwinterpolant idwInt;
            int nq = (int)(data.srcN * tbrInterpNQ.Value / 100.0);
            int nw = (int)(data.srcN * tbrInterpNW.Value / 100.0);
            try
            {
                alglib.idwbuildnoisy(data.srcXYZ, data.srcN, 2, cbxIrregInterpMethod.SelectedIndex + 1, nq, nw, out idwInt);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Не удается произвести интерполяцию данных. " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            double[] xx = new double[2];
            for (int i = 0; i < data.intNX; i++)
            {
                xx[0] = data.intX[i];
                for (int j = 0; j < data.intNY; j++)
                {
                    xx[1] = data.intY[j];
                    try
                    {
                        data.intZ[i, j] = alglib.idwcalc(idwInt, xx);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Не удается произвести интерполяцию данных. " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            // пересчет отклонений интерполированных точек от исходных
            UpdateInterpData();
        }

#endregion

#region функции графического вывода

        // инициализация библиотеки OpenGL
        private void glControl_Load(object sender, EventArgs e)
        {
            GL.ClearColor(Color.FromArgb(255, 170, 170, 175));
            Matrix4 p = Matrix4.Zero;
            GL.Enable(EnableCap.DepthTest);
            try
            {
                p = Matrix4.CreateOrthographicOffCenter(0, glControl.ClientSize.Width, 0, glControl.ClientSize.Height, -10000, 10000); //CreatePerspectiveFieldOfView((float)(80 * Math.PI / 180), 1, 1, 10000);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref p);
            GL.Translate(glControl.ClientSize.Width / 2, glControl.ClientSize.Height / 2, 0);
            UpdateCameraPosition();
            plot.textRenderer = new TextRenderer(glControl.ClientSize);
            plot.fntAxisName = new Font("Calibri", 16, FontStyle.Bold);
            plot.fntAxisCoord = new Font("Calibri", 12);
            plot.fntPntCoord = new Font("Arial", 8);
            plot.isGLLoaded = true;
        }

        // рендеринг кадра
        private void glControl_Paint(object sender, PaintEventArgs e)
        {
            if (!plot.isGLLoaded) return;
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            DrawAxis(); // рисование координатных осей
            if (chkShowGraph.Checked)
            {
                // рисование поверхности по интерполированной таблице значений
                if (rbtDrawGrid.Checked == true) // если выбрано рисование сетки
                {
                    if (rbtOneColor.Checked) DrawGrid(ColorMode.cmOneColor); // рисование линий сетки монотонным цветом
                    else if (rbtColorByValue.Checked) DrawGrid(ColorMode.cmColorByValue); // цвет линий сетки зависит от значения
                    else if (rbtColorByDer.Checked) DrawGrid(ColorMode.cmColorByDer); // цвет линий сетки зависит от производной
                }
                else // иначе рисуем поверхность
                {
                    if (rbtOneColor.Checked) DrawSurface(ColorMode.cmOneColor); // рисование поверхности монотонным цветом
                    else if (rbtColorByValue.Checked) DrawSurface(ColorMode.cmColorByValue); // цвет поверхности зависит от значения
                    else if (rbtColorByDerX.Checked) DrawSurface(ColorMode.cmColorByDerX); // цвет поверхности зависит от производной по X
                    else DrawSurface(ColorMode.cmColorByDerY); // цвет поверхности зависит от производной по Y
                }
            }
            if(chkShowSourcePoints.Checked)
                DrawSourcePoints(chkShowPointsProjections.Checked && chkShowGraph.Checked, chkShowHiddenPoints.Checked); // рисование исходных точек
            DrawMarkersForSelectedPoints(); // рисование маркеров для выделенных точек
            // отрисовка текста на поверхности рисования
            plot.textRenderer.Draw();
            // вывод буфера на экран
            glControl.SwapBuffers();
        }

        // функция рисует координатные оси
        void DrawAxis()
        {
            Point pnt;
            double val;
            float pos;
            string str;
            // рисование координатных осей
            GL.Color3(Color.Yellow);
            GL.LineWidth(3);
            GL.Begin(PrimitiveType.Lines);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(Plot.AXIS_LEN * plot.dist, 0, 0);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, Plot.AXIS_LEN * plot.dist, 0);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, 0, Plot.AXIS_LEN * plot.dist);
            GL.End();
            // вывод названий осей
            pnt = WorldToScreenCoordinates(Plot.AXIS_LEN * plot.dist, 0, 0);
            plot.textRenderer.SetText("X", pnt, plot.fntAxisName, Brushes.Black);
            pnt = WorldToScreenCoordinates(0, Plot.AXIS_LEN * plot.dist, 0);
            plot.textRenderer.SetText("Y", pnt, plot.fntAxisName, Brushes.Black);
            pnt = WorldToScreenCoordinates(0, 0, Plot.AXIS_LEN * plot.dist);
            plot.textRenderer.SetText("Z", pnt, plot.fntAxisName, Brushes.Black);
            // вывод подписей осей
            int lblCount = (int)(Plot.AXIS_LEN / plot.dist * 4 + 3);
            lblCount = lblCount > 8 ? 8 : lblCount;
            for (int i = 1; i < lblCount - 1; i++)
            {
                pos = i * Plot.AXIS_LEN / (lblCount - 1) * plot.dist;
                // подписи оси X
                val = data.minIX + i * (data.maxIX - data.minIX) / (lblCount - 1);
                str = val.ToString("F2");
                pnt = WorldToScreenCoordinates(pos, 0, 0);
                plot.textRenderer.SetText(str, pnt, plot.fntAxisCoord, Brushes.Navy);
                // подписи оси Y
                val = data.minIY + i * (data.maxIY - data.minIY) / (lblCount - 1);
                str = val.ToString("F2");
                pnt = WorldToScreenCoordinates(0, pos, 0);
                plot.textRenderer.SetText(str, pnt, plot.fntAxisCoord, Brushes.Navy);
                // подписи оси Z
                val = data.minIZ + i * (data.maxIZ - data.minIZ) / (lblCount - 1);
                str = val.ToString("F2");
                pnt = WorldToScreenCoordinates(0, 0, pos);
                plot.textRenderer.SetText(str, pnt, plot.fntAxisCoord, Brushes.Navy);
            }
        }

        // функция отрисовывает сетку по интерполированным значениям
        void DrawGrid(ColorMode cm)
        {
            if (data.intX == null || data.intY == null || data.intZ == null) return;
            Vector3 vec1, vec2;
            double x;
            int r, g, b; // компоненты цвета
            GL.LineWidth(2);
            for (int i = 0; i < data.intNX; i++)
            {
                for (int j = 0; j < data.intNY; j++)
                {
                    vec1.X = (float)data.intX[i];
                    vec1.Y = (float)data.intY[j];
                    vec1.Z = (float)data.intZ[i, j];
                    for (int k = 0; k <= 1; k++)
                    {
                        if (i + k >= data.intNX || j + (1 - k) >= data.intNY) continue;
                        vec2.X = (float)data.intX[i + k];
                        vec2.Y = (float)data.intY[j + (1 - k)];
                        vec2.Z = (float)data.intZ[i + k, j + (1 - k)];
                        switch (cm)
                        {
                            case ColorMode.cmOneColor:
                                GL.Color3(Color.Green);
                                break;
                            case ColorMode.cmColorByValue:
                                r = (int)((vec2.Z - data.minIZ) / (data.maxIZ - data.minIZ) * 255.0);
                                b = 255 - r;
                                GL.Color3(Color.FromArgb(255, r, 0, b));
                                break;
                            case ColorMode.cmColorByDer:
                                if(k == 1) x = (data.derZX[i, j] < 0.0) ? -data.derZX[i, j] / data.minDZX : data.derZX[i, j] / data.maxDZX; // производная по X
                                else x = (data.derZY[i, j] < 0.0) ? -data.derZY[i, j] / data.minDZY : data.derZY[i, j] / data.maxDZY; // производная по X
                                r = (int)Math.Max(x * 255.0, 0.0);
                                g = (int)((1.0 - Math.Abs(x)) * 127.0);
                                b = (int)Math.Max(-x * 255.0, 0.0);
                                GL.Color3(Color.FromArgb(255, r, g, b));
                                break;
                        }
                        GL.Begin(PrimitiveType.Lines);
                        GL.Vertex3((vec1 - plot.CS0) * plot.scale * plot.dist);
                        GL.Vertex3((vec2 - plot.CS0) * plot.scale * plot.dist);
                        GL.End();
                    }
                }
            }
        }

        // функция отрисовывает поверхность по интерполированным значениям
        void DrawSurface(ColorMode cm)
        {
            if (data.intX == null || data.intY == null || data.intZ == null) return;
            Vector3 vec1, vec2, vec3, vec4;
            int r, g, b;
            double x, y, d1, d2;
            float v;
            for (int i = 0; i < data.intNX - 1; i++)
            {
                for (int j = 0; j < data.intNY - 1; j++)
                {
                    vec1.X = (float)data.intX[i]; vec1.Y = (float)data.intY[j]; vec1.Z = (float)data.intZ[i, j];
                    vec2.X = (float)data.intX[i + 1]; vec2.Y = (float)data.intY[j]; vec2.Z = (float)data.intZ[i + 1, j];
                    vec3.X = (float)data.intX[i + 1]; vec3.Y = (float)data.intY[j + 1]; vec3.Z = (float)data.intZ[i + 1, j + 1];
                    vec4.X = (float)data.intX[i]; vec4.Y = (float)data.intY[j + 1]; vec4.Z = (float)data.intZ[i, j + 1];
                    switch (cm)
                    {
                        case ColorMode.cmOneColor:
                            GL.Color3(Color.Green);
                            break;
                        case ColorMode.cmColorByValue:
                            v = (vec1.Z + vec2.Z + vec3.Z + vec4.Z) / 4.0f;
                            r = (int)((v - data.minIZ) / (data.maxIZ - data.minIZ) * 255.0);
                            b = 255 - r;
                            GL.Color3(Color.FromArgb(255, r, 0, b));
                            break;
                        case ColorMode.cmColorByDerX:
                            d1 = data.derZX[i, j];
                            d2 = data.derZX[i, j + 1];
                            x = (d1 + d2) / 2;
                            x = (x < 0.0) ? -x / data.minDZX : x / data.maxDZX; // производная по X
                            r = (int)Math.Max(x * 255.0, 0.0);
                            g = (int)((1.0 - Math.Abs(x)) * 127.0);
                            b = (int)Math.Max(-x * 255.0, 0.0);
                            GL.Color3(Color.FromArgb(255, r, g, b));
                            break;
                        case ColorMode.cmColorByDerY:
                            d1 = data.derZY[i, j];
                            d2 = data.derZY[i + 1, j];
                            y = (d1 + d2) / 2;
                            y = (y < 0.0) ? -y / data.minDZY : y / data.maxDZY; // производная по Y
                            r = (int)Math.Max(y * 255.0, 0.0);
                            g = (int)((1.0 - Math.Abs(y)) * 127.0);
                            b = (int)Math.Max(-y * 255.0, 0.0);
                            GL.Color3(Color.FromArgb(255, r, g, b));
                            break;
                    }
                    GL.Begin(PrimitiveType.Quads);
                    GL.Vertex3((vec1 - plot.CS0) * plot.scale * plot.dist);
                    GL.Vertex3((vec2 - plot.CS0) * plot.scale * plot.dist);
                    GL.Vertex3((vec3 - plot.CS0) * plot.scale * plot.dist);
                    GL.Vertex3((vec4 - plot.CS0) * plot.scale * plot.dist);
                    GL.End();
                }
            }            
        }

        // функция рисует точки по набору исходных данных
        void DrawSourcePoints(bool showProj, bool showHidden)
        {
            if (data.srcXYZ == null) return;
            int r, g, b;
            Vector3 vec;
            for (int i = 0; i < data.srcN; i++)
            {
                vec.X = (float)data.srcXYZ[i, 0];
                vec.Y = (float)data.srcXYZ[i, 1];
                vec.Z = (float)data.srcXYZ[i, 2];
                bool inside;
                if ((inside = data.srcDataBoundsRect.Contains(vec.X, vec.Y)) || showHidden)
                {
                    // цвет маркера зависит от величины отклонения исходной точки от интерполированной поверхности
                    r = g = b = 0;
                    if (inside)
                    {
                        // определение цвета маркера в зависимости от отклонения
                        if (data.diffs[i] > 0) r = (int)(data.diffs[i] / data.maxPosDiff * 255.0f);
                        else b = (int)(data.diffs[i] / data.maxNegDiff * 255.0f);
                    }
                    vec = (vec - plot.CS0) * plot.scale * plot.dist;
                    GL.Color3(Color.FromArgb(r, g, b));
                    GL.PointSize(5);
                    GL.Begin(PrimitiveType.Points);
                    GL.Vertex3(vec);
                    GL.End();
                    if (inside && showProj)
                    {
                        // рисование соединительных линий
                        if (data.diffs[i] > 0) GL.Color3(Color.Red);
                        else GL.Color3(Color.Blue);
                        GL.LineWidth(1);
                        GL.Begin(PrimitiveType.Lines);
                        GL.Vertex3(vec);
                        vec.Z = (float)(data.int2Z[i] - plot.CS0.Z) * plot.scale.Z * plot.dist;
                        GL.Vertex3(vec);
                        GL.End();
                    }
                }
            }
            // выделение точек с наибольшими отклонениями
            GL.PointSize(15);
            GL.Color3(Color.Red);
            GL.Begin(PrimitiveType.Points);
            vec.X = (float)data.srcXYZ[data.maxPosDiffNum, 0];
            vec.Y = (float)data.srcXYZ[data.maxPosDiffNum, 1];
            vec.Z = (float)data.srcXYZ[data.maxPosDiffNum, 2];
            GL.Vertex3((vec - plot.CS0) * plot.scale * plot.dist);
            GL.End();
            GL.Color3(Color.Blue);
            GL.Begin(PrimitiveType.Points);
            vec.X = (float)data.srcXYZ[data.maxNegDiffNum, 0];
            vec.Y = (float)data.srcXYZ[data.maxNegDiffNum, 1];
            vec.Z = (float)data.srcXYZ[data.maxNegDiffNum, 2];
            GL.Vertex3((vec - plot.CS0) * plot.scale * plot.dist);
            GL.End();
        }

        // функция рисует маркеры для выбранных точек
        void DrawMarkersForSelectedPoints()
        {
            Vector3 vec;
            Point pnt;
            double x, y, z;
            string str;
            GL.Color4(Color.FromArgb(127, 255, 255, 255)); // белый полупрозрачный цвет
            GL.PointSize(20);
            if (data.intX != null && data.intY != null && data.intZ != null) // рисование маркеров выделения для точек поверхности
            {
                foreach (Point selPnt in plot.selIntPoints)
                {
                    x = data.intX[selPnt.X];
                    y = data.intY[selPnt.Y];
                    z = data.intZ[selPnt.X, selPnt.Y];
                    vec.X = (float)(x - plot.CS0.X) * plot.scale.X * plot.dist;
                    vec.Y = (float)(y - plot.CS0.Y) * plot.scale.Y * plot.dist;
                    vec.Z = (float)(z - plot.CS0.Z) * plot.scale.Z * plot.dist;
                    GL.Begin(PrimitiveType.Points);
                    GL.Vertex3(vec);
                    GL.End();
                    // вывод подписей к маркерам
                    str = "x " + x.ToString("F2") + "\n" +
                          "y " + y.ToString("F2") + "\n" +
                          "z " + z.ToString("F2");
                    pnt = WorldToScreenCoordinates(vec);
                    pnt.X -= 40;
                    pnt.Y -= 60;
                    plot.textRenderer.SetText(str, pnt, plot.fntPntCoord, Brushes.Black);
                }
            }
            if (data.srcXYZ != null) // рисование маркеров выделения для исходных точек
            {
                foreach (int selPnt in plot.selSrcPoints)
                {
                    x = data.srcXYZ[selPnt, 0];
                    y = data.srcXYZ[selPnt, 1];
                    z = data.srcXYZ[selPnt, 2];
                    vec.X = (float)(data.srcXYZ[selPnt, 0] - plot.CS0.X) * plot.scale.X * plot.dist;
                    vec.Y = (float)(data.srcXYZ[selPnt, 1] - plot.CS0.Y) * plot.scale.Y * plot.dist;
                    vec.Z = (float)(data.srcXYZ[selPnt, 2] - plot.CS0.Z) * plot.scale.Z * plot.dist;
                    GL.Begin(PrimitiveType.Points);
                    GL.Vertex3(vec);
                    GL.End();
                    // вывод подписей к маркерам
                    str = "x " + x.ToString("F2") + "\n" +
                          "y " + y.ToString("F2") + "\n" +
                          "z " + z.ToString("F2");
                    pnt = WorldToScreenCoordinates(vec);
                    pnt.X -= 40;
                    pnt.Y -= 60;
                    plot.textRenderer.SetText(str, pnt, plot.fntPntCoord, Brushes.Black);
                }
            }
        }

        // функция преобразует координаты точки из мировой в экранную СК
        private Point WorldToScreenCoordinates(Vector3 worldPoint)
        {
            Matrix4 modelViewMatrix, projectionMatrix;
            GL.GetFloat(GetPName.ModelviewMatrix, out modelViewMatrix);
            GL.GetFloat(GetPName.ProjectionMatrix, out projectionMatrix);
            int[] viewport = new int[4];
            GL.GetInteger(GetPName.Viewport, viewport);
            Vector4 vec = new Vector4(worldPoint.X, worldPoint.Y, worldPoint.Z, 1);
            Vector4.Transform(ref vec, ref modelViewMatrix, out vec);
            Vector4.Transform(ref vec, ref projectionMatrix, out vec);
            int x, y;
            x = (int)((vec[0] / vec[3] + 1) / 2.0f * viewport[2]);
            y = (int)((1 - vec[1] / vec[3]) / 2.0f * viewport[3]);
            Point screenPoint = new Point(x, y);
            return screenPoint;
        }

        // функция преобразует координаты точки из мировой в экранную СК
        private Point WorldToScreenCoordinates(float x, float y, float z)
        {
            Vector3 vec = new Vector3(x, y, z);
            return WorldToScreenCoordinates(vec);
        }

        private void UpdateCameraPosition()
        {
            Vector3 camPos, target = plot.target * plot.dist;
            camPos.X = target.X + (float)(Math.Cos(plot.alpha) * Math.Cos(plot.beta));
            camPos.Y = target.Y + (float)(Math.Sin(plot.alpha) * Math.Cos(plot.beta));
            camPos.Z = target.Z + (float)(Math.Sin(plot.beta));
            Matrix4 modelview = Matrix4.LookAt(camPos, target, Vector3.UnitZ);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref modelview);
            glControl.Invalidate();
        }

#endregion

    }
}