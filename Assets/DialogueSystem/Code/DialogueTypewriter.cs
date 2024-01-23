using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace DialogueSystem
{
    // Types out text based on a configurable type speed
    public class DialogueTypewriter : MonoBehaviour
    {
        // Configuration
        public float typingSpeed;
        public bool hasInterruptedItself;
        public bool canInterruptItself;

        // Behavior
        public bool isTyping;

        // Methods
        public void TypeLine(TMP_Text tmp, string line, bool useTypewriter)
        {
            if (isTyping) { return; }
            if (!useTypewriter)
            {
                tmp.text = line;
                return;
            }
            
            StartCoroutine(TypeLineHelper(tmp, line));
        }

        private IEnumerator TypeLineHelper(TMP_Text tmp, string line)
        {
            isTyping = true;
            var sb = new System.Text.StringBuilder();
            tmp.text = string.Empty;
            WaitForSeconds typeDelay = new(typingSpeed);
            for (int i = 0; i < line.Length; i++)
            {
                if (canInterruptItself && hasInterruptedItself)
                {
                    hasInterruptedItself = false;
                    tmp.text = line;
                    isTyping = false;
                    yield break;
                }

                sb.Append(line[i]);
                yield return typeDelay;
                tmp.text = sb.ToString();
            }

            tmp.text = line;
            isTyping = false;
        }

        public void OnInterrupt()
        {
            hasInterruptedItself = true;
        }
    }
}
