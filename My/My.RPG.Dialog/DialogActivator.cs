using My.Unity.Extensions.Debugging;

using UnityEngine;

namespace My.RPG.Dialog
{
   public class DialogActivator : BaseDialogActivator
   {
      [Header("Dialog")]
      [SerializeField] private DialogSO dialogSO;


      private void Awake ()
      {
         dialogSO.WarnIfNull($"{nameof(dialogSO)} is unassigned on {name}");
      }

      protected override void ActivateDialog ()
      {
         DialogManager.Instance.SetDialog(dialogSO);
      }
   }
}