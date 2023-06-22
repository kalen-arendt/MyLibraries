using My.Core.Singletons;
using UnityEngine;

namespace My.Unity.Singletons
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISingletonMonoBehaviour<T> : ISingleton<T>
        where T : ISingletonMonoBehaviour<T>
    {
		/// <summary>
		/// This property is inherently satisfied by all MonoBehaviours
		/// </summary>
		GameObject gameObject { get; }
    }
}