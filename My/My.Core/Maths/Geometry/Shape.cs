using System;
using System.Collections.Generic;

namespace My.Core.Maths
{
   public class Shape : IEquatable<Shape>
   {
      private Point[] positions;

      public int Size => positions.Length;

      public Point this[int i] {
         get => positions[i];
         set => positions[i] = value;
      }

      public Point[] Positions {
         get => positions;
         set {
            positions = new Point[value.Length];
            for (var i = 0; i < value.Length; i++)
            {
               this[i] = value[i];
            }
         }
      }

      public Shape (int size)
      {
         positions = new Point[size];
      }

      public Shape (Point[] positions) : this(positions.Length)
      {
         Positions = positions;
      }

      public override string ToString ()
      {
         var str = "{\n";

         for (var i = 0; i < Size; i++)
         {
            str += '\t' + i + ':' + positions[i].ToString() + '\n';
         }

         return str + '}';
      }

      public override bool Equals (object obj)
      {
         return Equals(obj as Shape);
      }

      public bool Equals (Shape other)
      {
         return other != null
               && EqualityComparer<Point[]>.Default.Equals(positions, other.positions);
      }

      public override int GetHashCode ()
      {
         return -1378504013 + EqualityComparer<Point[]>.Default.GetHashCode(positions);
      }

      public static bool operator == (Shape left, Shape right)
      {
         return EqualityComparer<Shape>.Default.Equals(left, right);
      }

      public static bool operator != (Shape left, Shape right)
      {
         return !(left == right);
      }
   }
}