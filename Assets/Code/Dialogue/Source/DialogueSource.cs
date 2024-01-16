using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogueSystem
{
    public class DialogueSource : MonoBehaviour
    {
        // Outlets
        [SerializeField] private DialogueSystemController system;

        // Configuration
        [SerializeField] private string[] lines;
        [SerializeField] private string sourceName;
        public bool useName;

        // Behavior
        private int _currIndex;
        public int currIndex
        {
            get 
            { 
                return _currIndex; 
            }
            set 
            { 
                _currIndex = value; 
            }
        }

        // Methods
        private void OnMouseDown()
        {
            // TODO: Do not have this behavior here. Instead, place it elsewhere for a separate NPC script to call StartConversation
            StartConversation();
        }

        public void StartConversation()
        {
            if (system == null || system.isActive) { return; }

            // Restart 
            currIndex = 0;

            // Display
            if (useName)
            {
                system.UpdateDialogue(lines[currIndex], sourceName);
            }
            else
            {
                system.UpdateDialogue(lines[currIndex]);
            }
            system.StartDialogue(this);
        }

        public void NextLine()
        {
            if (system == null || system.GetSpeaker() != this) { return; }

            if (!system.CanUpdateDialogue())
            {
                system.FastUpdateDialogue(lines[currIndex]);
                return;
            }

            currIndex++;
            if (currIndex < 0 || currIndex >= lines.Length)
            {
                system.EndDialogue();
                return;
            }

            if (useName)
            {
                system.UpdateDialogue(lines[currIndex], sourceName);
            }
            else
            {
                system.UpdateDialogue(lines[currIndex]);
            }
        }
    }
}
