using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
   public enum dir
   {
      UP = 0,
      RIGHT = 1,
      DOWN = 2,
      LEFT = 3,
      UNKNOWN = -1,
   }

   public class Path
   {
      public Node parent;
      public Node child;
   }

   public class Map
   {
      public Node[,] map;
      private Random rand;
      private int width, height;
      public Node Start, End;
      private const int cutChance = 10;
      System.Diagnostics.Stopwatch st;

      public Map(int w, int h)
      {
         rand = new Random();
         width = w;
         height = h;
         map = new Node[width, height];
         st = new System.Diagnostics.Stopwatch();
         for (int x = 0; x < width; x++)
            for (int y = 0; y < height; y++)
            {
               map[x, y] = new Node(x, y);
            }
      }

      public void ResetNodeInfo()
      {
         for (int x = 0; x < width; x++)
            for (int y = 0; y < height; y++)
            {
               map[x, y].ResetInfo();
            }
         Start.pl = place.start;
         End.pl = place.end;
      }

      private string MakeKey(int x, int y)
      {
         return x.ToString() + "," + y.ToString();
      }

      public float GenerateMap(int xStart = 0, int yStart = 0, int cutPercent = 0)
      {
         st.Start();
         xStart = rand.Next() % width;
         yStart = rand.Next() % height;
         map = new Node[width, height];
         for (int x = 0; x < width; x++)
            for (int y = 0; y < height; y++)
            {
               map[x, y] = new Node(x, y);
            }
         Start = map[xStart, yStart];
         Start.pl = place.start;

         Stack<Node> nodeStack = new Stack<Node>();
         Dictionary<string,Node> closed = new Dictionary<string, Node>();
         int xOriginal;
         int yOriginal;

         nodeStack.Push(map[xStart, yStart]);
         while(nodeStack.Count != 0)
         {
            xOriginal = nodeStack.Peek().xPos;
            yOriginal = nodeStack.Peek().yPos;
            dir direction = DetermineDirection(closed, xOriginal, yOriginal);
            if (direction == dir.UNKNOWN && nodeStack.Peek().IsDeadEnd() && cutPercent > rand.Next() % 100)
               CutSection(nodeStack);
            closed[MakeKey(xOriginal,yOriginal)] = nodeStack.Peek();
            UpdateStack(nodeStack, xOriginal, yOriginal, direction);
         }

         End = map[rand.Next() % width, rand.Next() % height];
            End.pl = place.end;
         st.Stop();
         float test = st.ElapsedMilliseconds;
         return (float) st.ElapsedMilliseconds;
      }

      private dir DetermineDirection(Dictionary<string,Node> closedList,int x, int y)
      {
         List<dir> possibleIndex = new List<dir>();
         possibleIndex.Add(dir.UP);
         possibleIndex.Add(dir.DOWN);
         possibleIndex.Add(dir.RIGHT);
         possibleIndex.Add(dir.LEFT);
         object o = closedList.ContainsKey(MakeKey(x, y - 1));
         int next;
         while(possibleIndex.Count != 0)
         {
            next = rand.Next() % possibleIndex.Count;
            if (possibleIndex[next] == dir.UP && y != 0 && !closedList.ContainsKey(MakeKey(x, y - 1)))
               return dir.UP;
            if (possibleIndex[next] == dir.RIGHT && x != width - 1 && !closedList.ContainsKey(MakeKey(x + 1, y)))
               return dir.RIGHT;
            if (possibleIndex[next] == dir.DOWN && y != height - 1 && !closedList.ContainsKey(MakeKey(x, y + 1)))
               return dir.DOWN;
            if (possibleIndex[next] == dir.LEFT && x != 0 && !closedList.ContainsKey(MakeKey(x - 1, y)))
               return dir.LEFT;
            possibleIndex.RemoveAt(next);
         }
         return dir.UNKNOWN;
      }

      private void UpdateStack(Stack<Node> nodeStack ,int xOriginal, int yOriginal,dir moveDirection)
      {
         if (moveDirection == dir.UP)
            MoveToNextNode(nodeStack, map[xOriginal, yOriginal], map[xOriginal, yOriginal - 1], moveDirection);
         else if (moveDirection == dir.DOWN)
            MoveToNextNode(nodeStack, map[xOriginal, yOriginal], map[xOriginal, yOriginal + 1], moveDirection);
         else if (moveDirection == dir.RIGHT)
            MoveToNextNode(nodeStack, map[xOriginal, yOriginal], map[xOriginal + 1, yOriginal], moveDirection);
         else if (moveDirection == dir.LEFT)
            MoveToNextNode(nodeStack, map[xOriginal, yOriginal], map[xOriginal - 1, yOriginal], moveDirection);
         else
            nodeStack.Pop();
      }

      private void MoveToNextNode(Stack<Node> nodeStack, Node oldNode, Node newNode, dir moveDirection)
      {
         int test1 = (int)moveDirection;
         int test2 = ((int)moveDirection + 2) % 4;
         oldNode.nodes[(int)moveDirection] = newNode;
         newNode.nodes[((int)moveDirection + 2) % 4] = oldNode;
         nodeStack.Push(newNode);
      }

      private void CutSection(Stack<Node> nodeStack)
      {
         Node n = nodeStack.Peek();


         if (n.nodes[(int)dir.UP] != null && n.yPos != height - 1)
         {
            MoveToNextNode(nodeStack, n, map[n.xPos, n.yPos + 1], dir.DOWN);
            nodeStack.Pop();
         }
         else if (n.nodes[(int)dir.DOWN] != null && n.yPos != 0)
         {
            MoveToNextNode(nodeStack, n, map[n.xPos, n.yPos - 1], dir.UP);
            nodeStack.Pop();
         }
         else if (n.nodes[(int)dir.RIGHT] != null && n.xPos != 0)
         {
            MoveToNextNode(nodeStack, n, map[n.xPos - 1, n.yPos], dir.LEFT);
            nodeStack.Pop();
         }
         else if (n.nodes[(int)dir.LEFT] != null && n.xPos != width - 1)
         {
            MoveToNextNode(nodeStack, n, map[n.xPos + 1, n.yPos], dir.RIGHT);
            nodeStack.Pop();
         }
      }

      public void BackTrack(Node Start, Node End)
      {
         //End.pl = place.start;
         while (End.Parent != null)
         {
            End = End.Parent;
            End.pl = place.path;
         }
         End.pl = place.start;
      }

      public float BreathFirstSearch(Node start, Node goal)
      {
         st.Reset();
         st.Start();
         Dictionary<string,Node> closed = new Dictionary<string, Node>();
         Queue<Node> open = new Queue<Node>();
         open.Enqueue(start);
         bool found = false;
         while(!found && open.Count != 0)
         {
            closed[MakeKey(open.Peek().xPos,open.Peek().yPos)] = open.Peek();
            foreach(Node n in open.Peek().nodes)
            {
               if(n != null && !closed.ContainsKey(MakeKey(n.xPos,n.yPos)))
               {
                  if (n == goal)
                  {
                     n.visited = true;
                     n.Parent = open.Peek();
                     BackTrack(start, goal);
                     st.Stop();
                     return (float) st.ElapsedMilliseconds;
                  }
                  else
                  {
                     n.Parent = open.Peek();
                     if (!n.visited)
                        open.Enqueue(n);
                     n.visited = true;
                  }
               }
            }
            open.Dequeue();
         }
         st.Stop();
         return st.ElapsedMilliseconds;
      }

      public float DepthFIrstSearch(Node start, Node goal)
      {
         st.Reset();
         st.Start();
         Dictionary<string,Node> closed = new Dictionary<string, Node>();
         Stack<Node> open = new Stack<Node>();
         open.Push(start);
         bool found = false;
         while (!found && open.Count != 0)
         {
            closed[MakeKey(open.Peek().xPos,open.Peek().yPos)] = open.Peek();
            open.Peek().visited = true;
            Node n = open.Pop();
            foreach (Node node in n.nodes)
            {
               if (node != null && !closed.ContainsKey(MakeKey(node.xPos,node.yPos)))
               {
                  if (node == goal)
                  {
                     node.visited = true;
                     node.Parent = n;
                     BackTrack(start, goal);
                     st.Stop();
                     return st.ElapsedMilliseconds;
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
         st.Stop();
         return st.ElapsedMilliseconds;
      }

      public float DepthFIrstSearchOld2(Node start, Node goal)
      {
         st.Reset();
         st.Start();
         Dictionary<string, Node> closed = new Dictionary<string, Node>();
         List<Node> open = new List<Node>();
         open.Add(start);
         bool found = false;
         while (!found && open.Count != 0)
         {
            closed[MakeKey(open[0].xPos, open[0].yPos)] = open[0];
            open[0].visited = true;
            Node n = open[0];
            open.RemoveAt(0);
            foreach (Node node in n.nodes)
            {
               if (node != null && !closed.ContainsKey(MakeKey(node.xPos, node.yPos)))
               {
                  if (node == goal)
                  {
                     node.visited = true;
                     node.Parent = n;
                     BackTrack(start, goal);
                     st.Stop();
                     return st.ElapsedMilliseconds;
                  }
                  else
                  {
                     if (!node.visited)
                        open.Insert(0, node);
                     node.visited = true;
                     node.Parent = n;
                  }
               }
            }
         }
         st.Stop();
         return st.ElapsedMilliseconds;
      }

      public float DepthFIrstSearchOld(Node start, Node goal)
      {
         st.Reset();
         st.Start();
         List<Node> closed = new List<Node>();
         List<Node> open = new List<Node>();
         open.Add(start);
         bool found = false;
         while (!found && open.Count != 0)
         {
            closed.Add(open[0]);
            open[0].visited = true;
            Node n = open[0];
            open.RemoveAt(0);
            foreach (Node node in n.nodes)
            {
               if (node != null && closed.IndexOf(node) == -1)
               {
                  if (node == goal)
                  {
                     node.visited = true;
                     node.Parent = n;
                     BackTrack(start, goal);
                     st.Stop();
                     return st.ElapsedMilliseconds;
                  }
                  else
                  {
                     node.visited = true;
                     node.Parent = n;
                     if (open.IndexOf(node) == -1)
                        open.Insert(0, node);
                  }
               }
            }
         }
         st.Stop();
         return st.ElapsedMilliseconds;
      }

      public float BreathFirstSearchOld(Node start, Node goal)
      {
         st.Reset();
         st.Start();
         List<Node> closed = new List<Node>();
         List<Node> open = new List<Node>();
         open.Add(start);
         bool found = false;
         while (!found && open.Count != 0)
         {
            closed.Add(open[0]);
            foreach (Node n in open[0].nodes)
            {
               int t = closed.IndexOf(n);
               if (n != null && closed.IndexOf(n) == -1)
               {
                  if (n == goal)
                  {
                     n.visited = true;
                     n.Parent = open[0];
                     BackTrack(start, goal);
                     st.Stop();
                     return (float)st.ElapsedMilliseconds;
                  }
                  else
                  {
                     n.visited = true;
                     n.Parent = open[0];
                     if (open.IndexOf(n) == -1)
                        open.Add(n);
                  }
               }
            }
            open.RemoveAt(0);
         }
         st.Stop();
         return st.ElapsedMilliseconds;
      }
   }
}
