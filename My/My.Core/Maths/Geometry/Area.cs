using System.Numerics;

using My.Core.Extensions.Numerics;

namespace My.Core.Maths
{
   public static class Area
   {

      /// <summary>
      /// Calculate the Area of a Triangle
      /// </summary>
      public static float OfTriangle (Vector2 v1, Vector2 v2, Vector2 v3)
      {
         Vector2 e1 = v2 - v1;
         Vector2 e2 = v3 - v2;

         return e1.CrossProduct(e2).Abs() / 2;
      }

      /// <summary>
      /// Calculate the Area of a Parallelogram
      /// </summary>
      public static float OfParallelogram (Vector2 v1, Vector2 v2, Vector2 v3)
      {
         Vector2 e1 = v2 - v1;
         Vector2 e2 = v3 - v2;

         return e1.CrossProduct(e2).Abs() / 2;
      }
   }
}
