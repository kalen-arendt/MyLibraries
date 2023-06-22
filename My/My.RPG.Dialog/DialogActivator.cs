using UnityEngine;
using My.Unity.Extentions.Debugging;
using My.RPG.Dialog;

namespace DialogSystem
{
    public class DialogActivator: BaseDialogActivator
	{
		[Header("Dialog")]
		[SerializeField] DialogSO dialogSO;


		private void Awake()
		{
			dialogSO.WarnIfNull($"{nameof(dialogSO)} is unassigned on {name}");
		}

		protected override void ActivateDialog()
		{
			DialogManager.Instance.SetDialog(dialogSO);
		}
	}
}