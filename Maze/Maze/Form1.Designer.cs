namespace Maze
{
   partial class Form1
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.components = new System.ComponentModel.Container();
         this.btnRegen = new System.Windows.Forms.Button();
         this.lblStartKey = new System.Windows.Forms.Label();
         this.lblEndKey = new System.Windows.Forms.Label();
         this.pbStart = new System.Windows.Forms.PictureBox();
         this.pbEnd = new System.Windows.Forms.PictureBox();
         this.txtBoxPercent = new System.Windows.Forms.TextBox();
         this.lblCutPercent = new System.Windows.Forms.Label();
         this.btnRunSearch = new System.Windows.Forms.Button();
         this.txtBoxX = new System.Windows.Forms.TextBox();
         this.txtBoxY = new System.Windows.Forms.TextBox();
         this.lblXY = new System.Windows.Forms.Label();
         this.lblDrawTime = new System.Windows.Forms.Label();
         this.pnlMetrics = new System.Windows.Forms.Panel();
         this.lblSelectedSearches = new System.Windows.Forms.Label();
         this.lblSearches = new System.Windows.Forms.Label();
         this.btnRemove = new System.Windows.Forms.Button();
         this.btnAdd = new System.Windows.Forms.Button();
         this.lstBoxSelected = new System.Windows.Forms.ListBox();
         this.lstBoxOptions = new System.Windows.Forms.ListBox();
         this.btnMetrics = new System.Windows.Forms.Button();
         this.lblPathLength = new System.Windows.Forms.Label();
         this.lblVisited = new System.Windows.Forms.Label();
         this.lblElapsedAvg = new System.Windows.Forms.Label();
         this.lblKey = new System.Windows.Forms.Label();
         this.timerTick = new System.Windows.Forms.Timer(this.components);
         this.pbPath = new System.Windows.Forms.PictureBox();
         this.pbVisited = new System.Windows.Forms.PictureBox();
         this.lblPathKey = new System.Windows.Forms.Label();
         this.lblVisitedKey = new System.Windows.Forms.Label();
         this.pnlKey = new System.Windows.Forms.Panel();
         this.cboxRealtime = new System.Windows.Forms.CheckBox();
         this.PBarMetrics = new System.Windows.Forms.ProgressBar();
         this.NUDLoopsPerTick = new System.Windows.Forms.NumericUpDown();
         this.NUDInterval = new System.Windows.Forms.NumericUpDown();
         this.lblTickLoop = new System.Windows.Forms.Label();
         this.lblInterval = new System.Windows.Forms.Label();
         this.cmbSelection = new System.Windows.Forms.ComboBox();
         this.pnlRealtimeSettings = new System.Windows.Forms.Panel();
         this.lblRealtimeSettings = new System.Windows.Forms.Label();
         this.pnlSingleSearch = new System.Windows.Forms.Panel();
         this.lblSingleSearch = new System.Windows.Forms.Label();
         this.pnlMapGeneration = new System.Windows.Forms.Panel();
         this.lblMapGenerationTime = new System.Windows.Forms.Label();
         this.RBEnd = new System.Windows.Forms.RadioButton();
         this.RBStart = new System.Windows.Forms.RadioButton();
         this.BtnSetStartEnd = new System.Windows.Forms.Button();
         this.lblMapGeneration = new System.Windows.Forms.Label();
         this.pnlMetricOptions = new System.Windows.Forms.Panel();
         this.btnSaveMetrics = new System.Windows.Forms.Button();
         this.btnClearMetrics = new System.Windows.Forms.Button();
         this.lblNumOfRuns = new System.Windows.Forms.Label();
         this.NUDRuns = new System.Windows.Forms.NumericUpDown();
         this.lblCanvasSize = new System.Windows.Forms.Label();
         this.btnSave = new System.Windows.Forms.Button();
         this.btnLoad = new System.Windows.Forms.Button();
         this.pnlFileIO = new System.Windows.Forms.Panel();
         this.lblFileIO = new System.Windows.Forms.Label();
         this.cBoxEditing = new System.Windows.Forms.CheckBox();
         this.pnlEdit = new System.Windows.Forms.Panel();
         this.rbAdd = new System.Windows.Forms.RadioButton();
         this.rbRemove = new System.Windows.Forms.RadioButton();
         this.rbReplace = new System.Windows.Forms.RadioButton();
         this.cmbEditOptions = new System.Windows.Forms.ComboBox();
         this.pnlEditOptions = new System.Windows.Forms.Panel();
         this.lblEditOptions = new System.Windows.Forms.Label();
         this.Canvas = new Maze.DBPanel();
         ((System.ComponentModel.ISupportInitialize)(this.pbStart)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.pbEnd)).BeginInit();
         this.pnlMetrics.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.pbPath)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.pbVisited)).BeginInit();
         this.pnlKey.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.NUDLoopsPerTick)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.NUDInterval)).BeginInit();
         this.pnlRealtimeSettings.SuspendLayout();
         this.pnlSingleSearch.SuspendLayout();
         this.pnlMapGeneration.SuspendLayout();
         this.pnlMetricOptions.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.NUDRuns)).BeginInit();
         this.pnlFileIO.SuspendLayout();
         this.pnlEditOptions.SuspendLayout();
         this.SuspendLayout();
         // 
         // btnRegen
         // 
         this.btnRegen.Location = new System.Drawing.Point(122, 91);
         this.btnRegen.Name = "btnRegen";
         this.btnRegen.Size = new System.Drawing.Size(75, 23);
         this.btnRegen.TabIndex = 1;
         this.btnRegen.Text = "Regenerate";
         this.btnRegen.UseVisualStyleBackColor = true;
         this.btnRegen.Click += new System.EventHandler(this.btnRegen_Click);
         // 
         // lblStartKey
         // 
         this.lblStartKey.AutoSize = true;
         this.lblStartKey.Location = new System.Drawing.Point(11, 47);
         this.lblStartKey.Name = "lblStartKey";
         this.lblStartKey.Size = new System.Drawing.Size(32, 13);
         this.lblStartKey.TabIndex = 2;
         this.lblStartKey.Text = "Start:";
         // 
         // lblEndKey
         // 
         this.lblEndKey.AutoSize = true;
         this.lblEndKey.Location = new System.Drawing.Point(12, 91);
         this.lblEndKey.Name = "lblEndKey";
         this.lblEndKey.Size = new System.Drawing.Size(29, 13);
         this.lblEndKey.TabIndex = 3;
         this.lblEndKey.Text = "End:";
         // 
         // pbStart
         // 
         this.pbStart.Location = new System.Drawing.Point(43, 38);
         this.pbStart.Name = "pbStart";
         this.pbStart.Size = new System.Drawing.Size(23, 22);
         this.pbStart.TabIndex = 4;
         this.pbStart.TabStop = false;
         // 
         // pbEnd
         // 
         this.pbEnd.Location = new System.Drawing.Point(43, 82);
         this.pbEnd.Name = "pbEnd";
         this.pbEnd.Size = new System.Drawing.Size(23, 22);
         this.pbEnd.TabIndex = 5;
         this.pbEnd.TabStop = false;
         // 
         // txtBoxPercent
         // 
         this.txtBoxPercent.Location = new System.Drawing.Point(6, 46);
         this.txtBoxPercent.Name = "txtBoxPercent";
         this.txtBoxPercent.Size = new System.Drawing.Size(100, 20);
         this.txtBoxPercent.TabIndex = 7;
         this.txtBoxPercent.Text = "50";
         // 
         // lblCutPercent
         // 
         this.lblCutPercent.AutoSize = true;
         this.lblCutPercent.Location = new System.Drawing.Point(3, 30);
         this.lblCutPercent.Name = "lblCutPercent";
         this.lblCutPercent.Size = new System.Drawing.Size(130, 13);
         this.lblCutPercent.TabIndex = 8;
         this.lblCutPercent.Text = "Open Percentage (0-100):";
         // 
         // btnRunSearch
         // 
         this.btnRunSearch.Location = new System.Drawing.Point(6, 59);
         this.btnRunSearch.Name = "btnRunSearch";
         this.btnRunSearch.Size = new System.Drawing.Size(75, 23);
         this.btnRunSearch.TabIndex = 9;
         this.btnRunSearch.Text = "Run Search";
         this.btnRunSearch.UseVisualStyleBackColor = true;
         this.btnRunSearch.Click += new System.EventHandler(this.btnRunSearch_Click);
         // 
         // txtBoxX
         // 
         this.txtBoxX.Location = new System.Drawing.Point(6, 91);
         this.txtBoxX.Name = "txtBoxX";
         this.txtBoxX.Size = new System.Drawing.Size(29, 20);
         this.txtBoxX.TabIndex = 10;
         this.txtBoxX.Text = "10";
         // 
         // txtBoxY
         // 
         this.txtBoxY.Location = new System.Drawing.Point(41, 91);
         this.txtBoxY.Name = "txtBoxY";
         this.txtBoxY.Size = new System.Drawing.Size(29, 20);
         this.txtBoxY.TabIndex = 11;
         this.txtBoxY.Text = "10";
         // 
         // lblXY
         // 
         this.lblXY.AutoSize = true;
         this.lblXY.Location = new System.Drawing.Point(3, 75);
         this.lblXY.Name = "lblXY";
         this.lblXY.Size = new System.Drawing.Size(50, 13);
         this.lblXY.TabIndex = 12;
         this.lblXY.Text = "Size X,Y:";
         // 
         // lblDrawTime
         // 
         this.lblDrawTime.AutoSize = true;
         this.lblDrawTime.Location = new System.Drawing.Point(1162, 269);
         this.lblDrawTime.Name = "lblDrawTime";
         this.lblDrawTime.Size = new System.Drawing.Size(70, 13);
         this.lblDrawTime.TabIndex = 14;
         this.lblDrawTime.Text = "Draw Time: 0";
         // 
         // pnlMetrics
         // 
         this.pnlMetrics.Controls.Add(this.lblSelectedSearches);
         this.pnlMetrics.Controls.Add(this.lblSearches);
         this.pnlMetrics.Controls.Add(this.btnRemove);
         this.pnlMetrics.Controls.Add(this.btnAdd);
         this.pnlMetrics.Controls.Add(this.lstBoxSelected);
         this.pnlMetrics.Controls.Add(this.lstBoxOptions);
         this.pnlMetrics.Location = new System.Drawing.Point(715, 117);
         this.pnlMetrics.Name = "pnlMetrics";
         this.pnlMetrics.Size = new System.Drawing.Size(200, 575);
         this.pnlMetrics.TabIndex = 15;
         // 
         // lblSelectedSearches
         // 
         this.lblSelectedSearches.Location = new System.Drawing.Point(43, 429);
         this.lblSelectedSearches.Name = "lblSelectedSearches";
         this.lblSelectedSearches.Size = new System.Drawing.Size(100, 13);
         this.lblSelectedSearches.TabIndex = 9;
         this.lblSelectedSearches.Text = "Selected Searches:";
         this.lblSelectedSearches.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
         // 
         // lblSearches
         // 
         this.lblSearches.Location = new System.Drawing.Point(43, 267);
         this.lblSearches.Name = "lblSearches";
         this.lblSearches.Size = new System.Drawing.Size(55, 13);
         this.lblSearches.TabIndex = 8;
         this.lblSearches.Text = "Searches:";
         this.lblSearches.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
         // 
         // btnRemove
         // 
         this.btnRemove.Location = new System.Drawing.Point(100, 393);
         this.btnRemove.Name = "btnRemove";
         this.btnRemove.Size = new System.Drawing.Size(63, 23);
         this.btnRemove.TabIndex = 6;
         this.btnRemove.Text = "Remove";
         this.btnRemove.UseVisualStyleBackColor = true;
         this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
         // 
         // btnAdd
         // 
         this.btnAdd.Location = new System.Drawing.Point(43, 393);
         this.btnAdd.Name = "btnAdd";
         this.btnAdd.Size = new System.Drawing.Size(55, 23);
         this.btnAdd.TabIndex = 5;
         this.btnAdd.Text = "Add";
         this.btnAdd.UseVisualStyleBackColor = true;
         this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
         // 
         // lstBoxSelected
         // 
         this.lstBoxSelected.FormattingEnabled = true;
         this.lstBoxSelected.Location = new System.Drawing.Point(43, 451);
         this.lstBoxSelected.Name = "lstBoxSelected";
         this.lstBoxSelected.Size = new System.Drawing.Size(120, 147);
         this.lstBoxSelected.TabIndex = 4;
         // 
         // lstBoxOptions
         // 
         this.lstBoxOptions.FormattingEnabled = true;
         this.lstBoxOptions.Items.AddRange(new object[] {
            "Breadth First (Levon)",
            "Depth First (Levon)",
            "Hill Climb (Levon)",
            "A* (Ryan)",
            "Greedy Best First (Ryan)",
            "Dijkstra (Matthew)"});
         this.lstBoxOptions.Location = new System.Drawing.Point(43, 292);
         this.lstBoxOptions.Name = "lstBoxOptions";
         this.lstBoxOptions.Size = new System.Drawing.Size(120, 95);
         this.lstBoxOptions.TabIndex = 3;
         // 
         // btnMetrics
         // 
         this.btnMetrics.Location = new System.Drawing.Point(3, 37);
         this.btnMetrics.MaximumSize = new System.Drawing.Size(200, 25);
         this.btnMetrics.Name = "btnMetrics";
         this.btnMetrics.Size = new System.Drawing.Size(94, 25);
         this.btnMetrics.TabIndex = 7;
         this.btnMetrics.Text = "Run Metrics";
         this.btnMetrics.UseVisualStyleBackColor = true;
         this.btnMetrics.Click += new System.EventHandler(this.btnMetrics_Click);
         // 
         // lblPathLength
         // 
         this.lblPathLength.AutoSize = true;
         this.lblPathLength.Location = new System.Drawing.Point(3, 140);
         this.lblPathLength.Name = "lblPathLength";
         this.lblPathLength.Size = new System.Drawing.Size(68, 13);
         this.lblPathLength.TabIndex = 2;
         this.lblPathLength.Text = "Path Length:";
         // 
         // lblVisited
         // 
         this.lblVisited.AutoSize = true;
         this.lblVisited.Location = new System.Drawing.Point(3, 117);
         this.lblVisited.Name = "lblVisited";
         this.lblVisited.Size = new System.Drawing.Size(66, 13);
         this.lblVisited.TabIndex = 1;
         this.lblVisited.Text = "Tiles Visited:";
         // 
         // lblElapsedAvg
         // 
         this.lblElapsedAvg.AutoSize = true;
         this.lblElapsedAvg.Location = new System.Drawing.Point(3, 94);
         this.lblElapsedAvg.Name = "lblElapsedAvg";
         this.lblElapsedAvg.Size = new System.Drawing.Size(96, 13);
         this.lblElapsedAvg.TabIndex = 0;
         this.lblElapsedAvg.Text = "Elapsed Time (ms):";
         // 
         // lblKey
         // 
         this.lblKey.AutoSize = true;
         this.lblKey.Location = new System.Drawing.Point(88, 9);
         this.lblKey.Name = "lblKey";
         this.lblKey.Size = new System.Drawing.Size(25, 13);
         this.lblKey.TabIndex = 16;
         this.lblKey.Text = "Key";
         // 
         // timerTick
         // 
         this.timerTick.Interval = 1;
         this.timerTick.Tick += new System.EventHandler(this.timerTick_Tick);
         // 
         // pbPath
         // 
         this.pbPath.Location = new System.Drawing.Point(160, 82);
         this.pbPath.Name = "pbPath";
         this.pbPath.Size = new System.Drawing.Size(23, 22);
         this.pbPath.TabIndex = 20;
         this.pbPath.TabStop = false;
         // 
         // pbVisited
         // 
         this.pbVisited.Location = new System.Drawing.Point(160, 38);
         this.pbVisited.Name = "pbVisited";
         this.pbVisited.Size = new System.Drawing.Size(23, 22);
         this.pbVisited.TabIndex = 19;
         this.pbVisited.TabStop = false;
         // 
         // lblPathKey
         // 
         this.lblPathKey.AutoSize = true;
         this.lblPathKey.Location = new System.Drawing.Point(122, 91);
         this.lblPathKey.Name = "lblPathKey";
         this.lblPathKey.Size = new System.Drawing.Size(32, 13);
         this.lblPathKey.TabIndex = 18;
         this.lblPathKey.Text = "Path:";
         // 
         // lblVisitedKey
         // 
         this.lblVisitedKey.AutoSize = true;
         this.lblVisitedKey.Location = new System.Drawing.Point(113, 47);
         this.lblVisitedKey.Name = "lblVisitedKey";
         this.lblVisitedKey.Size = new System.Drawing.Size(41, 13);
         this.lblVisitedKey.TabIndex = 17;
         this.lblVisitedKey.Text = "Visited:";
         // 
         // pnlKey
         // 
         this.pnlKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.pnlKey.Controls.Add(this.lblKey);
         this.pnlKey.Controls.Add(this.pbPath);
         this.pnlKey.Controls.Add(this.lblStartKey);
         this.pnlKey.Controls.Add(this.pbVisited);
         this.pnlKey.Controls.Add(this.lblEndKey);
         this.pnlKey.Controls.Add(this.lblPathKey);
         this.pnlKey.Controls.Add(this.pbStart);
         this.pnlKey.Controls.Add(this.lblVisitedKey);
         this.pnlKey.Controls.Add(this.pbEnd);
         this.pnlKey.Location = new System.Drawing.Point(1158, 593);
         this.pnlKey.Name = "pnlKey";
         this.pnlKey.Size = new System.Drawing.Size(200, 121);
         this.pnlKey.TabIndex = 21;
         // 
         // cboxRealtime
         // 
         this.cboxRealtime.AutoSize = true;
         this.cboxRealtime.Location = new System.Drawing.Point(113, 59);
         this.cboxRealtime.Margin = new System.Windows.Forms.Padding(2);
         this.cboxRealtime.Name = "cboxRealtime";
         this.cboxRealtime.Size = new System.Drawing.Size(67, 17);
         this.cboxRealtime.TabIndex = 22;
         this.cboxRealtime.Text = "Realtime";
         this.cboxRealtime.UseVisualStyleBackColor = true;
         // 
         // PBarMetrics
         // 
         this.PBarMetrics.Location = new System.Drawing.Point(715, 691);
         this.PBarMetrics.MaximumSize = new System.Drawing.Size(500, 23);
         this.PBarMetrics.Name = "PBarMetrics";
         this.PBarMetrics.Size = new System.Drawing.Size(200, 23);
         this.PBarMetrics.TabIndex = 23;
         // 
         // NUDLoopsPerTick
         // 
         this.NUDLoopsPerTick.Location = new System.Drawing.Point(9, 54);
         this.NUDLoopsPerTick.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
         this.NUDLoopsPerTick.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this.NUDLoopsPerTick.Name = "NUDLoopsPerTick";
         this.NUDLoopsPerTick.Size = new System.Drawing.Size(120, 20);
         this.NUDLoopsPerTick.TabIndex = 24;
         this.NUDLoopsPerTick.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
         // 
         // NUDInterval
         // 
         this.NUDInterval.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
         this.NUDInterval.Location = new System.Drawing.Point(11, 105);
         this.NUDInterval.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
         this.NUDInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this.NUDInterval.Name = "NUDInterval";
         this.NUDInterval.Size = new System.Drawing.Size(120, 20);
         this.NUDInterval.TabIndex = 25;
         this.NUDInterval.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
         this.NUDInterval.ValueChanged += new System.EventHandler(this.NUDInterval_ValueChanged);
         // 
         // lblTickLoop
         // 
         this.lblTickLoop.AutoSize = true;
         this.lblTickLoop.Location = new System.Drawing.Point(9, 35);
         this.lblTickLoop.Name = "lblTickLoop";
         this.lblTickLoop.Size = new System.Drawing.Size(67, 13);
         this.lblTickLoop.TabIndex = 26;
         this.lblTickLoop.Text = "TickAmount:";
         // 
         // lblInterval
         // 
         this.lblInterval.AutoSize = true;
         this.lblInterval.Location = new System.Drawing.Point(9, 83);
         this.lblInterval.Name = "lblInterval";
         this.lblInterval.Size = new System.Drawing.Size(93, 13);
         this.lblInterval.TabIndex = 27;
         this.lblInterval.Text = "Interval Time (ms):";
         // 
         // cmbSelection
         // 
         this.cmbSelection.FormattingEnabled = true;
         this.cmbSelection.Items.AddRange(new object[] {
            "Breadth First (Levon)",
            "Depth First (Levon)",
            "Hill Climb (Levon)",
            "A* (Ryan)",
            "Greedy Best First (Ryan)",
            "Dijkstra (Matthew)"});
         this.cmbSelection.Location = new System.Drawing.Point(4, 23);
         this.cmbSelection.Margin = new System.Windows.Forms.Padding(2);
         this.cmbSelection.Name = "cmbSelection";
         this.cmbSelection.Size = new System.Drawing.Size(92, 21);
         this.cmbSelection.TabIndex = 28;
         this.cmbSelection.Text = "Select Search";
         // 
         // pnlRealtimeSettings
         // 
         this.pnlRealtimeSettings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.pnlRealtimeSettings.Controls.Add(this.lblRealtimeSettings);
         this.pnlRealtimeSettings.Controls.Add(this.lblTickLoop);
         this.pnlRealtimeSettings.Controls.Add(this.NUDLoopsPerTick);
         this.pnlRealtimeSettings.Controls.Add(this.lblInterval);
         this.pnlRealtimeSettings.Controls.Add(this.NUDInterval);
         this.pnlRealtimeSettings.Location = new System.Drawing.Point(1158, 455);
         this.pnlRealtimeSettings.Name = "pnlRealtimeSettings";
         this.pnlRealtimeSettings.Size = new System.Drawing.Size(200, 132);
         this.pnlRealtimeSettings.TabIndex = 29;
         // 
         // lblRealtimeSettings
         // 
         this.lblRealtimeSettings.AutoSize = true;
         this.lblRealtimeSettings.Location = new System.Drawing.Point(59, 10);
         this.lblRealtimeSettings.Name = "lblRealtimeSettings";
         this.lblRealtimeSettings.Size = new System.Drawing.Size(89, 13);
         this.lblRealtimeSettings.TabIndex = 28;
         this.lblRealtimeSettings.Text = "Realtime Settings";
         // 
         // pnlSingleSearch
         // 
         this.pnlSingleSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.pnlSingleSearch.Controls.Add(this.lblSingleSearch);
         this.pnlSingleSearch.Controls.Add(this.lblElapsedAvg);
         this.pnlSingleSearch.Controls.Add(this.cmbSelection);
         this.pnlSingleSearch.Controls.Add(this.lblVisited);
         this.pnlSingleSearch.Controls.Add(this.cboxRealtime);
         this.pnlSingleSearch.Controls.Add(this.lblPathLength);
         this.pnlSingleSearch.Controls.Add(this.btnRunSearch);
         this.pnlSingleSearch.Location = new System.Drawing.Point(1158, 285);
         this.pnlSingleSearch.Name = "pnlSingleSearch";
         this.pnlSingleSearch.Size = new System.Drawing.Size(200, 164);
         this.pnlSingleSearch.TabIndex = 30;
         // 
         // lblSingleSearch
         // 
         this.lblSingleSearch.AutoSize = true;
         this.lblSingleSearch.Location = new System.Drawing.Point(57, 8);
         this.lblSingleSearch.Name = "lblSingleSearch";
         this.lblSingleSearch.Size = new System.Drawing.Size(73, 13);
         this.lblSingleSearch.TabIndex = 0;
         this.lblSingleSearch.Text = "Single Search";
         // 
         // pnlMapGeneration
         // 
         this.pnlMapGeneration.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.pnlMapGeneration.Controls.Add(this.lblMapGenerationTime);
         this.pnlMapGeneration.Controls.Add(this.RBEnd);
         this.pnlMapGeneration.Controls.Add(this.RBStart);
         this.pnlMapGeneration.Controls.Add(this.BtnSetStartEnd);
         this.pnlMapGeneration.Controls.Add(this.lblMapGeneration);
         this.pnlMapGeneration.Controls.Add(this.lblXY);
         this.pnlMapGeneration.Controls.Add(this.txtBoxX);
         this.pnlMapGeneration.Controls.Add(this.txtBoxY);
         this.pnlMapGeneration.Controls.Add(this.lblCutPercent);
         this.pnlMapGeneration.Controls.Add(this.btnRegen);
         this.pnlMapGeneration.Controls.Add(this.txtBoxPercent);
         this.pnlMapGeneration.Location = new System.Drawing.Point(1158, 12);
         this.pnlMapGeneration.Name = "pnlMapGeneration";
         this.pnlMapGeneration.Size = new System.Drawing.Size(200, 171);
         this.pnlMapGeneration.TabIndex = 31;
         // 
         // lblMapGenerationTime
         // 
         this.lblMapGenerationTime.AutoSize = true;
         this.lblMapGenerationTime.Location = new System.Drawing.Point(15, 147);
         this.lblMapGenerationTime.Name = "lblMapGenerationTime";
         this.lblMapGenerationTime.Size = new System.Drawing.Size(88, 13);
         this.lblMapGenerationTime.TabIndex = 16;
         this.lblMapGenerationTime.Text = "Generation Time:\r\n";
         // 
         // RBEnd
         // 
         this.RBEnd.AutoSize = true;
         this.RBEnd.Location = new System.Drawing.Point(137, 120);
         this.RBEnd.Name = "RBEnd";
         this.RBEnd.Size = new System.Drawing.Size(44, 17);
         this.RBEnd.TabIndex = 15;
         this.RBEnd.TabStop = true;
         this.RBEnd.Text = "End";
         this.RBEnd.UseVisualStyleBackColor = true;
         // 
         // RBStart
         // 
         this.RBStart.AutoSize = true;
         this.RBStart.Checked = true;
         this.RBStart.Location = new System.Drawing.Point(84, 120);
         this.RBStart.Name = "RBStart";
         this.RBStart.Size = new System.Drawing.Size(47, 17);
         this.RBStart.TabIndex = 14;
         this.RBStart.TabStop = true;
         this.RBStart.Text = "Start";
         this.RBStart.UseVisualStyleBackColor = true;
         // 
         // BtnSetStartEnd
         // 
         this.BtnSetStartEnd.Location = new System.Drawing.Point(3, 117);
         this.BtnSetStartEnd.Name = "BtnSetStartEnd";
         this.BtnSetStartEnd.Size = new System.Drawing.Size(75, 23);
         this.BtnSetStartEnd.TabIndex = 13;
         this.BtnSetStartEnd.Text = "Set";
         this.BtnSetStartEnd.UseVisualStyleBackColor = true;
         this.BtnSetStartEnd.Click += new System.EventHandler(this.BtnSetStartEnd_Click);
         // 
         // lblMapGeneration
         // 
         this.lblMapGeneration.AutoSize = true;
         this.lblMapGeneration.Location = new System.Drawing.Point(60, 7);
         this.lblMapGeneration.Name = "lblMapGeneration";
         this.lblMapGeneration.Size = new System.Drawing.Size(83, 13);
         this.lblMapGeneration.TabIndex = 0;
         this.lblMapGeneration.Text = "Map Generation";
         // 
         // pnlMetricOptions
         // 
         this.pnlMetricOptions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.pnlMetricOptions.Controls.Add(this.btnSaveMetrics);
         this.pnlMetricOptions.Controls.Add(this.btnClearMetrics);
         this.pnlMetricOptions.Controls.Add(this.lblNumOfRuns);
         this.pnlMetricOptions.Controls.Add(this.NUDRuns);
         this.pnlMetricOptions.Controls.Add(this.btnMetrics);
         this.pnlMetricOptions.Location = new System.Drawing.Point(715, 14);
         this.pnlMetricOptions.Name = "pnlMetricOptions";
         this.pnlMetricOptions.Size = new System.Drawing.Size(200, 97);
         this.pnlMetricOptions.TabIndex = 32;
         // 
         // btnSaveMetrics
         // 
         this.btnSaveMetrics.Enabled = false;
         this.btnSaveMetrics.Location = new System.Drawing.Point(3, 68);
         this.btnSaveMetrics.MaximumSize = new System.Drawing.Size(500, 25);
         this.btnSaveMetrics.Name = "btnSaveMetrics";
         this.btnSaveMetrics.Size = new System.Drawing.Size(94, 25);
         this.btnSaveMetrics.TabIndex = 36;
         this.btnSaveMetrics.Text = "Save Metrics";
         this.btnSaveMetrics.UseVisualStyleBackColor = true;
         this.btnSaveMetrics.Click += new System.EventHandler(this.btnSaveMetrics_Click);
         // 
         // btnClearMetrics
         // 
         this.btnClearMetrics.Enabled = false;
         this.btnClearMetrics.Location = new System.Drawing.Point(100, 37);
         this.btnClearMetrics.MaximumSize = new System.Drawing.Size(200, 25);
         this.btnClearMetrics.Name = "btnClearMetrics";
         this.btnClearMetrics.Size = new System.Drawing.Size(97, 25);
         this.btnClearMetrics.TabIndex = 35;
         this.btnClearMetrics.Text = "Clear Metrics";
         this.btnClearMetrics.UseVisualStyleBackColor = true;
         this.btnClearMetrics.Click += new System.EventHandler(this.btnClearMetrics_Click);
         // 
         // lblNumOfRuns
         // 
         this.lblNumOfRuns.AutoSize = true;
         this.lblNumOfRuns.Location = new System.Drawing.Point(3, 13);
         this.lblNumOfRuns.Name = "lblNumOfRuns";
         this.lblNumOfRuns.Size = new System.Drawing.Size(82, 13);
         this.lblNumOfRuns.TabIndex = 34;
         this.lblNumOfRuns.Text = "Number of runs:";
         // 
         // NUDRuns
         // 
         this.NUDRuns.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
         this.NUDRuns.Location = new System.Drawing.Point(100, 11);
         this.NUDRuns.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this.NUDRuns.Name = "NUDRuns";
         this.NUDRuns.Size = new System.Drawing.Size(97, 20);
         this.NUDRuns.TabIndex = 33;
         this.NUDRuns.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
         // 
         // lblCanvasSize
         // 
         this.lblCanvasSize.AutoSize = true;
         this.lblCanvasSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblCanvasSize.Location = new System.Drawing.Point(16, 3);
         this.lblCanvasSize.Name = "lblCanvasSize";
         this.lblCanvasSize.Size = new System.Drawing.Size(78, 9);
         this.lblCanvasSize.TabIndex = 33;
         this.lblCanvasSize.Text = "Canvas Size: 700,700";
         // 
         // btnSave
         // 
         this.btnSave.Location = new System.Drawing.Point(24, 29);
         this.btnSave.Name = "btnSave";
         this.btnSave.Size = new System.Drawing.Size(75, 23);
         this.btnSave.TabIndex = 34;
         this.btnSave.Text = "Save";
         this.btnSave.UseVisualStyleBackColor = true;
         this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
         // 
         // btnLoad
         // 
         this.btnLoad.Location = new System.Drawing.Point(105, 29);
         this.btnLoad.Name = "btnLoad";
         this.btnLoad.Size = new System.Drawing.Size(75, 23);
         this.btnLoad.TabIndex = 35;
         this.btnLoad.Text = "Load";
         this.btnLoad.UseVisualStyleBackColor = true;
         this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
         // 
         // pnlFileIO
         // 
         this.pnlFileIO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.pnlFileIO.Controls.Add(this.lblFileIO);
         this.pnlFileIO.Controls.Add(this.btnSave);
         this.pnlFileIO.Controls.Add(this.btnLoad);
         this.pnlFileIO.Location = new System.Drawing.Point(1158, 189);
         this.pnlFileIO.Name = "pnlFileIO";
         this.pnlFileIO.Size = new System.Drawing.Size(200, 65);
         this.pnlFileIO.TabIndex = 36;
         // 
         // lblFileIO
         // 
         this.lblFileIO.AutoSize = true;
         this.lblFileIO.Location = new System.Drawing.Point(85, 7);
         this.lblFileIO.Name = "lblFileIO";
         this.lblFileIO.Size = new System.Drawing.Size(38, 13);
         this.lblFileIO.TabIndex = 36;
         this.lblFileIO.Text = "FIle IO";
         // 
         // cBoxEditing
         // 
         this.cBoxEditing.AutoSize = true;
         this.cBoxEditing.BackColor = System.Drawing.SystemColors.Control;
         this.cBoxEditing.Location = new System.Drawing.Point(7, 24);
         this.cBoxEditing.Margin = new System.Windows.Forms.Padding(2);
         this.cBoxEditing.Name = "cBoxEditing";
         this.cBoxEditing.Size = new System.Drawing.Size(58, 17);
         this.cBoxEditing.TabIndex = 37;
         this.cBoxEditing.Text = "Editing";
         this.cBoxEditing.UseVisualStyleBackColor = false;
         // 
         // pnlEdit
         // 
         this.pnlEdit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.pnlEdit.Location = new System.Drawing.Point(7, 49);
         this.pnlEdit.Margin = new System.Windows.Forms.Padding(2);
         this.pnlEdit.Name = "pnlEdit";
         this.pnlEdit.Size = new System.Drawing.Size(55, 55);
         this.pnlEdit.TabIndex = 38;
         this.pnlEdit.Click += new System.EventHandler(this.panel1_Click);
         this.pnlEdit.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
         // 
         // rbAdd
         // 
         this.rbAdd.AutoSize = true;
         this.rbAdd.Location = new System.Drawing.Point(69, 49);
         this.rbAdd.Margin = new System.Windows.Forms.Padding(2);
         this.rbAdd.Name = "rbAdd";
         this.rbAdd.Size = new System.Drawing.Size(44, 17);
         this.rbAdd.TabIndex = 40;
         this.rbAdd.Text = "Add";
         this.rbAdd.UseVisualStyleBackColor = true;
         // 
         // rbRemove
         // 
         this.rbRemove.AutoSize = true;
         this.rbRemove.Location = new System.Drawing.Point(69, 68);
         this.rbRemove.Margin = new System.Windows.Forms.Padding(2);
         this.rbRemove.Name = "rbRemove";
         this.rbRemove.Size = new System.Drawing.Size(65, 17);
         this.rbRemove.TabIndex = 41;
         this.rbRemove.Text = "Remove";
         this.rbRemove.UseVisualStyleBackColor = true;
         // 
         // rbReplace
         // 
         this.rbReplace.AutoSize = true;
         this.rbReplace.Checked = true;
         this.rbReplace.Location = new System.Drawing.Point(69, 85);
         this.rbReplace.Margin = new System.Windows.Forms.Padding(2);
         this.rbReplace.Name = "rbReplace";
         this.rbReplace.Size = new System.Drawing.Size(65, 17);
         this.rbReplace.TabIndex = 42;
         this.rbReplace.TabStop = true;
         this.rbReplace.Text = "Replace";
         this.rbReplace.UseVisualStyleBackColor = true;
         // 
         // cmbEditOptions
         // 
         this.cmbEditOptions.FormattingEnabled = true;
         this.cmbEditOptions.Items.AddRange(new object[] {
            "Fill",
            "Perimeter"});
         this.cmbEditOptions.Location = new System.Drawing.Point(69, 22);
         this.cmbEditOptions.Margin = new System.Windows.Forms.Padding(2);
         this.cmbEditOptions.Name = "cmbEditOptions";
         this.cmbEditOptions.Size = new System.Drawing.Size(92, 21);
         this.cmbEditOptions.TabIndex = 43;
         this.cmbEditOptions.Text = "Edit Option";
         // 
         // pnlEditOptions
         // 
         this.pnlEditOptions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.pnlEditOptions.Controls.Add(this.lblEditOptions);
         this.pnlEditOptions.Controls.Add(this.cBoxEditing);
         this.pnlEditOptions.Controls.Add(this.cmbEditOptions);
         this.pnlEditOptions.Controls.Add(this.pnlEdit);
         this.pnlEditOptions.Controls.Add(this.rbReplace);
         this.pnlEditOptions.Controls.Add(this.rbAdd);
         this.pnlEditOptions.Controls.Add(this.rbRemove);
         this.pnlEditOptions.Location = new System.Drawing.Point(984, 12);
         this.pnlEditOptions.Margin = new System.Windows.Forms.Padding(2);
         this.pnlEditOptions.Name = "pnlEditOptions";
         this.pnlEditOptions.Size = new System.Drawing.Size(173, 115);
         this.pnlEditOptions.TabIndex = 44;
         // 
         // lblEditOptions
         // 
         this.lblEditOptions.AutoSize = true;
         this.lblEditOptions.Location = new System.Drawing.Point(49, 7);
         this.lblEditOptions.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
         this.lblEditOptions.Name = "lblEditOptions";
         this.lblEditOptions.Size = new System.Drawing.Size(64, 13);
         this.lblEditOptions.TabIndex = 44;
         this.lblEditOptions.Text = "Edit Options";
         // 
         // Canvas
         // 
         this.Canvas.AutoSize = true;
         this.Canvas.Location = new System.Drawing.Point(14, 14);
         this.Canvas.Margin = new System.Windows.Forms.Padding(5, 5, 200, 5);
         this.Canvas.Name = "Canvas";
         this.Canvas.Size = new System.Drawing.Size(700, 700);
         this.Canvas.TabIndex = 0;
         this.Canvas.Click += new System.EventHandler(this.Canvas_Click);
         this.Canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.Canvas_Paint);
         this.Canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseDown);
         this.Canvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseUp);
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(1366, 749);
         this.Controls.Add(this.pnlEditOptions);
         this.Controls.Add(this.pnlFileIO);
         this.Controls.Add(this.lblCanvasSize);
         this.Controls.Add(this.pnlMetricOptions);
         this.Controls.Add(this.pnlMapGeneration);
         this.Controls.Add(this.pnlSingleSearch);
         this.Controls.Add(this.pnlRealtimeSettings);
         this.Controls.Add(this.PBarMetrics);
         this.Controls.Add(this.pnlKey);
         this.Controls.Add(this.pnlMetrics);
         this.Controls.Add(this.lblDrawTime);
         this.Controls.Add(this.Canvas);
         this.DoubleBuffered = true;
         this.Name = "Form1";
         this.Text = "Form1";
         this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
         this.Load += new System.EventHandler(this.Form1_Load);
         ((System.ComponentModel.ISupportInitialize)(this.pbStart)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.pbEnd)).EndInit();
         this.pnlMetrics.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.pbPath)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.pbVisited)).EndInit();
         this.pnlKey.ResumeLayout(false);
         this.pnlKey.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.NUDLoopsPerTick)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.NUDInterval)).EndInit();
         this.pnlRealtimeSettings.ResumeLayout(false);
         this.pnlRealtimeSettings.PerformLayout();
         this.pnlSingleSearch.ResumeLayout(false);
         this.pnlSingleSearch.PerformLayout();
         this.pnlMapGeneration.ResumeLayout(false);
         this.pnlMapGeneration.PerformLayout();
         this.pnlMetricOptions.ResumeLayout(false);
         this.pnlMetricOptions.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.NUDRuns)).EndInit();
         this.pnlFileIO.ResumeLayout(false);
         this.pnlFileIO.PerformLayout();
         this.pnlEditOptions.ResumeLayout(false);
         this.pnlEditOptions.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private DBPanel Canvas;
      private System.Windows.Forms.Button btnRegen;
      private System.Windows.Forms.Label lblStartKey;
      private System.Windows.Forms.Label lblEndKey;
      private System.Windows.Forms.PictureBox pbStart;
      private System.Windows.Forms.PictureBox pbEnd;
      private System.Windows.Forms.TextBox txtBoxPercent;
      private System.Windows.Forms.Label lblCutPercent;
      private System.Windows.Forms.Button btnRunSearch;
      private System.Windows.Forms.TextBox txtBoxX;
      private System.Windows.Forms.TextBox txtBoxY;
      private System.Windows.Forms.Label lblXY;
      private System.Windows.Forms.Label lblDrawTime;
      private System.Windows.Forms.Panel pnlMetrics;
      private System.Windows.Forms.Label lblPathLength;
      private System.Windows.Forms.Label lblVisited;
      private System.Windows.Forms.Label lblElapsedAvg;
      private System.Windows.Forms.Button btnRemove;
      private System.Windows.Forms.Button btnAdd;
      private System.Windows.Forms.ListBox lstBoxSelected;
      private System.Windows.Forms.ListBox lstBoxOptions;
      private System.Windows.Forms.Button btnMetrics;
      private System.Windows.Forms.Label lblKey;
      private System.Windows.Forms.Timer timerTick;
      private System.Windows.Forms.PictureBox pbPath;
      private System.Windows.Forms.PictureBox pbVisited;
      private System.Windows.Forms.Label lblPathKey;
      private System.Windows.Forms.Label lblVisitedKey;
      private System.Windows.Forms.Panel pnlKey;
      private System.Windows.Forms.CheckBox cboxRealtime;
      private System.Windows.Forms.ProgressBar PBarMetrics;
      private System.Windows.Forms.NumericUpDown NUDLoopsPerTick;
      private System.Windows.Forms.NumericUpDown NUDInterval;
      private System.Windows.Forms.Label lblTickLoop;
      private System.Windows.Forms.Label lblInterval;
      private System.Windows.Forms.ComboBox cmbSelection;
      private System.Windows.Forms.Panel pnlRealtimeSettings;
      private System.Windows.Forms.Label lblRealtimeSettings;
      private System.Windows.Forms.Panel pnlSingleSearch;
      private System.Windows.Forms.Label lblSingleSearch;
      private System.Windows.Forms.Panel pnlMapGeneration;
      private System.Windows.Forms.Label lblMapGeneration;
      private System.Windows.Forms.RadioButton RBEnd;
      private System.Windows.Forms.RadioButton RBStart;
      private System.Windows.Forms.Button BtnSetStartEnd;
      private System.Windows.Forms.Label lblSelectedSearches;
      private System.Windows.Forms.Label lblSearches;
      private System.Windows.Forms.Panel pnlMetricOptions;
      private System.Windows.Forms.Label lblNumOfRuns;
      private System.Windows.Forms.NumericUpDown NUDRuns;
      private System.Windows.Forms.Button btnClearMetrics;
      private System.Windows.Forms.Label lblMapGenerationTime;
      private System.Windows.Forms.Label lblCanvasSize;
      private System.Windows.Forms.Button btnSave;
      private System.Windows.Forms.Button btnLoad;
      private System.Windows.Forms.Panel pnlFileIO;
      private System.Windows.Forms.Label lblFileIO;
      private System.Windows.Forms.CheckBox cBoxEditing;
      private System.Windows.Forms.Panel pnlEdit;
      private System.Windows.Forms.RadioButton rbAdd;
      private System.Windows.Forms.RadioButton rbRemove;
      private System.Windows.Forms.RadioButton rbReplace;
      private System.Windows.Forms.ComboBox cmbEditOptions;
      private System.Windows.Forms.Panel pnlEditOptions;
      private System.Windows.Forms.Label lblEditOptions;
      private System.Windows.Forms.Button btnSaveMetrics;
   }
}

