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
      public static Point NearestOfPoints (this Point self, IEnumerable<Point> points)
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


      /// <summary>
      /// The nearest point to self.
      /// </summary>
      /// <returns>The point.</returns>
      /// <param name="self">Self.</param>
      /// <param name="p1">P1.</param>
      /// <param name="p2">P2.</param>
      public static Point NearestPoint (this Point self, Point p1, Point p2)
      {
         return (self - p1).SqrMagnitude() < (self - p2).SqrMagnitude() ? p1 : p2;
      }
   }
}
