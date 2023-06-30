using System.Collections.Generic;

namespace My.Core.Maths.Graphs
{
   /// <summary>
   /// 
   /// </summary>
   public sealed class HungarianAlgorithm
   {
      private readonly int[,] costMatrix;
      private int inf;
      private int n; //number of elements
      private int[] lx; //labels for workers
      private int[] ly; //labels for jobs 
      private bool[] s;
      private bool[] t;
      private int[] matchX; //vertex matched with x
      private int[] matchY; //vertex matched with y
      private int maxMatch;
      private int[] slack;
      private int[] slackx;
      private int[] prev; //memorizing paths




      /// <summary>
      /// 
      /// </summary>
      /// <param name="costMatrix"></param>
      public HungarianAlgorithm (int[,] costMatrix)
      {
         this.costMatrix = costMatrix;
      }

      /// <summary>
      /// 
      /// </summary>
      /// <returns></returns>
      public int[] Run ()
      {
         n = costMatrix.GetLength(0);

         lx = new int[n];
         ly = new int[n];
         s = new bool[n];
         t = new bool[n];
         matchX = new int[n];
         matchY = new int[n];
         slack = new int[n];
         slackx = new int[n];
         prev = new int[n];
         inf = int.MaxValue;


         InitMatches();

         if (n != costMatrix.GetLength(1))
         {
            return null;
         }

         InitLbls();

         maxMatch = 0;

         InitialMatching();

         var q = new Queue<int>();

         #region augment

         while (maxMatch != n)
         {
            q.Clear();

            InitSt();
            //Array.Clear(S,0,n);
            //Array.Clear(T, 0, n);


            //parameters for keeping the position of root node and two other nodes
            var root = 0;
            int x;
            var y = 0;

            //find root of the tree
            for (x = 0; x < n; x++)
            {
               if (matchX[x] != -1)
               {
                  continue;
               }

               q.Enqueue(x);
               root = x;
               prev[x] = -2;

               s[x] = true;
               break;
            }

            //init slack
            for (var i = 0; i < n; i++)
            {
               slack[i] = costMatrix[root, i] - lx[root] - ly[i];
               slackx[i] = root;
            }

            //finding augmenting path
            while (true)
            {
               while (q.Count != 0)
               {
                  x = q.Dequeue();
                  var lxx = lx[x];
                  for (y = 0; y < n; y++)
                  {
                     if (costMatrix[x, y] != lxx + ly[y] || t[y])
                     {
                        continue;
                     }

                     if (matchY[y] == -1)
                     {
                        break; //augmenting path found!
                     }

                     t[y] = true;
                     q.Enqueue(matchY[y]);

                     AddToTree(matchY[y], x);
                  }

                  if (y < n)
                  {
                     break; //augmenting path found!
                  }
               }

               if (y < n)
               {
                  break; //augmenting path found!
               }

               UpdateLabels(); //augmenting path not found, update labels

               for (y = 0; y < n; y++)
               {
                  //in this cycle we add edges that were added to the equality graph as a
                  //result of improving the labeling, we add edge (slackx[y], y) to the tree if
                  //and only if !T[y] &&  slack[y] == 0, also with this edge we add another one
                  //(y, yx[y]) or augment the matching, if y was exposed

                  if (t[y] || slack[y] != 0)
                  {
                     continue;
                  }

                  if (matchY[y] == -1) //found exposed vertex-augmenting path exists
                  {
                     x = slackx[y];
                     break;
                  }

                  t[y] = true;
                  if (s[matchY[y]])
                  {
                     continue;
                  }

                  q.Enqueue(matchY[y]);
                  AddToTree(matchY[y], slackx[y]);
               }

               if (y < n)
               {
                  break;
               }
            }

            maxMatch++;

            //inverse edges along the augmenting path
            int ty;
            for (int cx = x, cy = y; cx != -2; cx = prev[cx], cy = ty)
            {
               ty = matchX[cx];
               matchY[cy] = cx;
               matchX[cx] = cy;
            }
         }

         #endregion

         return matchX;
      }

      private void InitMatches ()
      {
         for (var i = 0; i < n; i++)
         {
            matchX[i] = -1;
            matchY[i] = -1;
         }
      }

      private void InitSt ()
      {
         for (var i = 0; i < n; i++)
         {
            s[i] = false;
            t[i] = false;
         }
      }

      private void InitLbls ()
      {
         for (var i = 0; i < n; i++)
         {
            var minRow = costMatrix[i, 0];
            for (var j = 0; j < n; j++)
            {
               if (costMatrix[i, j] < minRow)
               {
                  minRow = costMatrix[i, j];
               }

               if (minRow == 0)
               {
                  break;
               }
            }

            lx[i] = minRow;
         }

         for (var j = 0; j < n; j++)
         {
            var minColumn = costMatrix[0, j] - lx[0];
            for (var i = 0; i < n; i++)
            {
               if (costMatrix[i, j] - lx[i] < minColumn)
               {
                  minColumn = costMatrix[i, j] - lx[i];
               }

               if (minColumn == 0)
               {
                  break;
               }
            }

            ly[j] = minColumn;
         }
      }

      private void UpdateLabels ()
      {
         var delta = inf;
         for (var i = 0; i < n; i++)
         {
            if (!t[i])
            {
               if (delta > slack[i])
               {
                  delta = slack[i];
               }
            }
         }

         for (var i = 0; i < n; i++)
         {
            if (s[i])
            {
               lx[i] = lx[i] + delta;
            }

            if (t[i])
            {
               ly[i] = ly[i] - delta;
            }
            else
            {
               slack[i] = slack[i] - delta;
            }
         }
      }

      private void AddToTree (int x, int prevx)
      {
         //x-current vertex, prevx-vertex from x before x in the alternating path,
         //so we are adding edges (prevx, matchX[x]), (matchX[x],x)

         s[x] = true; //adding x to S
         prev[x] = prevx;

         var lxx = lx[x];
         //updateing slack
         for (var y = 0; y < n; y++)
         {
            if (costMatrix[x, y] - lxx - ly[y] >= slack[y])
            {
               continue;
            }

            slack[y] = costMatrix[x, y] - lxx - ly[y];
            slackx[y] = x;
         }
      }

      private void InitialMatching ()
      {
         for (var x = 0; x < n; x++)
         {
            for (var y = 0; y < n; y++)
            {
               if (costMatrix[x, y] != lx[x] + ly[y] || matchY[y] != -1)
               {
                  continue;
               }

               matchX[x] = y;
               matchY[y] = x;
               maxMatch++;
               break;
            }
         }
      }
   }
}
