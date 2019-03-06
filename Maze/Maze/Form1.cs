using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maze
{
   public partial class Form1 : Form
   {
      Map m;
      int mapWidth = 10;
      int mapHeight = 10;

      public Form1()
      {
         InitializeComponent();
         mapWidth = int.Parse(txtBoxX.Text);
         mapHeight = int.Parse(txtBoxY.Text);
         m = new Map(mapWidth,mapHeight);
         m.GenerateMap(int.Parse(txtBoxX.Text), int.Parse(txtBoxY.Text), int.Parse(txtBoxPercent.Text));
         pbStart.BackColor = Color.Blue;
         pbEnd.BackColor = Color.Red;
      }

      private void panel1_Paint(object sender, PaintEventArgs e)
      {
         Pen b = new Pen(Color.Black,1);
         SolidBrush sbStart = new SolidBrush(Color.Blue);
         SolidBrush sbEnd = new SolidBrush(Color.Red);
         SolidBrush sbVisited = new SolidBrush(Color.Cyan);
         SolidBrush sbPath = new SolidBrush(Color.Purple);
         
         //e.Graphics.DrawRectangle(b, 0, 0, panel1.Width - (panel1.Width % 10), panel1.Height - (panel1.Height % 10));
         foreach (Node n in m.map)
         {
            int tileHeight = (panel1.Height / mapHeight);
            int tilewidth = (panel1.Width / mapWidth);
            int xPixel = n.xPos * tilewidth;
            int yPixel = n.yPos * tileHeight;
            if (n.visited)
               e.Graphics.FillRectangle(sbVisited, xPixel, yPixel, tilewidth, tileHeight);
            if (n.pl == place.start)
               e.Graphics.FillRectangle(sbStart, xPixel, yPixel, tilewidth, tileHeight);
            if(n.pl == place.end)
               e.Graphics.FillRectangle(sbEnd, xPixel, yPixel, tilewidth, tileHeight);
            if (n.pl == place.path)
               e.Graphics.FillRectangle(sbPath, xPixel, yPixel, tilewidth, tileHeight);
            if (n.nodes[(int)dir.UP] == null)
               e.Graphics.DrawLine(b,
                  xPixel, yPixel, xPixel + tilewidth, yPixel);
            if (n.nodes[(int)dir.RIGHT] == null)
               e.Graphics.DrawLine(b,
                  xPixel + tilewidth, yPixel, xPixel + tilewidth, yPixel + tileHeight);
            if (n.nodes[(int)dir.DOWN] == null)
               e.Graphics.DrawLine(b,
                  xPixel, yPixel + tileHeight, xPixel + tilewidth, yPixel + tileHeight);
            if (n.nodes[(int)dir.LEFT] == null)
               e.Graphics.DrawLine(b,
                  xPixel, yPixel, xPixel, yPixel + tileHeight);
         }
      }

      private void button1_Click(object sender, EventArgs e)
      {
         mapWidth = int.Parse(txtBoxX.Text);
         mapHeight = int.Parse(txtBoxY.Text);
         m = new Map(mapWidth, mapHeight);
         int percent = int.Parse(txtBoxPercent.Text);
         lblElapsed.Text = "Elpsed TIme: " + m.GenerateMap(0,0,percent) + " ms";
         panel1.Invalidate();
      }

      private void brnBruteForce_Click(object sender, EventArgs e)
      {
         
         m.ResetNodeInfo();
         lblElapsed.Text = "Elpsed TIme: " + m.BreathFirstSearch(m.Start,m.End) + " ms";
         panel1.Invalidate();
      }

      private void btnDepthFirst_Click(object sender, EventArgs e)
      {
         m.ResetNodeInfo();
         lblElapsed.Text = "Elpsed TIme: " + m.DepthFIrstSearch(m.Start, m.End) + " ms";
         panel1.Invalidate();
      }
   }
}
