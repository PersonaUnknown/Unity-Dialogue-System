using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogueSystem
{
    public class DialogueSystemController : MonoBehaviour
    {
        // Outlets
        [SerializeField] private DialogueUIController uiController;
        [SerializeField] DialogueSource speaker;

        // Behavior
        public bool isActive;

        // Methods        
        public DialogueSource GetSpeaker()
        {
            return speaker;
        }

        public bool CanUpdateDialogue()
        {
            return uiController.IsReady();
        }

        public void StartDialogue(DialogueSource source)
        {
            // Enable all sub-components of system
            uiController.Setup(source.useName);
            uiController.Show();

            // Set new speaker
            speaker = source;
            isActive = true;
        }

        public void FastUpdateDialogue(string line)
        {
            // Quickly update all sub-components
            uiController.FastUpdateUI(line);
        }

        public void UpdateDialogue(string line)
        {
            // Update all sub-components of system
            uiController.UpdateUI(line);
        }

        public void UpdateDialogue(string line, string speaker)
        {
            // Update all sub-components of system
            uiController.UpdateUI(line, speaker);
        }

        public void EndDialogue()
        {
            // Hide all sub-components of system
            uiController.Hide();

            // Remove speaker
            speaker = null;
            isActive = false;
        }
    }
}
