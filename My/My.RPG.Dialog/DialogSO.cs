using UnityEngine;


namespace My.RPG.Dialog
{
   [CreateAssetMenu(menuName = "DialogSO", fileName = "DialogSO")]
   public class DialogSO : ScriptableObject, IDialogContainer
   {
      [SerializeField] private DialogContainer dialog;

      public int Length => Dialog.Length;
      public IDialogMessage this[int dialogIndex] => Dialog[dialogIndex];
      public IDialogMessage[] GetDialog ()
      {
         return Dialog.GetDialog();
      }

      private IDialogContainer Dialog => dialog;
   }
}
