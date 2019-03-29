using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
   class GreedyLevon : Search
   {


      public GreedyLevon() : base()
      {

      }


      public override void SetupSearch(AINode[,] nodeMap, int StartX, int StartY, int EndX, int EndY)
      {
         GenerateHValues(nodeMap,EndX,EndY);

         

      }

      public override bool RunRealTimeTick(int times, out List<AINode> nodesSearched)
      {
         throw new NotImplementedException();
      }

      public override float RunSearch()
      {
         throw new NotImplementedException();
      }

      private void GenerateHValues(AINode[,] nodeMap, int endX, int endY)
      {
         foreach(AINode n in nodeMap)
         {
            n.h = Math.Abs(endX - n.x) + Math.Abs(endY - n.y);
         }
      }
   }
}
