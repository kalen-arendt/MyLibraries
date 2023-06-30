using System;

using My.Core.Maths.Calculators;

namespace My.Core.Maths.Matrices
{
   public class Matrix2x2<T, TCalculator> : SquareMatrix<T, TCalculator> where TCalculator : ICalculator<T>
   {
      /// <summary>
      /// Creates an EMPTY MATRIX
      /// </summary>
      /// <param name="calculator"></param>
      public Matrix2x2 (TCalculator calculator) : base(calculator, 2) { }

      /// <summary>
      /// Creates an INITIALIZED MATRIX
      /// </summary>
      /// <param name="calculator"></param>
      /// <param name="matrix"></param>
      public Matrix2x2 (TCalculator calculator, T[,] matrix) : base(calculator, matrix)
      {
         if (Rows != 2)
         {
            throw new ArgumentException();
         }
      }

      /// <summary>
      /// Creates a COPIED MATRIX
      /// </summary>
      /// <param name="other"></param>
      public Matrix2x2 (Matrix2x2<T, TCalculator> other) : base(other) { }

      public T Det => Determinant(
         calculator,
         this[0, 0],
         this[0, 1],
         this[1, 0],
         this[1, 1]
      );


      public Matrix2x2<T, TCalculator> Inverse ()
      {
         return new Matrix2x2<T, TCalculator>(
            calculator,
            new T[2, 2] {
               {this[1,1], calculator.Negate( this[0,1] )},
               {calculator.Negate( this[1,0] ), this[0,0]}
            }
         ).Scaled(calculator.Inverse(Det)) as Matrix2x2<T, TCalculator>;
      }
   }
}
