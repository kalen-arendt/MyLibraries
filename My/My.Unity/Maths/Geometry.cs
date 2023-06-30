//using System.Linq;

//using My.Core.Extensions.Numerics;
//using My.Core.Maths.Matrices;

//using UnityEngine;

//namespace My.Unity.Maths
//{
//   public static class Geometry
//   {
//      #region IsPointInPoly, AreaOfTriangle, IsPointInTriangle

//      public static bool IsPointInPoly (Vector2[] Ps, Vector2 test)
//      {
//         var L = Ps.Length;

//         for (var i = 2; i < L; i++)
//         {
//            if (IsPointInTriangle(Ps[0], Ps[i - 1], Ps[i], test))
//            {
//               return true;
//            }
//         }

//         return false;
//      }

//      /// <summary>
//      /// Calculate the Area of a Triangle using Side Lengths
//      /// </summary>
//      /// <param name="a"></param>
//      /// <param name="b"></param>
//      /// <param name="c"></param>
//      /// <returns></returns>
//      public static float AreaOfTriangle (Vector2 a, Vector2 b, Vector2 c)
//      {
//         float
//         A = Vector2.Distance( b, c ),
//         B = Vector2.Distance( a, c ),
//         C = Vector2.Distance( a, b ),
//         S = (A + B + C) / 2f;

//         return Mathf.Sqrt(S * (S - A) * (S - B) * (S - C));
//      }

//      /// <summary>
//      /// Calculate the Area of a Triangle using Determinants.
//      /// </summary>
//      /// <param name="a"></param>
//      /// <param name="b"></param>
//      /// <param name="c"></param>
//      /// <returns></returns>
//      public static float AreaTriangle (Vector2 a, Vector2 b, Vector2 c)
//      {
//         return 0.5f * (
//                  new FloatMatrix2x2(a.ToPoint(), b.ToPoint()).Det +
//                  new FloatMatrix2x2(b.ToPoint(), c.ToPoint()).Det +
//                  new FloatMatrix2x2(c.ToPoint(), a.ToPoint()).Det
//                  ).Abs();
//      }

//      public static bool IsPointInTriangle (Vector2 a, Vector2 b, Vector2 c, Vector2 point)
//      {
//         var areaWith = AreaTriangle( a, b, point ) + AreaTriangle( b, c, point ) + AreaTriangle( c, a, point );
//         var areaWithout = AreaTriangle( a, b, c );

//         return areaWith == areaWithout;
//      }

//      #endregion


//      #region MagnitudeBetween, Bisector

//      /// <summary>
//      /// The product of squares of components.
//      /// Faster than finding length when comparing lengths and not calculating them.
//      /// </summary>
//      /// <returns></returns>
//      /// <param name="a"></param>
//      /// <param name="b"></param>
//      public static float MagnitudeBetween (this Vector2 a, Vector2 b)
//      {
//         return (b - a).sqrMagnitude;
//      }



//      /// <summary>
//      /// returns the bisector PointAngle between target1 and target2
//      /// </summary>
//      /// <param name="source">Source.</param>
//      /// <param name="target1">Target1.</param>
//      /// <param name="target2">Target2.</param>
//      public static PointAngle Bisector (this Vector2 source, Vector2 target1, Vector2 target2)
//      {
//         return new PointAngle(
//            source.ToPoint(),
//            ((target1 - source).normalized + (target2 - source).normalized).normalized.ToPoint()
//         );
//      }


//      #endregion


//      #region NearestOfPoints, NearestPoint, NearestPointAlongAngle

//      /// <summary>
//      /// The nearest point to self of many points.
//      /// </summary>
//      /// <returns>The of points.</returns>
//      /// <param name="self">Self.</param>
//      /// <param name="points">Points.</param>
//      public static Vector2
//      NearestOfPoints (this Vector2 self, Vector2[] points)
//      {
//         if (points.Length == 0)
//         {
//            return self;
//         }
//         else
//         {
//            Vector2 nearestP = points[0];
//            foreach (Vector2 p in points)
//            {
//               nearestP = self.NearestPoint(nearestP, p);
//            }

//            return nearestP;
//         }
//      }


//      /// <summary>
//      /// The nearest point to self.
//      /// </summary>
//      /// <returns>The point.</returns>
//      /// <param name="self">Self.</param>
//      /// <param name="p1">P1.</param>
//      /// <param name="p2">P2.</param>
//      public static Vector2 NearestPoint (this Vector2 self, Vector2 p1, Vector2 p2)
//      {
//         return (self - p1).sqrMagnitude < (self - p2).sqrMagnitude ? p1 : p2;
//      }

//      /// <summary>
//      /// The nearest point to self, found along angles(lines from) source->p1 & source->p2.
//      /// Useful for cutting off the nearest passing lane.
//      /// </summary>
//      /// <returns>The nearest point.</returns>
//      /// <param name="self">Self.</param>
//      /// <param name="source">the origin of the 2 lines</param>
//      /// <param name="p1">the end point of line 1</param>
//      /// <param name="p2">the end point of line 2</param>
//      public static Vector2 NearestPointAlongAngle (this Vector2 self, Vector2 source, Vector2 p1, Vector2 p2)
//      {
//         Vector2
//         p1x = source.IntersectAtNormal( p1, self ), // x for the x of intersection
//			p2x = source.IntersectAtNormal( p2, self ),
//         p1f = source.NearestPoint( p1, p1x ),
//         p2f = source.NearestPoint( p2, p2x );

//         return self.NearestPoint(p1f, p2f);
//      }

//      #endregion


//      #region IntersectAtNormal, IntersectLineSegments

