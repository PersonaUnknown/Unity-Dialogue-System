using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// Template for a UI controller for basic dialogue system
namespace DialogueSystem
{
    public abstract class DialogueUIController : MonoBehaviour
    {
        // Outlets
        public GameObject uiMenu;            // All UI elements associated with dialogue
        public GameObject dialogueTextbox;   // Textbox
        public GameObject dialogueSpeaker;   // Overall Speaker Gameobject
        public TMP_Text dialogueText;        // Main dialogue text
        public TMP_Text dialogueSpeakerText; // Speaker's Name

        // Configuration
        public bool useTextbox;
        public bool useSpeakerName;

        // Methods
        public void Setup(bool useSpeakerName)
        {
            this.useSpeakerName = useSpeakerName;
        }
        public abstract void Show();
        public abstract void Hide();
        public abstract void FastUpdateUI(string line);
        public abstract void UpdateUI(string line);
        public abstract void UpdateUI(string line, string speaker);
        public abstract bool IsReady(); // If UI is finished updating and ready to transition
    }
}
