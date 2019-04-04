using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
   /// <summary>
   /// Child of search class used to run a depth first search
   /// </summary>
   class DepthFirstLevon:Search
   {
      // Search specific variables
      Stack<AINode> open;
      protected bool[,] storedChildren;

      public DepthFirstLevon():base()
      {
         open = new Stack<AINode>();
      }
      
      public override void SetupSearch(AINode[,] nodeMap, int StartX, int StartY, int EndX, int EndY)
      {
         closed.Clear();
         open.Clear();

         storedChildren = new bool[nodeMap.GetLength(0), nodeMap.GetLength(1)];
         for (int i = 0; i < storedChildren.GetLength(0); i++)
         {
            for (int j = 0; j < storedChildren.GetLength(1); j++)
            {
               storedChildren[i, j] = false;
            }
         }
         storedChildren[StartX, StartY] = true;

         // puts start node in stack
         open.Push(nodeMap[StartX, StartY]);
         open.Peek().visited = true;

         xStart = StartX;
         yStart = StartY;
         xEnd = EndX;
         yEnd = EndY;

         if (xStart == xEnd && yStart == yEnd)
         {
            open.Peek().pl = place.start;
            open.Pop();
         }
      }

      public override float RunSearch()
      {
         st.Restart();
         // Check for goal until found or all nodes are checked
         while (open.Count != 0)
         {
            AINode n = open.Pop();
            n.visited = true;

            if (n.x == xEnd && n.y == yEnd)
            {
               BackTrack(n); // Creates path from start to end
               st.Stop();
               return st.ElapsedMilliseconds;
            }
            else
            {
               // Adds all children nodes of current node
               foreach (AINode node in n.AINodes)
               {
                  if (node != null && !storedChildren[node.x,node.y])
                  {
                     open.Push(node);
                     node.Parent = n;
                     storedChildren[node.x, node.y] = true;
                  }
               }
            }
         }
         st.Stop();
         return st.ElapsedMilliseconds;
      }

      public override bool RunRealTimeTick(int times, out List<AINode> nodesSearched)
      {
         nodesSearched = new List<AINode>();
         if (open.Count != 0)
         {
            for (int i = 0; i < times; i++)
            {
               open.Peek().visited = true;
               AINode n = open.Pop();
               nodesSearched.Add(n);

               if (n.x == xEnd && n.y == yEnd)
               {
                  BackTrack(n); // Creates path from start to end
                  return true;
               }
               else
               {
                  foreach (AINode node in n.AINodes)
                  {
                     if (node != null && !storedChildren[node.x, node.y])
                     {
                        open.Push(node);
                        node.Parent = n;
                        storedChildren[node.x, node.y] = true;
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
