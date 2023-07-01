using My.Core.Singletons;

using TMPro;

using UnityEngine;
using UnityEngine.InputSystem;

namespace My.RPG.Dialog
{
   public class DialogManager : MonoBehaviour, ISingleton<DialogManager>
   {
      [Header("Dialog")]
      [SerializeField] private GameObject dialogPanel;
      [SerializeField] private TextMeshProUGUI dialogText;

      [Header("Speaker")]
      [SerializeField] private GameObject speakerPanel;
      [SerializeField] private TextMeshProUGUI speakerText;
      private IDialogContainer currentDialog = null;
      private IMessage overrideMessage = null;

      [Min(0)] private int msgIndex = 0;
      [Min(0)] private int lineIndex = 0;

      public bool IsInputActive { get; private set; } = false;
      public bool IsOpen { get; private set; } = false;
      public DialogManager Singleton => Instance;

      public static DialogManager Instance { get; private set; }

      private void Awake ()
      {
         Instance = this;
         dialogPanel.SetActive(false);
      }

      private void OnDestroy () // this will only get called if the entire UI is destroyed
      {
         Instance = null;
      }

      private void OnSubmit (InputValue value)
      {
         if (IsInputActive)
         {
            if (!IsOpen)
            {
               Open();
            }
            else
            {
               Next();
            }
         }
      }


      #region public Methods

      public void SetDialog (IDialogContainer dialog)
      {
         IsInputActive = true;
         ClearIndices();

         currentDialog = dialog;
         overrideMessage = null;
      }

      public void SetMessage (IMessage message)
      {
         IsInputActive = true;
         ClearIndices();

         currentDialog = null;
         overrideMessage = message;
      }

      public void Open ()
      {
         if (IsInputActive || !IsOpen)
         {
            IsOpen = true;
            dialogPanel.SetActive(true);
            DisplayCurrent();
         }
      }

      public void Deactivate ()
      {
         IsInputActive = false;
         Close();
      }

      #endregion


      #region Next, Close

      private void Next ()
      {
         if (!MoveToNextLine())
         {
            if (!MoveNextMessage())
            {
               Close();
            }
         }
      }

      private void Close ()
      {
         ClearIndices();
         IsOpen = false;
         dialogPanel.SetActive(false);
      }

      private void ClearIndices ()
      {
         msgIndex = 0;
         lineIndex = 0;
      }

      #endregion


      #region Private Message Display Methods
      private bool MoveNextMessage ()
      {
         msgIndex++;
         lineIndex = 0;
         return DisplayCurrent();
      }

      private bool MoveToNextLine ()
      {
         lineIndex++;
         return DisplayCurrentLine();
      }

      private bool DisplayCurrent ()
      {
         DisplayCurrentSpeakerName();
         return DisplayCurrentLine();
      }

      private void DisplayCurrentSpeakerName ()
      {
         if (GetCurrentMessage() is IDialogMessage msg && !string.IsNullOrEmpty(msg.SpeakerName))
         {
            speakerPanel.SetActive(true);
            speakerText.text = msg.SpeakerName;
         }
         else
         {
            speakerText.text = "";
            speakerPanel.SetActive(false);
         }
      }

      private bool DisplayCurrentLine ()
      {
         var line = GetCurrentLine();
         if (line != null)
         {
            dialogText.text = line;
            return true;
         }
         else
         {
            dialogText.text = "";
            return false;
         }
      }

      private string GetCurrentLine ()
      {
         IMessage msg = GetCurrentMessage();
         return msg != null && lineIndex < msg.Length
          ? msg[lineIndex]
          : null;
      }

      private IMessage GetCurrentMessage ()
      {
         return overrideMessage ?? (
            currentDialog != null && msgIndex < currentDialog.Length
               ? currentDialog[msgIndex]
               : null
         );
      }

      #endregion
   }
}
