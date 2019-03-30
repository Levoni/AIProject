using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
   class DijkstraMatthew : Search
   {
      private Dictionary<string, AINode> open;
      private AINode goalNode;

      public DijkstraMatthew() : base()
      {
         open = new Dictionary<string, AINode>();
         goalNode = null;
      }

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

      public override float RunSearch()
      {
         st.Restart();
         AINode currentNode = null;

         while(!goalNode.visited && open.Count != 0)
         {
            currentNode = SelectNextNode();
            
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
            closed.Add(MakeKey(currentNode.x, currentNode.y), currentNode);

            currentNode.visited = true;
         }

         st.Stop();
         BackTrack(currentNode);
         
         return st.ElapsedMilliseconds;
      }

      public override bool RunRealTimeTick(int times, out List<AINode> nodesSearched)
      {
         nodesSearched = new List<AINode>();
         return false;
      }

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
   }
}