//      /// <summary>
//      /// Point along source->target, perpendicular to normIntersect
//      /// For covering source (getting the pass from target) while also perpendicular to normIntersect
//      /// </summary>
//      /// <returns>The at normal.</returns>
//      /// <param name="source">Source.</param>
//      /// <param name="target">Target.</param>
//      /// <param name="normIntersect">Norm intersect.</param>
//      public static Vector2 IntersectAtNormal (this Vector2 source, Vector2 target, Vector2 normIntersect)
//      {
//         PointAngle l1 = PointAngle.CreateFrom2Points( source, target );
//         Vector2 inverse = Vector2.Perpendicular( l1.Angle );
//         var l2 = new PointAngle( normIntersect, inverse );
//         return l1.Intersection(l2).Value;
//      }


//      /// <summary>
//      /// Intersection of lines |p1 -> p2| and |p3 -> p4|
//      /// </summary>
//      /// <param name="p1a">P1a.</param>
//      /// <param name="p1b">P1b.</param>
//      /// <param name="p2a">P2a.</param>
//      /// <param name="p2b">P2b.</param>
//      public static Vector2? IntersectLineSegments (Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4, bool extrapolate = false)
//      {
//         if (p1.x > p2.x)
//         { // reorder points left -> right
//            (p2, p1) = (p1, p2);
//         }

//         if (p3.x > p4.x)
//         { // reorder points left -> right
//            (p4, p3) = (p3, p4);
//         }

//         if (p1.x > p3.x)
//         { // reorder groups so the leftmost is the first equation
//            (p3, p1) = (p1, p3);

//            temp = p2;
//            p2 = p4;
//            p4 = temp;
//         }

//         Vector2
//         angle1 = (p2 - p1).normalized,
//         angle2 = (p4 - p3).normalized;

//         Vector2?
//         crossPoint = new PointAngle( p1, angle1 ).Intersection( new PointAngle( p3, angle2 ) );

//         if (crossPoint.HasValue)
//         {
//            Vector2 output = crossPoint.Value;
//            var valid = output.x >= p3.x && output.x <= p4.x && output.x >= p1.x && output.x <= p2.x;
//            if (extrapolate || valid)
//            {
//               return output;
//            }
//         }

//         return null;
//      }


//      #endregion


//      #region Midpoint, MeanPoint, IncenterOfPoints, CircumCenterOfPoints

//      public static Vector2 Midpoint (this Vector2 a, Vector2 b)
//      {
//         return (a + b) * .5f;
//      }

//      public static Vector2 MeanPoint (this Vector2[] points)
//      {
//         return points.Aggregate(
//            seed: new Vector2(),
//            func: (total, next) => total + next,
//            resultSelector: (total) => total / points.Count());
//      }

//      public static Vector2 IncenterOfPoints (Vector2 p1, Vector2 p2, Vector2 p3)
//      {
//         return p1.Bisector(p2, p3).Intersection(p2.Bisector(p1, p3)).Value ?.ToVector2();
//      }

//      /// <summary>
//      /// The average of all Incenters calculated.
//      /// </summary>
//      /// <returns>The of points.</returns>
//      /// <param name="points">Points.</param>
//      public static Vector2 IncenterOfPoints (this Vector2[] points)
//      {
//         var length = points.Length;
//         switch (length)
//         {
//            case 0:
//               return Vector2.zero;
//            case 1:
//               return points[0];
//            case 2:
//               return points[0].Midpoint(points[1]);
//            case 3:
//               return IncenterOfPoints(points[0], points[1], points[2]);
//            default: // gather 3 at a time the incenter of the 3 points, then take the average.
//               Vector2 output = Vector2.zero;
//               for (var i = 0; i < length; i++)
//               {
//                  output += IncenterOfPoints(points[i], points[(i + 1) % length], points[(i + 2) % length]);
//               }

//               return output * (1f / length);
//         }
//      }


//      /// <summary>
//      /// The point which is equa distance to all 3 points, they fall on the circumference of the same circle.
//      /// 
//      /// for a point P to be equal distance to both A and B, then it must fall on the line {perpendicular to dirAB, intersecting at midpoint}
//      /// therefore the circum center is the intersection of 
//      /// </summary>
//      /// <returns>The (x,y) center of points, z = radius.</returns>
//      /// <param name="p1">P1.</param>
//      /// <param name="p2">P2.</param>
//      /// <param name="p3">P3.</param>
//      public static Vector2 CircumCenterOfPoints (Vector2 p1, Vector2 p2, Vector2 p3)
//      {
//         return p1.MiddlePerpendicular(p2).Intersection(p1.MiddlePerpendicular(p3)).Value;
//      }

//      public static Vector3 CircumCenterOfPoints (this Vector2[] points)
//      {
//         var length = points.Length;
//         switch (length)
//         {
//            case 0:
//               return Vector3.zero;
//            case 1:
//               return points[0];
//            case 2:
//               Vector3 mid = points[0].Midpoint( points[1] );
//               return mid + (Vector3.forward * Vector2.Distance(mid, points[0]));
//            case 3:
//               return CircumCenterOfPoints(points[0], points[1], points[2]);
//            default: // gather 3 at a time the incenter of the 3 points, then take the average.
//               Vector2 output = Vector2.zero;
//               for (var i = 0; i < length; i++)
//               {
//                  output += CircumCenterOfPoints(points[i], points[(i + 1) % length], points[(i + 2) % length]);
//               }

//               return output * (1f / length);
//         }
//      }


//      public static PointAngle MiddlePerpendicular (this Vector2 p1, Vector2 p2)
//      {
//         return new PointAngle(p1.Midpoint(p2), (p2 - p1).RotatedRight());
//      }

//      #endregion
//   }
//}
