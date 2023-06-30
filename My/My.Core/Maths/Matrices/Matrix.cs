using System;

using My.Core.Maths.Calculators;

namespace My.Core.Maths.Matrices
{
   public class Matrix<T, TCalculator> where TCalculator : ICalculator<T>
   {
      public static T Determinant (TCalculator calc, T x1, T x2, T y1, T y2)
      {
         return calc.Subtract(calc.Multiply(x1, y2), calc.Multiply(x2, y1));
      }

      private readonly T[,] matrix;
      protected readonly TCalculator calculator;


      public T this[int c, int r] {
         get => matrix[c, r];
         protected set => matrix[c, r] = value;
      }

      public int Rows => matrix.GetLength(1);
      public int Columns => matrix.GetLength(2);



      public Matrix (TCalculator calculator, int rows, int cols)
      {
         matrix
            = rows > 0 && cols > 0
            ? new T[rows, cols]
            : throw new ArgumentOutOfRangeException(nameof(calculator));

         this.calculator = calculator ?? throw new ArgumentNullException(nameof(calculator));
      }

      public Matrix (TCalculator calculator, T[,] matrix)
      {
         this.matrix = matrix ?? throw new ArgumentNullException(nameof(matrix));
         this.calculator = calculator ?? throw new ArgumentNullException(nameof(calculator));
      }

      public Matrix (Matrix<T, TCalculator> other)
      {
         if (calculator == null) // UHH I'm pretty sure calculator will always be null as its uninitialized...
         {
            throw new ArgumentNullException(nameof(calculator));
         }

         if (other == null)
         {
            throw new ArgumentNullException(nameof(other));
         }

         calculator = other.calculator;
         matrix = new T[other.Rows, other.Columns];

         for (var i = 0; i < Rows; i++)
         {
            for (var j = 0; j < Columns; j++)
            {
               this[i, j] = other[i, j];
            }
         }
      }


      public Matrix<T, TCalculator> Transpose ()
      {
         var result = new Matrix<T, TCalculator>( calculator, Columns, Rows );

         for (var i = 0; i < Rows; i++)
         {
            for (var j = 0; j < Columns; j++)
            {
               result[j, i] = this[i, j];
            }
         }

         return result;
      }

      public Matrix<T, TCalculator> Scaled (T scale)
      {
         var result = new Matrix<T, TCalculator>( calculator, Rows, Columns );

         for (var i = 0; i < Rows; i++)
         {
            for (var j = 0; j < Columns; j++)
            {
               result[i, j] = calculator.Multiply(this[i, j], scale);
            }
         }

         return result;
      }

      public T Trace ()
      {
         T trace = default;
         var k = Math.Min( Rows, Columns );

         for (var i = 0; i < k; i++)
         {
            trace = calculator.Add(trace, this[i, i]);
         }

         return trace;
      }


      #region -Operators			--------------------------------------------------

      public static Matrix<T, TCalculator> operator + (Matrix<T, TCalculator> left, Matrix<T, TCalculator> right)
      {
         if (left.Rows != right.Rows || left.Columns != right.Columns)
         {
            throw new ArgumentException("The dimentions of Matrices must be equal to +");
         }

         var result = new Matrix<T, TCalculator>( left.calculator, left.Rows, left.Columns );

         for (var i = 0; i < left.Rows; i++)
         {
            for (var j = 0; j < left.Columns; j++)
            {
               result[i, j] = left.calculator.Add(left[i, j], right[i, j]);
            }
         }

         return result;
      }

      public static Matrix<T, TCalculator> operator - (Matrix<T, TCalculator> left, Matrix<T, TCalculator> right)
      {
         if (left.Rows != right.Rows || left.Columns != right.Columns)
         {
            throw new ArgumentException("The dimentions of Matrices must be equal to -");
         }

         var result = new Matrix<T, TCalculator>( left.calculator, left.Rows, left.Columns );

         for (var i = 0; i < left.Rows; i++)
         {
            for (var j = 0; j < left.Columns; j++)
            {
               result[i, j] = left.calculator.Subtract(left[i, j], right[i, j]);
            }
         }

         return result;
      }

      public static Matrix<T, TCalculator> operator * (Matrix<T, TCalculator> left, Matrix<T, TCalculator> right)
      {
         if (left.Columns != right.Rows)
         {
            throw new ArgumentException("left.Columns == right.Rows required to *");
         }

         var n = left.Columns;

         // YxZ*Z*W = Y*W
         var result = new Matrix<T, TCalculator>( left.calculator, left.Rows, right.Columns );

         for (var i = 0; i < left.Rows; i++)
         {
            for (var j = 0; j < left.Columns; j++)
            {
               T dotProduct = default;

               for (var k = 0; k < n; k++)
               {
                  dotProduct = left.calculator.Add(
                     dotProduct,
                     left.calculator.Multiply(
                        left[i, k],
                        right[k, j]
                     )
                  );
               }

               result[i, j] = dotProduct;
            }
         }

         return result;
      }



      #endregion
   }
}
