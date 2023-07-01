namespace My.Core.Singletons
{
   /// <summary>
   /// 
   /// </summary>
   public interface ISingleton<T>
        where T : ISingleton<T>
   {
      T Singleton { get; }
   }
}