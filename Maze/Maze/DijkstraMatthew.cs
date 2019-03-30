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

      public DijkstraMatthew() : base()
      {
         open = new Dictionary<string, AINode>();
      }

      public override void SetupSearch(AINode[,] nodeMap, int startX, int startY, int endX, int endY)
      {
         xStart = startX;
         yStart = startY;
         xEnd = endX;
         yEnd = endY;

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
         AINode currentNode = null;
         while(!closed.ContainsKey(MakeKey(xEnd, yEnd)) && open.Count != 0)
         {
            currentNode = SelectNextNode();
            currentNode.visited = true;
            foreach (AINode neighborNode in currentNode.AINodes)
            {
               if (neighborNode != null && !closed.ContainsKey(MakeKey(neighborNode.x, neighborNode.y)))
               {
                  AINode nodeToEdit;
                  if (open.ContainsKey(MakeKey(neighborNode.x, neighborNode.y)))
                  {
                     open.TryGetValue(MakeKey(neighborNode.x, neighborNode.y), out nodeToEdit);
                     open.Remove(MakeKey(neighborNode.x, neighborNode.y));
                  }
                  else
                  {
                     nodeToEdit = neighborNode;
                  }

                  int distanceFromStart = currentNode.g + 1;
                  if (distanceFromStart < neighborNode.g || neighborNode.g == -1)
                  {
                     neighborNode.g = distanceFromStart;
                     neighborNode.Parent = currentNode;
                  }
                  open.Add(MakeKey(neighborNode.x, neighborNode.y), neighborNode);
               }
            }

            open.Remove(MakeKey(currentNode.x, currentNode.y));
            closed.Add(MakeKey(currentNode.x, currentNode.y), currentNode);
         }

         BackTrack(currentNode);

         return 0;
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