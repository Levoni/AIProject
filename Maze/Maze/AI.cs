using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
   /// <summary>
   /// Class responsible for search algorithms. It also stores
   /// a map of nodes that keep relevant search info in them.
   /// </summary>
   class AI
   {

      System.Diagnostics.Stopwatch st;
      public AINode[,] nodeMap;
      private Search currentSearch;

      public int time, visitedTiles, pathLength;


      public AI()
      {
         st = new System.Diagnostics.Stopwatch();
      }

      /// <summary>
      /// Generates the node map based on a tileMap that is given
      /// </summary>
      /// <param name="tileMap">TileMap to base NodeMap on</param>
      /// <param name="xSize">Size of first slot in 2D array</param>
      /// <param name="ySize">Size of secondslot in 2D array</param>
      public void CreateNodeMap(Tile[,] tileMap, int xSize, int ySize, Tile start, Tile end)
      {
         // Allocates memory for NodeMap
         nodeMap = new AINode[xSize, ySize];
         for(int x = 0; x < xSize; x++)
            for(int y = 0; y < ySize; y++)
            {
               nodeMap[x, y] = new AINode(x,y);
            }

         // Connects Nodes together based on tileMap. sets start and end
         // nodes.
         for (int x = 0; x < xSize; x++)
            for (int y = 0; y < ySize; y++)
            {
               if (tileMap[x, y].nodes[(int)dir.UP] != null)
                  nodeMap[x, y].AINodes[(int)dir.UP] = nodeMap[x, y - 1];
               if (tileMap[x, y].nodes[(int)dir.RIGHT] != null)
                  nodeMap[x, y].AINodes[(int)dir.RIGHT] = nodeMap[x + 1, y];
               if (tileMap[x, y].nodes[(int)dir.DOWN] != null)
                  nodeMap[x, y].AINodes[(int)dir.DOWN] = nodeMap[x, y + 1];
               if (tileMap[x, y].nodes[(int)dir.LEFT] != null)
                  nodeMap[x, y].AINodes[(int)dir.LEFT] = nodeMap[x - 1, y];
               if (tileMap[x, y] == start)
                  nodeMap[x, y].pl = place.start;
               if (tileMap[x, y] == end)
                  nodeMap[x, y].pl = place.end;
            }
      }

      /// <summary>
      /// Run search that corrispondes with search name passed in
      /// </summary>
      /// <param name="searchType">The name of search function</param>
      /// <param name="XStart">Start x location</param>
      /// <param name="XEnd">End x location</param>
      /// <param name="YStart">Start y location</param>
      /// <param name="YEnd">End y location</param>
      /// <returns>float for time it took algorithm to run in ms</returns>
      public float RunSearch(string searchType, int XStart, int YStart, int XEnd, int YEnd)
      {
         if (searchType == "Breadth First (Levon)")
         {
            Search s = new BreadthFirstLevon();
            s.SetupSearch(nodeMap, XStart, YStart, XEnd, YEnd);
            return s.RunSearch();
         }
         else
         {
            Search s = new DepthFirstLevon();
            s.SetupSearch(nodeMap, XStart, YStart, XEnd, YEnd);
            return s.RunSearch();
         }

      }

      /// <summary>
      /// Resets the search information for each node in the maze
      /// </summary>
      public void ResetNodeSearchInfo()
      {
         foreach(AINode n in nodeMap)
         {
            n.ResetSearchInfo();
         }
      }

      /// <summary>
      /// Calculates time, Visited Tiles, and Path length and stores it into the 
      /// appropriate variables.
      /// </summary>
      public void GenerateMetrics()
      {
         //resets variables
         visitedTiles = 0;
         pathLength = 0;

         // sets time to the elapsedMilliseconds of stopwatch
         time = (int) st.ElapsedMilliseconds;

         // Calculates teh number of visited tiles
         // and the lenth of critical path
         foreach(AINode n in nodeMap)
         {
            if (n.visited)
               visitedTiles++;
            if (n.pl != place.none)
               pathLength++;
         }
      }

      /// <summary>
      /// Setus up realtime search for the search with the search
      /// name passed.
      /// </summary>
      /// <param name="search">Search name</param>
      /// <param name="xStart">start x position</param>
      /// <param name="yStart">start y position</param>
      public void StartRealtimeSearch(string search, int xStart, int yStart, int xEnd, int yEnd)
      {
         nodeMap[xStart, yStart].pl = place.start;
         if(search == "Breadth First Realtime (Levon)")
         {
            currentSearch = new BreadthFirstLevon();
            currentSearch.SetupSearch(nodeMap, xStart, yStart, xEnd, yEnd);
         }
         else if(search == "Depth First Realtime (Levon)")
         {
            currentSearch = new DepthFirstLevon();
            currentSearch.SetupSearch(nodeMap, xStart, yStart, xEnd, yEnd);
         }
      }

      /// <summary>
      /// runs the realtime search one time through
      /// </summary>
      /// <param name="search">search name that will be run</param>
      /// <param name="xEnd">start x position</param>
      /// <param name="yEnd">start y position</param>
      /// <returns></returns>
      public bool RunRealtimeSearch(string search, int ticks)
      {
         return currentSearch.RunRealTimeTick(ticks);
      }
   }
}
