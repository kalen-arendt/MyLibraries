using System;
using System.Collections.Generic;
using System.Linq;

namespace My.Core.Maths
{
   public static class NearestPointExtension
   {
      /// <summary>
      /// The nearest point to self of many points.
      /// </summary>
      /// <returns>The of points.</returns>
      /// <param name="self">Self.</param>
      /// <param name="points">Points.</param>
      public static Point NearestPoint (this Point self, IEnumerable<Point> points)
      {
         return points.Select(
                  p => new
                  {
                     point = p,
                     mag = Point.SqrMagnitude(self, p)
                  })
               .Aggregate(
                  (curr, next) => curr.mag > next.mag ? curr : next
               )
               .point;
      }
   }
}
