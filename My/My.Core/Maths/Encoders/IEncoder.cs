namespace My.Core.Maths.Encoders
{
   public interface IEncoder<TObj, TEncoding>
   {
      TEncoding Encode (TObj value);

      TObj Decode (TEncoding encoding);
   }
}
