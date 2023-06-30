namespace My.Core.Maths.Calculators
{
   public static class CalculatorExtentions
   {
      public static T Subtract<T> (this ICalculator<T> c, T left, T right)
      {
         return c.Add(left, c.Negate(right));
      }
   }
}
