using System;
using System.Text;

using My.Core.Maths;
using My.Core.Maths.Encoders;
using My.Football.Periodization;

namespace My.Football.Encoders
{
   public class GameStateEncoder : IEncoder<GameState, string>
   {
      private const char SEPARATOR = ',';


      //ShapeEncoder<char> shapeEncoder;

      private readonly IEncoder<Shape, string> shapeEncoder;
      private readonly IEncoder<Point, char> pointEncoder;

      //public GameStateEncoder (ShapeEncoder<string> shapeEncoder, PointEncoder pointEncoder)
      //{
      //   this.shapeEncoder = shapeEncoder ?? throw new ArgumentNullException(nameof(shapeEncoder));
      //   this.pointEncoder = pointEncoder ?? throw new ArgumentNullException(nameof(pointEncoder));
      //}

      public GameStateEncoder (IEncoder<Shape, string> shapeEncoder, IEncoder<Point, char> pointEncoder)
      {
         this.shapeEncoder = shapeEncoder ?? throw new ArgumentNullException(nameof(shapeEncoder));
         this.pointEncoder = pointEncoder ?? throw new ArgumentNullException(nameof(pointEncoder));
      }

      public string Encode (GameState state)
      {
         return new StringBuilder()
            .Append(pointEncoder.Encode(state.BallPosition))
            .Append(SEPARATOR)
            .Append(shapeEncoder.Encode(state.Home))
            .Append(SEPARATOR)
            .Append(shapeEncoder.Encode(state.Away))
            .ToString();
      }

      public GameState Decode (string encoding)
      {
         var split = encoding.Split( SEPARATOR );

         return new GameState(
            shapeEncoder.Decode(split[1]),
            shapeEncoder.Decode(split[2]),
            pointEncoder.Decode(split[0][0])
         );
      }
   }
}
