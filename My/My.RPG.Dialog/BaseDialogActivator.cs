using My.Core.Extentions.Strings;

using UnityEngine;

namespace My.RPG.Dialog
{
   [RequireComponent(typeof(Collider2D))]
   public abstract class BaseDialogActivator : MonoBehaviour
   {
      [Header("Interaction")]
      [SerializeField] protected string activationTag = "";
      [SerializeField] protected bool autoActivate = true;
      [SerializeField] protected GameObject actionIcon;

      protected const string DEFAULT_ACTIVATION_TAG = "Player";

      private void Awake ()
      {
         activationTag = activationTag.CoalesceEmpty(DEFAULT_ACTIVATION_TAG);
      }

      private void Start ()
      {
         SetIconActive(false);
      }

      protected abstract void ActivateDialog ();

      private void OnTriggerEnter2D (Collider2D other)
      {
         if (other.CompareTag(activationTag))
         {
            SetIconActive(true);
            ActivateDialog();

            if (autoActivate)
            {
               DialogManager.Instance.Open();
            }
         }
      }

      private void OnTriggerExit2D (Collider2D other)
      {
         if (other.CompareTag(activationTag))
         {
            SetIconActive(false);
            DialogManager.Instance.Deactivate();
         }
      }

      protected void SetIconActive (bool active)
      {
         actionIcon?.SetActive(active);
      }
   }
}