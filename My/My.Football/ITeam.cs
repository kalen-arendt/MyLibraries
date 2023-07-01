using My.Core.Maths;

namespace My.Football
{
   public interface ITeam<TPlayer> where TPlayer : IPlayer
   {
      public TPlayer this[int index] { get; }
      int Size { get; }
      Shape Shape { get; set; }
   }
}
