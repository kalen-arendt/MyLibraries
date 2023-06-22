using My.Core.Extensions.Generic;
using My.Core.Extentions.Strings;

using UnityEngine;

namespace My.Unity.Extentions.Debugging
{
    public static class DebugExtensions
    {
        public static bool LogIfNull<T>(this T obj, string msg) where T : Object
		{
			return obj.IfNull(() => Debug.Log(msg, obj));
        }

        public static bool WarnIfNull<T>(this T obj, string warning = null) where T : Object
        {
			return obj.IfNull(() => Debug.LogWarning(warning.CoalesceEmpty($"An Object of type `{obj.GetType().FullName}` is null."), obj));
		}

		public static bool ErrorIfNull<T>(this T obj, string error = null) where T : Object
		{
			return obj.IfNull(() => Debug.LogError(error.CoalesceEmpty($"An Object of type `{obj.GetType().FullName}` is null."), obj));
        }


		public static bool WarnIfNotFound<T>(this T obj) where T : Object
		{
			return obj.IfNull(() => Debug.LogWarning($"No Object of type `{obj.GetType().FullName}` was not found.", obj));
		}

		public static bool ErrorIfNotFound<T>(this T obj) where T : Object
		{
			return obj.IfNull(() => Debug.LogError($"No Object of type `{obj.GetType().FullName}` was not found.", obj));

		}
	}
}
