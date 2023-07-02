namespace My.Core.Patterns
{
   public interface IReversibleAction
   {
      void Redo ();
      void Undo ();
   }
}
