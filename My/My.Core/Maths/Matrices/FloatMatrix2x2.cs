using My.Core.Maths.Calculators;

namespace My.Core.Maths.Matrices
{
   public class FloatMatrix2x2 : Matrix2x2<float, FloatCalculator>
   {
      /// <summary>
      /// Creates an EMPTY MATRIX
      /// </summary>
      /// <param name="calculator"></param>
      public FloatMatrix2x2 () : base(new FloatCalculator()) { }

      /// <summary>
      /// Creates an INITIALIZED MATRIX
      /// </summary>
      /// <param name="calculator"></param>
      /// <param name="matrix"></param>
      public FloatMatrix2x2 (float[,] matrix) : base(new FloatCalculator(), matrix) { }

      /// <summary>
      /// Create a new Matrix2x2 {
      ///	{ a.x, b.x }
      ///	{ a.y, b.y }
      /// }
      /// </summary>
      /// <param name="a"></param>
      /// <param name="b"></param>
      /// <returns></returns>
      public FloatMatrix2x2 (Point a, Point b)
         : base(new FloatCalculator(), new float[,] { { a.X, b.X }, { a.Y, b.Y } }) { }



      public Point? IntersectionGivenCVector (Point c)
      {
         var d = Det;
         return d == 0
               ? null
               : (Point?)new Point(
                  x: (this[1, 1] * c.X) - (this[0, 1] * c.Y),
                  y: (this[0, 0] * c.Y) - (this[1, 0] * c.X)
               ) / d;
      }
   }
}
