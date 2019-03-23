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

      public BreadthFirstLevon():base()
      {
         open = new Queue<AINode>();
      }

      public override void SetupSearch(AINode[,] nodeMap, int StartX, int StartY, int EndX, int EndY)
      {
         closed.Clear();
         open.Clear();

         //TODO: fix this bc it will not find path if start = end
         // puts start node in queue
         open.Enqueue(nodeMap[StartX, StartY]);
         open.Peek().visited = true;

         xStart = StartX;
         yStart = StartY;
         xEnd = EndX;
         yEnd = EndY;
      }

      public override float RunSearch()
      {
         st.Restart();
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
         return (float)st.ElapsedMilliseconds;
      }

      public override bool RunRealTimeTick(int times, out List<AINode> nodesSearched)
      {
         nodesSearched = new List<AINode>();
         if (open.Count != 0)
         {
            for (int i = 0; i < times; i++)
            {
               closed[MakeKey(open.Peek().x, open.Peek().y)] = open.Peek();
               foreach (AINode node in open.Peek().AINodes)
               {
                  if (node != null && !closed.ContainsKey(MakeKey(node.x, node.y)))
                  {
                     nodesSearched.Add(node);
                     if (node.x == xEnd && node.y == yEnd)
                     {
                        node.visited = true;
                        node.Parent = open.Peek();
                        BackTrack(node);
                        st.Stop();
                        return true;
                     }
                     else
                     {
                        node.Parent = open.Peek();
                        if (!node.visited)
                           open.Enqueue(node);
                        node.visited = true;
                     }
                  }
               }
               open.Dequeue();
            }
            return false;
         }
         return true;
      }
   }
}
