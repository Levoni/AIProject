using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
   /// <summary>
   /// Class created just to have the doubleBuffered
   /// property set to true
   /// </summary>
   class DBPanel:System.Windows.Forms.Panel
   {

      public DBPanel():base()
      {
         DoubleBuffered = true;
      }
   }
}
