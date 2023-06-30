using System;

namespace My.Core.Maths
{
   public readonly struct Point : IEquatable<Point>
   {
      public static Point Zero => new Point(0, 0);

      public float X { get; }
      public float Y { get; }


      /// <summary>
      /// Create a new Position
      /// </summary>
      /// <param name="x"></param>
      /// <param name="y"></param>
      public Point (float x, float y)
      {
         X = x;
         Y = y;
      }


      /// <summary>
      /// The sqr magnitude of the Point treated as a vector.
      /// </summary>
      public readonly float SqrMagnitude ()
      {
         return (X * X) + (Y * Y);
      }


      public static float SqrMagnitude (Point p1, Point p2)
      {
         return (p1 - p2).SqrMagnitude();
      }

      public static double Distance (Point a, Point b)
      {
         return Math.Sqrt((a - b).SqrMagnitude());
      }


      #region Overrides			--------------------------------------------------

      public override string ToString ()
      {
         return string.Format("({0},{1})", X, Y);
      }

      public override bool Equals (object obj)
      {
         return obj is Point position && Equals(position);
      }

      public bool Equals (Point other)
      {
         return X == other.X && Y == other.Y;
      }

      public override int GetHashCode ()
      {
         return HashCode.Combine(X, Y);
      }

      #endregion


      #region Operators			--------------------------------------------------

      //public static implicit operator Point (Vector2 v)
      //{
      //   return new Point(v.x, v.y);
      //}

      //public static implicit operator Vector2 (Point p)
      //{
      //   return new Vector2(p.X, p.Y);
      //}

      //public static implicit operator Point (Vector2Int v)
      //{
      //   return new Point(v.x, v.y);
      //}

      //public static implicit operator Vector2Int (Point p)
      //{
      //   return new Vector2Int((int)p.X, (int)p.Y);
      //}

      //public static implicit operator Point (Vector3 v)
      //{
      //   return new Point(v.x, v.y);
      //}

      //public static implicit operator Vector3 (Point p)
      //{
      //   return new Vector2(p.X, p.Y);
      //}

      public static bool operator == (Point left, Point right)
      {
         return left.Equals(right);
      }

      public static bool operator != (Point left, Point right)
      {
         return !(left == right);
      }

      public static Point operator + (Point a, Point b)
      {
         return new Point(a.X + b.X, a.Y + b.Y);
      }

      //public static Point operator + (Point a, Vector2 b)
      //{
      //   return a + (Point)b;
      //}

      //public static Point operator + (Vector2 a, Point b)
      //{
      //   return b + a;
      //}

      public static Point operator - (Point left, Point right)
      {
         return left + -right;
      }

      public static Point operator - (Point unary)
      {
         return new Point(-unary.X, -unary.Y);
      }

      public static Point operator * (float left, Point right)
      {
         return new Point(left * right.X, left * right.Y);
      }

      public static Point operator * (Point left, float right)
      {
         return right * left;
      }

      public static Point operator * (int left, Point right)
      {
         return new Point(left * right.X, left * right.Y);
      }

      public static Point operator * (Point left, int right)
      {
         return right * left;
      }

      public static Point operator * (Point left, Point right)
      {
         return new Point(left.X * right.X, left.Y * right.Y);
      }

      public static Point operator / (Point left, float right)
      {
         return new Point(left.X / right, left.Y / right);
      }

      public static Point operator / (Point left, Point right)
      {
         return new Point(left.X / right.X, left.Y / right.Y);
      }


      #endregion
   }
}

