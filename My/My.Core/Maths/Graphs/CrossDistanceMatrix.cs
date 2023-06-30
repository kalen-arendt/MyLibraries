using System;

namespace My.Core.Maths.Graphs
{
   public class CrossDistanceMatrix
   {
      public Shape a;
      public Shape b;

      public CrossDistanceMatrix (Shape a, Shape b)
      {
         this.a = a ?? throw new ArgumentNullException(nameof(a));
         this.b = b ?? throw new ArgumentNullException(nameof(b));
      }

      /// <summary>
      /// Calculate the distances of each vector a:A->b:B
      /// </summary>
      /// <param name="A"></param>
      /// <param name="B"></param>
      /// <returns></returns>
      public int[,] Get ()
      {
         var k = Math.Min( a.Size, b.Size );
         var cost = new int[k, k];
         var sol = new int[k];

         for (var i = 0; i < k; i++)
         {
            sol[i] = i;
            for (var j = 0; j < k; j++)
            {
               cost[i, j] = (int)(10 * Point.Distance(a[i], b[j]));
            }
         }

         return cost;
      }
   }
}
