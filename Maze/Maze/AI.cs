using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
   //TODO: refactor: Searches into classes
   //                search initilizer function to create search class
   //TODO: comment

   /// <summary>
   /// Class responsible for search algorithms. It also stores
   /// a map of nodes that keep relevant search info in them.
   /// </summary>
   class AI
   {
      public class AINode
      {
         public int x, y;
         public int g, h;
         public AINode[] AINodes;

         // Results of searching
         public place pl;
         public AINode Parent;
         public bool visited;

         public AINode(int xPos, int yPos) {
            x = xPos;
            y = yPos;
            g = h = 0;
            AINodes = new AINode[4];
            for (int i = 0; i < 4; i++)
               AINodes[i] = null;

            pl = place.none;
            Parent = null;
            visited = false;
         }

         public void ResetSearchInfo() {
            pl = place.none;
            Parent = null;
            visited = false;
         }
      }

      System.Diagnostics.Stopwatch st;
      public AINode[,] nodeMap;

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
      public float RunSearch(string searchType, int XStart, int XEnd, int YStart, int YEnd)
      {
         if (searchType == "Breadth First (Levon)")
            return BreathFirstSearch(XStart, XEnd, YStart, YEnd);
         else
            return DepthFIrstSearch(XStart, XEnd, YStart, YEnd);

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
      /// Used to create a unique key (string) for a single node in the maze.
      /// The key is used for dictionaries in the differnt search functions.
      /// </summary>
      /// <param name="x">X location of the node</param>
      /// <param name="y">Y location of the node</param>
      /// <returns>A unique string for a single node in the maze</returns>
      private string MakeKey(int x, int y)
      {
         return x.ToString() + "," + y.ToString();
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
      /// Creates the path from the end to start.
      /// </summary>
      /// <param name="End">The goal node of the maze</param>
      public void BackTrack(AINode End)
      {
         End.pl = place.end;

         // Sets the current node place to path and continus to parent node. 
         while (End.Parent != null)
         {
            End = End.Parent;
            End.pl = place.path;
         }

         End.pl = place.start;
      }

      /// <summary>
      /// Searches for the goal node starting at the start node. It 
      /// searches the children of the parent node then those childrens
      /// children and so on till the goal is found or maze is completaly searched.
      /// </summary>
      /// <param name="xStart">X start position</param>
      /// <param name="xEnd">X end position</param>
      /// <param name="yStart">Y start position</param>
      /// <param name="yEnd">Y end position</param>
      /// <returns>The time in ms the function takes to run</returns>
      public float BreathFirstSearch(int xStart, int xEnd, int yStart, int yEnd)
      {
         // Sets up stopwatch
         st.Reset();
         st.Start();

         // Sets up local variables
         Dictionary<string, AINode> closed = new Dictionary<string, AINode>();
         Queue<AINode> open = new Queue<AINode>();

         //TODO: fix this bc it will not find path if start = end
         // puts start node in queue
         open.Enqueue(nodeMap[xStart,yStart]);
         open.Peek().visited = true;

         // Check for goal until found or all nodes are checked
         while (open.Count != 0)
         {
            closed[MakeKey(open.Peek().x, open.Peek().y)] = open.Peek();
            // Checks all children nodes of current node for goal
            foreach (AINode node in open.Peek().AINodes)
            {
               if (node != null && !closed.ContainsKey(MakeKey(node.x, node.y)))
               {
                  if (node.x == xEnd && node.y == yEnd)
                  {
                     node.visited = true;
                     node.Parent = open.Peek();
                     BackTrack(node); // Creates path from start to end
                     st.Stop();
                     return (float)st.ElapsedMilliseconds;
                  }
                  else
                  {
                     // Adds node to queue if it hasn't been visited yet
                     node.Parent = open.Peek();
                     if (!node.visited)
                        open.Enqueue(node);
                     node.visited = true;
                  }
               }
            }
            open.Dequeue();
         }
         st.Stop();
         return st.ElapsedMilliseconds;
      }

      /// <summary>
      /// Searches for the goal node starting at the start node. It 
      /// searches by giving certain directions a higher priority
      /// the priority is left down right up.
      /// </summary>
      /// <param name="xStart">X start position</param>
      /// <param name="xEnd">X end position</param>
      /// <param name="yStart">Y start position</param>
      /// <param name="yEnd">Y end position</param>
      /// <returns>The time in ms the function takes to run</returns>
      public float DepthFIrstSearch(int xStart, int xEnd, int yStart, int yEnd)
      {
         // Sets up stopwatch
         st.Reset();
         st.Start();

         // Sets up local variables
         Dictionary<string, AINode> closed = new Dictionary<string, AINode>();
         Stack<AINode> open = new Stack<AINode>();

         //TODO: fix this bc it will not find path if start = end
         // puts start node in queue
         open.Push(nodeMap[xStart, yStart]);
         open.Peek().visited = true;

         // Check for goal until found or all nodes are checked
         while (open.Count != 0)
         {
            closed[MakeKey(open.Peek().x, open.Peek().y)] = open.Peek();
            open.Peek().visited = true;
            AINode n = open.Pop();
            foreach (AINode node in n.AINodes)
            {
               if (node != null && !closed.ContainsKey(MakeKey(node.x, node.y)))
               {
                  if (node.x == xEnd && node.y == yEnd)
                  {
                     node.visited = true;
                     node.Parent = n;
                     BackTrack(node); // Creates path from start to end
                     st.Stop();
                     return st.ElapsedMilliseconds;
                  }
                  else
                  {
                     // Adds node to stack if it hasn't been visited yet
                     if (!node.visited)
                        open.Push(node);
                     node.visited = true;
                     node.Parent = n;
                  }
               }
            }
         }
         st.Stop();
         return st.ElapsedMilliseconds;
      }


      public Dictionary<string, AINode> closed = new Dictionary<string, AINode>();
      public Stack<AINode> openS = new Stack<AINode>();

      /// <summary>
      /// Runs through the realtime Depth search's
      /// main loop 5 times
      /// </summary>
      /// <param name="xEnd">End x Position</param>
      /// <param name="yEnd">End y Positions</param>
      /// <returns>True if search is done, false otherwise</returns>
      public bool RealTimeDepth(int xEnd, int yEnd)
      {

         if (openS.Count != 0)
         {
            for (int i = 0; i < 5; i++)
            {
               closed[MakeKey(openS.Peek().x, openS.Peek().y)] = openS.Peek();
               openS.Peek().visited = true;
               AINode n = openS.Pop();
               foreach (AINode node in n.AINodes)
               {
                  if (node != null && !closed.ContainsKey(MakeKey(node.x, node.y)))
                  {
                     if (node.x == xEnd && node.y == yEnd)
                     {
                        node.visited = true;
                        node.Parent = n;
                        BackTrack(node);
                        st.Stop();
                        return true;
                     }
                     else
                     {
                        if (!node.visited)
                           openS.Push(node);
                        node.visited = true;
                        node.Parent = n;
                     }
                  }
               }
            }
            return false;
         }
         return true;
      }

      public Queue<AINode> openQ = new Queue<AINode>();

      /// <summary>
      /// Runs through the realtime Breadth search's
      /// main loop 5 times
      /// </summary>
      /// <param name="xEnd">End x Position</param>
      /// <param name="yEnd">End y Positions</param>
      /// <returns>True if search is done, false otherwise</returns>
      public bool RealTimeBreadth(int xEnd, int yEnd)
      {
      
         if (openQ.Count != 0)
         {
            for (int i = 0; i < 5; i++)
            {
               closed[MakeKey(openQ.Peek().x, openQ.Peek().y)] = openQ.Peek();
               foreach (AINode node in openQ.Peek().AINodes)
               {
                  if (node != null && !closed.ContainsKey(MakeKey(node.x, node.y)))
                  {
                     if (node.x == xEnd && node.y == yEnd)
                     {
                        node.visited = true;
                        node.Parent = openQ.Peek();
                        BackTrack(node);
                        st.Stop();
                        return true;
                     }
                     else
                     {
                        node.Parent = openQ.Peek();
                        if (!node.visited)
                           openQ.Enqueue(node);
                        node.visited = true;
                     }
                  }
               }
               openQ.Dequeue();
            }
            return false;
         }
         return true;
      }
      
      /// <summary>
      /// Setus up realtime search for the search with the search
      /// name passed.
      /// </summary>
      /// <param name="search">Search name</param>
      /// <param name="xStart">start x position</param>
      /// <param name="yStart">start y position</param>
      public void StartRealtimeSearch(string search, int xStart, int yStart)
      {
         nodeMap[xStart, yStart].pl = place.start;
         if(search == "Breadth First Realtime (Levon)")
         {
            closed.Clear();
            openQ.Clear();
            openQ.Enqueue(nodeMap[xStart, yStart]);
            openQ.Peek().visited = true;
         }
         else if(search == "Depth First Realtime (Levon)")
         {
            closed.Clear();
            openS.Clear();
            openS.Push(nodeMap[xStart, yStart]);
            openS.Peek().visited = true;
         }
      }

      /// <summary>
      /// runs the realtime search one time through
      /// </summary>
      /// <param name="search">search name that will be run</param>
      /// <param name="xEnd">start x position</param>
      /// <param name="yEnd">start y position</param>
      /// <returns></returns>
      public bool RunRealtimeSearch(string search, int xEnd, int yEnd)
      {
         nodeMap[xEnd, yEnd].pl = place.end;
         if (search == "Breadth First Realtime (Levon)")
         {
            return RealTimeBreadth(xEnd, yEnd);
         }
         else if (search == "Depth First Realtime (Levon)")
         {
            return RealTimeDepth(xEnd, yEnd);
         }
         return true;
      }
   }
}
