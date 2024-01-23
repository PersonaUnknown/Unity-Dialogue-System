using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogueSystem
{
    // Intended for objects with basic dialogue 
    public class LinearDialogueSource : MonoBehaviour
    {
        // Outlets
        [SerializeField] private LinearDialogueSystemController systemController;

        // Configuration
        public string[] linesOfDialogue;
        public string sourceName;
        public bool useName;
        public AudioClip[] linesOfDialogueAudio;
        public bool useAudioArray;               

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
                _currIndex = Mathf.Clamp(value, 0, linesOfDialogue.Length - 1);
            }
        }

        // Methods
        private void Start()
        {
            currIndex = 0;
        }

        public void StartConversation()
        {
            systemController.StartConversation(this);
        }

        public void ResetDialogue()
        {
            currIndex = 0;
        }

        public void NextLine()
        {
            if (currIndex >= linesOfDialogue.Length - 1)
            {
                systemController.EndConversation();
                return;
            }

            currIndex++;
        }

        public string GetCurrLine()
        {
            return linesOfDialogue[currIndex];
        }

        public AudioClip GetCurrAudioLine()
        {
            if (linesOfDialogueAudio == null || linesOfDialogueAudio.Length <= 0)
            {
                return null;
            }

            return useAudioArray && currIndex < linesOfDialogueAudio.Length? linesOfDialogueAudio[currIndex] : linesOfDialogueAudio[0];
        }
    }
}
