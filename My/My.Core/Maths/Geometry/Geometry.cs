namespace My.Core.Maths
{
   public static class Geometryyy
   {
      #region IsPointInPoly, AreaOfTriangle, IsPointInTriangle

      //public static bool IsPointInPoly (Point[] Ps, Point test)
      //{
      //   var L = Ps.Length;

      //   for (var i = 2; i < L; i++)
      //   {
      //      if (IsPointInTriangle(Ps[0], Ps[i - 1], Ps[i], test))
      //      {
      //         return true;
      //      }
      //   }

      //   return false;
      //}




      #endregion


      #region MagnitudeBetween, Bisector

      ///// <summary>
      ///// returns the bisector PointAngle between target1 and target2
      ///// </summary>
      ///// <param name="source">Source.</param>
      ///// <param name="target1">Target1.</param>
      ///// <param name="target2">Target2.</param>
      //public static PointAngle Bisector (this Point source, Point target1, Point target2)
      //{
      //   return new PointAngle(
      //      source.ToPoint(),
      //      ((target1 - source).normalized + (target2 - source).normalized).normalized.ToPoint()
      //   );
      //}


      #endregion


      #region NearestOfPoints, NearestPoint, NearestPointAlongAngle



      //   /// <summary>
      //   /// The nearest point to self, found along angles(lines from) source->p1 & source->p2.
      //   /// Useful for cutting off the nearest passing lane.
      //   /// </summary>
      //   /// <returns>The nearest point.</returns>
      //   /// <param name="self">Self.</param>
      //   /// <param name="source">the origin of the 2 lines</param>
      //   /// <param name="p1">the end point of line 1</param>
      //   /// <param name="p2">the end point of line 2</param>
      //   public static Point NearestPointAlongAngle (this Point self, Point source, Point p1, Point p2)
      //   {
      //      Point
      //      p1x = source.IntersectAtNormal( p1, self ), // x for the x of intersection
      //p2x = source.IntersectAtNormal( p2, self ),
      //      p1f = source.NearestPoint( p1, p1x ),
      //      p2f = source.NearestPoint( p2, p2x );

      //      return self.NearestPoint(p1f, p2f);
      //   }

      #endregion


      #region IntersectAtNormal, IntersectLineSegments

      ///// <summary>
      ///// Point along source->target, perpendicular to normIntersect
      ///// For covering source (getting the pass from target) while also perpendicular to normIntersect
      ///// </summary>
      ///// <returns>The at normal.</returns>
      ///// <param name="source">Source.</param>
      ///// <param name="target">Target.</param>
      ///// <param name="normIntersect">Norm intersect.</param>
      //public static Point IntersectAtNormal (this Point source, Point target, Point normIntersect)
      //{
      //   PointAngle l1 = PointAngle.CreateFrom2Points( source, target );
      //   Point inverse = Point.Perpendicular( l1.Angle );
      //   var l2 = new PointAngle( normIntersect, inverse );
      //   return l1.Intersection(l2).Value;
      //}


      ///// <summary>
      ///// Intersection of lines |p1 -> p2| and |p3 -> p4|
      ///// </summary>
      ///// <param name="p1a">P1a.</param>
      ///// <param name="p1b">P1b.</param>
      ///// <param name="p2a">P2a.</param>
      ///// <param name="p2b">P2b.</param>
      //public static Point? IntersectLineSegments (Point p1, Point p2, Point p3, Point p4, bool extrapolate = false)
      //{
      //   if (p1.x > p2.x)
      //   { // reorder points left -> right
      //      var temp = p1;
      //      p1 = p2;
      //      p2 = temp;
      //   }
      //   if (p3.x > p4.x)
      //   { // reorder points left -> right
      //      var temp = p3;
      //      p3 = p4;
      //      p4 = temp;
      //   }
      //   if (p1.x > p3.x)
      //   { // reorder groups so the leftmost is the first equation
      //      var temp = p1;
      //      p1 = p3;
      //      p3 = temp;

      //      temp = p2;
      //      p2 = p4;
      //      p4 = temp;
      //   }

      //   Point
      //   angle1 = (p2 - p1).normalized,
      //   angle2 = (p4 - p3).normalized;

      //   Point?
      //   crossPoint = new PointAngle( p1, angle1 ).Intersection( new PointAngle( p3, angle2 ) );

      //   if (crossPoint.HasValue)
      //   {
      //      Point output = crossPoint.Value;
      //      var valid = output.x >= p3.x && output.x <= p4.x && output.x >= p1.x && output.x <= p2.x;
      //      if (extrapolate || valid)
      //         return output;
      //   }
      //   return null;
      //}


      #endregion


      #region Midpoint, MeanPoint, IncenterOfPoints, CircumCenterOfPoints

      //public static Point Midpoint (this Point a, Point b)
      //{
      //   return (a + b) * .5f;
      //}

      //public static Point MeanPoint (this Point[] points)
      //{
      //   Point output = Point.Zero;
      //   foreach (var p in points)
      //      output += p;
      //   return output / points.Length;
      //}

      //public static Point IncenterOfPoints (Point p1, Point p2, Point p3)
      //{
      //   return p1.Bisector(p2, p3).Intersection(p2.Bisector(p1, p3)).Value;
      //}

      ///// <summary>
      ///// The average of all Incenters calculated.
      ///// </summary>
      ///// <returns>The of points.</returns>
      ///// <param name="points">Points.</param>
      //public static Point IncenterOfPoints (this Point[] points)
      //{
      //   var length = points.Length;
      //   switch (length)
      //   {
      //      case 0:
      //         return Point.Zero;
      //      case 1:
      //         return points[0];
      //      case 2:
      //         return points[0].Midpoint(points[1]);
      //      case 3:
      //         return IncenterOfPoints(points[0], points[1], points[2]);
      //      default: // gather 3 at a time the incenter of the 3 points, then take the average.
      //         Point output = Point.Zero;
      //         for (var i = 0; i < length; i++)
      //            output += IncenterOfPoints(points[i], points[(i + 1) % length], points[(i + 2) % length]);
      //         return output * (1f / length);
      //   }
      //}


      ///// <summary>
      ///// The point which is equa distance to all 3 points, they fall on the circumference of the same circle.
      ///// 
      ///// for a point P to be equal distance to both A and B, then it must fall on the line {perpendicular to dirAB, intersecting at midpoint}
      ///// therefore the circum center is the intersection of 
      ///// </summary>
      ///// <returns>The (x,y) center of points, z = radius.</returns>
      ///// <param name="p1">P1.</param>
      ///// <param name="p2">P2.</param>
      ///// <param name="p3">P3.</param>
      //public static Point CircumCenterOfPoints (Point p1, Point p2, Point p3)
      //{
      //   return p1.MiddlePerpendicular(p2).Intersection(p1.MiddlePerpendicular(p3)).Value;
      //}

      //public static Point CircumCenterOfPoints (this Point[] points)
      //{
      //   var length = points.Length;
      //   switch (length)
      //   {
      //      case 0:
      //         return Point.Zero;
      //      case 1:
      //         return points[0];
      //      case 2:
      //         Point mid = points[0].Midpoint( points[1] );
      //         return mid + (Point.forward * Point.Distance(mid, points[0]));
      //      case 3:
      //         return CircumCenterOfPoints(points[0], points[1], points[2]);
      //      default: // gather 3 at a time the incenter of the 3 points, then take the average.
      //         Point output = Point.Zero;
      //         for (var i = 0; i < length; i++)
      //            output += CircumCenterOfPoints(points[i], points[(i + 1) % length], points[(i + 2) % length]);
      //         return output * (1f / length);
      //   }
      //}


      //public static PointAngle MiddlePerpendicular (this Point p1, Point p2)
      //{
      //   return new PointAngle(p1.Midpoint(p2), (p2.ToVector2() - p1.ToVector2()).RotatedRight());
      //}

      #endregion
   }
}
