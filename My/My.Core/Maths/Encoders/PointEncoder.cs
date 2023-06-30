namespace My.Core.Maths.Encoders
{
   public class PointEncoder : IEncoder<Point, char>
   {
      public char Encode (Point value)
      {
         return (char)(((int)(value.X * 2) << 8) | (int)(value.Y * 2));
      }

      public Point Decode (char encoding)
      {
         return new Point(
            ((encoding >> 8) & 0xF) / 2f,
            (encoding & 0xF) / 2f
         );
      }
   }
}
