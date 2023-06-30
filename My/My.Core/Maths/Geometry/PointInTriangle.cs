using System.Numerics;

namespace My.Core.Maths
{
   public class PointInTriangle
   {
      public static bool Test (Vector2 v1, Vector2 v2, Vector2 v3, Vector2 p)
      {
         var areaWith = Area.OfTriangle( v1, v2, p ) + Area.OfTriangle( v2, v3, p ) + Area.OfTriangle( v3, v1, p );
         var areaWithout = Area.OfTriangle( v1, v2, v3 );

         return areaWith == areaWithout;
      }
   }
}
