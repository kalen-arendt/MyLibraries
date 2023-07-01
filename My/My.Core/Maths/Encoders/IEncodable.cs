namespace My.Core.Maths.Encoders
{
   /// <summary>
   /// This interface agrees to implement: <br></br>
   /// <see cref="Encode"/> and <br></br>
   /// <see cref="Decode(T)"/>
   /// </summary>
   /// <typeparam name="T">The (primitive) Type to store the encoding</typeparam>
   public interface IEncodable<T>
   {
      /// <summary>
      /// Encode an object's data, in a <typeparamref name="T"/>
      /// </summary>
      /// <returns>the encoding of this</returns>
      T Encode ();


      /// <summary>
      /// Load an object's data, by decoding <paramref name="encoding"/>.
      /// </summary>
      /// <param name="encoding"></param>
      void Decode (T encoding);
   }
}
