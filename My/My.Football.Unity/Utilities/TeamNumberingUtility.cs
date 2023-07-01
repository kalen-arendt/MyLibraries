using TMPro;

using UnityEngine;

namespace My.Football.Unity.Utilities
{
   public class TeamNumberingUtility : MonoBehaviour
   {
      [ContextMenu("Set Numbers")]
      private void Execute ()
      {
         var i = 1;

         foreach (Transform t in transform)
         {
            t.GetComponentInChildren<TextMeshProUGUI>().text = "" + i++;
         }
      }
   }
}
