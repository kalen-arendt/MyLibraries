using System.Linq;

namespace My.Core.Maths.Encoders
{
   public class ShapeEncoder<TPointEncoding> : IEncoder<Shape, TPointEncoding[]>
   {
      private readonly IEncoder<Point, TPointEncoding> pointEncoder;

      public ShapeEncoder (IEncoder<Point, TPointEncoding> pointEncoder)
      {
         this.pointEncoder = pointEncoder;
      }

      public TPointEncoding[] Encode (Shape value)
      {
         return value.Positions.Select(point => pointEncoder.Encode(point)).ToArray();
      }

      public Shape Decode (TPointEncoding[] encoding)
      {
         return new Shape(encoding.Select(encoding => pointEncoder.Decode(encoding)).ToArray());
      }
   }
}
