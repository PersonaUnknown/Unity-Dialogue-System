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
        public GameObject uiMenu;     // All UI elements associated with dialogue
        public TMP_Text dialogueText; // Main dialogue text

        // Methods
        public abstract void Show();
        public abstract void Hide();
        public abstract void FastUpdateUI(string line);
        public abstract void UpdateUI(string line);
        public abstract void UpdateUI(string line, string speaker);
        public abstract bool IsReady(); // If UI is finished updating and ready to transition
    }
}
