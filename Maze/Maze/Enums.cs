using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
   // The respetive place in the critical path
   public enum place
   {
      start,
      end,
      path,
      none,
   }

   // Enum for direction. It is also used as the index for the 
   // children nodes in the nodes array for each node
   public enum dir
   {
      UP = 0,
      RIGHT = 1,
      DOWN = 2,
      LEFT = 3,
      UNKNOWN = -1,
   }
}
