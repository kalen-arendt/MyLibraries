//using UnityEngine;

//namespace My.Unity.Maths
//{
//   public static class MathExtentions
//   {
//      //#region Vector2: TurnVector, SetLength, LeftToRight, Area, SumSqrs, Direction, Perpendicular

//      //public static Point PositionAsBasisVector( this Point inDirection, float forward, float right )
//      //	=> (forward * inDirection) + (right * inDirection.RotatedRight());

//      //public static Point PositionAsBasisVector( this Point self, Point scale )
//      //	=> self * scale.Y + self.RotatedRight() * scale.X;

//      //public static Point LerpTowards( this Point self, Point other, float t )
//      //	=> Vector2.Lerp( self, other, t );


//      ///// <summary>
//      ///// Resizes the vector to any length
//      ///// </summary>
//      ///// <param name="input">Input.</param>
//      ///// <param name="length">Length.</param>
//      //public static Point SetLength( this Point input, float length ) => input.normalized * length;


//      ///// <summary>
//      ///// The angle of this vector from left to right (-x -> +x)
//      ///// </summary>
//      ///// <param name="input">Input.</param>
//      //public static void LeftToRight( this Point input ) {
//      //	if ( input.X < 0 )
//      //		input = (-1) * input;
//      //}


//      ///// <summary>
//      ///// Returns the area of the vector2 as a rectangle
//      ///// </summary>
//      ///// <param name="obj">Object.</param>
//      //public static float Area( this Point obj ) => (obj.X * obj.Y).Abs();


//      ///// <summary>
//      ///// The sum of the square of each component
//      ///// </summary>
//      ///// <returns>The sum.</returns>
//      ///// <param name="obj">Object.</param>
//      //public static float SumSqrs( this Point obj ) => obj.X.Sqr() + obj.Y.Sqr();

//      ////	public static Vector2 RightAngleTo (this Vector2 a, Vector2 b) {
//      ////		return a.AngleTo(b).RotatedRight();
//      ////	}

//      ///// <summary>
//      ///// Returns the angle in radians.
//      ///// </summary>
//      ///// <param name="v">V.</param>
//      //public static float Angle( this Point v ) => Mathf.Atan2( v.Y, v.X );

//      //public static Point AngleTo( this Point a, Point b ) => b - a;

//      //public static Point NormDirection( this Point a, Point b ) => a.AngleTo( b ).normalized;


//      //public static Point RotatedRight( this Point a ) => new Point( a.Y, -a.X );

//      //// return is normalized since Direction normalizes.
//      //public static Point RightOfVectorTo( this Point aa, Point bb ) => aa.NormDirection( bb ).RotatedRight();

//      //public static float Distance( this Point a, Point b ) => Vector2.Distance( a, b );


//      //#endregion

//      #region Vector2: TurnVector, SetLength, LeftToRight, Area, SumSqrs, Direction, Perpendicular

//      public static Vector2 PositionAsBasisVector (this Vector2 inDirection, float forward, float right)
//         => (inDirection * forward) + (inDirection.RotatedRight() * right);

//      public static Vector2 PositionAsBasisVector (this Vector2 self, Vector2 scale)
//         => (self * scale.y) + (self.RotatedRight() * scale.x);

//      public static Vector2 LerpTowards (this Vector2 self, Vector2 other, float t)
//         => Vector2.Lerp(self, other, t);


//      /// <summary>
//      /// Resizes the vector to any length
//      /// </summary>
//      /// <param name="input">Input.</param>
//      /// <param name="length">Length.</param>
//      public static Vector2 SetLength (this Vector2 input, float length) => input.normalized * length;


//      /// <summary>
//      /// The angle of this vector from left to right (-x -> +x)
//      /// </summary>
//      /// <param name="input">Input.</param>
//      public static void LeftToRight (this Vector2 input)
//      {
//         if (input.x < 0)
//            input = -1 * input;
//      }


//      /// <summary>
//      /// Returns the area of the vector2 as a rectangle
//      /// </summary>
//      /// <param name="obj">Object.</param>
//      public static float Area (this Vector2 obj) => (obj.x * obj.y).Abs();



//      //	public static Vector2 RightAngleTo (this Vector2 a, Vector2 b) {
//      //		return a.AngleTo(b).RotatedRight();
//      //	}

//      /// <summary>
//      /// Returns the angle in radians.
//      /// </summary>
//      /// <param name="v">V.</param>
//      public static float Angle (this Vector2 v) => Mathf.Atan2(v.y, v.x);

//      public static Vector2 AngleTo (this Vector2 a, Vector2 b) => b - a;

//      public static Vector2 NormDirection (this Vector2 a, Vector2 b) => a.AngleTo(b).normalized;


//      public static Vector2 RotatedRight (this Vector2 a) => new Vector2(a.y, -a.x);

//      // return is normalized since Direction normalizes.
//      public static Vector2 RightOfVectorTo (this Vector2 aa, Vector2 bb) => aa.NormDirection(bb).RotatedRight();

//      public static float Distance (this Vector2 a, Vector2 b) => Vector2.Distance(a, b);


//      #endregion
//   }
//}
