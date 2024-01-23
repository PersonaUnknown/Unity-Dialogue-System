using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogueSystem
{
    // Specific dialogue system controller for typewriter add-on
    public class LinearDialogueSystemTypewriterController : LinearDialogueSystemController
    {
        public override void ProgressConversation()
        {
            if (!CanProgressConversation())
            {
                uiController.UpdateUI(speaker);
                return;
            }
                
            base.ProgressConversation();
        }
    }
}
