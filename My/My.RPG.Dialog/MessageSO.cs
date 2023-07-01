﻿using UnityEngine;


namespace My.RPG.Dialog
{
   [CreateAssetMenu(menuName = "DialogSO", fileName = "DialogSO")]
   public class MessageSO : ScriptableObject, IMessage
   {
      [SerializeField] private Message message;

      public string this[int msgIndex] => Message[msgIndex];

      public IMessage Message => message;
      public int Length => Message.Length;
      public string[] GetMessages ()
      {
         return Message.GetMessages();
      }
   }
}
