using System;

using My.Core.Maths;

namespace My.Football.Whiteboard
{
   public interface IWhiteboardEventListener
   {
      event Action<Point> OnMouseDown;
      event Action<Point> OnMousePressed;
      event Action<Point> OnMouseDrag;
      event Action<Point> OnMouseUp;

      event Action<Point> OnPlayerSelected;
      event Action<Point> OnPlayerDragged;
   }
}
