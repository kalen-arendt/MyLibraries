using UnityEngine;

namespace My.Unity.Extensions
{
   public static class Vector3Extensions
   {
      /// <summary>
      /// Volume of the Vector3.
      /// </summary>
      /// <param name="obj">Object.</param>
      public static float Volume (this Vector3 obj)
      {
         return obj.x * obj.y * obj.z;
      }
   }
}
