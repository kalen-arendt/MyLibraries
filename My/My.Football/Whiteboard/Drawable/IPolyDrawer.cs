using My.Core.Maths;

namespace My.Football.Whiteboard
{
   public interface IPolyDrawer
   {
      void AddPoint (Point point);
      void Finish ();
   }
}
