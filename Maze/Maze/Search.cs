using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
   /// <summary>
   /// Class responible fro executing search on a nodeMap
   /// </summary>
   abstract class Search
   {
      // For speed testing
      protected System.Diagnostics.Stopwatch st;

      // Basic variables for seaching
      protected Dictionary<string, AINode> closed;
      protected int xStart, yStart, xEnd, yEnd;
      
      // Creates memory space for variables
      public Search()
      {
         st = new System.Diagnostics.Stopwatch();
         closed = new Dictionary<string, AINode>();
      }

      /// <summary>
      /// Sets up/Resets search information
      /// </summary>
      /// <param name="nodeMap">AINode array to setup search info with</param>
      /// <param name="StartX">X location to start search at</param>
      /// <param name="StartY">Y location to start search at</param>
      /// <param name="EndX">X location to end search at</param>
      /// <param name="EndY">Y location to end search at</param>
      public abstract void SetupSearch(AINode[,] nodeMap, int StartX, int StartY, int EndX, int EndY);
      
      /// <summary>
      /// Executes a full search
      /// </summary>
      /// <returns>float with amount of time to execute in ms</returns>
      public abstract float RunSearch();

      /// <summary>
      /// Runs x number of ticks of the search function
      /// </summary>
      /// <param name="times">number of ticks to run</param>
      /// <returns>True is goal is found, false otherwise</returns>
      public abstract bool RunRealTimeTick(int times);

      /// <summary>
      /// Used to create a unique key (string) for a single node in the maze.
      /// The key is used for dictionaries in the differnt search functions.
      /// </summary>
      /// <param name="x">X location of the node</param>
      /// <param name="y">Y location of the node</param>
      /// <returns>A unique string for a single node in the maze</returns>
      protected string MakeKey(int x, int y)
      {
         return x.ToString() + "," + y.ToString();
      }

      /// <summary>
      /// Creates the path from the end to start.
      /// </summary>
      /// <param name="End">The goal node of the maze</param>
      public void BackTrack(AINode End)
      {
         End.pl = place.end;

         // Sets the current node place to path and continus to parent node. 
         while (End.Parent != null)
         {
            End = End.Parent;
            End.pl = place.path;
         }

         End.pl = place.start;
      } 
   }
}
