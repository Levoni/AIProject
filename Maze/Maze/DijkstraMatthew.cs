using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    class DijkstraMatthew:Search
    {
        public DijkstraMatthew():base()
        {

        }

        public override void SetupSearch(AINode[,] nodeMap, int startX, int startY, int endX, int endY)
        {
            
        }

        public override float RunSearch()
        {
            return 0;
        }

        public override bool RunRealTimeTick(int times, out List<AINode> nodesSearched)
        {
            nodesSearched = new List<AINode>();
            return false;
        }


    }
}