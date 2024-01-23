using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogueSystem
{
    public class LinearDialogueUIController : MonoBehaviour
    {
        // Outlets
        [SerializeField] public DialogueUIElement dialogueText;
        [SerializeField] public DialogueUIElement nameText;

        // Methods
        private void Start()
        {
            if (dialogueText)
            {
                dialogueText.Hide();
            }

            if (nameText)
            {
                nameText.Hide();
            }
        }

        public virtual void Show()
        {
            if (dialogueText)
            {
                dialogueText.Show();
            }

            if (nameText)
            {
                nameText.Show();
            }
        }

        public virtual void Hide()
        {
            if (dialogueText)
            {
                dialogueText.Hide();
            }

            if (nameText)
            {
                nameText.Hide();
            }
        }

        public virtual void UpdateUI(LinearDialogueSource speaker)
        {
            if (speaker == null)
            {
                return;
            }

            if (dialogueText)
            {
                string currLine = speaker.GetCurrLine();
                dialogueText.UpdateText(currLine);
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

        public virtual bool IsReady()
        {
            return true;
        }
    }
}
