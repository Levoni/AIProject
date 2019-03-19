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
         this.btnBreadthFirst = new System.Windows.Forms.Button();
         this.txtBoxPercent = new System.Windows.Forms.TextBox();
         this.lblCutPercent = new System.Windows.Forms.Label();
         this.btnDepthFirst = new System.Windows.Forms.Button();
         this.txtBoxX = new System.Windows.Forms.TextBox();
         this.txtBoxY = new System.Windows.Forms.TextBox();
         this.lblXY = new System.Windows.Forms.Label();
         this.lblElapsed = new System.Windows.Forms.Label();
         this.lblDrawTime = new System.Windows.Forms.Label();
         this.pnlMetrics = new System.Windows.Forms.Panel();
         this.btnMetrics = new System.Windows.Forms.Button();
         this.btnRemove = new System.Windows.Forms.Button();
         this.btnAdd = new System.Windows.Forms.Button();
         this.lstBoxSelected = new System.Windows.Forms.ListBox();
         this.lstBoxOptions = new System.Windows.Forms.ListBox();
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
         this.cbRealtime = new System.Windows.Forms.CheckBox();
         this.progressBar1 = new System.Windows.Forms.ProgressBar();
         this.NUDLoopsPerTick = new System.Windows.Forms.NumericUpDown();
         this.NUDInterval = new System.Windows.Forms.NumericUpDown();
         this.Canvas = new Maze.DBPanel();
         this.lblToickLoop = new System.Windows.Forms.Label();
         this.lblInterval = new System.Windows.Forms.Label();
         ((System.ComponentModel.ISupportInitialize)(this.pbStart)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.pbEnd)).BeginInit();
         this.pnlMetrics.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.pbPath)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.pbVisited)).BeginInit();
         this.pnlKey.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.NUDLoopsPerTick)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.NUDInterval)).BeginInit();
         this.SuspendLayout();
         // 
         // btnRegen
         // 
         this.btnRegen.Location = new System.Drawing.Point(1171, 14);
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
         // btnBreadthFirst
         // 
         this.btnBreadthFirst.Location = new System.Drawing.Point(1171, 219);
         this.btnBreadthFirst.Name = "btnBreadthFirst";
         this.btnBreadthFirst.Size = new System.Drawing.Size(75, 23);
         this.btnBreadthFirst.TabIndex = 6;
         this.btnBreadthFirst.Text = "Breadth First";
         this.btnBreadthFirst.UseVisualStyleBackColor = true;
         this.btnBreadthFirst.Click += new System.EventHandler(this.btnBreadthFirst_Click);
         // 
         // txtBoxPercent
         // 
         this.txtBoxPercent.Location = new System.Drawing.Point(1171, 67);
         this.txtBoxPercent.Name = "txtBoxPercent";
         this.txtBoxPercent.Size = new System.Drawing.Size(100, 20);
         this.txtBoxPercent.TabIndex = 7;
         this.txtBoxPercent.Text = "20";
         // 
         // lblCutPercent
         // 
         this.lblCutPercent.AutoSize = true;
         this.lblCutPercent.Location = new System.Drawing.Point(1168, 51);
         this.lblCutPercent.Name = "lblCutPercent";
         this.lblCutPercent.Size = new System.Drawing.Size(130, 13);
         this.lblCutPercent.TabIndex = 8;
         this.lblCutPercent.Text = "Open Percentage (0-100):";
         // 
         // btnDepthFirst
         // 
         this.btnDepthFirst.Location = new System.Drawing.Point(1171, 248);
         this.btnDepthFirst.Name = "btnDepthFirst";
         this.btnDepthFirst.Size = new System.Drawing.Size(75, 23);
         this.btnDepthFirst.TabIndex = 9;
         this.btnDepthFirst.Text = "Depth First";
         this.btnDepthFirst.UseVisualStyleBackColor = true;
         this.btnDepthFirst.Click += new System.EventHandler(this.btnDepthFirst_Click);
         // 
         // txtBoxX
         // 
         this.txtBoxX.Location = new System.Drawing.Point(1171, 125);
         this.txtBoxX.Name = "txtBoxX";
         this.txtBoxX.Size = new System.Drawing.Size(29, 20);
         this.txtBoxX.TabIndex = 10;
         this.txtBoxX.Text = "10";
         // 
         // txtBoxY
         // 
         this.txtBoxY.Location = new System.Drawing.Point(1206, 125);
         this.txtBoxY.Name = "txtBoxY";
         this.txtBoxY.Size = new System.Drawing.Size(29, 20);
         this.txtBoxY.TabIndex = 11;
         this.txtBoxY.Text = "10";
         // 
         // lblXY
         // 
         this.lblXY.AutoSize = true;
         this.lblXY.Location = new System.Drawing.Point(1168, 109);
         this.lblXY.Name = "lblXY";
         this.lblXY.Size = new System.Drawing.Size(50, 13);
         this.lblXY.TabIndex = 12;
         this.lblXY.Text = "Size X,Y:";
         // 
         // lblElapsed
         // 
         this.lblElapsed.AutoSize = true;
         this.lblElapsed.Location = new System.Drawing.Point(1171, 200);
         this.lblElapsed.Name = "lblElapsed";
         this.lblElapsed.Size = new System.Drawing.Size(74, 13);
         this.lblElapsed.TabIndex = 13;
         this.lblElapsed.Text = "Elapsed Time:";
         // 
         // lblDrawTime
         // 
         this.lblDrawTime.AutoSize = true;
         this.lblDrawTime.Location = new System.Drawing.Point(1171, 278);
         this.lblDrawTime.Name = "lblDrawTime";
         this.lblDrawTime.Size = new System.Drawing.Size(55, 13);
         this.lblDrawTime.TabIndex = 14;
         this.lblDrawTime.Text = "DrawTime";
         // 
         // pnlMetrics
         // 
         this.pnlMetrics.Controls.Add(this.btnMetrics);
         this.pnlMetrics.Controls.Add(this.btnRemove);
         this.pnlMetrics.Controls.Add(this.btnAdd);
         this.pnlMetrics.Controls.Add(this.lstBoxSelected);
         this.pnlMetrics.Controls.Add(this.lstBoxOptions);
         this.pnlMetrics.Location = new System.Drawing.Point(715, 14);
         this.pnlMetrics.Name = "pnlMetrics";
         this.pnlMetrics.Size = new System.Drawing.Size(200, 700);
         this.pnlMetrics.TabIndex = 15;
         // 
         // btnMetrics
         // 
         this.btnMetrics.Location = new System.Drawing.Point(38, 645);
         this.btnMetrics.Name = "btnMetrics";
         this.btnMetrics.Size = new System.Drawing.Size(120, 23);
         this.btnMetrics.TabIndex = 7;
         this.btnMetrics.Text = "Run Metrics";
         this.btnMetrics.UseVisualStyleBackColor = true;
         this.btnMetrics.Click += new System.EventHandler(this.btnMetrics_Click);
         // 
         // btnRemove
         // 
         this.btnRemove.Location = new System.Drawing.Point(95, 498);
         this.btnRemove.Name = "btnRemove";
         this.btnRemove.Size = new System.Drawing.Size(63, 23);
         this.btnRemove.TabIndex = 6;
         this.btnRemove.Text = "Remove";
         this.btnRemove.UseVisualStyleBackColor = true;
         this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
         // 
         // btnAdd
         // 
         this.btnAdd.Location = new System.Drawing.Point(38, 498);
         this.btnAdd.Name = "btnAdd";
         this.btnAdd.Size = new System.Drawing.Size(63, 23);
         this.btnAdd.TabIndex = 5;
         this.btnAdd.Text = "Add";
         this.btnAdd.UseVisualStyleBackColor = true;
         this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
         // 
         // lstBoxSelected
         // 
         this.lstBoxSelected.FormattingEnabled = true;
         this.lstBoxSelected.Location = new System.Drawing.Point(38, 544);
         this.lstBoxSelected.Name = "lstBoxSelected";
         this.lstBoxSelected.Size = new System.Drawing.Size(120, 95);
         this.lstBoxSelected.TabIndex = 4;
         // 
         // lstBoxOptions
         // 
         this.lstBoxOptions.FormattingEnabled = true;
         this.lstBoxOptions.Items.AddRange(new object[] {
            "Breadth First (Levon)",
            "Depth FIrst (Levon)"});
         this.lstBoxOptions.Location = new System.Drawing.Point(38, 385);
         this.lstBoxOptions.Name = "lstBoxOptions";
         this.lstBoxOptions.Size = new System.Drawing.Size(120, 95);
         this.lstBoxOptions.TabIndex = 3;
         // 
         // lblPathLength
         // 
         this.lblPathLength.AutoSize = true;
         this.lblPathLength.Location = new System.Drawing.Point(1171, 399);
         this.lblPathLength.Name = "lblPathLength";
         this.lblPathLength.Size = new System.Drawing.Size(68, 13);
         this.lblPathLength.TabIndex = 2;
         this.lblPathLength.Text = "Path Length:";
         // 
         // lblVisited
         // 
         this.lblVisited.AutoSize = true;
         this.lblVisited.Location = new System.Drawing.Point(1171, 358);
         this.lblVisited.Name = "lblVisited";
         this.lblVisited.Size = new System.Drawing.Size(66, 13);
         this.lblVisited.TabIndex = 1;
         this.lblVisited.Text = "Tiles Visited:";
         // 
         // lblElapsedAvg
         // 
         this.lblElapsedAvg.AutoSize = true;
         this.lblElapsedAvg.Location = new System.Drawing.Point(1171, 324);
         this.lblElapsedAvg.Name = "lblElapsedAvg";
         this.lblElapsedAvg.Size = new System.Drawing.Size(55, 13);
         this.lblElapsedAvg.TabIndex = 0;
         this.lblElapsedAvg.Text = "Time (ms):";
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
         // cbRealtime
         // 
         this.cbRealtime.AutoSize = true;
         this.cbRealtime.Location = new System.Drawing.Point(1262, 252);
         this.cbRealtime.Name = "cbRealtime";
         this.cbRealtime.Size = new System.Drawing.Size(67, 17);
         this.cbRealtime.TabIndex = 22;
         this.cbRealtime.Text = "Realtime";
         this.cbRealtime.UseVisualStyleBackColor = true;
         // 
         // progressBar1
         // 
         this.progressBar1.Location = new System.Drawing.Point(715, 714);
         this.progressBar1.Name = "progressBar1";
         this.progressBar1.Size = new System.Drawing.Size(200, 23);
         this.progressBar1.TabIndex = 23;
         // 
         // NUDLoopsPerTick
         // 
         this.NUDLoopsPerTick.Location = new System.Drawing.Point(1171, 493);
         this.NUDLoopsPerTick.Maximum = new decimal(new int[] {
            1000,
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
         this.NUDLoopsPerTick.ValueChanged += new System.EventHandler(this.NUDLoopsPerTick_ValueChanged);
         // 
         // NUDInterval
         // 
         this.NUDInterval.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
         this.NUDInterval.Location = new System.Drawing.Point(1173, 544);
         this.NUDInterval.Maximum = new decimal(new int[] {
            1000,
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
         // Canvas
         // 
         this.Canvas.AutoSize = true;
         this.Canvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.Canvas.Location = new System.Drawing.Point(14, 14);
         this.Canvas.Margin = new System.Windows.Forms.Padding(5, 5, 200, 5);
         this.Canvas.Name = "Canvas";
         this.Canvas.Size = new System.Drawing.Size(700, 700);
         this.Canvas.TabIndex = 0;
         this.Canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.Canvas_Paint);
         // 
         // lblToickLoop
         // 
         this.lblToickLoop.AutoSize = true;
         this.lblToickLoop.Location = new System.Drawing.Point(1171, 474);
         this.lblToickLoop.Name = "lblToickLoop";
         this.lblToickLoop.Size = new System.Drawing.Size(67, 13);
         this.lblToickLoop.TabIndex = 26;
         this.lblToickLoop.Text = "TickAmount:";
         // 
         // lblInterval
         // 
         this.lblInterval.AutoSize = true;
         this.lblInterval.Location = new System.Drawing.Point(1171, 522);
         this.lblInterval.Name = "lblInterval";
         this.lblInterval.Size = new System.Drawing.Size(93, 13);
         this.lblInterval.TabIndex = 27;
         this.lblInterval.Text = "Interval Time (ms):";
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(1370, 749);
         this.Controls.Add(this.lblInterval);
         this.Controls.Add(this.lblToickLoop);
         this.Controls.Add(this.NUDInterval);
         this.Controls.Add(this.NUDLoopsPerTick);
         this.Controls.Add(this.progressBar1);
         this.Controls.Add(this.cbRealtime);
         this.Controls.Add(this.pnlKey);
         this.Controls.Add(this.pnlMetrics);
         this.Controls.Add(this.lblDrawTime);
         this.Controls.Add(this.lblElapsed);
         this.Controls.Add(this.lblXY);
         this.Controls.Add(this.txtBoxY);
         this.Controls.Add(this.lblPathLength);
         this.Controls.Add(this.txtBoxX);
         this.Controls.Add(this.lblVisited);
         this.Controls.Add(this.btnDepthFirst);
         this.Controls.Add(this.lblElapsedAvg);
         this.Controls.Add(this.lblCutPercent);
         this.Controls.Add(this.txtBoxPercent);
         this.Controls.Add(this.btnBreadthFirst);
         this.Controls.Add(this.btnRegen);
         this.Controls.Add(this.Canvas);
         this.DoubleBuffered = true;
         this.Name = "Form1";
         this.Text = "Form1";
         ((System.ComponentModel.ISupportInitialize)(this.pbStart)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.pbEnd)).EndInit();
         this.pnlMetrics.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.pbPath)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.pbVisited)).EndInit();
         this.pnlKey.ResumeLayout(false);
         this.pnlKey.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.NUDLoopsPerTick)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.NUDInterval)).EndInit();
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
      private System.Windows.Forms.Button btnBreadthFirst;
      private System.Windows.Forms.TextBox txtBoxPercent;
      private System.Windows.Forms.Label lblCutPercent;
      private System.Windows.Forms.Button btnDepthFirst;
      private System.Windows.Forms.TextBox txtBoxX;
      private System.Windows.Forms.TextBox txtBoxY;
      private System.Windows.Forms.Label lblXY;
      private System.Windows.Forms.Label lblElapsed;
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
      private System.Windows.Forms.CheckBox cbRealtime;
      private System.Windows.Forms.ProgressBar progressBar1;
      private System.Windows.Forms.NumericUpDown NUDLoopsPerTick;
      private System.Windows.Forms.NumericUpDown NUDInterval;
      private System.Windows.Forms.Label lblToickLoop;
      private System.Windows.Forms.Label lblInterval;
   }
}

