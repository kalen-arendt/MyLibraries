namespace My.Core.Maths.Calculators
{
   public interface ICalculator<T>
   {
      T Add (T left, T right);
      T Multiply (T left, T right);
      T Divide (T left, T right);
      T Negate (T t);
      T Inverse (T t);
   }
}
