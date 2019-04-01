using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
   /// <summary>
   /// Search class responsible for running a breadth first search
   /// </summary>
   class BreadthFirstLevon:Search
   {
      // Specific search variables
      protected Queue<AINode> open;
      protected bool[,] storedChildren;

      public BreadthFirstLevon():base()
      {
         open = new Queue<AINode>();
      }

      public override void SetupSearch(AINode[,] nodeMap, int StartX, int StartY, int EndX, int EndY)
      {
         closed.Clear();
         open.Clear();

         storedChildren = new bool[nodeMap.GetLength(0), nodeMap.GetLength(1)];
         for(int i = 0; i < storedChildren.GetLength(0); i++)
         {
            for (int j = 0; j < storedChildren.GetLength(1); j++)
            {
               storedChildren[i,j] = false;
            }
         }
         storedChildren[StartX, StartY] = true;

         open.Enqueue(nodeMap[StartX, StartY]);
         open.Peek().visited = true;

         xStart = StartX;
         yStart = StartY;
         xEnd = EndX;
         yEnd = EndY;

         if (xStart == xEnd && yStart == yEnd)
         {
            open.Peek().pl = place.start;
            open.Dequeue();
         }
      }

      public override float RunSearch()
      {
         st.Restart();
         while (open.Count != 0)
         {
            AINode n = open.Dequeue();
            n.visited = true;

            if (n.x == xEnd && n.y == yEnd)
            {
               BackTrack(n);
               st.Stop();
               return (float)st.ElapsedMilliseconds;
            }
            else
            {
               // Adds all children nodes of current node
               foreach (AINode node in n.AINodes)
               {
                  if (node != null && !storedChildren[node.x,node.y])
                  {
                        open.Enqueue(node);
                        storedChildren[node.x, node.y] = true;
                        node.Parent = n;
                  }
               }
            }
         }
         st.Stop();
         return (float)st.ElapsedMilliseconds;
      }

      public override bool RunRealTimeTick(int times, out List<AINode> nodesSearched)
      {
         nodesSearched = new List<AINode>();
         if (open.Count != 0)
         {
            for (int i = 0; i < times; i++)
            {
               AINode n = open.Dequeue();
               n.visited = true;
               nodesSearched.Add(n);

               if (n.x == xEnd && n.y == yEnd)
               {
                  BackTrack(n);
                  return true;
               }
               else
               {
                  // Adds all children nodes of current node
                  foreach (AINode node in n.AINodes)
                  {
                     if (node != null && !storedChildren[node.x, node.y])
                     {
                        open.Enqueue(node);
                        storedChildren[node.x, node.y] = true;
                        node.Parent = n;
                     }
                  }
               }
            }
            return false;
         }
         return true;
      }
   }
}
