using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

namespace My.Unity.Extensions.Debugging
{
   public static class PrintExtensions
   {
      public static void Print<T> (this IEnumerable<T> collection, string name)
      {
         int i = 0;
         Debug.Log(
            collection.Aggregate(
               new StringBuilder().Append(name)
                                  .Append(" {")
                                  .AppendLine(),
               (sb, next) => sb.AppendFormat("\t{0} -> {1}", i++, next)
                               .AppendLine()
            )
            .AppendLine("}")
            .ToString()
         );
      }

      public static void Print<T> (this IEnumerable<T> collection)
      {
         collection.Print("");
      }
   }
}
