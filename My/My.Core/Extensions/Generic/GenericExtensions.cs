using System;

namespace My.Core.Extensions.Generic
{
   public static class GenericExtensions
   {
      public static bool IfNull<T> (this T t, Action<T> action)
      {
         if (t == null)
         {
            action(t);
            return true;
         }

         return false;
      }

      public static bool IfNull<T> (this T t, Action action)
      {
         if (t == null)
         {
            action();
            return true;
         }

         return false;
      }

      public static T IfNull<T> (this T t, Func<T> func)
      {
         return t == null ? func() : t;
      }
   }
}
