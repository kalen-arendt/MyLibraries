namespace My.Core.Maths.Calculators
{

   public class DoubleCalculator : ICalculator<double>
   {
      public double Add (double left, double right)
      {
         return left + right;
      }

      public double Multiply (double left, double right)
      {
         return left * right;
      }

      public double Divide (double left, double right)
      {
         return left / right;
      }

      public double Negate (double t)
      {
         return -t;
      }

      public double Inverse (double t)
      {
         return 1 / t;
      }
   }
}
