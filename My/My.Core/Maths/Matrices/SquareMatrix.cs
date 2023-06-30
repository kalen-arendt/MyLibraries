using System;

using My.Core.Maths.Calculators;

namespace My.Core.Maths.Matrices
{
   public class SquareMatrix<T, TCalculator> : Matrix<T, TCalculator> where TCalculator : ICalculator<T>
   {

      public SquareMatrix (TCalculator calculator, int size) : base(calculator, size, size) { }

      public SquareMatrix (TCalculator calculator, T[,] matrix) : base(calculator, matrix)
      {
         if (Rows != Columns)
         {
            throw new ArgumentException();
         }
      }

      public SquareMatrix (SquareMatrix<T, TCalculator> other) : base(other) { }
   }
}
