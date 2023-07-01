namespace My.Core.Maths.Encoders
{
   public class MatchingEncoder : IEncoder<IndexMatching, long>
   {
      private const int BITS_PER_INDEX = 4;
      private const int BIT_MASK = 0b1111;

      public long Encode (IndexMatching value)
      {
         long encoding = 0;

         var size = value.Length;

         encoding |= (uint)size;

         for (var i = 0; i < size; i++)
         {
            encoding |= (long)(value[i] & BIT_MASK) << (i * BITS_PER_INDEX);
         }

         return encoding;
      }

      public IndexMatching Decode (long encoding)
      {
         var size = (int)(encoding & BIT_MASK);
         var matching = new int[size];

         for (var i = 0; i < size; i++)
         {
            matching[i] = (int)((encoding >> (i * BITS_PER_INDEX)) & BIT_MASK);
         }

         return new IndexMatching(matching);
      }
   }
}
