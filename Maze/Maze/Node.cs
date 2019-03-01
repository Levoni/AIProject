using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
   public enum place
   {
      start,
      end,
      path,
      none,
   }

   public class Node
   {
      public Node[] nodes;

      public Node Parent;

      public bool visited;

      public int xPos, yPos;

      public place pl;

      public Node(int x,int y)
      {
         xPos = x;
         yPos = y;
         visited = false;
         pl = place.none;
         nodes = new Node[4];
         for (int i = 0; i < nodes.Length; i++)
            nodes[i] = null;

      }

      public void AddNode(Node n, dir d)
      {
         nodes[(int)d] = n;
      }

      public void ResetInfo()
      {
         Parent = null;
         visited = false;
         pl = place.none;
      }

      public bool IsDeadEnd()
      {
         int connection = 0;
         foreach(Node n in nodes)
         {
            if (n != null)
               connection++;
         }
         if (connection >= 1)
            return true;
         return false;
      }

   }
}
