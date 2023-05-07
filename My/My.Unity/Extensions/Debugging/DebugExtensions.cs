using UnityEngine;

namespace My.Unity.Extentions.Debugging
{
    public static class DebugExtensions
    {
        public static void LogIfNull(this Object obj, string log)
        {
            if (obj == null)
            {
                Debug.Log(log, obj);
            }
        }

        public static void WarnIfNull(this Object obj, string warning)
        {
            if (obj == null)
            {
                Debug.LogWarning(warning, obj);
            }
        }

        public static void ErrorIfNull(this Object obj, string error)
        {
            if (obj == null)
            {
                Debug.LogError(error, obj);
            }
        }
    }
}
