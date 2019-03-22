using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Maze
{
   //TODO: rename form components to proper names
   //TODO: Add options for running realtime functions
   //TODO: Unenable button and etc... when they should be and vise versa
   //TODO: Create Drawing method for realtime Drawing
   //TODO: confirm Draw time metric is correct and format it better on form
   public partial class Form1 : Form
   {
      Map m;
      AI pathfinding;
      int mapWidth;
      int mapHeight;
      int ticksPerLoops;
      System.Diagnostics.Stopwatch st;
      Bitmap WallBitmap = new Bitmap(700, 700);
      Bitmap MainBitmap = new Bitmap(700, 700);
      List<Panel> MetricPanels = new List<Panel>();

      //TODO: change selection method on form to remove this variable
      string searchName;


      public Form1()
      {
         InitializeComponent();

         // Initialize AI Class and stopwatch
         pathfinding = new AI();
         st = new System.Diagnostics.Stopwatch();

         //Generates the first map
         mapWidth = int.Parse(txtBoxX.Text);
         mapHeight = int.Parse(txtBoxY.Text);
         m = new Map(mapWidth, mapHeight);
         m.GenerateMap(int.Parse(txtBoxX.Text), int.Parse(txtBoxY.Text), int.Parse(txtBoxPercent.Text));
         MainBitmap = WallBitmap = CreateWallBitmap();

         //Set up AI info for the generated map
         pathfinding = new AI();
         pathfinding.CreateNodeMap(m.map, int.Parse(txtBoxX.Text), int.Parse(txtBoxX.Text),m.Start,m.End);

         //sets coor of picture boxes in the legend
         pbStart.BackColor = Color.Blue;
         pbEnd.BackColor = Color.Red;
         pbVisited.BackColor = Color.Cyan;
         pbPath.BackColor = Color.Purple;

         ticksPerLoops = (int) NUDLoopsPerTick.Value;
         timerTick.Interval = (int) NUDInterval.Value;
      }

      /// <summary>
      /// Function for drawing to the Panel
      /// </summary>
      /// <param name="sender">Canvas panel</param>
      /// <param name="e">Draw event</param>
      private void Canvas_Paint(object sender, PaintEventArgs e)
      {
         st.Start();
         e.Graphics.DrawImage(MainBitmap, 0, 0);
         
         st.Stop();
         lblDrawTime.Text = st.ElapsedMilliseconds.ToString();
         st.Reset();
      }

      /// <summary>
      /// Creats the bitmap for current Tile map
      /// </summary>
      /// <returns></returns>
      Bitmap CreateWallBitmap()
      {
         st.Restart();

         // Creates new bitmap and grpahics for the bitmap
         Bitmap wallBit = new Bitmap(700, 700);
         Graphics g = Graphics.FromImage(wallBit);

         // Creating the differnt pens/brushes used to draw in diffent colors
         Pen b = new Pen(Color.Black, 1);
         SolidBrush sbStart = new SolidBrush(Color.Blue);
         SolidBrush sbEnd = new SolidBrush(Color.Red);
         SolidBrush sbVisited = new SolidBrush(Color.Cyan);
         SolidBrush sbPath = new SolidBrush(Color.Purple);

         //TODO: the right and bottom side walls on the edge isn't drawn
         // when the tile amount is a divisor of pixel amount of the panel.
         foreach (Tile n in m.map)
         {
            // Creating local variables used in drawing calculations for current node
            int tileHeight = (Canvas.Height / mapHeight);
            int tilewidth = (Canvas.Width / mapWidth);
            int xPixel = n.xPos * tilewidth;
            int yPixel = n.yPos * tileHeight;

            // Drawing the walls of each tile
            if (n.nodes[(int)dir.UP] == null)
               g.DrawLine(b,
                  xPixel, yPixel, xPixel + tilewidth, yPixel);
            if (n.nodes[(int)dir.RIGHT] == null)
               g.DrawLine(b,
                  xPixel + tilewidth, yPixel, xPixel + tilewidth, yPixel + tileHeight);
            if (n.nodes[(int)dir.DOWN] == null)
               g.DrawLine(b,
                  xPixel, yPixel + tileHeight, xPixel + tilewidth, yPixel + tileHeight);
            if (n.nodes[(int)dir.LEFT] == null)
               g.DrawLine(b,
                  xPixel, yPixel, xPixel, yPixel + tileHeight);
         }
         st.Stop();
         return wallBit;
      }

      /// <summary>
      /// Creates the bitmap with the current search information and 
      /// wallBitmap.
      /// </summary>
      /// <returns></returns>
      Bitmap CreateSearchBitmap()
      {
         st.Start();

         // Creates new bitmap and grpahics for the bitmap
         Bitmap tempBitmap = new Bitmap(Canvas.Width, Canvas.Height);
         Graphics g = Graphics.FromImage(tempBitmap);

         // Creates all the pens/brushes used for drawing
         Pen b = new Pen(Color.Black, 1);
         SolidBrush sbStart = new SolidBrush(Color.Blue);
         SolidBrush sbEnd = new SolidBrush(Color.Red);
         SolidBrush sbVisited = new SolidBrush(Color.Cyan);
         SolidBrush sbPath = new SolidBrush(Color.Purple);

         foreach (AINode n in pathfinding.nodeMap)
         {
            //creating local variables used in drawing calculations for current node
            int tileHeight = (Canvas.Height / mapHeight);
            int tilewidth = (Canvas.Width / mapWidth);
            int xPixel = n.x * tilewidth;
            int yPixel = n.y * tileHeight;

            // Drawing the results of x search algorithm after it runs
            if (n.pl == place.start)
               g.FillRectangle(sbStart, xPixel, yPixel, tilewidth, tileHeight);
            else if (n.pl == place.end)
               g.FillRectangle(sbEnd, xPixel, yPixel, tilewidth, tileHeight);
            else if (n.pl == place.path)
               g.FillRectangle(sbPath, xPixel, yPixel, tilewidth, tileHeight);
            else if (n.visited)
               g.FillRectangle(sbVisited, xPixel, yPixel, tilewidth, tileHeight);
         }

         g.DrawImage(WallBitmap, 0, 0); // Draws wall bitmap to currently generating bitmap
         st.Stop();
         return tempBitmap;
      }

      /// <summary>
      /// Sets labels text to different metrics
      /// </summary>
      /// <param name="time">Label to set text to the Elapsed time number</param>
      /// <param name="visited">Label to set text to the Visited tile number</param>
      /// <param name="length">Label to set text to the path length number</param>
      void SetMetricLabelText(Label time, Label visited, Label length)
      {
         time.Text = "Elapsed Time (ms): " + pathfinding.time.ToString();
         visited.Text = "Visited Nodes: " + pathfinding.visitedTiles.ToString();
         length.Text = "Path Length: " + pathfinding.pathLength.ToString();
      }

      /// <summary>
      /// Used to Generate a new map based on information in the
      /// size and open percentage text boxes
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void btnRegen_Click(object sender, EventArgs e)
      {
         // Reseting Map
         mapWidth = int.Parse(txtBoxX.Text);
         mapHeight = int.Parse(txtBoxY.Text);
         m = new Map(mapWidth, mapHeight);
         int percent = int.Parse(txtBoxPercent.Text);

         // Generate Map and set time elapsed statistic label
         lblElapsed.Text = "Elpsed TIme: " + m.GenerateMap(0, 0, percent) + " ms";
         
         //Removes any Metric panels that are still being displayed
         foreach (Control c in MetricPanels)
         {
            c.Dispose();
            Controls.Remove(c);
         }
         MetricPanels = new List<Panel>();


         // Generate the coorisponding node map for tile map
         pathfinding.CreateNodeMap(m.map, int.Parse(txtBoxX.Text), int.Parse(txtBoxY.Text),m.Start,m.End);

         // Creates the bitmaps that will be drawn 
         WallBitmap = CreateWallBitmap();
         MainBitmap = CreateSearchBitmap();

         // Forces Garbage to be collected
         GC.Collect();
         GC.WaitForPendingFinalizers();
         GC.Collect();  

         Canvas.Invalidate(); // Forces Canvas to redraw
      }

      /// <summary>
      /// Used to run the Breadth first search It first resets the previous
      /// searches info and then runs the new search
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void btnBreadthFirst_Click(object sender, EventArgs e)
      {
         if (!cbRealtime.Checked)
         {
            pathfinding.ResetNodeSearchInfo();
            lblElapsed.Text = "Elpsed TIme: " + pathfinding.RunSearch("Breadth First (Levon)",m.Start.xPos, m.Start.yPos, m.End.xPos, m.End.yPos) + " ms";
            pathfinding.GenerateMetrics();
            SetMetricLabelText(lblElapsedAvg, lblVisited, lblPathLength);
            MainBitmap = CreateSearchBitmap();
         }
         else
         {
            pathfinding.ResetNodeSearchInfo();
            pathfinding.StartRealtimeSearch("Breadth First Realtime (Levon)", m.Start.xPos, m.Start.yPos,m.End.xPos,m.End.yPos);
            timerTick.Enabled = true;
            searchName = "Breadth First Realtime (Levon)";
         }
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
         if (!cbRealtime.Checked)
         {
            pathfinding.ResetNodeSearchInfo();
            lblElapsed.Text = "Elpsed TIme: " + pathfinding.RunSearch("Depth First (Levon)", m.Start.xPos, m.Start.yPos, m.End.xPos, m.End.yPos) + " ms";
            pathfinding.GenerateMetrics();
            SetMetricLabelText(lblElapsedAvg, lblVisited, lblPathLength);
            MainBitmap = CreateSearchBitmap();
         }
         else
         {
            pathfinding.ResetNodeSearchInfo();
            pathfinding.StartRealtimeSearch("Depth First Realtime (Levon)", m.Start.xPos, m.Start.yPos,m.End.xPos,m.End.yPos);
            timerTick.Enabled = true;
            searchName = "Depth First Realtime (Levon)";
         }
         Canvas.Invalidate(); // forces Canvas to redraw
      }

      /// <summary>
      /// Creates Components for different search algorithms.
      /// </summary>
      /// <param name="numOfCompnents">Number of searches to create components for</param>
      /// <param name="searches">Search names to run</param>
      public void CreateMetricComponents(int numOfCompnents, List<string> searches)
      {
         PBarMetrics.Value = 0;
         // Removes any Metric Panels currently being displayed
         foreach (Control c in MetricPanels)
         {
            c.Dispose();
            Controls.Remove(c);
         }

         // Sets local variables for size and location of panel
         // containing all the metric panlels
         int xSize = pnlMetrics.Bounds.Width;
         int ySize = pnlMetrics.Bounds.Height;
         int xLoc = pnlMetrics.Bounds.X;
         int yLoc = pnlMetrics.Bounds.Y;

         float totalRuns = numOfCompnents * 10;
         float curRun = 0;

         if (totalRuns == 0)
            PBarMetrics.Value = 100;

         //Loop for creating the Metric panels
         for (int i = 0; i < numOfCompnents; i++)
         {

            // Runs through the current search x times to create reliable metrics
            //TODO: allow for passing in a variable number for amount of runs of each search
            float time = 0;
            for (int j = 0; j < 10; j++)
            {
               pathfinding.ResetNodeSearchInfo();
               time += pathfinding.RunSearch(searches[i], m.Start.xPos, m.Start.yPos, m.End.xPos, m.End.yPos);
               PBarMetrics.Value = (int) (100 * (++curRun / totalRuns));
            }
            time = time / 10;
            pathfinding.GenerateMetrics();

            // Creates and sets up the differnet controls for the metric panel
            Panel tempPanel = new Panel();
            tempPanel.Bounds = new Rectangle(xLoc, yLoc + i * ySize / numOfCompnents, xSize, ySize / numOfCompnents);
            tempPanel.BorderStyle = BorderStyle.FixedSingle;
            tempPanel.Name = "mPanel" + i.ToString();
            Label tempName = new Label();
            tempName.Location = new Point(0, 0);
            tempName.AutoSize = true;
            tempName.Text = searches[i];

            Label tempElapsed = new Label();
            tempElapsed.Location = new Point(0, 0 + ((ySize / numOfCompnents) / 5) * 1);
            tempElapsed.AutoSize = true;

            Label tempVisited = new Label();
            tempVisited.Location = new Point(0, 0 + ((ySize / numOfCompnents) / 5) * 2);
            tempVisited.AutoSize = true;

            Label tempPathLength = new Label();
            tempPathLength.Location = new Point(0, 0 + ((ySize / numOfCompnents) / 5) * 3);
            tempPathLength.AutoSize = true;

            Button tempB = new Button();
            tempB.Location = new Point(0, 0 + ((ySize / numOfCompnents) / 5) * 4);
            tempB.AutoSize = true;
            tempB.Text = "Show Bitmap";
            Bitmap tempBitmap = CreateSearchBitmap();
            
            // TODO: look into passing bitmap into lambda function to remove global variable
            tempB.Click += new EventHandler((sender, e) => btnShow_Click(sender, e, tempBitmap));

            SetMetricLabelText(tempElapsed, tempVisited, tempPathLength);

            // Adds bitmap for search into the global bitmap list
            //SearchBitmaps.Add(CreateSearchBitmap());

            // Adds the controls to the necessary components
            this.Controls.Add(tempPanel);
            tempPanel.Controls.Add(tempName);
            tempPanel.Controls.Add(tempElapsed);
            tempPanel.Controls.Add(tempVisited);
            tempPanel.Controls.Add(tempPathLength);
            tempPanel.Controls.Add(tempB);
            tempPanel.BringToFront();

            tempPanel.Refresh();

            // Adds metric panel to global metricPanel list
            MetricPanels.Add(tempPanel);
         }
      }

      /// <summary>
      /// Shows the bitmap that corrisponding location of SearchBitmaps.
      /// </summary>
      /// <param name="sender">Button</param>
      /// <param name="e">Click Event</param>
      /// <param name="num">The index for the bitmap to display</param>
      private void btnShow_Click(object sender, EventArgs e, Bitmap bitmap)
      {
         MainBitmap = bitmap;
         Canvas.Invalidate();
      }

      /// <summary>
      /// Adds the selected item in lstBoxOptions to lstBoxSelected.
      /// </summary>
      /// <param name="sender">Button</param>
      /// <param name="e">Click Event</param>
      private void btnAdd_Click(object sender, EventArgs e)
      {
         if (lstBoxOptions.SelectedIndex != -1)
            lstBoxSelected.Items.Add(lstBoxOptions.SelectedItem.ToString());
      }

      /// <summary>
      /// Removes the selected item in lstboxSelected
      /// </summary>
      /// <param name="sender">Button</param>
      /// <param name="e">Click Event</param>
      private void btnRemove_Click(object sender, EventArgs e)
      {
         if (lstBoxSelected.SelectedIndex != -1)
            lstBoxSelected.Items.RemoveAt(lstBoxSelected.SelectedIndex);
      }

      /// <summary>
      /// Creates metrics for the search functions in lstBoxSelected.
      /// </summary>
      /// <param name="sender">Button</param>
      /// <param name="e">Click Event</param>
      private void btnMetrics_Click(object sender, EventArgs e)
      {
         List<string> stringList = new List<string>();
         foreach (object o in lstBoxSelected.Items)
         {
            stringList.Add(o.ToString());
         }
         CreateMetricComponents(lstBoxSelected.Items.Count, stringList);
      }

      /// <summary>
      /// Runs the realtime search after it has started.
      /// Occures after a set interval for the timer tick.
      /// </summary>
      /// <param name="sender">Timmer</param>
      /// <param name="e">Tick Event</param>
      private void timerTick_Tick(object sender, EventArgs e)
      {
         if (pathfinding.RunRealtimeSearch(searchName, ticksPerLoops))
            timerTick.Enabled = false;
         MainBitmap = CreateSearchBitmap();
         Canvas.Invalidate();
         
      }

      private void NUDLoopsPerTick_ValueChanged(object sender, EventArgs e)
      {
         ticksPerLoops = (int) NUDLoopsPerTick.Value;
      }

      private void NUDInterval_ValueChanged(object sender, EventArgs e)
      {
         timerTick.Interval = (int) NUDInterval.Value;
      }
   }
}
