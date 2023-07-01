namespace My.Football.Periodization
{
   public class GameMoment
   {
      public GameState State { get; private set; }
      public float Time { get; private set; }


      public GameMoment (GameState state, float time)
      {
         State = state;
         Time = time;
      }
   }
}
