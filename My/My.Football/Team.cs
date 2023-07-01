using My.Core.Maths;

namespace My.Football
{
   public class Team<T> : ITeam<T> where T : IPlayer
   {
      // [SerializeField] 
      protected T[] players;

      public T this[int index] => players[index];

      public int Size => players.Length;


      public Shape Shape {
         get =>
            //var shape = new Shape(Size);

            //for (var i = 0; i < Size; i++)
            //{
            //   shape[i] = this[i].Position;
            //}

            null;
         set {
            //if (value.Complexity != Size)
            //{
            //   throw new System.ArgumentException("Shape must be same size as Team!");
            //}

            //for (var i = 0; i < players.Length; i++)
            //{
            //   players[i].Position = value.Positions[i];
            //}
         }
      }

      public Team (T[] players)
      {
         this.players = players;
      }
   }
}
