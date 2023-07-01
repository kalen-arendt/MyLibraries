using My.Core.Maths;

namespace My.Football.Extensions
{
   public static class TeamExtensions
   {

      public static Shape Shape<TPlayer> (this ITeam<TPlayer> team) where TPlayer : IPlayer
      {
         // TODO: implement this once a GetPosition is added somewhere to IPlayer.

         return new Shape(team.Size);
      }
   }
}
