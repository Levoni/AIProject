using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
   /// <summary>
   /// Contains all variables and methods relevant to performing a search of
   /// the maze according to Dijkstra's algorithm.
   /// </summary>
   class DijkstraMatthew : Search
   {
      private Dictionary<string, AINode> open;
      private AINode goalNode;

      /// <summary>
      /// Constructor.
      /// </summary>
      public DijkstraMatthew() : base()
      {
         open = new Dictionary<string, AINode>();
         goalNode = null;
      }

      /// <summary>
      /// Sets all class variables, sets the heuristic for each node to 1, sets
      /// the g value for each node to -1 (except the starting node, whose g
      /// value is set to 0), and adds the starting node as the first node in
      /// the "open" list.
      /// </summary>
      /// <param name="nodeMap">An array of AINodes representing each
      /// tile in the maze</param>
      /// <param name="startX">The x-coordinate of the start tile</param>
      /// <param name="startY">The y-coordinate of the start tile</param>
      /// <param name="endX">The x-coordinate of the end tile</param>
      /// <param name="endY">The y-coordinate of the end tile</param>
      public override void SetupSearch(AINode[,] nodeMap, int startX, int startY, int endX, int endY)
      {
         xStart = startX;
         yStart = startY;
         xEnd = endX;
         yEnd = endY;
         goalNode = nodeMap[endX, endY];

         for (int x = 0; x < nodeMap.GetLength(0); x++)
         {
            for (int y = 0; y < nodeMap.GetLength(1); y++)
            {
               nodeMap[x, y].h = 1;
               nodeMap[x, y].g = -1;
            }
         }

         nodeMap[startX, startY].g = 0;

         open.Add(MakeKey(startX, startY), nodeMap[startX, startY]);
      }

      /// <summary>
      /// Performs a Dijkstra search from the starting node of the maze.  The
      /// search runs until either the ending node is found or until there are
      /// no more accessible nodes to process.
      /// </summary>
      /// <returns>The search time in milliseconds</returns>
      public override float RunSearch()
      {
         st.Restart();
         AINode currentNode = null;

         while(!goalNode.visited && open.Count != 0)
         {
            currentNode = SelectNextNode();
            ProcessCurrentNode(currentNode);
         }

         st.Stop();

         if (currentNode != null)
         {
            BackTrack(currentNode);
         }
         
         return st.ElapsedMilliseconds;
      }

      /// <summary>
      /// Performs a single iteration of a Dijkstra search of the maze where
      /// the iteration processes "times" number of nodes.  The iteration will
      /// end when either the specified number of nodes has been processed or
      /// the ending node has been reached.
      /// </summary>
      /// <param name="times">The number of nodes to be processed in the 
      /// iteration</param>
      /// <param name="nodesSearched">The list of all nodes searched during the
      /// iteration</param>
      /// <returns>True if the ending node was reached during the iteration,
      /// false otherwise</returns>
      public override bool RunRealTimeTick(int times, out List<AINode> nodesSearched)
      {
         nodesSearched = new List<AINode>();
         AINode currentNode = null;

         for (int i = 0; i < times; i++)
         {
            currentNode = SelectNextNode();
            ProcessCurrentNode(currentNode);
            nodesSearched.Add(currentNode);

            if (goalNode.visited)
            {
               st.Stop();
               BackTrack(currentNode);
               return true;
            }
         }

         return false;
      }

      /// <summary>
      /// Selects the next node to be processed in a Dijkstra search.  This
      /// node will be the node in the list of open nodes with the smallest
      /// g value.
      /// </summary>
      /// <returns>The next node to be processed</returns>
      private AINode SelectNextNode()
      {
         AINode nextCandidate;

         nextCandidate = open.First().Value;
         foreach (KeyValuePair<string, AINode> pair in open)
         {
            if (pair.Value.g < nextCandidate.g)
            {
               nextCandidate = pair.Value;
            }
         }

         return nextCandidate;
      }

      /// <summary>
      /// Processes a given node according to Dijkstra's algorithm.  The g
      /// value for each of the given node's unvisited neighbors is modified if
      /// passing through the given node provides a shorter route to the
      /// neighbor, and each of these neighbors is added to the list of open
      /// nodes.  Finally, the given node is marked as visited and removed from
      /// the open list.
      /// </summary>
      /// <param name="currentNode">The node to be processed</param>
      private void ProcessCurrentNode(AINode currentNode)
      {
         foreach (AINode neighborNode in currentNode.AINodes)
         {
            if (neighborNode != null && !neighborNode.visited)
            {
               int distanceFromStart = currentNode.g + 1;
               if (distanceFromStart < neighborNode.g || neighborNode.g == -1)
               {
                  neighborNode.g = distanceFromStart;
                  neighborNode.Parent = currentNode;
               }

               if (!open.ContainsKey(MakeKey(neighborNode.x, neighborNode.y)))
               {
                  open.Add(MakeKey(neighborNode.x, neighborNode.y), neighborNode);
               }
            }
         }

         open.Remove(MakeKey(currentNode.x, currentNode.y));

         currentNode.visited = true;
      }
   }
}