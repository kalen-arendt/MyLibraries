namespace My.Core.Maths.Graphs
{
   public class MinimalShift
   {
      public static IndexMatching FindMinimalMatching (Shape a, Shape b)
      {
         return new IndexMatching(new HungarianAlgorithm(new CrossDistanceMatrix(a, b).Get()).Run());
      }
   }
}
