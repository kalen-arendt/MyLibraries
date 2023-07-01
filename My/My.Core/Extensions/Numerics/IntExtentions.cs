using System;
using System.Collections.Generic;

namespace My.Core.Extensions.Numerics
{
   public static class IntExtentions
   {
      public static IEnumerable<TOut> Iterate<TOut> (this int length, Func<int, TOut> func)
      {
         if (length <= 0)
         {
            yield break;
         }

         for (var i = 0; i < length; i++)
         {
            yield return func(i);
         }
      }


      public static int Sqr (this int i)
      {
         return i * i;
      }

      public static float Sqrt (this int i)
      {
         return (float)Math.Sqrt(i);
      }

      public static int Abs (this int i)
      {
         return i >= 0 ? i : -i;
      }

      public static int Pow (this int f, int pow)
      {
         var result = 1;
         for (var i = 0; i < pow; i++)
         {
            result *= f;
         }

         return result;
      }
   }
}
