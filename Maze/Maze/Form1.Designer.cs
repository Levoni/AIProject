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
         this.panel1 = new System.Windows.Forms.Panel();
         this.button1 = new System.Windows.Forms.Button();
         this.lblStart = new System.Windows.Forms.Label();
         this.lblEnd = new System.Windows.Forms.Label();
         this.pbStart = new System.Windows.Forms.PictureBox();
         this.pbEnd = new System.Windows.Forms.PictureBox();
         this.brnBruteForce = new System.Windows.Forms.Button();
         this.txtBoxPercent = new System.Windows.Forms.TextBox();
         this.lblCutPercent = new System.Windows.Forms.Label();
         ((System.ComponentModel.ISupportInitialize)(this.pbStart)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.pbEnd)).BeginInit();
         this.SuspendLayout();
         // 
         // panel1
         // 
         this.panel1.AutoSize = true;
         this.panel1.Location = new System.Drawing.Point(14, 14);
         this.panel1.Margin = new System.Windows.Forms.Padding(5, 5, 200, 5);
         this.panel1.Name = "panel1";
         this.panel1.Size = new System.Drawing.Size(577, 433);
         this.panel1.TabIndex = 0;
         this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
         // 
         // button1
         // 
         this.button1.Location = new System.Drawing.Point(599, 14);
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
         this.lblStart.Location = new System.Drawing.Point(599, 351);
         this.lblStart.Name = "lblStart";
         this.lblStart.Size = new System.Drawing.Size(32, 13);
         this.lblStart.TabIndex = 2;
         this.lblStart.Text = "Start:";
         // 
         // lblEnd
         // 
         this.lblEnd.AutoSize = true;
         this.lblEnd.Location = new System.Drawing.Point(599, 395);
         this.lblEnd.Name = "lblEnd";
         this.lblEnd.Size = new System.Drawing.Size(29, 13);
         this.lblEnd.TabIndex = 3;
         this.lblEnd.Text = "End:";
         // 
         // pbStart
         // 
         this.pbStart.Location = new System.Drawing.Point(662, 342);
         this.pbStart.Name = "pbStart";
         this.pbStart.Size = new System.Drawing.Size(23, 22);
         this.pbStart.TabIndex = 4;
         this.pbStart.TabStop = false;
         // 
         // pbEnd
         // 
         this.pbEnd.Location = new System.Drawing.Point(662, 386);
         this.pbEnd.Name = "pbEnd";
         this.pbEnd.Size = new System.Drawing.Size(23, 22);
         this.pbEnd.TabIndex = 5;
         this.pbEnd.TabStop = false;
         // 
         // brnBruteForce
         // 
         this.brnBruteForce.Location = new System.Drawing.Point(602, 219);
         this.brnBruteForce.Name = "brnBruteForce";
         this.brnBruteForce.Size = new System.Drawing.Size(75, 23);
         this.brnBruteForce.TabIndex = 6;
         this.brnBruteForce.Text = "Brute Force";
         this.brnBruteForce.UseVisualStyleBackColor = true;
         this.brnBruteForce.Click += new System.EventHandler(this.brnBruteForce_Click);
         // 
         // txtBoxPercent
         // 
         this.txtBoxPercent.Location = new System.Drawing.Point(599, 70);
         this.txtBoxPercent.Name = "txtBoxPercent";
         this.txtBoxPercent.Size = new System.Drawing.Size(100, 20);
         this.txtBoxPercent.TabIndex = 7;
         this.txtBoxPercent.Text = "0";
         // 
         // lblCutPercent
         // 
         this.lblCutPercent.AutoSize = true;
         this.lblCutPercent.Location = new System.Drawing.Point(602, 51);
         this.lblCutPercent.Name = "lblCutPercent";
         this.lblCutPercent.Size = new System.Drawing.Size(130, 13);
         this.lblCutPercent.TabIndex = 8;
         this.lblCutPercent.Text = "Open Percentage (0-100):";
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(800, 450);
         this.Controls.Add(this.lblCutPercent);
         this.Controls.Add(this.txtBoxPercent);
         this.Controls.Add(this.brnBruteForce);
         this.Controls.Add(this.pbEnd);
         this.Controls.Add(this.pbStart);
         this.Controls.Add(this.lblEnd);
         this.Controls.Add(this.lblStart);
         this.Controls.Add(this.button1);
         this.Controls.Add(this.panel1);
         this.Name = "Form1";
         this.Text = "Form1";
         ((System.ComponentModel.ISupportInitialize)(this.pbStart)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.pbEnd)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Panel panel1;
      private System.Windows.Forms.Button button1;
      private System.Windows.Forms.Label lblStart;
      private System.Windows.Forms.Label lblEnd;
      private System.Windows.Forms.PictureBox pbStart;
      private System.Windows.Forms.PictureBox pbEnd;
      private System.Windows.Forms.Button brnBruteForce;
      private System.Windows.Forms.TextBox txtBoxPercent;
      private System.Windows.Forms.Label lblCutPercent;
   }
}

