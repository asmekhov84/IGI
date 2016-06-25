namespace IGI
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.mstMainMenu = new System.Windows.Forms.MenuStrip();
            this.tmiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiFileLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiFileLoadSourceData = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiFileLoadAxisData = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiFileLoadConfigData = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiFileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiFileSaveConfigData = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiFileSaveResultsData = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiHelpOpenFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.ofdOpenFile = new System.Windows.Forms.OpenFileDialog();
            this.sfdSaveFile = new System.Windows.Forms.SaveFileDialog();
            this.tctMain = new System.Windows.Forms.TabControl();
            this.tpgData = new System.Windows.Forms.TabPage();
            this.tctData = new System.Windows.Forms.TabControl();
            this.tpgSrcData = new System.Windows.Forms.TabPage();
            this.tblSource = new System.Windows.Forms.DataGridView();
            this.pnlSrcDataParams = new System.Windows.Forms.Panel();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.tctGridType = new System.Windows.Forms.TabControl();
            this.tabIrregGrid = new System.Windows.Forms.TabPage();
            this.gbxIrregDataPosition = new System.Windows.Forms.GroupBox();
            this.nudIrregZPos = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.nudIrregYPos = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.nudIrregXPos = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.gbxIrregSkipCount = new System.Windows.Forms.GroupBox();
            this.nudIrregSkipCount = new System.Windows.Forms.NumericUpDown();
            this.lblIrregSkipWhat = new System.Windows.Forms.Label();
            this.gbxIrregReadMode = new System.Windows.Forms.GroupBox();
            this.cbxIrregReadMode = new System.Windows.Forms.ComboBox();
            this.tabRegGrid = new System.Windows.Forms.TabPage();
            this.grpRegZData = new System.Windows.Forms.GroupBox();
            this.pnlRegZReadMode = new System.Windows.Forms.Panel();
            this.rbtRegReadYX = new System.Windows.Forms.RadioButton();
            this.rbtRegReadXY = new System.Windows.Forms.RadioButton();
            this.grpRegZRows = new System.Windows.Forms.GroupBox();
            this.nudRegZRowA = new System.Windows.Forms.NumericUpDown();
            this.nudRegZRowB = new System.Windows.Forms.NumericUpDown();
            this.grpRegZCols = new System.Windows.Forms.GroupBox();
            this.nudRegZColA = new System.Windows.Forms.NumericUpDown();
            this.nudRegZColB = new System.Windows.Forms.NumericUpDown();
            this.grpRegYData = new System.Windows.Forms.GroupBox();
            this.grpRegYRange = new System.Windows.Forms.GroupBox();
            this.nudRegYRangeA = new System.Windows.Forms.NumericUpDown();
            this.nudRegYRangeB = new System.Windows.Forms.NumericUpDown();
            this.lblRegYPos = new System.Windows.Forms.Label();
            this.nudRegYPos = new System.Windows.Forms.NumericUpDown();
            this.rbtRegYCol = new System.Windows.Forms.RadioButton();
            this.rbtRegYRow = new System.Windows.Forms.RadioButton();
            this.grpRegXData = new System.Windows.Forms.GroupBox();
            this.grpRegXRange = new System.Windows.Forms.GroupBox();
            this.nudRegXRangeA = new System.Windows.Forms.NumericUpDown();
            this.nudRegXRangeB = new System.Windows.Forms.NumericUpDown();
            this.lblRegXPos = new System.Windows.Forms.Label();
            this.nudRegXPos = new System.Windows.Forms.NumericUpDown();
            this.rbtRegXCol = new System.Windows.Forms.RadioButton();
            this.rbtRegXRow = new System.Windows.Forms.RadioButton();
            this.pnlSrcDataFilePath = new System.Windows.Forms.Panel();
            this.lblSrcDataFilePath = new System.Windows.Forms.Label();
            this.tbxSrcDataFilePath = new System.Windows.Forms.TextBox();
            this.tpgAxisData = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tblYAxis = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tblXAxis = new System.Windows.Forms.DataGridView();
            this.pnlAxisDataFilePath = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.tbxAxisFileName = new System.Windows.Forms.TextBox();
            this.tpgCalculation = new System.Windows.Forms.TabPage();
            this.pnlCalcParams = new System.Windows.Forms.Panel();
            this.tlpCalcParams = new System.Windows.Forms.TableLayoutPanel();
            this.grpShowParams = new System.Windows.Forms.GroupBox();
            this.chkShowPointsProjections = new System.Windows.Forms.CheckBox();
            this.chkShowHiddenPoints = new System.Windows.Forms.CheckBox();
            this.grpShowGraph = new System.Windows.Forms.GroupBox();
            this.chkShowGraph = new System.Windows.Forms.CheckBox();
            this.rbtDrawSurface = new System.Windows.Forms.RadioButton();
            this.rbtDrawGrid = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pnlColorByDerType = new System.Windows.Forms.Panel();
            this.rbtColorByDerY = new System.Windows.Forms.RadioButton();
            this.rbtColorByDerX = new System.Windows.Forms.RadioButton();
            this.rbtColorByDer = new System.Windows.Forms.RadioButton();
            this.rbtOneColor = new System.Windows.Forms.RadioButton();
            this.rbtColorByValue = new System.Windows.Forms.RadioButton();
            this.chkShowSourcePoints = new System.Windows.Forms.CheckBox();
            this.lblDifferences = new System.Windows.Forms.Label();
            this.gbxInterpParams = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxIrregInterpMethod = new System.Windows.Forms.ComboBox();
            this.chkAutoUpdate = new System.Windows.Forms.CheckBox();
            this.tbrInterpNQ = new System.Windows.Forms.TrackBar();
            this.tbrInterpNW = new System.Windows.Forms.TrackBar();
            this.glControl = new OpenTK.GLControl();
            this.tpgResults = new System.Windows.Forms.TabPage();
            this.panel7 = new System.Windows.Forms.Panel();
            this.tblResults = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnSaveResults = new System.Windows.Forms.Button();
            this.pbrResultsTableProgress = new System.Windows.Forms.ProgressBar();
            this.mstMainMenu.SuspendLayout();
            this.tctMain.SuspendLayout();
            this.tpgData.SuspendLayout();
            this.tctData.SuspendLayout();
            this.tpgSrcData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblSource)).BeginInit();
            this.pnlSrcDataParams.SuspendLayout();
            this.tctGridType.SuspendLayout();
            this.tabIrregGrid.SuspendLayout();
            this.gbxIrregDataPosition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudIrregZPos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIrregYPos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIrregXPos)).BeginInit();
            this.gbxIrregSkipCount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudIrregSkipCount)).BeginInit();
            this.gbxIrregReadMode.SuspendLayout();
            this.tabRegGrid.SuspendLayout();
            this.grpRegZData.SuspendLayout();
            this.pnlRegZReadMode.SuspendLayout();
            this.grpRegZRows.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRegZRowA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRegZRowB)).BeginInit();
            this.grpRegZCols.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRegZColA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRegZColB)).BeginInit();
            this.grpRegYData.SuspendLayout();
            this.grpRegYRange.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRegYRangeA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRegYRangeB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRegYPos)).BeginInit();
            this.grpRegXData.SuspendLayout();
            this.grpRegXRange.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRegXRangeA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRegXRangeB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRegXPos)).BeginInit();
            this.pnlSrcDataFilePath.SuspendLayout();
            this.tpgAxisData.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblYAxis)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblXAxis)).BeginInit();
            this.pnlAxisDataFilePath.SuspendLayout();
            this.tpgCalculation.SuspendLayout();
            this.pnlCalcParams.SuspendLayout();
            this.tlpCalcParams.SuspendLayout();
            this.grpShowParams.SuspendLayout();
            this.grpShowGraph.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pnlColorByDerType.SuspendLayout();
            this.gbxInterpParams.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbrInterpNQ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbrInterpNW)).BeginInit();
            this.tpgResults.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblResults)).BeginInit();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // mstMainMenu
            // 
            this.mstMainMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mstMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmiFile,
            this.tmiHelp});
            this.mstMainMenu.Location = new System.Drawing.Point(0, 0);
            this.mstMainMenu.Name = "mstMainMenu";
            this.mstMainMenu.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.mstMainMenu.Size = new System.Drawing.Size(792, 26);
            this.mstMainMenu.TabIndex = 23;
            this.mstMainMenu.Text = "menuStrip1";
            // 
            // tmiFile
            // 
            this.tmiFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmiFileLoad,
            this.tmiFileSave,
            this.tmiFileExit});
            this.tmiFile.Name = "tmiFile";
            this.tmiFile.Size = new System.Drawing.Size(54, 22);
            this.tmiFile.Text = "Файл";
            // 
            // tmiFileLoad
            // 
            this.tmiFileLoad.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmiFileLoadSourceData,
            this.tmiFileLoadAxisData,
            this.tmiFileLoadConfigData});
            this.tmiFileLoad.Name = "tmiFileLoad";
            this.tmiFileLoad.Size = new System.Drawing.Size(149, 22);
            this.tmiFileLoad.Text = "Открыть";
            // 
            // tmiFileLoadSourceData
            // 
            this.tmiFileLoadSourceData.Name = "tmiFileLoadSourceData";
            this.tmiFileLoadSourceData.Size = new System.Drawing.Size(214, 22);
            this.tmiFileLoadSourceData.Text = "Исходные данные";
            this.tmiFileLoadSourceData.Click += new System.EventHandler(this.tmiFileLoadSourceData_Click);
            // 
            // tmiFileLoadAxisData
            // 
            this.tmiFileLoadAxisData.Name = "tmiFileLoadAxisData";
            this.tmiFileLoadAxisData.Size = new System.Drawing.Size(214, 22);
            this.tmiFileLoadAxisData.Text = "Данные осей";
            this.tmiFileLoadAxisData.Click += new System.EventHandler(this.tmiFileLoadAxisData_Click);
            // 
            // tmiFileLoadConfigData
            // 
            this.tmiFileLoadConfigData.Name = "tmiFileLoadConfigData";
            this.tmiFileLoadConfigData.Size = new System.Drawing.Size(214, 22);
            this.tmiFileLoadConfigData.Text = "Параметры расчета";
            this.tmiFileLoadConfigData.Click += new System.EventHandler(this.tmiFileLoadConfigData_Click);
            // 
            // tmiFileSave
            // 
            this.tmiFileSave.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmiFileSaveConfigData,
            this.tmiFileSaveResultsData});
            this.tmiFileSave.Name = "tmiFileSave";
            this.tmiFileSave.Size = new System.Drawing.Size(149, 22);
            this.tmiFileSave.Text = "Сохранить";
            // 
            // tmiFileSaveConfigData
            // 
            this.tmiFileSaveConfigData.Name = "tmiFileSaveConfigData";
            this.tmiFileSaveConfigData.Size = new System.Drawing.Size(227, 22);
            this.tmiFileSaveConfigData.Text = "Параметры расчета";
            this.tmiFileSaveConfigData.Click += new System.EventHandler(this.tmiFileSaveConfigData_Click);
            // 
            // tmiFileSaveResultsData
            // 
            this.tmiFileSaveResultsData.Name = "tmiFileSaveResultsData";
            this.tmiFileSaveResultsData.Size = new System.Drawing.Size(227, 22);
            this.tmiFileSaveResultsData.Text = "Таблица результатов";
            this.tmiFileSaveResultsData.Click += new System.EventHandler(this.tmiFileSaveResultsData_Click);
            // 
            // tmiFileExit
            // 
            this.tmiFileExit.Name = "tmiFileExit";
            this.tmiFileExit.Size = new System.Drawing.Size(149, 22);
            this.tmiFileExit.Text = "Выход";
            this.tmiFileExit.Click += new System.EventHandler(this.tmiFileExit_Click);
            // 
            // tmiHelp
            // 
            this.tmiHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmiHelpOpenFile,
            this.tmiHelpAbout});
            this.tmiHelp.Name = "tmiHelp";
            this.tmiHelp.Size = new System.Drawing.Size(76, 22);
            this.tmiHelp.Text = "Справка";
            // 
            // tmiHelpOpenFile
            // 
            this.tmiHelpOpenFile.Name = "tmiHelpOpenFile";
            this.tmiHelpOpenFile.Size = new System.Drawing.Size(236, 22);
            this.tmiHelpOpenFile.Text = "Открыть файл справки";
            this.tmiHelpOpenFile.Click += new System.EventHandler(this.tmiHelpOpenFile_Click);
            // 
            // tmiHelpAbout
            // 
            this.tmiHelpAbout.Name = "tmiHelpAbout";
            this.tmiHelpAbout.Size = new System.Drawing.Size(236, 22);
            this.tmiHelpAbout.Text = "О программе";
            this.tmiHelpAbout.Click += new System.EventHandler(this.tmiHelpAbout_Click);
            // 
            // tctMain
            // 
            this.tctMain.Controls.Add(this.tpgData);
            this.tctMain.Controls.Add(this.tpgCalculation);
            this.tctMain.Controls.Add(this.tpgResults);
            this.tctMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tctMain.Location = new System.Drawing.Point(0, 26);
            this.tctMain.Name = "tctMain";
            this.tctMain.Padding = new System.Drawing.Point(5, 5);
            this.tctMain.SelectedIndex = 0;
            this.tctMain.Size = new System.Drawing.Size(792, 657);
            this.tctMain.TabIndex = 9;
            this.tctMain.SelectedIndexChanged += new System.EventHandler(this.tctMain_SelectedIndexChanged);
            // 
            // tpgData
            // 
            this.tpgData.BackColor = System.Drawing.Color.Transparent;
            this.tpgData.Controls.Add(this.tctData);
            this.tpgData.Location = new System.Drawing.Point(4, 29);
            this.tpgData.Name = "tpgData";
            this.tpgData.Padding = new System.Windows.Forms.Padding(3);
            this.tpgData.Size = new System.Drawing.Size(784, 624);
            this.tpgData.TabIndex = 4;
            this.tpgData.Text = "Данные";
            // 
            // tctData
            // 
            this.tctData.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tctData.Controls.Add(this.tpgSrcData);
            this.tctData.Controls.Add(this.tpgAxisData);
            this.tctData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tctData.Location = new System.Drawing.Point(3, 3);
            this.tctData.Name = "tctData";
            this.tctData.Padding = new System.Drawing.Point(5, 5);
            this.tctData.SelectedIndex = 0;
            this.tctData.Size = new System.Drawing.Size(778, 618);
            this.tctData.TabIndex = 22;
            // 
            // tpgSrcData
            // 
            this.tpgSrcData.Controls.Add(this.tblSource);
            this.tpgSrcData.Controls.Add(this.pnlSrcDataParams);
            this.tpgSrcData.Controls.Add(this.pnlSrcDataFilePath);
            this.tpgSrcData.Location = new System.Drawing.Point(4, 32);
            this.tpgSrcData.Name = "tpgSrcData";
            this.tpgSrcData.Padding = new System.Windows.Forms.Padding(3);
            this.tpgSrcData.Size = new System.Drawing.Size(770, 582);
            this.tpgSrcData.TabIndex = 0;
            this.tpgSrcData.Text = "Исходные данные";
            this.tpgSrcData.UseVisualStyleBackColor = true;
            // 
            // tblSource
            // 
            this.tblSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblSource.Location = new System.Drawing.Point(3, 53);
            this.tblSource.Name = "tblSource";
            this.tblSource.RowHeadersWidth = 50;
            this.tblSource.RowTemplate.DefaultCellStyle.NullValue = null;
            this.tblSource.Size = new System.Drawing.Size(464, 526);
            this.tblSource.TabIndex = 26;
            // 
            // pnlSrcDataParams
            // 
            this.pnlSrcDataParams.Controls.Add(this.btnCalculate);
            this.pnlSrcDataParams.Controls.Add(this.tctGridType);
            this.pnlSrcDataParams.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlSrcDataParams.Location = new System.Drawing.Point(467, 53);
            this.pnlSrcDataParams.Name = "pnlSrcDataParams";
            this.pnlSrcDataParams.Padding = new System.Windows.Forms.Padding(3);
            this.pnlSrcDataParams.Size = new System.Drawing.Size(300, 526);
            this.pnlSrcDataParams.TabIndex = 27;
            // 
            // btnCalculate
            // 
            this.btnCalculate.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnCalculate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCalculate.Location = new System.Drawing.Point(3, 483);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(294, 40);
            this.btnCalculate.TabIndex = 32;
            this.btnCalculate.Text = "Расчет";
            this.btnCalculate.UseMnemonic = false;
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // tctGridType
            // 
            this.tctGridType.Controls.Add(this.tabIrregGrid);
            this.tctGridType.Controls.Add(this.tabRegGrid);
            this.tctGridType.Dock = System.Windows.Forms.DockStyle.Top;
            this.tctGridType.Location = new System.Drawing.Point(3, 3);
            this.tctGridType.Name = "tctGridType";
            this.tctGridType.Padding = new System.Drawing.Point(5, 5);
            this.tctGridType.SelectedIndex = 0;
            this.tctGridType.Size = new System.Drawing.Size(294, 354);
            this.tctGridType.TabIndex = 17;
            // 
            // tabIrregGrid
            // 
            this.tabIrregGrid.AutoScroll = true;
            this.tabIrregGrid.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tabIrregGrid.Controls.Add(this.gbxIrregDataPosition);
            this.tabIrregGrid.Controls.Add(this.gbxIrregSkipCount);
            this.tabIrregGrid.Controls.Add(this.gbxIrregReadMode);
            this.tabIrregGrid.Location = new System.Drawing.Point(4, 29);
            this.tabIrregGrid.Name = "tabIrregGrid";
            this.tabIrregGrid.Padding = new System.Windows.Forms.Padding(5);
            this.tabIrregGrid.Size = new System.Drawing.Size(286, 321);
            this.tabIrregGrid.TabIndex = 0;
            this.tabIrregGrid.Text = "Нерегулярная сетка";
            // 
            // gbxIrregDataPosition
            // 
            this.gbxIrregDataPosition.Controls.Add(this.nudIrregZPos);
            this.gbxIrregDataPosition.Controls.Add(this.label4);
            this.gbxIrregDataPosition.Controls.Add(this.nudIrregYPos);
            this.gbxIrregDataPosition.Controls.Add(this.label3);
            this.gbxIrregDataPosition.Controls.Add(this.nudIrregXPos);
            this.gbxIrregDataPosition.Controls.Add(this.label2);
            this.gbxIrregDataPosition.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbxIrregDataPosition.Location = new System.Drawing.Point(5, 113);
            this.gbxIrregDataPosition.Margin = new System.Windows.Forms.Padding(4);
            this.gbxIrregDataPosition.Name = "gbxIrregDataPosition";
            this.gbxIrregDataPosition.Padding = new System.Windows.Forms.Padding(5);
            this.gbxIrregDataPosition.Size = new System.Drawing.Size(276, 122);
            this.gbxIrregDataPosition.TabIndex = 15;
            this.gbxIrregDataPosition.TabStop = false;
            this.gbxIrregDataPosition.Text = "Номера столбцов";
            // 
            // nudIrregZPos
            // 
            this.nudIrregZPos.Location = new System.Drawing.Point(144, 89);
            this.nudIrregZPos.Margin = new System.Windows.Forms.Padding(4);
            this.nudIrregZPos.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudIrregZPos.Name = "nudIrregZPos";
            this.nudIrregZPos.Size = new System.Drawing.Size(55, 22);
            this.nudIrregZPos.TabIndex = 14;
            this.nudIrregZPos.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(84, 92);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 17);
            this.label4.TabIndex = 15;
            this.label4.Text = "Z";
            // 
            // nudIrregYPos
            // 
            this.nudIrregYPos.Location = new System.Drawing.Point(144, 57);
            this.nudIrregYPos.Margin = new System.Windows.Forms.Padding(4);
            this.nudIrregYPos.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudIrregYPos.Name = "nudIrregYPos";
            this.nudIrregYPos.Size = new System.Drawing.Size(55, 22);
            this.nudIrregYPos.TabIndex = 12;
            this.nudIrregYPos.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(84, 60);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 17);
            this.label3.TabIndex = 13;
            this.label3.Text = "Y";
            // 
            // nudIrregXPos
            // 
            this.nudIrregXPos.Location = new System.Drawing.Point(144, 22);
            this.nudIrregXPos.Margin = new System.Windows.Forms.Padding(4);
            this.nudIrregXPos.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudIrregXPos.Name = "nudIrregXPos";
            this.nudIrregXPos.Size = new System.Drawing.Size(55, 22);
            this.nudIrregXPos.TabIndex = 10;
            this.nudIrregXPos.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(84, 25);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "X";
            // 
            // gbxIrregSkipCount
            // 
            this.gbxIrregSkipCount.Controls.Add(this.nudIrregSkipCount);
            this.gbxIrregSkipCount.Controls.Add(this.lblIrregSkipWhat);
            this.gbxIrregSkipCount.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbxIrregSkipCount.Location = new System.Drawing.Point(5, 61);
            this.gbxIrregSkipCount.Margin = new System.Windows.Forms.Padding(4);
            this.gbxIrregSkipCount.Name = "gbxIrregSkipCount";
            this.gbxIrregSkipCount.Padding = new System.Windows.Forms.Padding(5);
            this.gbxIrregSkipCount.Size = new System.Drawing.Size(276, 52);
            this.gbxIrregSkipCount.TabIndex = 16;
            this.gbxIrregSkipCount.TabStop = false;
            this.gbxIrregSkipCount.Text = "Пропустить";
            // 
            // nudIrregSkipCount
            // 
            this.nudIrregSkipCount.Location = new System.Drawing.Point(84, 21);
            this.nudIrregSkipCount.Margin = new System.Windows.Forms.Padding(4);
            this.nudIrregSkipCount.Name = "nudIrregSkipCount";
            this.nudIrregSkipCount.Size = new System.Drawing.Size(55, 22);
            this.nudIrregSkipCount.TabIndex = 11;
            // 
            // lblIrregSkipWhat
            // 
            this.lblIrregSkipWhat.AutoSize = true;
            this.lblIrregSkipWhat.Location = new System.Drawing.Point(154, 24);
            this.lblIrregSkipWhat.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIrregSkipWhat.Name = "lblIrregSkipWhat";
            this.lblIrregSkipWhat.Size = new System.Drawing.Size(45, 17);
            this.lblIrregSkipWhat.TabIndex = 13;
            this.lblIrregSkipWhat.Text = "строк";
            // 
            // gbxIrregReadMode
            // 
            this.gbxIrregReadMode.Controls.Add(this.cbxIrregReadMode);
            this.gbxIrregReadMode.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbxIrregReadMode.Location = new System.Drawing.Point(5, 5);
            this.gbxIrregReadMode.Name = "gbxIrregReadMode";
            this.gbxIrregReadMode.Padding = new System.Windows.Forms.Padding(5);
            this.gbxIrregReadMode.Size = new System.Drawing.Size(276, 56);
            this.gbxIrregReadMode.TabIndex = 23;
            this.gbxIrregReadMode.TabStop = false;
            this.gbxIrregReadMode.Text = "Считывать значения по";
            // 
            // cbxIrregReadMode
            // 
            this.cbxIrregReadMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxIrregReadMode.FormattingEnabled = true;
            this.cbxIrregReadMode.Items.AddRange(new object[] {
            "строкам",
            "столбцам"});
            this.cbxIrregReadMode.Location = new System.Drawing.Point(84, 23);
            this.cbxIrregReadMode.Margin = new System.Windows.Forms.Padding(4);
            this.cbxIrregReadMode.Name = "cbxIrregReadMode";
            this.cbxIrregReadMode.Size = new System.Drawing.Size(115, 24);
            this.cbxIrregReadMode.TabIndex = 22;
            this.cbxIrregReadMode.SelectedIndexChanged += new System.EventHandler(this.cbxReadMode_SelectedIndexChanged);
            // 
            // tabRegGrid
            // 
            this.tabRegGrid.Controls.Add(this.grpRegZData);
            this.tabRegGrid.Controls.Add(this.grpRegYData);
            this.tabRegGrid.Controls.Add(this.grpRegXData);
            this.tabRegGrid.Location = new System.Drawing.Point(4, 29);
            this.tabRegGrid.Name = "tabRegGrid";
            this.tabRegGrid.Padding = new System.Windows.Forms.Padding(3);
            this.tabRegGrid.Size = new System.Drawing.Size(286, 321);
            this.tabRegGrid.TabIndex = 1;
            this.tabRegGrid.Text = "Регулярная сетка";
            this.tabRegGrid.UseVisualStyleBackColor = true;
            // 
            // grpRegZData
            // 
            this.grpRegZData.Controls.Add(this.pnlRegZReadMode);
            this.grpRegZData.Controls.Add(this.grpRegZRows);
            this.grpRegZData.Controls.Add(this.grpRegZCols);
            this.grpRegZData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpRegZData.Location = new System.Drawing.Point(3, 213);
            this.grpRegZData.Name = "grpRegZData";
            this.grpRegZData.Size = new System.Drawing.Size(280, 105);
            this.grpRegZData.TabIndex = 2;
            this.grpRegZData.TabStop = false;
            this.grpRegZData.Text = "Значения Z";
            // 
            // pnlRegZReadMode
            // 
            this.pnlRegZReadMode.Controls.Add(this.rbtRegReadYX);
            this.pnlRegZReadMode.Controls.Add(this.rbtRegReadXY);
            this.pnlRegZReadMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRegZReadMode.Location = new System.Drawing.Point(3, 18);
            this.pnlRegZReadMode.Name = "pnlRegZReadMode";
            this.pnlRegZReadMode.Padding = new System.Windows.Forms.Padding(3);
            this.pnlRegZReadMode.Size = new System.Drawing.Size(110, 84);
            this.pnlRegZReadMode.TabIndex = 8;
            // 
            // rbtRegReadYX
            // 
            this.rbtRegReadYX.AutoSize = true;
            this.rbtRegReadYX.Location = new System.Drawing.Point(26, 50);
            this.rbtRegReadYX.Name = "rbtRegReadYX";
            this.rbtRegReadYX.Size = new System.Drawing.Size(51, 21);
            this.rbtRegReadYX.TabIndex = 1;
            this.rbtRegReadYX.Text = "Y\\X";
            this.rbtRegReadYX.UseVisualStyleBackColor = true;
            // 
            // rbtRegReadXY
            // 
            this.rbtRegReadXY.AutoSize = true;
            this.rbtRegReadXY.Checked = true;
            this.rbtRegReadXY.Location = new System.Drawing.Point(26, 22);
            this.rbtRegReadXY.Name = "rbtRegReadXY";
            this.rbtRegReadXY.Size = new System.Drawing.Size(51, 21);
            this.rbtRegReadXY.TabIndex = 0;
            this.rbtRegReadXY.TabStop = true;
            this.rbtRegReadXY.Text = "X\\Y";
            this.rbtRegReadXY.UseVisualStyleBackColor = true;
            // 
            // grpRegZRows
            // 
            this.grpRegZRows.Controls.Add(this.nudRegZRowA);
            this.grpRegZRows.Controls.Add(this.nudRegZRowB);
            this.grpRegZRows.Dock = System.Windows.Forms.DockStyle.Right;
            this.grpRegZRows.Location = new System.Drawing.Point(113, 18);
            this.grpRegZRows.Name = "grpRegZRows";
            this.grpRegZRows.Size = new System.Drawing.Size(82, 84);
            this.grpRegZRows.TabIndex = 6;
            this.grpRegZRows.TabStop = false;
            this.grpRegZRows.Text = "строки";
            // 
            // nudRegZRowA
            // 
            this.nudRegZRowA.Location = new System.Drawing.Point(15, 21);
            this.nudRegZRowA.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRegZRowA.Name = "nudRegZRowA";
            this.nudRegZRowA.Size = new System.Drawing.Size(55, 22);
            this.nudRegZRowA.TabIndex = 6;
            this.nudRegZRowA.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudRegZRowB
            // 
            this.nudRegZRowB.Location = new System.Drawing.Point(15, 49);
            this.nudRegZRowB.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRegZRowB.Name = "nudRegZRowB";
            this.nudRegZRowB.Size = new System.Drawing.Size(55, 22);
            this.nudRegZRowB.TabIndex = 5;
            this.nudRegZRowB.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // grpRegZCols
            // 
            this.grpRegZCols.Controls.Add(this.nudRegZColA);
            this.grpRegZCols.Controls.Add(this.nudRegZColB);
            this.grpRegZCols.Dock = System.Windows.Forms.DockStyle.Right;
            this.grpRegZCols.Location = new System.Drawing.Point(195, 18);
            this.grpRegZCols.Margin = new System.Windows.Forms.Padding(0);
            this.grpRegZCols.Name = "grpRegZCols";
            this.grpRegZCols.Size = new System.Drawing.Size(82, 84);
            this.grpRegZCols.TabIndex = 7;
            this.grpRegZCols.TabStop = false;
            this.grpRegZCols.Text = "столбцы";
            // 
            // nudRegZColA
            // 
            this.nudRegZColA.Location = new System.Drawing.Point(15, 21);
            this.nudRegZColA.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRegZColA.Name = "nudRegZColA";
            this.nudRegZColA.Size = new System.Drawing.Size(55, 22);
            this.nudRegZColA.TabIndex = 6;
            this.nudRegZColA.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudRegZColB
            // 
            this.nudRegZColB.Location = new System.Drawing.Point(15, 49);
            this.nudRegZColB.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRegZColB.Name = "nudRegZColB";
            this.nudRegZColB.Size = new System.Drawing.Size(55, 22);
            this.nudRegZColB.TabIndex = 5;
            this.nudRegZColB.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // grpRegYData
            // 
            this.grpRegYData.Controls.Add(this.grpRegYRange);
            this.grpRegYData.Controls.Add(this.lblRegYPos);
            this.grpRegYData.Controls.Add(this.nudRegYPos);
            this.grpRegYData.Controls.Add(this.rbtRegYCol);
            this.grpRegYData.Controls.Add(this.rbtRegYRow);
            this.grpRegYData.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpRegYData.Location = new System.Drawing.Point(3, 108);
            this.grpRegYData.Name = "grpRegYData";
            this.grpRegYData.Size = new System.Drawing.Size(280, 105);
            this.grpRegYData.TabIndex = 3;
            this.grpRegYData.TabStop = false;
            this.grpRegYData.Text = "Значения Y";
            // 
            // grpRegYRange
            // 
            this.grpRegYRange.Controls.Add(this.nudRegYRangeA);
            this.grpRegYRange.Controls.Add(this.nudRegYRangeB);
            this.grpRegYRange.Location = new System.Drawing.Point(104, 48);
            this.grpRegYRange.Name = "grpRegYRange";
            this.grpRegYRange.Size = new System.Drawing.Size(170, 50);
            this.grpRegYRange.TabIndex = 6;
            this.grpRegYRange.TabStop = false;
            this.grpRegYRange.Text = "диапазон строк";
            // 
            // nudRegYRangeA
            // 
            this.nudRegYRangeA.Location = new System.Drawing.Point(6, 21);
            this.nudRegYRangeA.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRegYRangeA.Name = "nudRegYRangeA";
            this.nudRegYRangeA.Size = new System.Drawing.Size(55, 22);
            this.nudRegYRangeA.TabIndex = 6;
            this.nudRegYRangeA.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudRegYRangeB
            // 
            this.nudRegYRangeB.Location = new System.Drawing.Point(110, 21);
            this.nudRegYRangeB.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRegYRangeB.Name = "nudRegYRangeB";
            this.nudRegYRangeB.Size = new System.Drawing.Size(55, 22);
            this.nudRegYRangeB.TabIndex = 5;
            this.nudRegYRangeB.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblRegYPos
            // 
            this.lblRegYPos.AutoSize = true;
            this.lblRegYPos.Location = new System.Drawing.Point(104, 23);
            this.lblRegYPos.Name = "lblRegYPos";
            this.lblRegYPos.Size = new System.Drawing.Size(98, 17);
            this.lblRegYPos.TabIndex = 5;
            this.lblRegYPos.Text = "номер строки";
            // 
            // nudRegYPos
            // 
            this.nudRegYPos.Location = new System.Drawing.Point(219, 20);
            this.nudRegYPos.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRegYPos.Name = "nudRegYPos";
            this.nudRegYPos.Size = new System.Drawing.Size(55, 22);
            this.nudRegYPos.TabIndex = 2;
            this.nudRegYPos.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // rbtRegYCol
            // 
            this.rbtRegYCol.AutoSize = true;
            this.rbtRegYCol.Location = new System.Drawing.Point(6, 48);
            this.rbtRegYCol.Name = "rbtRegYCol";
            this.rbtRegYCol.Size = new System.Drawing.Size(83, 21);
            this.rbtRegYCol.TabIndex = 1;
            this.rbtRegYCol.Text = "столбец";
            this.rbtRegYCol.UseVisualStyleBackColor = true;
            this.rbtRegYCol.CheckedChanged += new System.EventHandler(this.IrregReadDirChange);
            // 
            // rbtRegYRow
            // 
            this.rbtRegYRow.AutoSize = true;
            this.rbtRegYRow.Checked = true;
            this.rbtRegYRow.Location = new System.Drawing.Point(6, 21);
            this.rbtRegYRow.Name = "rbtRegYRow";
            this.rbtRegYRow.Size = new System.Drawing.Size(74, 21);
            this.rbtRegYRow.TabIndex = 0;
            this.rbtRegYRow.TabStop = true;
            this.rbtRegYRow.Text = "строка";
            this.rbtRegYRow.UseVisualStyleBackColor = true;
            this.rbtRegYRow.CheckedChanged += new System.EventHandler(this.IrregReadDirChange);
            // 
            // grpRegXData
            // 
            this.grpRegXData.Controls.Add(this.grpRegXRange);
            this.grpRegXData.Controls.Add(this.lblRegXPos);
            this.grpRegXData.Controls.Add(this.nudRegXPos);
            this.grpRegXData.Controls.Add(this.rbtRegXCol);
            this.grpRegXData.Controls.Add(this.rbtRegXRow);
            this.grpRegXData.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpRegXData.Location = new System.Drawing.Point(3, 3);
            this.grpRegXData.Name = "grpRegXData";
            this.grpRegXData.Size = new System.Drawing.Size(280, 105);
            this.grpRegXData.TabIndex = 4;
            this.grpRegXData.TabStop = false;
            this.grpRegXData.Text = "Значения X";
            // 
            // grpRegXRange
            // 
            this.grpRegXRange.Controls.Add(this.nudRegXRangeA);
            this.grpRegXRange.Controls.Add(this.nudRegXRangeB);
            this.grpRegXRange.Location = new System.Drawing.Point(104, 48);
            this.grpRegXRange.Name = "grpRegXRange";
            this.grpRegXRange.Size = new System.Drawing.Size(170, 50);
            this.grpRegXRange.TabIndex = 6;
            this.grpRegXRange.TabStop = false;
            this.grpRegXRange.Text = "диапазон строк";
            // 
            // nudRegXRangeA
            // 
            this.nudRegXRangeA.Location = new System.Drawing.Point(6, 21);
            this.nudRegXRangeA.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRegXRangeA.Name = "nudRegXRangeA";
            this.nudRegXRangeA.Size = new System.Drawing.Size(55, 22);
            this.nudRegXRangeA.TabIndex = 6;
            this.nudRegXRangeA.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudRegXRangeB
            // 
            this.nudRegXRangeB.Location = new System.Drawing.Point(110, 21);
            this.nudRegXRangeB.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRegXRangeB.Name = "nudRegXRangeB";
            this.nudRegXRangeB.Size = new System.Drawing.Size(55, 22);
            this.nudRegXRangeB.TabIndex = 5;
            this.nudRegXRangeB.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblRegXPos
            // 
            this.lblRegXPos.AutoSize = true;
            this.lblRegXPos.Location = new System.Drawing.Point(104, 23);
            this.lblRegXPos.Name = "lblRegXPos";
            this.lblRegXPos.Size = new System.Drawing.Size(107, 17);
            this.lblRegXPos.TabIndex = 5;
            this.lblRegXPos.Text = "номер столбца";
            // 
            // nudRegXPos
            // 
            this.nudRegXPos.Location = new System.Drawing.Point(219, 20);
            this.nudRegXPos.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRegXPos.Name = "nudRegXPos";
            this.nudRegXPos.Size = new System.Drawing.Size(55, 22);
            this.nudRegXPos.TabIndex = 2;
            this.nudRegXPos.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // rbtRegXCol
            // 
            this.rbtRegXCol.AutoSize = true;
            this.rbtRegXCol.Checked = true;
            this.rbtRegXCol.Location = new System.Drawing.Point(6, 48);
            this.rbtRegXCol.Name = "rbtRegXCol";
            this.rbtRegXCol.Size = new System.Drawing.Size(83, 21);
            this.rbtRegXCol.TabIndex = 1;
            this.rbtRegXCol.TabStop = true;
            this.rbtRegXCol.Text = "столбец";
            this.rbtRegXCol.UseVisualStyleBackColor = true;
            this.rbtRegXCol.CheckedChanged += new System.EventHandler(this.IrregReadDirChange);
            // 
            // rbtRegXRow
            // 
            this.rbtRegXRow.AutoSize = true;
            this.rbtRegXRow.Location = new System.Drawing.Point(6, 21);
            this.rbtRegXRow.Name = "rbtRegXRow";
            this.rbtRegXRow.Size = new System.Drawing.Size(74, 21);
            this.rbtRegXRow.TabIndex = 0;
            this.rbtRegXRow.Text = "строка";
            this.rbtRegXRow.UseVisualStyleBackColor = true;
            this.rbtRegXRow.CheckedChanged += new System.EventHandler(this.IrregReadDirChange);
            // 
            // pnlSrcDataFilePath
            // 
            this.pnlSrcDataFilePath.Controls.Add(this.lblSrcDataFilePath);
            this.pnlSrcDataFilePath.Controls.Add(this.tbxSrcDataFilePath);
            this.pnlSrcDataFilePath.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSrcDataFilePath.Location = new System.Drawing.Point(3, 3);
            this.pnlSrcDataFilePath.Name = "pnlSrcDataFilePath";
            this.pnlSrcDataFilePath.Padding = new System.Windows.Forms.Padding(5);
            this.pnlSrcDataFilePath.Size = new System.Drawing.Size(764, 50);
            this.pnlSrcDataFilePath.TabIndex = 22;
            // 
            // lblSrcDataFilePath
            // 
            this.lblSrcDataFilePath.AutoSize = true;
            this.lblSrcDataFilePath.Location = new System.Drawing.Point(9, 17);
            this.lblSrcDataFilePath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSrcDataFilePath.Name = "lblSrcDataFilePath";
            this.lblSrcDataFilePath.Size = new System.Drawing.Size(97, 17);
            this.lblSrcDataFilePath.TabIndex = 14;
            this.lblSrcDataFilePath.Text = "Файл данных";
            // 
            // tbxSrcDataFilePath
            // 
            this.tbxSrcDataFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxSrcDataFilePath.Location = new System.Drawing.Point(114, 14);
            this.tbxSrcDataFilePath.Margin = new System.Windows.Forms.Padding(4);
            this.tbxSrcDataFilePath.Name = "tbxSrcDataFilePath";
            this.tbxSrcDataFilePath.ReadOnly = true;
            this.tbxSrcDataFilePath.Size = new System.Drawing.Size(645, 22);
            this.tbxSrcDataFilePath.TabIndex = 4;
            // 
            // tpgAxisData
            // 
            this.tpgAxisData.Controls.Add(this.groupBox4);
            this.tpgAxisData.Controls.Add(this.groupBox2);
            this.tpgAxisData.Controls.Add(this.pnlAxisDataFilePath);
            this.tpgAxisData.Location = new System.Drawing.Point(4, 32);
            this.tpgAxisData.Name = "tpgAxisData";
            this.tpgAxisData.Padding = new System.Windows.Forms.Padding(3);
            this.tpgAxisData.Size = new System.Drawing.Size(770, 582);
            this.tpgAxisData.TabIndex = 1;
            this.tpgAxisData.Text = "Данные осей";
            this.tpgAxisData.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tblYAxis);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Location = new System.Drawing.Point(3, 151);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(764, 98);
            this.groupBox4.TabIndex = 27;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Значения оси Y";
            // 
            // tblYAxis
            // 
            this.tblYAxis.AllowUserToAddRows = false;
            this.tblYAxis.AllowUserToDeleteRows = false;
            this.tblYAxis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblYAxis.Location = new System.Drawing.Point(3, 18);
            this.tblYAxis.Name = "tblYAxis";
            this.tblYAxis.RowTemplate.DefaultCellStyle.NullValue = null;
            this.tblYAxis.Size = new System.Drawing.Size(758, 77);
            this.tblYAxis.TabIndex = 25;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tblXAxis);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 53);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(764, 98);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Значения оси X";
            // 
            // tblXAxis
            // 
            this.tblXAxis.AllowUserToAddRows = false;
            this.tblXAxis.AllowUserToDeleteRows = false;
            this.tblXAxis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblXAxis.Location = new System.Drawing.Point(3, 18);
            this.tblXAxis.Name = "tblXAxis";
            this.tblXAxis.RowTemplate.DefaultCellStyle.NullValue = null;
            this.tblXAxis.Size = new System.Drawing.Size(758, 77);
            this.tblXAxis.TabIndex = 25;
            // 
            // pnlAxisDataFilePath
            // 
            this.pnlAxisDataFilePath.Controls.Add(this.label6);
            this.pnlAxisDataFilePath.Controls.Add(this.tbxAxisFileName);
            this.pnlAxisDataFilePath.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAxisDataFilePath.Location = new System.Drawing.Point(3, 3);
            this.pnlAxisDataFilePath.Margin = new System.Windows.Forms.Padding(4);
            this.pnlAxisDataFilePath.Name = "pnlAxisDataFilePath";
            this.pnlAxisDataFilePath.Padding = new System.Windows.Forms.Padding(5);
            this.pnlAxisDataFilePath.Size = new System.Drawing.Size(764, 50);
            this.pnlAxisDataFilePath.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 17);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 17);
            this.label6.TabIndex = 15;
            this.label6.Text = "Файл осей";
            // 
            // tbxAxisFileName
            // 
            this.tbxAxisFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxAxisFileName.Location = new System.Drawing.Point(114, 14);
            this.tbxAxisFileName.Margin = new System.Windows.Forms.Padding(4);
            this.tbxAxisFileName.Name = "tbxAxisFileName";
            this.tbxAxisFileName.ReadOnly = true;
            this.tbxAxisFileName.Size = new System.Drawing.Size(645, 22);
            this.tbxAxisFileName.TabIndex = 12;
            // 
            // tpgCalculation
            // 
            this.tpgCalculation.Controls.Add(this.pnlCalcParams);
            this.tpgCalculation.Controls.Add(this.glControl);
            this.tpgCalculation.Location = new System.Drawing.Point(4, 29);
            this.tpgCalculation.Margin = new System.Windows.Forms.Padding(4);
            this.tpgCalculation.Name = "tpgCalculation";
            this.tpgCalculation.Padding = new System.Windows.Forms.Padding(5);
            this.tpgCalculation.Size = new System.Drawing.Size(784, 624);
            this.tpgCalculation.TabIndex = 3;
            this.tpgCalculation.Text = "Расчет";
            this.tpgCalculation.UseVisualStyleBackColor = true;
            // 
            // pnlCalcParams
            // 
            this.pnlCalcParams.Controls.Add(this.tlpCalcParams);
            this.pnlCalcParams.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlCalcParams.Location = new System.Drawing.Point(479, 5);
            this.pnlCalcParams.Name = "pnlCalcParams";
            this.pnlCalcParams.Padding = new System.Windows.Forms.Padding(3);
            this.pnlCalcParams.Size = new System.Drawing.Size(300, 614);
            this.pnlCalcParams.TabIndex = 3;
            // 
            // tlpCalcParams
            // 
            this.tlpCalcParams.ColumnCount = 1;
            this.tlpCalcParams.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCalcParams.Controls.Add(this.grpShowParams, 0, 2);
            this.tlpCalcParams.Controls.Add(this.lblDifferences, 0, 0);
            this.tlpCalcParams.Controls.Add(this.gbxInterpParams, 0, 1);
            this.tlpCalcParams.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCalcParams.Location = new System.Drawing.Point(3, 3);
            this.tlpCalcParams.Name = "tlpCalcParams";
            this.tlpCalcParams.RowCount = 3;
            this.tlpCalcParams.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tlpCalcParams.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tlpCalcParams.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCalcParams.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpCalcParams.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpCalcParams.Size = new System.Drawing.Size(294, 608);
            this.tlpCalcParams.TabIndex = 0;
            // 
            // grpShowParams
            // 
            this.grpShowParams.Controls.Add(this.chkShowPointsProjections);
            this.grpShowParams.Controls.Add(this.chkShowHiddenPoints);
            this.grpShowParams.Controls.Add(this.grpShowGraph);
            this.grpShowParams.Controls.Add(this.chkShowSourcePoints);
            this.grpShowParams.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpShowParams.Location = new System.Drawing.Point(3, 306);
            this.grpShowParams.Name = "grpShowParams";
            this.grpShowParams.Padding = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.grpShowParams.Size = new System.Drawing.Size(288, 294);
            this.grpShowParams.TabIndex = 0;
            this.grpShowParams.TabStop = false;
            this.grpShowParams.Text = "Отображение";
            // 
            // chkShowPointsProjections
            // 
            this.chkShowPointsProjections.AutoSize = true;
            this.chkShowPointsProjections.Checked = true;
            this.chkShowPointsProjections.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowPointsProjections.Location = new System.Drawing.Point(26, 267);
            this.chkShowPointsProjections.Name = "chkShowPointsProjections";
            this.chkShowPointsProjections.Size = new System.Drawing.Size(216, 21);
            this.chkShowPointsProjections.TabIndex = 31;
            this.chkShowPointsProjections.Text = "показывать проекции точек";
            this.chkShowPointsProjections.UseVisualStyleBackColor = true;
            this.chkShowPointsProjections.CheckedChanged += new System.EventHandler(this.DrawingParamsChanged);
            // 
            // chkShowHiddenPoints
            // 
            this.chkShowHiddenPoints.AutoSize = true;
            this.chkShowHiddenPoints.Location = new System.Drawing.Point(26, 240);
            this.chkShowHiddenPoints.Name = "chkShowHiddenPoints";
            this.chkShowHiddenPoints.Size = new System.Drawing.Size(210, 21);
            this.chkShowHiddenPoints.TabIndex = 25;
            this.chkShowHiddenPoints.Tag = "";
            this.chkShowHiddenPoints.Text = "показывать скрытые точки";
            this.chkShowHiddenPoints.UseVisualStyleBackColor = true;
            this.chkShowHiddenPoints.CheckedChanged += new System.EventHandler(this.DrawingParamsChanged);
            // 
            // grpShowGraph
            // 
            this.grpShowGraph.Controls.Add(this.chkShowGraph);
            this.grpShowGraph.Controls.Add(this.rbtDrawSurface);
            this.grpShowGraph.Controls.Add(this.rbtDrawGrid);
            this.grpShowGraph.Controls.Add(this.groupBox1);
            this.grpShowGraph.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpShowGraph.Location = new System.Drawing.Point(3, 23);
            this.grpShowGraph.Name = "grpShowGraph";
            this.grpShowGraph.Size = new System.Drawing.Size(282, 184);
            this.grpShowGraph.TabIndex = 24;
            this.grpShowGraph.TabStop = false;
            // 
            // chkShowGraph
            // 
            this.chkShowGraph.AutoSize = true;
            this.chkShowGraph.Checked = true;
            this.chkShowGraph.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowGraph.Location = new System.Drawing.Point(6, -2);
            this.chkShowGraph.Name = "chkShowGraph";
            this.chkShowGraph.Size = new System.Drawing.Size(158, 21);
            this.chkShowGraph.TabIndex = 30;
            this.chkShowGraph.Text = "показывать график";
            this.chkShowGraph.UseVisualStyleBackColor = true;
            this.chkShowGraph.CheckedChanged += new System.EventHandler(this.DrawingParamsChanged);
            // 
            // rbtDrawSurface
            // 
            this.rbtDrawSurface.AutoSize = true;
            this.rbtDrawSurface.Location = new System.Drawing.Point(165, 25);
            this.rbtDrawSurface.Name = "rbtDrawSurface";
            this.rbtDrawSurface.Size = new System.Drawing.Size(111, 21);
            this.rbtDrawSurface.TabIndex = 23;
            this.rbtDrawSurface.Text = "поверхность";
            this.rbtDrawSurface.UseVisualStyleBackColor = true;
            this.rbtDrawSurface.CheckedChanged += new System.EventHandler(this.DrawingParamsChanged);
            // 
            // rbtDrawGrid
            // 
            this.rbtDrawGrid.AutoSize = true;
            this.rbtDrawGrid.Checked = true;
            this.rbtDrawGrid.Location = new System.Drawing.Point(6, 25);
            this.rbtDrawGrid.Name = "rbtDrawGrid";
            this.rbtDrawGrid.Size = new System.Drawing.Size(66, 21);
            this.rbtDrawGrid.TabIndex = 23;
            this.rbtDrawGrid.TabStop = true;
            this.rbtDrawGrid.Text = "сетка";
            this.rbtDrawGrid.UseVisualStyleBackColor = true;
            this.rbtDrawGrid.CheckedChanged += new System.EventHandler(this.DrawingParamsChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pnlColorByDerType);
            this.groupBox1.Controls.Add(this.rbtColorByDer);
            this.groupBox1.Controls.Add(this.rbtOneColor);
            this.groupBox1.Controls.Add(this.rbtColorByValue);
            this.groupBox1.Location = new System.Drawing.Point(6, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(270, 126);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Окрашивание";
            // 
            // pnlColorByDerType
            // 
            this.pnlColorByDerType.Controls.Add(this.rbtColorByDerY);
            this.pnlColorByDerType.Controls.Add(this.rbtColorByDerX);
            this.pnlColorByDerType.Enabled = false;
            this.pnlColorByDerType.Location = new System.Drawing.Point(45, 92);
            this.pnlColorByDerType.Name = "pnlColorByDerType";
            this.pnlColorByDerType.Size = new System.Drawing.Size(182, 28);
            this.pnlColorByDerType.TabIndex = 32;
            // 
            // rbtColorByDerY
            // 
            this.rbtColorByDerY.AutoSize = true;
            this.rbtColorByDerY.Location = new System.Drawing.Point(121, 3);
            this.rbtColorByDerY.Name = "rbtColorByDerY";
            this.rbtColorByDerY.Size = new System.Drawing.Size(58, 21);
            this.rbtColorByDerY.TabIndex = 29;
            this.rbtColorByDerY.Text = "по Y";
            this.rbtColorByDerY.UseVisualStyleBackColor = true;
            this.rbtColorByDerY.CheckedChanged += new System.EventHandler(this.DrawingParamsChanged);
            // 
            // rbtColorByDerX
            // 
            this.rbtColorByDerX.AutoSize = true;
            this.rbtColorByDerX.Location = new System.Drawing.Point(3, 3);
            this.rbtColorByDerX.Name = "rbtColorByDerX";
            this.rbtColorByDerX.Size = new System.Drawing.Size(58, 21);
            this.rbtColorByDerX.TabIndex = 28;
            this.rbtColorByDerX.Text = "по X";
            this.rbtColorByDerX.UseVisualStyleBackColor = true;
            this.rbtColorByDerX.CheckedChanged += new System.EventHandler(this.DrawingParamsChanged);
            // 
            // rbtColorByDer
            // 
            this.rbtColorByDer.AutoSize = true;
            this.rbtColorByDer.Location = new System.Drawing.Point(6, 72);
            this.rbtColorByDer.Name = "rbtColorByDer";
            this.rbtColorByDer.Size = new System.Drawing.Size(182, 21);
            this.rbtColorByDer.TabIndex = 30;
            this.rbtColorByDer.Text = "значение производной";
            this.rbtColorByDer.UseVisualStyleBackColor = true;
            this.rbtColorByDer.CheckedChanged += new System.EventHandler(this.DrawingParamsChanged);
            // 
            // rbtOneColor
            // 
            this.rbtOneColor.AutoSize = true;
            this.rbtOneColor.Checked = true;
            this.rbtOneColor.Location = new System.Drawing.Point(6, 21);
            this.rbtOneColor.Name = "rbtOneColor";
            this.rbtOneColor.Size = new System.Drawing.Size(95, 21);
            this.rbtOneColor.TabIndex = 26;
            this.rbtOneColor.TabStop = true;
            this.rbtOneColor.Text = "один цвет";
            this.rbtOneColor.UseVisualStyleBackColor = true;
            this.rbtOneColor.CheckedChanged += new System.EventHandler(this.DrawingParamsChanged);
            // 
            // rbtColorByValue
            // 
            this.rbtColorByValue.AutoSize = true;
            this.rbtColorByValue.Location = new System.Drawing.Point(6, 47);
            this.rbtColorByValue.Name = "rbtColorByValue";
            this.rbtColorByValue.Size = new System.Drawing.Size(153, 21);
            this.rbtColorByValue.TabIndex = 27;
            this.rbtColorByValue.Text = "значение функции";
            this.rbtColorByValue.UseVisualStyleBackColor = true;
            this.rbtColorByValue.CheckedChanged += new System.EventHandler(this.DrawingParamsChanged);
            // 
            // chkShowSourcePoints
            // 
            this.chkShowSourcePoints.AutoSize = true;
            this.chkShowSourcePoints.Checked = true;
            this.chkShowSourcePoints.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowSourcePoints.Location = new System.Drawing.Point(9, 213);
            this.chkShowSourcePoints.Name = "chkShowSourcePoints";
            this.chkShowSourcePoints.Size = new System.Drawing.Size(216, 21);
            this.chkShowSourcePoints.TabIndex = 24;
            this.chkShowSourcePoints.Text = "показывать исходные точки";
            this.chkShowSourcePoints.UseVisualStyleBackColor = true;
            this.chkShowSourcePoints.CheckedChanged += new System.EventHandler(this.DrawingParamsChanged);
            // 
            // lblDifferences
            // 
            this.lblDifferences.AutoSize = true;
            this.lblDifferences.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDifferences.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDifferences.Location = new System.Drawing.Point(3, 0);
            this.lblDifferences.Name = "lblDifferences";
            this.lblDifferences.Size = new System.Drawing.Size(288, 91);
            this.lblDifferences.TabIndex = 31;
            this.lblDifferences.Text = "макс. полож. откл:\r\nмакс. отриц. откл:\r\nсред. откл:";
            // 
            // gbxInterpParams
            // 
            this.gbxInterpParams.Controls.Add(this.label7);
            this.gbxInterpParams.Controls.Add(this.label5);
            this.gbxInterpParams.Controls.Add(this.label1);
            this.gbxInterpParams.Controls.Add(this.cbxIrregInterpMethod);
            this.gbxInterpParams.Controls.Add(this.chkAutoUpdate);
            this.gbxInterpParams.Controls.Add(this.tbrInterpNQ);
            this.gbxInterpParams.Controls.Add(this.tbrInterpNW);
            this.gbxInterpParams.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbxInterpParams.Location = new System.Drawing.Point(4, 95);
            this.gbxInterpParams.Margin = new System.Windows.Forms.Padding(4);
            this.gbxInterpParams.Name = "gbxInterpParams";
            this.gbxInterpParams.Padding = new System.Windows.Forms.Padding(5);
            this.gbxInterpParams.Size = new System.Drawing.Size(286, 202);
            this.gbxInterpParams.TabIndex = 18;
            this.gbxInterpParams.TabStop = false;
            this.gbxInterpParams.Text = "Интерполяция";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(8, 129);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 23);
            this.label7.TabIndex = 26;
            this.label7.Text = "NW";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(8, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 23);
            this.label5.TabIndex = 25;
            this.label5.Text = "NQ";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 23);
            this.label1.TabIndex = 24;
            this.label1.Text = "метод ";
            // 
            // cbxIrregInterpMethod
            // 
            this.cbxIrregInterpMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxIrregInterpMethod.FormattingEnabled = true;
            this.cbxIrregInterpMethod.Items.AddRange(new object[] {
            "линейный",
            "квадратичный"});
            this.cbxIrregInterpMethod.Location = new System.Drawing.Point(90, 24);
            this.cbxIrregInterpMethod.Margin = new System.Windows.Forms.Padding(4);
            this.cbxIrregInterpMethod.Name = "cbxIrregInterpMethod";
            this.cbxIrregInterpMethod.Size = new System.Drawing.Size(157, 24);
            this.cbxIrregInterpMethod.TabIndex = 23;
            this.cbxIrregInterpMethod.SelectedIndexChanged += new System.EventHandler(this.InterpParamsChanged);
            // 
            // chkAutoUpdate
            // 
            this.chkAutoUpdate.AutoSize = true;
            this.chkAutoUpdate.Location = new System.Drawing.Point(11, 173);
            this.chkAutoUpdate.Name = "chkAutoUpdate";
            this.chkAutoUpdate.Size = new System.Drawing.Size(122, 21);
            this.chkAutoUpdate.TabIndex = 21;
            this.chkAutoUpdate.Text = "автопересчет";
            this.chkAutoUpdate.UseVisualStyleBackColor = true;
            // 
            // tbrInterpNQ
            // 
            this.tbrInterpNQ.Location = new System.Drawing.Point(90, 55);
            this.tbrInterpNQ.Maximum = 100;
            this.tbrInterpNQ.Minimum = 1;
            this.tbrInterpNQ.Name = "tbrInterpNQ";
            this.tbrInterpNQ.Size = new System.Drawing.Size(157, 53);
            this.tbrInterpNQ.TabIndex = 0;
            this.tbrInterpNQ.Value = 20;
            this.tbrInterpNQ.Scroll += new System.EventHandler(this.InterpParamsChanged);
            // 
            // tbrInterpNW
            // 
            this.tbrInterpNW.Location = new System.Drawing.Point(90, 114);
            this.tbrInterpNW.Maximum = 100;
            this.tbrInterpNW.Minimum = 1;
            this.tbrInterpNW.Name = "tbrInterpNW";
            this.tbrInterpNW.Size = new System.Drawing.Size(157, 53);
            this.tbrInterpNW.TabIndex = 1;
            this.tbrInterpNW.Value = 20;
            this.tbrInterpNW.Scroll += new System.EventHandler(this.InterpParamsChanged);
            // 
            // glControl
            // 
            this.glControl.BackColor = System.Drawing.Color.Black;
            this.glControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.glControl.Location = new System.Drawing.Point(5, 5);
            this.glControl.Margin = new System.Windows.Forms.Padding(5);
            this.glControl.Name = "glControl";
            this.glControl.Size = new System.Drawing.Size(774, 614);
            this.glControl.TabIndex = 0;
            this.glControl.TabStop = false;
            this.glControl.VSync = false;
            this.glControl.Load += new System.EventHandler(this.glControl_Load);
            this.glControl.Paint += new System.Windows.Forms.PaintEventHandler(this.glControl_Paint);
            this.glControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.glControl_KeyDown);
            this.glControl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.glControl_KeyPress);
            this.glControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.glControl_MouseDown);
            this.glControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.glControl_MouseMove);
            this.glControl.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.glControl_MouseMove);
            // 
            // tpgResults
            // 
            this.tpgResults.BackColor = System.Drawing.Color.Transparent;
            this.tpgResults.Controls.Add(this.panel7);
            this.tpgResults.Controls.Add(this.panel5);
            this.tpgResults.Location = new System.Drawing.Point(4, 29);
            this.tpgResults.Margin = new System.Windows.Forms.Padding(4);
            this.tpgResults.Name = "tpgResults";
            this.tpgResults.Padding = new System.Windows.Forms.Padding(5);
            this.tpgResults.Size = new System.Drawing.Size(784, 624);
            this.tpgResults.TabIndex = 2;
            this.tpgResults.Text = "Результаты";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.pbrResultsTableProgress);
            this.panel7.Controls.Add(this.tblResults);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(5, 5);
            this.panel7.Margin = new System.Windows.Forms.Padding(4);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(774, 559);
            this.panel7.TabIndex = 22;
            // 
            // tblResults
            // 
            this.tblResults.AllowUserToAddRows = false;
            this.tblResults.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N3";
            dataGridViewCellStyle1.NullValue = null;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tblResults.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.Format = "N3";
            dataGridViewCellStyle2.NullValue = null;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tblResults.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.Format = "N3";
            dataGridViewCellStyle3.NullValue = null;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tblResults.DefaultCellStyle = dataGridViewCellStyle3;
            this.tblResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblResults.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tblResults.Location = new System.Drawing.Point(0, 0);
            this.tblResults.Margin = new System.Windows.Forms.Padding(4);
            this.tblResults.Name = "tblResults";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.Format = "N3";
            dataGridViewCellStyle4.NullValue = null;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tblResults.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.tblResults.RowHeadersWidth = 80;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Format = "N3";
            dataGridViewCellStyle5.NullValue = null;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tblResults.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.tblResults.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.tblResults.RowTemplate.DefaultCellStyle.Format = "N3";
            this.tblResults.RowTemplate.DefaultCellStyle.NullValue = null;
            this.tblResults.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tblResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.tblResults.ShowEditingIcon = false;
            this.tblResults.Size = new System.Drawing.Size(774, 559);
            this.tblResults.TabIndex = 0;
            this.tblResults.TabStop = false;
            this.tblResults.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.tblResults_CellValueChanged);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnSaveResults);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(5, 564);
            this.panel5.Margin = new System.Windows.Forms.Padding(4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(774, 55);
            this.panel5.TabIndex = 21;
            // 
            // btnSaveResults
            // 
            this.btnSaveResults.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveResults.Location = new System.Drawing.Point(570, 8);
            this.btnSaveResults.Margin = new System.Windows.Forms.Padding(4);
            this.btnSaveResults.Name = "btnSaveResults";
            this.btnSaveResults.Size = new System.Drawing.Size(200, 43);
            this.btnSaveResults.TabIndex = 21;
            this.btnSaveResults.Text = "Сохранить";
            this.btnSaveResults.UseMnemonic = false;
            this.btnSaveResults.UseVisualStyleBackColor = true;
            this.btnSaveResults.Click += new System.EventHandler(this.tmiFileSaveResultsData_Click);
            // 
            // pbrResultsTableProgress
            // 
            this.pbrResultsTableProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbrResultsTableProgress.Location = new System.Drawing.Point(303, 243);
            this.pbrResultsTableProgress.Name = "pbrResultsTableProgress";
            this.pbrResultsTableProgress.Size = new System.Drawing.Size(150, 25);
            this.pbrResultsTableProgress.Step = 1;
            this.pbrResultsTableProgress.TabIndex = 1;
            this.pbrResultsTableProgress.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 683);
            this.Controls.Add(this.tctMain);
            this.Controls.Add(this.mstMainMenu);
            this.MainMenuStrip = this.mstMainMenu;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(800, 715);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.mstMainMenu.ResumeLayout(false);
            this.mstMainMenu.PerformLayout();
            this.tctMain.ResumeLayout(false);
            this.tpgData.ResumeLayout(false);
            this.tctData.ResumeLayout(false);
            this.tpgSrcData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tblSource)).EndInit();
            this.pnlSrcDataParams.ResumeLayout(false);
            this.tctGridType.ResumeLayout(false);
            this.tabIrregGrid.ResumeLayout(false);
            this.gbxIrregDataPosition.ResumeLayout(false);
            this.gbxIrregDataPosition.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudIrregZPos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIrregYPos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIrregXPos)).EndInit();
            this.gbxIrregSkipCount.ResumeLayout(false);
            this.gbxIrregSkipCount.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudIrregSkipCount)).EndInit();
            this.gbxIrregReadMode.ResumeLayout(false);
            this.tabRegGrid.ResumeLayout(false);
            this.grpRegZData.ResumeLayout(false);
            this.pnlRegZReadMode.ResumeLayout(false);
            this.pnlRegZReadMode.PerformLayout();
            this.grpRegZRows.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudRegZRowA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRegZRowB)).EndInit();
            this.grpRegZCols.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudRegZColA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRegZColB)).EndInit();
            this.grpRegYData.ResumeLayout(false);
            this.grpRegYData.PerformLayout();
            this.grpRegYRange.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudRegYRangeA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRegYRangeB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRegYPos)).EndInit();
            this.grpRegXData.ResumeLayout(false);
            this.grpRegXData.PerformLayout();
            this.grpRegXRange.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudRegXRangeA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRegXRangeB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRegXPos)).EndInit();
            this.pnlSrcDataFilePath.ResumeLayout(false);
            this.pnlSrcDataFilePath.PerformLayout();
            this.tpgAxisData.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tblYAxis)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tblXAxis)).EndInit();
            this.pnlAxisDataFilePath.ResumeLayout(false);
            this.pnlAxisDataFilePath.PerformLayout();
            this.tpgCalculation.ResumeLayout(false);
            this.pnlCalcParams.ResumeLayout(false);
            this.tlpCalcParams.ResumeLayout(false);
            this.tlpCalcParams.PerformLayout();
            this.grpShowParams.ResumeLayout(false);
            this.grpShowParams.PerformLayout();
            this.grpShowGraph.ResumeLayout(false);
            this.grpShowGraph.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnlColorByDerType.ResumeLayout(false);
            this.pnlColorByDerType.PerformLayout();
            this.gbxInterpParams.ResumeLayout(false);
            this.gbxInterpParams.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbrInterpNQ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbrInterpNW)).EndInit();
            this.tpgResults.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tblResults)).EndInit();
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog ofdOpenFile;
        private System.Windows.Forms.SaveFileDialog sfdSaveFile;
        private System.Windows.Forms.MenuStrip mstMainMenu;
        private System.Windows.Forms.ToolStripMenuItem tmiHelp;
        private System.Windows.Forms.ToolStripMenuItem tmiHelpAbout;
        private System.Windows.Forms.ToolStripMenuItem tmiHelpOpenFile;
        private System.Windows.Forms.ToolStripMenuItem tmiFile;
        private System.Windows.Forms.ToolStripMenuItem tmiFileLoad;
        private System.Windows.Forms.ToolStripMenuItem tmiFileLoadSourceData;
        private System.Windows.Forms.ToolStripMenuItem tmiFileLoadAxisData;
        private System.Windows.Forms.ToolStripMenuItem tmiFileLoadConfigData;
        private System.Windows.Forms.ToolStripMenuItem tmiFileSave;
        private System.Windows.Forms.ToolStripMenuItem tmiFileExit;
        private System.Windows.Forms.ToolStripMenuItem tmiFileSaveConfigData;
        private System.Windows.Forms.ToolStripMenuItem tmiFileSaveResultsData;
        private System.Windows.Forms.TabControl tctMain;
        private System.Windows.Forms.TabPage tpgData;
        private System.Windows.Forms.TabControl tctData;
        private System.Windows.Forms.TabPage tpgSrcData;
        private System.Windows.Forms.DataGridView tblSource;
        private System.Windows.Forms.Panel pnlSrcDataFilePath;
        private System.Windows.Forms.Label lblSrcDataFilePath;
        private System.Windows.Forms.TextBox tbxSrcDataFilePath;
        private System.Windows.Forms.TabPage tpgAxisData;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView tblYAxis;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView tblXAxis;
        private System.Windows.Forms.Panel pnlAxisDataFilePath;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbxAxisFileName;
        private System.Windows.Forms.TabPage tpgResults;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.DataGridView tblResults;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnSaveResults;
        private System.Windows.Forms.TabPage tpgCalculation;
        private OpenTK.GLControl glControl;
        private System.Windows.Forms.TabControl tctGridType;
        private System.Windows.Forms.TabPage tabIrregGrid;
        private System.Windows.Forms.ComboBox cbxIrregReadMode;
        private System.Windows.Forms.GroupBox gbxIrregDataPosition;
        private System.Windows.Forms.NumericUpDown nudIrregZPos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudIrregYPos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudIrregXPos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabRegGrid;
        private System.Windows.Forms.GroupBox grpRegXData;
        private System.Windows.Forms.NumericUpDown nudRegXPos;
        private System.Windows.Forms.RadioButton rbtRegXCol;
        private System.Windows.Forms.RadioButton rbtRegXRow;
        private System.Windows.Forms.GroupBox grpRegZData;
        private System.Windows.Forms.GroupBox grpRegZCols;
        private System.Windows.Forms.NumericUpDown nudRegZColA;
        private System.Windows.Forms.NumericUpDown nudRegZColB;
        private System.Windows.Forms.GroupBox grpRegZRows;
        private System.Windows.Forms.NumericUpDown nudRegZRowA;
        private System.Windows.Forms.NumericUpDown nudRegZRowB;
        private System.Windows.Forms.GroupBox grpRegYData;
        private System.Windows.Forms.GroupBox grpRegYRange;
        private System.Windows.Forms.NumericUpDown nudRegYRangeA;
        private System.Windows.Forms.NumericUpDown nudRegYRangeB;
        private System.Windows.Forms.Label lblRegYPos;
        private System.Windows.Forms.NumericUpDown nudRegYPos;
        private System.Windows.Forms.RadioButton rbtRegYCol;
        private System.Windows.Forms.RadioButton rbtRegYRow;
        private System.Windows.Forms.GroupBox grpRegXRange;
        private System.Windows.Forms.NumericUpDown nudRegXRangeA;
        private System.Windows.Forms.NumericUpDown nudRegXRangeB;
        private System.Windows.Forms.GroupBox gbxIrregSkipCount;
        private System.Windows.Forms.NumericUpDown nudIrregSkipCount;
        private System.Windows.Forms.Label lblIrregSkipWhat;
        private System.Windows.Forms.GroupBox gbxIrregReadMode;
        private System.Windows.Forms.Panel pnlSrcDataParams;
        private System.Windows.Forms.Panel pnlCalcParams;
        private System.Windows.Forms.TrackBar tbrInterpNW;
        private System.Windows.Forms.TrackBar tbrInterpNQ;
        private System.Windows.Forms.GroupBox gbxInterpParams;
        private System.Windows.Forms.ComboBox cbxIrregInterpMethod;
        private System.Windows.Forms.CheckBox chkAutoUpdate;
        private System.Windows.Forms.RadioButton rbtDrawSurface;
        private System.Windows.Forms.CheckBox chkShowSourcePoints;
        private System.Windows.Forms.CheckBox chkShowHiddenPoints;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbtOneColor;
        private System.Windows.Forms.RadioButton rbtColorByDerX;
        private System.Windows.Forms.RadioButton rbtColorByValue;
        private System.Windows.Forms.Label lblDifferences;
        private System.Windows.Forms.RadioButton rbtColorByDerY;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.RadioButton rbtColorByDer;
        private System.Windows.Forms.Panel pnlColorByDerType;
        private System.Windows.Forms.Panel pnlRegZReadMode;
        private System.Windows.Forms.RadioButton rbtRegReadYX;
        private System.Windows.Forms.RadioButton rbtRegReadXY;
        private System.Windows.Forms.Label lblRegXPos;
        private System.Windows.Forms.GroupBox grpShowGraph;
        private System.Windows.Forms.RadioButton rbtDrawGrid;
        private System.Windows.Forms.TableLayoutPanel tlpCalcParams;
        private System.Windows.Forms.GroupBox grpShowParams;
        private System.Windows.Forms.CheckBox chkShowGraph;
        private System.Windows.Forms.CheckBox chkShowPointsProjections;
        private System.Windows.Forms.ProgressBar pbrResultsTableProgress;

    }
}

