using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
	class GreedyBestRyan : Search
	{
		protected Dictionary<AINode, int> openNodes;

		public GreedyBestRyan() : base()
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
               int lowestValue = openNodes.ElementAt(0).Value;
               AINode nextNode = openNodes.ElementAt(0).Key;
               foreach (KeyValuePair<AINode, int> pair in openNodes)
               {
                  if (pair.Value < lowestValue)
                  {
                     nextNode = pair.Key;
                     lowestValue = pair.Value;
                  }
               }
               foreach (AINode node in nextNode.AINodes)
					{
						if (node != null && !node.visited) //Checking for legal node
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
									openNodes.Add(node, node.h);
								node.visited = true;
								nodesSearched.Add(node);
							}
						}
					}
					openNodes.Remove(nextNode); //Removing parent node and ordering by least cost
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
				int lowestValue = openNodes.ElementAt(0).Value;
				AINode nextNode = openNodes.ElementAt(0).Key;
				foreach (KeyValuePair<AINode, int> pair in openNodes)
				{
					if (pair.Value < lowestValue)
					{
						nextNode = pair.Key;
						lowestValue = pair.Value;
					}
				}
				foreach (AINode node in nextNode.AINodes)
				{
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
								openNodes.Add(node, node.h);
							node.visited = true;
						}
					}
				}
				openNodes.Remove(nextNode); //Removing parent node and ordering by least cost
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
			}
		}
	}
}
