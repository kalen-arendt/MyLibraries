using System;

namespace My.Football.Whiteboard.Drawable
{
   /// <summary>
   /// Used to draw poly shapes (polygon, polyline)
   /// defined by multiple points.
   /// 
   /// The drawing pattern is:
   /// - click (multiple)
   /// - enter:finalize
   /// </summary>
   public class DrawPoly
   {
      private readonly IPolyDrawer drawer;
      private IWhiteboardEventListener eventBroadcaster;

      public DrawPoly (IPolyDrawer drawer)
      {
         this.drawer = drawer;
      }

      public void Enable (IWhiteboardEventListener eventBroadcaster)
      {
         this.eventBroadcaster = eventBroadcaster ?? throw new ArgumentNullException(nameof(eventBroadcaster));

         eventBroadcaster.OnMouseDown += drawer.AddPoint;
         eventBroadcaster.OnEnter += drawer.Finish;
      }

      public void Disable ()
      {
         eventBroadcaster.OnMouseDown -= drawer.AddPoint;
         eventBroadcaster.OnEnter -= drawer.Finish;
      }
   }
}
