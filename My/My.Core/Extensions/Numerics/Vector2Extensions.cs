using System.Numerics;

namespace My.Core.Extensions.Numerics
{
   public static class Vector2Extensions
   {
      public static float CrossProduct (this Vector2 vectorA, Vector2 vectorB)
      {
         return (vectorA.X * vectorB.Y) - (vectorA.Y * vectorB.X);
      }
   }
}
