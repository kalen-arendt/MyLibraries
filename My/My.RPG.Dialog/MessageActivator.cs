using UnityEngine;

namespace My.RPG.Dialog
{
   public class MessageActivator : BaseDialogActivator
   {
      [Header("Message")]
      [SerializeField] private Message message;

      private void Awake ()
      {
         if (message == null)
         {
            Debug.LogWarning($"{nameof(message)} is unassigned on {name}", this);
         }
      }

      protected override void ActivateDialog ()
      {
         DialogManager.Instance.SetMessage(message);
      }
   }
}