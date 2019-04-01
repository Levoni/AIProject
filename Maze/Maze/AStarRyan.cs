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

		/// <summary>
		/// Constructor for A*
		/// </summary>
      public AStarRyan() : base()
      {
         openNodes = new Dictionary<AINode, int>();
      }

		/// <summary>
		/// This will run the algorithm in real time on the map
		/// </summary>
		/// <param name="times"> the interval between each node being processed </param>
		/// <param name="nodesSearched"> the list of nodes that have been searched up to that point </param>
		/// <returns> Returns true once it finds the end node </returns>
		public override bool RunRealTimeTick(int times, out List<AINode> nodesSearched)
      {
         nodesSearched = new List<AINode>();
         if (openNodes.Count != 0)
         {
            for (int i = 0; i < times; i++)
            {
					int lowestValue = openNodes.ElementAt(0).Value;
					AINode nextNode = openNodes.ElementAt(0).Key;
					foreach (KeyValuePair<AINode, int> pair in openNodes)
					{
						if (pair.Value < lowestValue)
							nextNode = pair.Key;
					}
					foreach (AINode node in nextNode.AINodes)
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
								if (!openNodes.ContainsKey(node))
								{
									node.g += nextNode.g;
									openNodes.Add(node, (node.g + node.h));
								}
								node.visited = true;
                        nodesSearched.Add(node);
                     }
                  }
               openNodes.Remove(nextNode); //Removing parent node and ordering by least cost
            }
            return false;
         }
         return true;
      }

		/// <summary>
		/// Runs the algorithm and displays the results onto the map
		/// </summary>
		/// <returns> Amount of time it took to process and find the end node </returns>
      public override float RunSearch()
      {
         st.Restart();
         while (openNodes.Count != 0)
         {
				int lowestValue = openNodes.ElementAt(0).Value;
				AINode nextNode = openNodes.ElementAt(0).Key;
				foreach (KeyValuePair<AINode, int> pair in openNodes)
				{
					if (pair.Value < lowestValue)
						nextNode = pair.Key;
				}
            foreach (AINode node in nextNode.AINodes)
               if (node != null && !node.visited) //Checking for legal node
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
							if (!openNodes.ContainsKey(node))
							{
								node.g += nextNode.g;
								openNodes.Add(node, (node.g + node.h));
							}
                     node.visited = true;
                  }
               }
            openNodes.Remove(nextNode); //Removing parent node and ordering by least cost
         }
         st.Stop();
         return (float)st.ElapsedMilliseconds;
      }

		/// <summary>
		/// Setup code with setting start and end values and generating heuristical values
		/// </summary>
		/// <param name="nodeMap"> the generated map </param>
		/// <param name="StartX"> starting node x coordinate </param>
		/// <param name="StartY"> starting node y coordinate </param>
		/// <param name="EndX"> ending node x coordinate </param> 
		/// <param name="EndY"> ending node y coordinate </param> 
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

		/// <summary>
		/// Generates heuristical values based off diagonal distance to the end node
		/// </summary>
		/// <param name="map"> the generated map </param> 
		private void generateHeuristicsAndValues(AINode[,] map) //diagonal distance
      {
         foreach (AINode n in map)
         {
            int distX = Math.Abs(xEnd - n.x);
				int distY = Math.Abs(yEnd - n.y);
				n.h = (int)Math.Sqrt((distX * distX) + (distY * distY));
            n.g = 1;
         }
      }
   }
}
