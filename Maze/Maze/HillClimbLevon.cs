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

         currentNode = nodeMap[xStart, yStart];

         if (xStart == xEnd && yStart == yEnd)
         {
            currentNode = null;
         }

      }

      public override bool RunRealTimeTick(int times, out List<AINode> nodesSearched)
      {
         throw new NotImplementedException();
      }

      public override float RunSearch()
      {
         st.Start();
         while (currentNode != null)
         {
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
                  if (currentNode.AINodes[i] != null && !closed.ContainsKey(MakeKey(currentNode.x, currentNode.y)))
                  {
                     if (nextNode == null)
                     {
                        currentNode.AINodes[i].Parent = currentNode;
                     }
                     else if (currentNode.AINodes[i].h < nextNode.h)
                     {
                        currentNode.AINodes[i].Parent = currentNode;
                     }
                  }
               }
               nextNode.Parent = currentNode;
               currentNode = nextNode;
               if (currentNode != null)
               {
                  if (currentNode.Parent != null)
                     closed.Add(MakeKey(currentNode.Parent.x, currentNode.Parent.y), currentNode.Parent);
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
