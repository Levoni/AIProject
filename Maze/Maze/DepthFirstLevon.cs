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

      public DepthFirstLevon():base()
      {
         open = new Stack<AINode>();
      }
      
      public override void SetupSearch(AINode[,] nodeMap, int StartX, int StartY, int EndX, int EndY)
      {
         closed.Clear();
         open.Clear();

         //TODO: fix this bc it will not find path if start = end
         // puts start node in queue
         open.Push(nodeMap[StartX, StartY]);
         open.Peek().visited = true;

         xStart = StartX;
         yStart = StartY;
         xEnd = EndX;
         yEnd = EndY;

      }

      public override float RunSearch()
      {
         st.Restart();
         // Check for goal until found or all nodes are checked
         while (open.Count != 0)
         {
            closed[MakeKey(open.Peek().x, open.Peek().y)] = open.Peek();
            open.Peek().visited = true;
            AINode n = open.Pop();
            // Checks each child node to see if it is the goal
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

      public override bool RunRealTimeTick(int times, out List<AINode> nodesSearched)
      {
         nodesSearched = new List<AINode>();
         if (open.Count != 0)
         {
            for (int i = 0; i < times; i++)
            {
               closed[MakeKey(open.Peek().x, open.Peek().y)] = open.Peek();
               open.Peek().visited = true;
               AINode n = open.Pop();
               foreach (AINode node in n.AINodes)
               {
                  if (node != null && !closed.ContainsKey(MakeKey(node.x, node.y)))
                  {
                     nodesSearched.Add(node);
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
                           open.Push(node);
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
   }
}
