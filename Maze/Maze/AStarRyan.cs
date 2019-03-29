using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
   class AStarRyan : Search
   {
      protected Dictionary<AINode, int> openNodes;

      public AStarRyan() : base()
      {
         openNodes = new Dictionary<AINode, int>();
      }

      public override bool RunRealTimeTick(int times, out List<AINode> nodesSearched)
      {
         nodesSearched = new List<AINode>();
         if (openNodes.Count != 0)
         {
            for (int i = 0; i < times; i++)
            {
               closed[MakeKey(openNodes.ElementAt(0).Key.x, openNodes.ElementAt(0).Key.y)] = openNodes.ElementAt(0).Key;
               AINode nextNode = openNodes.ElementAt(0).Key;
               //nodesSearched.Add(nextNode);
               foreach (AINode node in nextNode.AINodes)
               {
                  if (node != null && !closed.ContainsKey(MakeKey(node.x, node.y))) //Checking for legal node
                  {
                     if (node.x == xEnd && node.y == yEnd) //If at the end node
                     {
                        node.visited = true;
                        node.Parent = nextNode;
                        BackTrack(node);
                        st.Stop();
                        nodesSearched.Add(node);
                        return true;
                     }
                     else //Not at end node
                     {
                        node.Parent = nextNode;
                        node.g += nextNode.g;
                        if (!openNodes.ContainsKey(node))
                           openNodes.Add(node, (node.g + node.h));
                        node.visited = true;
                        nodesSearched.Add(node);
                     }
                  }
               }
               openNodes.Remove(nextNode); //Removing parent node and ordering by least cost
               if (openNodes.Count > 0)
                  openNodes = openNodes.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            }
            return false;
         }
         return true;
      }

      public override float RunSearch()
      {
         st.Restart();
         while (openNodes.Count != 0)
         {
            closed[MakeKey(openNodes.ElementAt(0).Key.x, openNodes.ElementAt(0).Key.y)] = openNodes.ElementAt(0).Key;
            AINode nextNode = openNodes.ElementAt(0).Key;
            foreach (AINode node in nextNode.AINodes)
            {
               if (node != null && !closed.ContainsKey(MakeKey(node.x, node.y))) //Checking for legal node
               {
                  if (node.x == xEnd && node.y == yEnd) //if at the end node
                  {
                     node.visited = true;
                     node.Parent = nextNode;
                     BackTrack(node);
                     st.Stop();
                     return (float)st.ElapsedMilliseconds;
                  }
                  else //Not at end node
                  {
                     node.Parent = nextNode;
                     node.g += nextNode.g;
                     if (!openNodes.ContainsKey(node))
                     {
                        openNodes.Add(node, (node.g + node.h)); //remove '+1' later
                     }
                     node.visited = true;
                  }
               }
            }
            openNodes.Remove(nextNode); //Removing parent node and ordering by least cost
            if (openNodes.Count > 0)
               openNodes = openNodes.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
         }
         st.Stop();
         return (float)st.ElapsedMilliseconds;
      }

      public override void SetupSearch(AINode[,] nodeMap, int StartX, int StartY, int EndX, int EndY)
      {
         openNodes.Clear();
         closed.Clear();

         xStart = StartX;
         yStart = StartY;
         xEnd = EndX;
         yEnd = EndY;

         generateHeuristicsAndValues(nodeMap);

         AINode startNode;
         foreach (AINode n in nodeMap)
            if (n.x == StartX && n.y == StartY)
            {
               startNode = n;
               startNode.visited = true;
               openNodes.Add(startNode, 0);
            }
      }

      private void generateHeuristicsAndValues(AINode[,] map) //manhattan distance
      {
         foreach (AINode n in map)
         {
            int distX = Math.Abs(xEnd - n.x);
            int distY = Math.Abs(yEnd - n.y);
            n.h = distX + distY;
            n.g = 1;
         }
      }
   }
}
