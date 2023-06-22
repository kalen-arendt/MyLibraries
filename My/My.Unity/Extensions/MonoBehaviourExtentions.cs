using My.Core.Extensions.Generic;

using UnityEngine;

namespace My.Unity.Extensions
{
	public static class MonoBehaviourExtentions
	{
		public static T NullIfDestroyed<T>(this T t)
			where T : Object
		{
			return t.Coalesce(null);
		}

		/// <summary>
		/// If <paramref name="t"/> is null, sets t = <paramref name="valueIfNull"/>  
		/// </summary>
		/// <returns><paramref name="t"/></returns>
		public static T Coalesce<T>(this T t, T valueIfNull)
			where T : class
		{
			return t is Object
				? t.IfNull(() => t = valueIfNull)
				: (t ??= valueIfNull);
		}
	}
}
