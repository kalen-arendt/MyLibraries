namespace My.Core.Maths.Calculators
{
   public class IntCalculator : ICalculator<int>
   {
      public int Add (int left, int right)
      {
         return left + right;
      }

      public int Multiply (int left, int right)
      {
         return left * right;
      }

      public int Divide (int left, int right)
      {
         return left / right;
      }

      public int Negate (int t)
      {
         return -t;
      }

      public int Inverse (int t)
      {
         return 1 / t;
      }
   }
}
