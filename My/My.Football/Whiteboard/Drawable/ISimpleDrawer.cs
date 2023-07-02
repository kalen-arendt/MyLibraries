using My.Core.Maths;

namespace My.Football.Whiteboard
{
   public interface ISimpleDrawer
   {
      void Start (Point p);
      void Update (Point p);
      void Finish (Point p);
   }
}
