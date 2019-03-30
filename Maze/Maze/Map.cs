using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
   //TODO: look into possibly cutting wall even if not dead end ex) isWallCount < 2 vs isWallCount < 1

   /// <summary>
   /// Class responsible for creating and managing the nodes in the maze
   /// </summary>
   public class Map
   {
      public Tile[,] map;
      private Random rand;
      private int width, height;
      public Tile Start, End;
      private const int cutChance = 50;
      System.Diagnostics.Stopwatch st;

      /// <summary>
      /// Creates a non-generated map of specified size
      /// </summary>
      /// <param name="w">Amount of nodes wide the maze is</param>
      /// <param name="h">Amount of nodes high the maze is</param>
      public Map(int w, int h)
      {
         rand = new Random();
         width = w;
         height = h;
         map = new Tile[width, height];
         st = new System.Diagnostics.Stopwatch();
         // Allocates memory for every tile in array
         for (int x = 0; x < width; x++)
            for (int y = 0; y < height; y++)
            {
               map[x, y] = new Tile(x, y);
            }
      }

      /// <summary>
      /// Returns cutChance
      /// </summary>
      /// <returns>int cutChance</returns>
      public int GetCutPercent()
      {
         return cutChance;
      }

      /// <summary>
      /// Used to create a unique key (string) for a single node in the maze.
      /// The key is used for dictionaries in the differnt search functions.
      /// </summary>
      /// <param name="x">X location of the node</param>
      /// <param name="y">Y location of the node</param>
      /// <returns>A unique string for a single node in the maze</returns>
      private string MakeKey(int x, int y)
      {
         return x.ToString() + "," + y.ToString();
      }

      /// <summary>
      /// Generates a solvable maze with a start and end point.
      /// </summary>
      /// <param name="cutPercent">The chance that dead are opened up</param>
      /// <returns>Time needed to generate maze in miliseconds</returns>
      public float GenerateMap(int cutPercent)
      {
         st.Start(); // starts timmer for time generation
         
         // Resets map information
         map = new Tile[width, height];
         for (int x = 0; x < width; x++)
            for (int y = 0; y < height; y++)
            {
               map[x, y] = new Tile(x, y);
            }

         int xStart = rand.Next() % width;
         int yStart = rand.Next() % height;
         Start = map[xStart, yStart];
         
         // Set up local variables for generating the map
         Stack<Tile> nodeStack = new Stack<Tile>();
         Dictionary<string,Tile> closed = new Dictionary<string, Tile>();
         int xOriginal;
         int yOriginal;
         nodeStack.Push(map[xStart, yStart]);

         // Generates the map 
         while(nodeStack.Count != 0)
         {
            xOriginal = nodeStack.Peek().xPos;
            yOriginal = nodeStack.Peek().yPos;
            dir direction = DetermineDirection(closed, xOriginal, yOriginal); //Get direction to move next tile to
            if (direction == dir.UNKNOWN && nodeStack.Peek().IsDeadEnd() && cutPercent > rand.Next() % 100)
               RemoveDeadEnd(nodeStack.Peek()); // removes wall so tile is not a dead end
            closed[MakeKey(xOriginal,yOriginal)] = nodeStack.Peek(); 
            UpdateStack(nodeStack, xOriginal, yOriginal, direction); // moves to next tile 
         }

         End = map[rand.Next() % width, rand.Next() % height];
         //End.pl = place.end;
         st.Stop();

         return (float) st.ElapsedMilliseconds;
      }

      /// <summary>
      /// Picks a random direction from a specified location. Returns unknown
      /// direction if there are no directions with a node not in the dictionary.
      /// </summary>
      /// <param name="closedList">Dictionary of nodes already generated in the maze.</param>
      /// <param name="x">X position to start at</param>
      /// <param name="y">Y position to start at</param>
      /// <returns>Direction that open, unknown direction otherwise</returns>
      private dir DetermineDirection(Dictionary<string,Tile> closedList,int x, int y)
      {
         // Creates list of directions to randomly pick from
         List<dir> possibleIndex = new List<dir>();
         possibleIndex.Add(dir.UP);
         possibleIndex.Add(dir.DOWN);
         possibleIndex.Add(dir.RIGHT);
         possibleIndex.Add(dir.LEFT);


         int next;
         // randomlly picks a direction until viable direction is found
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

         // Return unknown direction if no non-closed nodes are available
         return dir.UNKNOWN;
      }

      /// <summary>
      /// This function updates the stack by putting the node in the 
      /// moveDirection on top of the stack while removing wall between.
      /// Pops the top tile off stack if direction is unknown.
      /// </summary>
      /// <param name="nodeStack">Current stack of nodes</param>
      /// <param name="xOriginal">X direction of current node</param>
      /// <param name="yOriginal">Y direction of current node</param>
      /// <param name="moveDirection">Direction of the node to add</param>
      private void UpdateStack(Stack<Tile> nodeStack ,int xOriginal, int yOriginal,dir moveDirection)
      {
         if (moveDirection == dir.UP)
         {
            RemoveWall(map[xOriginal, yOriginal], map[xOriginal, yOriginal - 1], moveDirection);
            nodeStack.Push(map[xOriginal, yOriginal - 1]);
         }
         else if (moveDirection == dir.DOWN)
         {
            RemoveWall(map[xOriginal, yOriginal], map[xOriginal, yOriginal + 1], moveDirection);
            nodeStack.Push(map[xOriginal, yOriginal + 1]);
         }
         else if (moveDirection == dir.RIGHT)
         {
            RemoveWall(map[xOriginal, yOriginal], map[xOriginal + 1, yOriginal], moveDirection);
            nodeStack.Push(map[xOriginal + 1, yOriginal]);
         }
         else if (moveDirection == dir.LEFT)
         {
            RemoveWall(map[xOriginal, yOriginal], map[xOriginal - 1, yOriginal], moveDirection);
            nodeStack.Push(map[xOriginal - 1, yOriginal]);
         }
         else
            nodeStack.Pop();
      }

      /// <summary>
      /// Connects two adjacent nodes in the maze together
      /// </summary>
      /// <param name="oldNode">The node to connect from</param>
      /// <param name="newNode">The node to connect to</param>
      /// <param name="moveDirection">The direction from oldNode to NewNode</param>
      public void RemoveWall(Tile oldNode, Tile newNode, dir moveDirection)
      {
         oldNode.adjacentTiles[(int)moveDirection] = newNode;
         newNode.adjacentTiles[((int)moveDirection + 2) % 4] = oldNode;
      }

      /// <summary>
      /// Disconnects two adjacent nodes in the maze together
      /// </summary>
      /// <param name="oldNode">The node to disconnect from</param>
      /// <param name="newNode">The node to disconnect to</param>
      /// <param name="moveDirection">The direction from oldNode to NewNode</param>
      public void AddWall(Tile oldNode, Tile newNode,dir moveDirection)
      {
         oldNode.adjacentTiles[(int)moveDirection] = null;
         newNode.adjacentTiles[((int)moveDirection + 2) % 4] = null;
      }

      /// <summary>
      /// Opens up a dead end by cutting out a wall 
      /// </summary>
      /// <param name="DeadEndTile">The Tile that is a dead end</param>
      private void RemoveDeadEnd(Tile DeadEndTIle)
      {
         // Removes wall opposite of the one open side if possible
         if (DeadEndTIle.adjacentTiles[(int)dir.UP] != null && DeadEndTIle.yPos != height - 1)
         {
            RemoveWall(DeadEndTIle,map[DeadEndTIle.xPos, DeadEndTIle.yPos + 1], dir.DOWN);
         }
         else if (DeadEndTIle.adjacentTiles[(int)dir.DOWN] != null && DeadEndTIle.yPos != 0)
         {
            RemoveWall(DeadEndTIle, map[DeadEndTIle.xPos, DeadEndTIle.yPos - 1], dir.UP);
         }
         else if (DeadEndTIle.adjacentTiles[(int)dir.RIGHT] != null && DeadEndTIle.xPos != 0)
         {
            RemoveWall(DeadEndTIle, map[DeadEndTIle.xPos - 1, DeadEndTIle.yPos], dir.LEFT);
         }
         else if (DeadEndTIle.adjacentTiles[(int)dir.LEFT] != null && DeadEndTIle.xPos != width - 1)
         {
            RemoveWall(DeadEndTIle, map[DeadEndTIle.xPos + 1, DeadEndTIle.yPos], dir.RIGHT);
         }
      }

      /// <summary>
      /// Saves current map to .tm file.
      /// </summary>
      /// <param name="saveName">Path to save the file to</param>
      public void SaveMap(string saveName)
      {
         using (StreamWriter sw = new StreamWriter(saveName))
         {
            string walls = string.Empty;
            sw.WriteLine(width.ToString() + "," + height.ToString());
            sw.WriteLine(Start.xPos + "," + Start.yPos + "," + End.xPos + "," + End.yPos);
            for(int j = 0; j < height; j++)
            {
               walls = string.Empty;
               for (int i = 0; i < width; i++)
               {
                  foreach(Tile t in map[i,j].adjacentTiles)
                  {
                     if (t == null)
                        walls += "0";
                     else
                        walls += "1";
                  }
                  walls += ":";
               }
               walls = walls.Substring(0, walls.Length - 1);
               sw.WriteLine(walls);
            }
         }
      }

      /// <summary>
      /// Loads a Map from a .tm file.
      /// </summary>
      /// <param name="fileName">Path to the file you want to load</param>
      public void LoadMap(string fileName)
      {
         using (StreamReader sr = new StreamReader(fileName))
         {
            string[] size = sr.ReadLine().Split(',');
            string[] startEnd = sr.ReadLine().Split(',');
            map = new Tile[int.Parse(size[0]), int.Parse(size[1])];
            width = int.Parse(size[0]);
            height = int.Parse(size[1]);

            for (int i = 0; i < width; i++)
            {
               for (int j = 0; j < height; j++)
               {
                  map[i, j] = new Tile(i,j);
               }
            }

            Start = map[int.Parse(startEnd[0]), int.Parse(startEnd[1])];
            End = map[int.Parse(startEnd[2]), int.Parse(startEnd[3])];

            for (int j = 0; j < height; j++)
            {
               string[] row = sr.ReadLine().Split(':');
               for(int i = 0; i < width; i++)
               {
                  string tile = row[i];
                  if (tile[(int)dir.UP] == '0')
                     map[i, j].adjacentTiles[(int)dir.UP] = map[i, j - 1];
                  if (tile[(int)dir.RIGHT] == '0')
                     map[i, j].adjacentTiles[(int)dir.RIGHT] = map[i + 1, j];
                  if (tile[(int)dir.DOWN] == '0')
                     map[i, j].adjacentTiles[(int)dir.DOWN] = map[i, j + 1];
                  if (tile[(int)dir.LEFT] == '0')
                     map[i, j].adjacentTiles[(int)dir.LEFT] = map[i - 1, j];
               }
            }
         }
      }
   }
}
