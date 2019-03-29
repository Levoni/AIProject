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
   //TODO: Add ability to stop the realtime search
   //TODO: Disable button and etc... when they should be and vise versa
   public partial class Form1 : Form
   {
      Map m;
      AI pathfinding;
      int mapWidth;
      int mapHeight;
      System.Diagnostics.Stopwatch st;
      Bitmap WallBitmap = new Bitmap(700, 700);
      Bitmap MainBitmap = new Bitmap(700, 700);
      List<Panel> MetricPanels = new List<Panel>();
      bool selectingStartEnd = false;

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
         lblMapGenerationTime.Text = "Generation Time: " + m.GenerateMap(int.Parse(txtBoxPercent.Text)).ToString();

         //Set up AI info for the generated map
         pathfinding = new AI();
         pathfinding.CreateNodeMap(m.map, int.Parse(txtBoxX.Text), int.Parse(txtBoxX.Text),m.Start,m.End);

         //sets coor of picture boxes in the legend
         pbStart.BackColor = Color.Blue;
         pbEnd.BackColor = Color.Red;
         pbVisited.BackColor = Color.Cyan;
         pbPath.BackColor = Color.Purple;

         // Sets Realtime variables
         timerTick.Interval = (int) NUDInterval.Value;
      }

      /// <summary>
      /// Resizes and repositions components on form.
      /// It then draws the bitmaps for the canvas panel.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void Form1_Load(object sender, EventArgs e)
      {
         RepositionAndResize();

         // Draws map
         WallBitmap = CreateWallBitmap();
         MainBitmap = CreateSearchBitmap();
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
         lblDrawTime.Text = "Draw Time: " + st.ElapsedMilliseconds.ToString();
         st.Reset();
      }

      /// <summary>
      /// Repositions and/or resizes conponents on the form
      /// </summary>
      public void RepositionAndResize()
      {
         int titleHeight = this.Height - this.ClientRectangle.Height;

         int formWidth = ClientRectangle.Width;
         int formHeight = this.Height - titleHeight;

         Canvas.Bounds = new Rectangle(14, 14, formHeight - 28, formHeight - 28);

         lblCanvasSize.Text = "Canvas Size: " + Canvas.Width.ToString() + " , " + Canvas.Height.ToString();

         pnlMetricOptions.Bounds = new Rectangle(formHeight - 14 + 20, 14, formWidth / 7, formHeight / 7);
         btnMetrics.Bounds = new Rectangle(0, pnlMetricOptions.Height / 2, pnlMetricOptions.Width / 2, pnlMetricOptions.Height / 2);
         btnClearMetrics.Bounds = new Rectangle(pnlMetricOptions.Width / 2, pnlMetricOptions.Height / 2, pnlMetricOptions.Width / 2, pnlMetricOptions.Height / 2);
         
         pnlMetrics.Bounds = new Rectangle(pnlMetricOptions.Bounds.X, 14 + formHeight / 7, formWidth / 7, formHeight - pnlMetricOptions.Bottom - PBarMetrics.Height - 14);
         lblSearches.Bounds = new Rectangle(0, 0, pnlMetrics.Bounds.Width, pnlMetrics.Bounds.Height / 10);
         lstBoxOptions.Bounds = new Rectangle(0, pnlMetrics.Height / 10, pnlMetrics.Width, pnlMetrics.Height / 5);
         btnAdd.Bounds = new Rectangle(0, pnlMetrics.Height / 10 * 4, pnlMetrics.Width / 2, pnlMetrics.Height / 10);
         btnRemove.Bounds = new Rectangle(pnlMetrics.Width / 2, pnlMetrics.Height / 10 * 4, pnlMetrics.Width / 2, pnlMetrics.Height / 10);
         lblSelectedSearches.Bounds = new Rectangle(0, pnlMetrics.Height / 10 * 5, pnlMetrics.Width, pnlMetrics.Height / 10);
         lstBoxSelected.Bounds = new Rectangle(0, pnlMetrics.Height / 10 * 6, pnlMetrics.Width, pnlMetrics.Height / 5);

         PBarMetrics.Bounds = new Rectangle(pnlMetrics.Location.X, pnlMetrics.Location.Y + pnlMetrics.Height, pnlMetrics.Width, formHeight / 7);

         pnlMapGeneration.Location = new Point(formWidth - pnlMapGeneration.Width - 28, 14);

         pnlFileIO.Location = new Point(formWidth - pnlMapGeneration.Width - 28, pnlMapGeneration.Bottom);

         lblDrawTime.Location = new Point(pnlMapGeneration.Location.X, pnlFileIO.Bottom);

         pnlSingleSearch.Location = new Point(pnlMapGeneration.Location.X, pnlFileIO.Bottom + 24);

         pnlRealtimeSettings.Location = new Point(pnlMapGeneration.Location.X, pnlSingleSearch.Bottom);

         pnlKey.Location = new Point(pnlMapGeneration.Left, formHeight - pnlKey.Height - 28);

      }

      /// <summary>
      /// Creats the bitmap for current Tile map
      /// </summary>
      /// <returns>Bitmap of map with only the walls displayed</returns>
      Bitmap CreateWallBitmap()
      {
         st.Restart();

         // Creates new bitmap and grpahics for the bitmap
         Bitmap wallBit = new Bitmap(Canvas.Width, Canvas.Height);
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
            if (n.adjacentTiles[(int)dir.UP] == null)
               g.DrawLine(b,
                  xPixel, yPixel, xPixel + tilewidth, yPixel);
            if (n.adjacentTiles[(int)dir.RIGHT] == null)
               g.DrawLine(b,
                  xPixel + tilewidth, yPixel, xPixel + tilewidth, yPixel + tileHeight);
            if (n.adjacentTiles[(int)dir.DOWN] == null)
               g.DrawLine(b,
                  xPixel, yPixel + tileHeight, xPixel + tilewidth, yPixel + tileHeight);
            if (n.adjacentTiles[(int)dir.LEFT] == null)
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
      /// <returns>Bitmap of map with current search information displayed</returns>
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
      /// Creates a bitmap with main bitmap and new node informaiton. Used
      /// for faster realtime drawing.
      /// </summary>
      /// <param name="nodes">List of new nodes to draw</param>
      /// <returns>Bitmap of map with current search information</returns>
      Bitmap DrawNodes(List<AINode> nodes)
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

         foreach (AINode n in nodes)
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

         g.DrawImage(MainBitmap,0,0);

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

         // Generate Map
         int percent = int.Parse(txtBoxPercent.Text);
         lblMapGenerationTime.Text = "Generation Time: " + m.GenerateMap(percent).ToString();
         
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
      /// Used to run the Depth first search It first resets the previous
      /// searches info and then runs the new search
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void btnRunSearch_Click(object sender, EventArgs e)
      {
         if (cBoxSelection.SelectedItem != null)
         {
            pathfinding.ResetNodeSearchInfo();
            if (!cbRealtime.Checked)
            {
               pathfinding.RunSearch(cBoxSelection.SelectedItem.ToString(), m.Start.xPos, m.Start.yPos, m.End.xPos, m.End.yPos);
               pathfinding.GenerateMetrics();
               SetMetricLabelText(lblElapsedAvg, lblVisited, lblPathLength);
               MainBitmap = CreateSearchBitmap();
            }
            else
            {
               pathfinding.CreateNodeMap(m.map, mapWidth, mapHeight, m.Start, m.End);
               MainBitmap = CreateSearchBitmap(); // resets drawn map
               pathfinding.StartRealtimeSearch(cBoxSelection.SelectedItem.ToString() + " Realtime", m.Start.xPos, m.Start.yPos, m.End.xPos, m.End.yPos);
               timerTick.Enabled = true;
            }
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
         MetricPanels = new List<Panel>(); // GC doesn't collect bitmaps otherwise

         // Sets local variables for size and location of panel
         // containing all the metric panlels
         int xSize = pnlMetrics.Bounds.Width;
         int ySize = pnlMetrics.Bounds.Height;
         int xLoc = pnlMetrics.Bounds.X;
         int yLoc = pnlMetrics.Bounds.Y;

         float totalRuns = numOfCompnents * (float)NUDRuns.Value;
         float curRun = 0;

         if (totalRuns == 0)
            PBarMetrics.Value = 100;

         //Loop for creating the Metric panels
         for (int i = 0; i < numOfCompnents; i++)
         {

            // Runs through the current search x times to create reliable metrics
            //TODO: allow for passing in a variable number for amount of runs of each search
            float time = 0;
            for (int j = 0; j < NUDRuns.Value; j++)
            {
               pathfinding.ResetNodeSearchInfo();
               time += pathfinding.RunSearch(searches[i], m.Start.xPos, m.Start.yPos, m.End.xPos, m.End.yPos);
               PBarMetrics.Value = (int) (100 * (++curRun / totalRuns));
            }
            time = time / (float)NUDRuns.Value;
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
            tempElapsed.Text = time.ToString();

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
         if (pathfinding.RunRealtimeSearch((int)NUDLoopsPerTick.Value, out List<AINode> tempNodes))
         {
            timerTick.Enabled = false;
            MainBitmap = CreateSearchBitmap();
            pathfinding.GenerateMetrics();
            SetMetricLabelText(lblElapsedAvg, lblVisited, lblPathLength);
            lblElapsedAvg.Text = "Elapsed Time (ms): N/A";
         }
         else
            MainBitmap = DrawNodes(tempNodes);

         Canvas.Invalidate();
         
      }

      /// <summary>
      /// Sets the timer interval to the NUDInterval value when it changes
      /// </summary>
      /// <param name="sender">NumericUpDown component</param>
      /// <param name="e">valueChanged</param>
      private void NUDInterval_ValueChanged(object sender, EventArgs e)
      {
         timerTick.Interval = (int) NUDInterval.Value;
      }

      /// <summary>
      /// Sets the selecingStartEnd bool to true
      /// </summary>
      /// <param name="sender">Button</param>
      /// <param name="e">click</param>
      private void BtnSetStartEnd_Click(object sender, EventArgs e)
      {
         selectingStartEnd = true;
         BtnSetStartEnd.Enabled = false;
      }

      /// <summary>
      /// Sets the start or end (based on radio buttons) of the maze
      /// to location clicked on canvas panel if selectingStartEnd is true.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void Canvas_Click(object sender, EventArgs e)
      {
         if(selectingStartEnd)
         {
            // Gets the mouse position relative to the canvas's top left pixel position
            int x = MousePosition.X - Canvas.PointToScreen(new Point(0, 0)).X;
            int y = MousePosition.Y - Canvas.PointToScreen(new Point(0, 0)).Y;

            // Determines which tile the click occured at
            int xTile = x / (Canvas.Width / mapWidth);
            int yTile = y / (Canvas.Height / mapHeight);

            if (RBStart.Checked)
               m.Start = m.map[xTile, yTile];
            else
               m.End = m.map[xTile, yTile];

            // Reset map to correctly display the new start and end
            pathfinding.ResetNodeSearchInfo();
            pathfinding.CreateNodeMap(m.map, mapWidth, mapHeight, m.Start, m.End);
            MainBitmap = CreateSearchBitmap();

            // Resets bool and components
            selectingStartEnd = false;
            BtnSetStartEnd.Enabled = true;
            Canvas.Invalidate();
         }
      }

      /// <summary>
      /// Clears the metric panels
      /// </summary>
      /// <param name="sender">button</param>
      /// <param name="e">click</param>
      private void btnClearMetrics_Click(object sender, EventArgs e)
      {
         // Removes any Metric Panels currently being displayed
         foreach (Control c in MetricPanels)
         {
            c.Dispose();
            Controls.Remove(c);
         }
         MetricPanels = new List<Panel>(); // GC doesn't collect bitmaps otherwise

         // Collect remaining garbage
         GC.Collect();
         GC.WaitForPendingFinalizers();
         GC.Collect();
      }

      /// <summary>
      /// Saves a map's information to a file
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void btnSave_Click(object sender, EventArgs e)
      {
         if (!System.IO.Directory.Exists("./maps"))
         {
            System.IO.Directory.CreateDirectory("./maps");
         }

         using (SaveFileDialog save = new SaveFileDialog())
         {
            save.InitialDirectory = System.IO.Directory.GetCurrentDirectory() + "/maps";
            save.Filter = "tile map files (*.tm)|*.tm|All files (*.*)|*.*";
            if (save.ShowDialog() == DialogResult.OK)
            {
               m.SaveMap(save.FileName);
            }
         }
      }

      /// <summary>
      /// Loads a map's information from a file
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void btnLoad_Click(object sender, EventArgs e)
      {
         if (!System.IO.Directory.Exists("./maps"))
         {
            System.IO.Directory.CreateDirectory("./maps");
         }

         using (OpenFileDialog load = new OpenFileDialog())
         {
            load.InitialDirectory = System.IO.Directory.GetCurrentDirectory() + "/maps";
            load.Filter = "tile map files (*.tm)|*.tm|All files (*.*)|*.*";
            if (load.ShowDialog() == DialogResult.OK)
            {
               m.LoadMap(load.FileName);
            }
         }

         pathfinding.CreateNodeMap(m.map, m.map.GetLength(0), m.map.GetLength(1), m.Start, m.End);

         mapWidth = m.map.GetLength(0);
         mapHeight = m.map.GetLength(1);

         WallBitmap = CreateWallBitmap();
         MainBitmap = CreateSearchBitmap();

         Canvas.Invalidate();
      }
   }
}
