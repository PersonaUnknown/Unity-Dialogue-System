using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogueSystem
{
    // UI Controller for Linear Dialogue System w/ Typewriter
    public class LinearDialogueTypewriterUIController : LinearDialogueUIController
    {
        // Outlets
        public DialogueTypewriter typewriter;

        // Configuration
        public bool useTypewriter;
        
        public override void UpdateUI(LinearDialogueSource speaker)
        {
            if (speaker == null)
            {
                return;
            }

            if (typewriter.isTyping)
            {
                typewriter.OnInterrupt();
                return;
            }

            if (dialogueText)
            {
                string currLine = speaker.GetCurrLine();
                typewriter.TypeLine(dialogueText.GetElementText(), currLine, useTypewriter);
            }

            if (nameText && speaker.useName && speaker.sourceName != "")
            {
                nameText.Show();
                nameText.UpdateText(speaker.sourceName);
            }
            else
            {
                nameText.Hide();
            }
        }

        public override bool IsReady()
        {
            return !typewriter.isTyping;
        }
    }
}
