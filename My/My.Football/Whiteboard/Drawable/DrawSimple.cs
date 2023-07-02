using System;

namespace My.Football.Whiteboard
{
   /// <summary>
   /// Used to draw shapes that can be defined by 2 points, and thus drawn by
   /// a simple click, drag, release pattern.
   /// <br></br>
   /// This includes
   /// <list type="bullet">
   ///   <item>DrawCircle</item>
   ///   <item>DrawRectangle</item>
   ///   <item>DrawArrow</item>
   /// </list>
   /// </summary>
   public class DrawSimple
   {
      ISimpleDrawer drawer;
      IWhiteboardEventListener eventBroadcaster;

      public DrawSimple (ISimpleDrawer drawer)
      {
         this.drawer = drawer;
      }

      public void Enable(IWhiteboardEventListener eventBroadcaster)
      {
         this.eventBroadcaster = eventBroadcaster ?? throw new ArgumentNullException(nameof(eventBroadcaster));

         eventBroadcaster.OnMouseDown  += drawer.Start;
         eventBroadcaster.OnMouseUp    += drawer.Update;
         eventBroadcaster.OnMouseKey   += drawer.Finish;
      }

      public void Disable ()
      {
         eventBroadcaster.OnMouseDown  -= drawer.Start;
         eventBroadcaster.OnMouseUp    -= drawer.Update;
         eventBroadcaster.OnMouseKey   -= drawer.Finish;
      }
   }
}
