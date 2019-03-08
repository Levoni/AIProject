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
      AI pathfinding;
      int mapWidth;
      int mapHeight;

      public Form1()
      {
         InitializeComponent();
         pathfinding = new AI();

         //Generates the first map
         mapWidth = int.Parse(txtBoxX.Text);
         mapHeight = int.Parse(txtBoxY.Text);
         m = new Map(mapWidth, mapHeight);
         m.GenerateMap(int.Parse(txtBoxX.Text), int.Parse(txtBoxY.Text), int.Parse(txtBoxPercent.Text));

         //Set up AI info for the generated map
         pathfinding = new AI();
         pathfinding.CreateNodeMap(m.map, int.Parse(txtBoxX.Text), int.Parse(txtBoxX.Text));

         //sets coor of picture boxes in the legend
         pbStart.BackColor = Color.Blue;
         pbEnd.BackColor = Color.Red;
      }

      private void Canvas_Paint(object sender, PaintEventArgs e)
      {
         // Creating the differnt pens/brushes used to draw in diffent colors
         Pen b = new Pen(Color.Black,1);
         SolidBrush sbStart = new SolidBrush(Color.Blue);
         SolidBrush sbEnd = new SolidBrush(Color.Red);
         SolidBrush sbVisited = new SolidBrush(Color.Cyan);
         SolidBrush sbPath = new SolidBrush(Color.Purple);

         //TODO: the right and bottom side walls on the edge isn't drawn
         // when the tile amount is a divisor of pixel amount of the panel.
         if (pathfinding.nodeMap != null)
         {
            foreach (AI.AINode n in pathfinding.nodeMap)
            {
               //creating local variables used in drawing calculations for current node
               int tileHeight = (Canvas.Height / mapHeight);
               int tilewidth = (Canvas.Width / mapWidth);
               int xPixel = n.x * tilewidth;
               int yPixel = n.y * tileHeight;

               // Drawing the results of x search algorithm after it runs

               if (n.pl == place.start)
                  e.Graphics.FillRectangle(sbStart, xPixel, yPixel, tilewidth, tileHeight);
               else if (n.pl == place.end)
                  e.Graphics.FillRectangle(sbEnd, xPixel, yPixel, tilewidth, tileHeight);
               else if (n.pl == place.path)
                  e.Graphics.FillRectangle(sbPath, xPixel, yPixel, tilewidth, tileHeight);
               else if (n.visited)
                  e.Graphics.FillRectangle(sbVisited, xPixel, yPixel, tilewidth, tileHeight);
            }
         }

         foreach (Tile n in m.map)
         {
            //creating local variables used in drawing calculations for current node
            int tileHeight = (Canvas.Height / mapHeight);
            int tilewidth = (Canvas.Width / mapWidth);
            int xPixel = n.xPos * tilewidth;
            int yPixel = n.yPos * tileHeight;

            // Drawing the walls of each node
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

      /// <summary>
      /// Used to Generate a new map based on information in the
      /// size and open percentage text boxes
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void button1_Click(object sender, EventArgs e)
      {
         // Reseting Map
         mapWidth = int.Parse(txtBoxX.Text);
         mapHeight = int.Parse(txtBoxY.Text);
         m = new Map(mapWidth, mapHeight);
         int percent = int.Parse(txtBoxPercent.Text);

         // Generate Map and set time elapsed statistic label
         lblElapsed.Text = "Elpsed TIme: " + m.GenerateMap(0,0,percent) + " ms";

         // Generate the coorisponding node map for tile map
         pathfinding.CreateNodeMap(m.map, int.Parse(txtBoxX.Text), int.Parse(txtBoxY.Text));

         Canvas.Invalidate(); // forces Canvas to redraw
      }

      /// <summary>
      /// Used to run the Breadth first search It first resets the previous
      /// searches info and then runs the new search
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void brnBruteForce_Click(object sender, EventArgs e)
      {
         pathfinding.ResetNodeSearchInfo();
         lblElapsed.Text = "Elpsed TIme: " + pathfinding.BreathFirstSearch(m.Start.xPos, m.End.xPos,m.Start.yPos,m.End.yPos) + " ms";
         Canvas.Invalidate(); // forces Canvas to redraw
      }

      /// <summary>
      /// Used to run the Depth first search It first resets the previous
      /// searches info and then runs the new search
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void btnDepthFirst_Click(object sender, EventArgs e)
      {
         pathfinding.ResetNodeSearchInfo();
         lblElapsed.Text = "Elpsed TIme: " + pathfinding.DepthFIrstSearch(m.Start.xPos, m.End.xPos, m.Start.yPos, m.End.yPos) + " ms";
         Canvas.Invalidate(); // forces Canvas to redraw
      }
   }
}
