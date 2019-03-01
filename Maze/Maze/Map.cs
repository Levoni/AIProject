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

   public class Map
   {
      public Node[,] map;
      private Random rand;
      private int width, height;
      public Node Start, End;

      public Map(int w, int h)
      {
         rand = new Random();
         width = w;
         height = h;
         map = new Node[width, height];
         for (int x = 0; x <width; x++)
            for (int y = 0; y < height; y++)
            {
               map[x, y] = new Node(x,y);
            }
         /*
         for (int x = 0; x < 10; x++)
            for (int y = 0; y < 10; y++)
            {
               if (y != 0)
               {
                  map[x, y].AddNode(map[x, y - 1], dir.UP);
               }
               if (y != 9)
               {
                  map[x, y].AddNode(map[x, y + 1], dir.DOWN);
               }
               if (x != 0)
               {
                  map[x, y].AddNode(map[x - 1, y], dir.LEFT);
               }
               if (x != 9)
               {
                  map[x, y].AddNode(map[x + 1, y], dir.RIGHT);
               }
            }
            */
         GenerateMap(0, 0);
      }

      public void GenerateMap(int xStart = 0, int yStart = 0)
      {
         map = new Node[width, height];
         for (int x = 0; x < width; x++)
            for (int y = 0; y < height; y++)
            {
               map[x, y] = new Node(x, y);
            }
         Start = map[xStart, yStart];
         Start.pl = place.start;

         Stack<Node> nodeStack = new Stack<Node>();
         List<Node> closed = new List<Node>();

         nodeStack.Push(map[xStart, yStart]);
         while(nodeStack.Count != 0)
         {
            int xOriginal = nodeStack.Peek().xPos;
            int yOriginal = nodeStack.Peek().yPos;
            dir direction = DetermineDirection(closed, xOriginal, yOriginal);
            closed.Remove(nodeStack.Peek());
            closed.Add(nodeStack.Peek());
            UpdateStack(nodeStack, xOriginal, yOriginal, direction);
         }

         End = map[rand.Next() % width, rand.Next() % height];
            End.pl = place.end;
      }

      private dir DetermineDirection(List<Node> closedList,int x, int y)
      {
         List<dir> possibleIndex = new List<dir>();
         possibleIndex.Add(dir.UP);
         possibleIndex.Add(dir.DOWN);
         possibleIndex.Add(dir.RIGHT);
         possibleIndex.Add(dir.LEFT);

         int next;
         while(possibleIndex.Count != 0)
         {
            next = rand.Next() % possibleIndex.Count;
            if (possibleIndex[next] == dir.UP && y != 0 && closedList.IndexOf(map[x, y - 1]) == -1)
               return dir.UP;
            if (possibleIndex[next] == dir.RIGHT && x != width - 1 && closedList.IndexOf(map[x + 1, y]) == -1)
               return dir.RIGHT;
            if (possibleIndex[next] == dir.DOWN && y != height - 1 && closedList.IndexOf(map[x, y + 1]) == -1)
               return dir.DOWN;
            if (possibleIndex[next] == dir.LEFT && x != 0 && closedList.IndexOf(map[x - 1, y]) == -1)
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



      public void BruteForceSearch(Node start, Node goal)
      {
         List<Node> closed = new List<Node>();
         List<Node> open = new List<Node>();

         open.Add(start);
         bool found = false;
         while(!found && open.Count != 0)
         {
            closed.Add(open[0]);
            open[0].visited = true;
            foreach(Node n in open[0].nodes)
            {
               if(n != null && closed.IndexOf(n) == -1)
               {
                  if (n == goal)
                     return;
                  else
                  {
                     open.Add(n);
                  }
               }
            }
            open.RemoveAt(0);
         }
         
      }
   }
}
