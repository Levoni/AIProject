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
         this.Canvas = new Maze.DBPanel();
         this.button1 = new System.Windows.Forms.Button();
         this.lblStart = new System.Windows.Forms.Label();
         this.lblEnd = new System.Windows.Forms.Label();
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
         ((System.ComponentModel.ISupportInitialize)(this.pbStart)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.pbEnd)).BeginInit();
         this.SuspendLayout();
         // 
         // Canvas
         // 
         this.Canvas.AutoSize = true;
         this.Canvas.Location = new System.Drawing.Point(14, 14);
         this.Canvas.Margin = new System.Windows.Forms.Padding(5, 5, 200, 5);
         this.Canvas.Name = "Canvas";
         this.Canvas.Size = new System.Drawing.Size(700, 700);
         this.Canvas.TabIndex = 0;
         this.Canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.Canvas_Paint);
         // 
         // button1
         // 
         this.button1.Location = new System.Drawing.Point(1171, 14);
         this.button1.Name = "button1";
         this.button1.Size = new System.Drawing.Size(75, 23);
         this.button1.TabIndex = 1;
         this.button1.Text = "Regenerate";
         this.button1.UseVisualStyleBackColor = true;
         this.button1.Click += new System.EventHandler(this.button1_Click);
         // 
         // lblStart
         // 
         this.lblStart.AutoSize = true;
         this.lblStart.Location = new System.Drawing.Point(1168, 351);
         this.lblStart.Name = "lblStart";
         this.lblStart.Size = new System.Drawing.Size(32, 13);
         this.lblStart.TabIndex = 2;
         this.lblStart.Text = "Start:";
         // 
         // lblEnd
         // 
         this.lblEnd.AutoSize = true;
         this.lblEnd.Location = new System.Drawing.Point(1168, 395);
         this.lblEnd.Name = "lblEnd";
         this.lblEnd.Size = new System.Drawing.Size(29, 13);
         this.lblEnd.TabIndex = 3;
         this.lblEnd.Text = "End:";
         // 
         // pbStart
         // 
         this.pbStart.Location = new System.Drawing.Point(1231, 342);
         this.pbStart.Name = "pbStart";
         this.pbStart.Size = new System.Drawing.Size(23, 22);
         this.pbStart.TabIndex = 4;
         this.pbStart.TabStop = false;
         // 
         // pbEnd
         // 
         this.pbEnd.Location = new System.Drawing.Point(1231, 386);
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
         this.btnBreadthFirst.Click += new System.EventHandler(this.brnBruteForce_Click);
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
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(1370, 749);
         this.Controls.Add(this.lblElapsed);
         this.Controls.Add(this.lblXY);
         this.Controls.Add(this.txtBoxY);
         this.Controls.Add(this.txtBoxX);
         this.Controls.Add(this.btnDepthFirst);
         this.Controls.Add(this.lblCutPercent);
         this.Controls.Add(this.txtBoxPercent);
         this.Controls.Add(this.btnBreadthFirst);
         this.Controls.Add(this.pbEnd);
         this.Controls.Add(this.pbStart);
         this.Controls.Add(this.lblEnd);
         this.Controls.Add(this.lblStart);
         this.Controls.Add(this.button1);
         this.Controls.Add(this.Canvas);
         this.DoubleBuffered = true;
         this.Name = "Form1";
         this.Text = "Form1";
         ((System.ComponentModel.ISupportInitialize)(this.pbStart)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.pbEnd)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private DBPanel Canvas;
      private System.Windows.Forms.Button button1;
      private System.Windows.Forms.Label lblStart;
      private System.Windows.Forms.Label lblEnd;
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
   }
}

