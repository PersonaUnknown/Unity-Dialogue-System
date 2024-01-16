using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogueSystem
{
    public class SimpleDialogueUIController : DialogueUIController
    {
        // Outlets
        [SerializeField] private DialogueSystemController system;
        public DialogueTypewriter typewriter;

        // Configuration
        public bool useTypewriter;

        // Methods
        public override void Hide()
        {
            uiMenu.SetActive(false);
        }

        public override void Show()
        {
            uiMenu.SetActive(true);
        }

        public override void FastUpdateUI(string line)
        {
            if (useTypewriter)
            {
                typewriter.OnInterrupt();
                return;
            }

            dialogueText.text = line;
        }

        public override void UpdateUI(string line)
        {
            if (useTypewriter)
            {
                StartCoroutine(typewriter.TypeLine(line, dialogueText));
            }
            else
            {
                dialogueText.text = line;
            }
        }

        public override void UpdateUI(string line, string speaker)
        {
            if (useTypewriter)
            {
                StartCoroutine(typewriter.TypeLine(line, dialogueText));
            }
            else
            {
                dialogueText.text = line;
            }
        }

        public override bool IsReady()
        {
            return !typewriter.isTyping;
        }
    }

}