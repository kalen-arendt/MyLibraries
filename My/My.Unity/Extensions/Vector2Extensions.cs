using UnityEngine;

namespace My.Unity.Extensions
{
   public static class Vector2Extensions
   {
      public static Vector2 PositionAsBasisVector (this Vector2 inDirection, float forward, float right)
      {
         return (inDirection * forward) + (inDirection.RotatedRight() * right);
      }

      public static Vector2 PositionAsBasisVector (this Vector2 self, Vector2 scale)
      {
         return (self * scale.y) + (self.RotatedRight() * scale.x);
      }

      public static Vector2 LerpTowards (this Vector2 v, Vector2 other, float t)
      {
         return Vector2.Lerp(v, other, t);
      }


      /// <summary>
      /// Returns a Vector with the same angle but with a different length.
      /// </summary>
      /// <param name="v">Input.</param>
      /// <param name="length">Length.</param>
      public static Vector2 WithLength (this Vector2 v, float length)
      {
         return v.normalized * length;
      }


      /// <summary>
      /// The angle of this vector from left to right (-x -> +x)
      /// </summary>
      /// <param name="v">Input.</param>
      public static Vector2 LeftToRight (this Vector2 v)
      {
         return v.x < 0 ? (-1) * v : v;
      }


      /// <summary>
      /// Returns the area of the vector2 as a rectangle
      /// </summary>
      /// <param name="v">Object.</param>
      public static float Area (this Vector2 v)
      {
         return Mathf.Abs(v.x * v.y);
      }


      /// <summary>
      /// The sum of the square of each component
      /// </summary>
      /// <returns>The sum.</returns>
      /// <param name="v">Object.</param>
      public static float SumSqrs (this Vector2 v)
      {
         return (v.x * v.x) + (v.y * v.y);
      }

      //	public static Vector2 RightAngleTo (this Vector2 a, Vector2 b) {
      //		return a.AngleTo(b).RotatedRight();
      //	}

      /// <summary>
      /// Returns the angle in radians.
      /// </summary>
      /// <param name="v">V.</param>
      public static float Radians (this Vector2 v)
      {
         return Mathf.Atan2(v.y, v.x);
      }

      public static Vector2 AngleTo (this Vector2 a, Vector2 b)
      {
         return b - a;
      }

      public static Vector2 NormDirection (this Vector2 a, Vector2 b)
      {
         return a.AngleTo(b).normalized;
      }


      public static Vector2 RotatedRight (this Vector2 a)
      {
         // 
         return new Vector2(a.y, -a.x);
      }

      // return is normalized since Direction normalizes.
      public static Vector2 RightOfVectorTo (this Vector2 aa, Vector2 bb)
      {
         return aa.NormDirection(bb).RotatedRight();
      }

      public static float Distance (this Vector2 a, Vector2 b)
      {
         return Vector2.Distance(a, b);
      }
   }
}
