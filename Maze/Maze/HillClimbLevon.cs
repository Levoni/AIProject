using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
   class HillClimbLevon : Search
   {
      AINode currentNode;
      AINode start;
      AINode end;

      public HillClimbLevon() : base()
      {

      }

      public override void SetupSearch(AINode[,] nodeMap, int StartX, int StartY, int EndX, int EndY)
      {
         GenerateHValues(nodeMap, EndX, EndY);

         closed.Clear();

         xStart = StartX;
         yStart = StartY;
         xEnd = EndX;
         yEnd = EndY;

         start = nodeMap[xStart, yStart];
         end = nodeMap[xEnd, yEnd];

         currentNode = nodeMap[xStart, yStart];

         if (xStart == xEnd && yStart == yEnd)
         {
            currentNode = null;
         }

      }

      public override bool RunRealTimeTick(int times, out List<AINode> nodesSearched)
      {
         nodesSearched = new List<AINode>();
         if (currentNode != null)
         {
            for (int k = 0; k < times; k++)
            {
               currentNode.visited = true;
               closed.Add(MakeKey(currentNode.x, currentNode.y), currentNode);
               nodesSearched.Add(currentNode);
               if (currentNode.x == xEnd && currentNode.y == yEnd)
               {
                  BackTrack(currentNode);
                  st.Stop();
                  return true;
               }
               else
               {
                  AINode nextNode = null;
                  for (int i = 0; i < 4; i++)
                  {
                     if (currentNode.AINodes[i] != null && !closed.ContainsKey(MakeKey(currentNode.AINodes[i].x, currentNode.AINodes[i].y)))
                     {
                        if (nextNode == null)
                        {
                           currentNode.AINodes[i].Parent = currentNode;
                           nextNode = currentNode.AINodes[i];
                        }
                        else if (currentNode.AINodes[i].h < nextNode.h)
                        {
                           currentNode.AINodes[i].Parent = currentNode;
                           nextNode = currentNode.AINodes[i];
                        }
                     }
                  }
                  if (nextNode != null)
                     nextNode.Parent = currentNode;
                  currentNode = nextNode;
                  if (nextNode == null)
                  {
                     start.pl = place.start;
                     end.pl = place.end;
                     return true;
                  }
               }
            }
            return false;
         }
         return true;
      }

      public override float RunSearch()
      {
         st.Start();
         while (currentNode != null)
         {
            currentNode.visited = true;
            closed.Add(MakeKey(currentNode.x, currentNode.y), currentNode);
            if (currentNode.x == xEnd && currentNode.y == yEnd)
            {
               BackTrack(currentNode);
               st.Stop();
               return (float)st.ElapsedMilliseconds;
            }
            else
            {
               AINode nextNode = null;
               for (int i = 0; i < 4; i++)
               {
                  if (currentNode.AINodes[i] != null && !closed.ContainsKey(MakeKey(currentNode.AINodes[i].x, currentNode.AINodes[i].y)))
                  {
                     if (nextNode == null)
                     {
                        currentNode.AINodes[i].Parent = currentNode;
                        nextNode = currentNode.AINodes[i];
                     }
                     else if (currentNode.AINodes[i].h < nextNode.h)
                     {
                        currentNode.AINodes[i].Parent = currentNode;
                        nextNode = currentNode.AINodes[i];
                     }
                  }
               }
               if(nextNode != null)
                  nextNode.Parent = currentNode;
               currentNode = nextNode;
               if (nextNode == null)
               {
                  start.pl = place.start;
                  end.pl = place.end;
               }
            }
         }
         st.Stop();
         return (float)st.ElapsedMilliseconds;
      }

      private void GenerateHValues(AINode[,] nodeMap, int endX, int endY)
      {
         foreach (AINode n in nodeMap)
         {
            n.h = Math.Abs(endX - n.x) + Math.Abs(endY - n.y);
         }
      }
   }
}
