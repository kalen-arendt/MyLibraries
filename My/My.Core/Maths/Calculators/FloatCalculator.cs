namespace My.Core.Maths.Calculators
{
   public class FloatCalculator : ICalculator<float>
   {
      public float Add (float left, float right)
      {
         return left + right;
      }

      public float Multiply (float left, float right)
      {
         return left * right;
      }

      public float Divide (float left, float right)
      {
         return left / right;
      }

      public float Negate (float t)
      {
         return -t;
      }

      public float Inverse (float t)
      {
         return 1 / t;
      }
   }
}
