using System;

using My.Core.Maths;

namespace My.Football.Whiteboard
{
   /// <summary>
   /// Used to draw in a 'freehand' manner
   /// </summary>
   public class DrawFreehand
   {
      private readonly IPolyDrawer drawer;
      private IWhiteboardEventListener eventBroadcaster;

      public DrawFreehand (IPolyDrawer drawer)
      {
         this.drawer = drawer;
      }

      public void Enable (IWhiteboardEventListener eventBroadcaster)
      {
         this.eventBroadcaster = eventBroadcaster ?? throw new ArgumentNullException(nameof(eventBroadcaster));

         eventBroadcaster.OnMouseKey += drawer.AddPoint;
         eventBroadcaster.OnMouseUp += EventBroadcaster_OnMouseUp;
      }

      public void Disable ()
      {
         eventBroadcaster.OnMouseKey -= drawer.AddPoint;
         eventBroadcaster.OnMouseUp -= EventBroadcaster_OnMouseUp;
      }

      // drawer.Finish doesn't care about the position
      private void EventBroadcaster_OnMouseUp (Point obj)
      {
         drawer.Finish();
      }
   }
}
