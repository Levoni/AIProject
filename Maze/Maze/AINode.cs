using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
   /// <summary>
   /// Node used in AI class
   /// </summary>
   public class AINode
   {
      // Position and huristics
      public int x { get; set; }

      public int y { get; set; }

      public int g { get; set; }

      public int h { get; set; }

      // Children nodes
      public AINode[] AINodes;

      // Results of searching
      public place pl;
      public AINode Parent;
      public bool visited;

      public AINode(int xPos, int yPos)
      {
         x = xPos;
         y = yPos;
         g = h = 0;
         AINodes = new AINode[4];
         for (int i = 0; i < 4; i++)
            AINodes[i] = null;

         pl = place.none;
         Parent = null;
         visited = false;
      }

      // Resets information related to searching
      public void ResetSearchInfo()
      {
         pl = place.none;
         Parent = null;
         visited = false;
      }
   }
}
