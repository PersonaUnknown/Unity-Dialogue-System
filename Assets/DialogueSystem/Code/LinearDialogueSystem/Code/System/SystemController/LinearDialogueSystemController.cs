using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogueSystem
{
    // Controls the various sub-components that make up a linear dialogue system
    public class LinearDialogueSystemController : MonoBehaviour
    {
        // Outlets
        public LinearDialogueSource speaker;
        public LinearDialogueUIController uiController;
        public LinearDialogueAudioController audioController;

        // Configuration
        public bool isActive { get; private set; }

        // Methods
        public void StartConversation(LinearDialogueSource speaker)
        {
            if (isActive || this.speaker != null) { return; }

            // System is now active
            this.speaker = speaker;
            this.speaker.ResetDialogue();
            isActive = true;

            // Show and update sub-components
            uiController.Show();
            uiController.UpdateUI(this.speaker);
            audioController.OnReset();
            audioController.UpdateAudio(this.speaker);
        }

        public bool CanProgressConversation()
        {
            return uiController.IsReady();
        }

        public virtual void ProgressConversation()
        {
            if (!isActive || speaker == null || !CanProgressConversation()) { return; }
            
            // Update dialogue
            speaker.NextLine();

            // Update sub-components
            uiController.UpdateUI(speaker);
            audioController.UpdateAudio(speaker);
        }

        public void EndConversation()
        {
            // Update sub-components
            uiController.Hide();

            // Remove speaker
            speaker = null;

            // Finish
            isActive = false;
        }
    }
}
