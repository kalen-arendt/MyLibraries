//using My.Core.Maths;
//using My.Core.Maths.Matrices;

//namespace My.Unity.Maths
//{
//   public readonly struct PointAngle
//   {
//      public Point Point { get; }
//      public Point Angle { get; }


//      public PointAngle (Point point, Point angle)
//      {
//         Point = point;
//         Angle = angle;
//      }

//      public static PointAngle CreateFrom2Points (Point from, Point to)
//      {
//         return new PointAngle(from, to - from);
//      }



//      public static float Slope (Point from, Point to)
//      {
//         return (from.Y - to.Y) / (from.X - to.X);
//      }


//      public Point? Intersection (PointAngle other)
//      {
//         var matrix = new FloatMatrix2x2( Angle, other.Angle );
//         return matrix.IntersectionGivenCVector(new Point(Point.Y, other.Point.Y));
//      }
//   }
//}
