using System;

namespace My.Core.Extensions.Numerics
{
   public static class NumericExtentions
   {
      public static float Sqr (this float f)
      {
         return f * f;
      }

      public static float Sqrt (this float f)
      {
         return (float)Math.Sqrt(f);
      }

      public static float Abs (this float f)
      {
         return f >= 0 ? f : -f;
      }

      public static float Pow (this float f, int pow = 2)
      {
         float o = 1;
         for (var i = 0; i < pow; i++)
         {
            o *= f;
         }

         return o;
      }
   }
}
