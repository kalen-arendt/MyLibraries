namespace My.Core.Extentions.Strings
{
   public static class CoalesceStringExtensions
   {
      public static string CoalesceEmpty (this string str, string coalesce)
      {
         return string.IsNullOrEmpty(str) ? coalesce : str;
      }

      public static string CoalesceWhiteSpace (this string str, string coalesce)
      {
         return string.IsNullOrWhiteSpace(str) ? coalesce : str;
      }
   }
}
