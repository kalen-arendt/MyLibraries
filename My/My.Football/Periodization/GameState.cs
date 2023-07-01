using System;
using System.Collections.Generic;

using My.Core.Maths;

namespace My.Football.Periodization
{
   public readonly struct GameState : IEquatable<GameState>
   {
      public Shape Home { get; }
      public Shape Away { get; }
      public Point BallPosition { get; }


      public GameState (Shape home, Shape away, Point ballPos)
      {
         Home = home ?? throw new ArgumentNullException(nameof(home));
         Away = away ?? throw new ArgumentNullException(nameof(away));
         BallPosition = ballPos != null ? ballPos : throw new ArgumentNullException(nameof(ballPos));
      }

      public override string ToString ()
      {
         return nameof(GameState) + ":{\n" +
                  "ball:" + BallPosition.ToString() + '\n' +
                  "home:" + Home.ToString() + '\n' +
                  "away:" + Away.ToString() + "\n}";
      }

      public override bool Equals (object obj)
      {
         return obj is GameState state &&
                EqualityComparer<Shape>.Default.Equals(Home, state.Home) &&
                EqualityComparer<Shape>.Default.Equals(Away, state.Away) &&
                BallPosition.Equals(state.BallPosition);
      }

      public override int GetHashCode ()
      {
         return HashCode.Combine(Home, Away, BallPosition);
      }

      public bool Equals (GameState other)
      {
         return other != null
               && EqualityComparer<Shape>.Default.Equals(Home, other.Home)
               && EqualityComparer<Shape>.Default.Equals(Away, other.Away)
               && BallPosition.Equals(other.BallPosition);
      }

      public static bool operator == (GameState left, GameState right)
      {
         return EqualityComparer<GameState>.Default.Equals(left, right);
      }

      public static bool operator != (GameState left, GameState right)
      {
         return !(left == right);
      }
   }
}
