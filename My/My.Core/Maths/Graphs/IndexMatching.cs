using System;
using System.Collections.Generic;
using System.Linq;

using My.Core.Extensions.Numerics;

namespace My.Core.Maths
{
   /// <summary>
   /// Map player indices to instruction/position indices
   /// Array positions are player indices, array values are mapped indices.
   /// </summary>
   public class IndexMatching : IEquatable<IndexMatching>
   {
      private int[] matching;

      public int this[int i] {
         get => matching[i];
         set => matching[i] = value;
      }

      public int[] IndexMap {
         get => matching;
         set {
            matching = new int[value.Length];
            for (var i = 1; i < value.Length; i++)
            {
               this[i] = value[i];
            }
         }
      }

      public int Length => matching.Length;

      public static int Size { get; set; } = 11;




      public IndexMatching (int size)
      {
         matching = new int[size];
         Reset();
      }

      public IndexMatching (int[] matching) : this(matching.Length)
      {
         Set(matching);
      }

      public IndexMatching (IEnumerable<int> matching)
      {
         this.matching = matching.ToArray();
      }





      public void Set (int[] shift)
      {
         matching = shift;
      }

      /// <summary>
      /// Reset the ShiftMap to defualt
      /// </summary>
      public void Reset ()
      {
         Length.Iterate(i => matching[i] = i);
      }

      public void Empty ()
      {
         for (var i = 0; i < Length; i++)
         {
            this[i] = 0;
         }
      }

      public void Randomize ()
      {
         this[0] = 0;
         var r = new System.Random();

         List<int> list = IndexList.CreateOrderedList( Length );
         int index;

         for (var i = 1; i < Length; i++)
         {
            index = r.Next() % list.Count;
            this[i] = list[index];
            list.RemoveAt(index);
         }
      }



      #region Static Methods: CalculateAssignment( Shape a, Shape b ); Random(); Map( ShiftMap a, ShiftMap b );


      public static IndexMatching Random (int size)
      {
         var shift = new IndexMatching( size );
         shift.Randomize();
         return shift;
      }

      public static IndexMatching Map (IndexMatching a, IndexMatching b)
      {
         if (a == null)
         {
            throw new ArgumentNullException(nameof(a));
         }

         if (b == null)
         {
            throw new ArgumentNullException(nameof(b));
         }

         if (a.Length != b.Length)
         {
            throw new InvalidOperationException("a.Length != b.Length");
         }

         var output = new IndexMatching( a.Length );

         for (var i = 1; i < a.Length; i++)
         {
            output[i] = b[a[i]];
         }

         return output;
      }

      #endregion


      #region Overrides			--------------------------------------------------
      public override string ToString ()
      {
         var str = "";

         for (var i = 0; i < matching.Length; i++)
         {
            str += i + "->" + matching[i] + '\n';
         }

         return str;
      }


      public override bool Equals (object obj)
      {
         return Equals(obj as IndexMatching);
      }

      public bool Equals (IndexMatching other)
      {
         return other != null
               && EqualityComparer<int[]>.Default.Equals(matching, other.matching)
               && EqualityComparer<int[]>.Default.Equals(IndexMap, other.IndexMap)
               && Length == other.Length;
      }

      public override int GetHashCode ()
      {
         return HashCode.Combine(matching, IndexMap, Length);
      }

      public static bool operator == (IndexMatching left, IndexMatching right)
      {
         return EqualityComparer<IndexMatching>.Default.Equals(left, right);
      }

      public static bool operator != (IndexMatching left, IndexMatching right)
      {
         return !(left == right);
      }

      public static IndexMatching operator * (IndexMatching left, IndexMatching right)
      {
         return left == null || right == null || left.Length != right.Length
            ? null
            : new IndexMatching(left.Length.Iterate(i => right[left[i]]));
      }

      #endregion
   }

   public static class IndexList
   {
      /// <summary>
      /// Return a <see cref="List{int}"/> with values [1,10] :: [0,10]-keeper
      /// </summary>
      /// <returns></returns>
      public static List<int> CreateOrderedList (int size)
      {
         var list = new List<int>();
         for (var i = 1; i < size; i++)
         {
            list.Add(i);
         }

         return list;
      }
   }
}