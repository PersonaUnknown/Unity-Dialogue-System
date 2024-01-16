using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace DialogueSystem
{
    public class DialogueTypewriter : MonoBehaviour
    {
        // Configuration
        [SerializeField] private float typeSpeed;
        [SerializeField] private bool canInterruptItself;
        public bool isTyping;
        public bool isInterrupted;

        // Methods
        public IEnumerator TypeLine(string line, TMP_Text tmp)
        {
            isTyping = true;
            var sb = new System.Text.StringBuilder();
            tmp.text = sb.ToString();

            WaitForSeconds delay = new(typeSpeed);
            for (int i = 0; i < line.Length; i++)
            {
                if (canInterruptItself && isInterrupted)
                {
                    tmp.text = line;
                    break;
                }

                sb.Append(line[i]);
                tmp.text = sb.ToString();
                yield return delay;
            }

            isTyping = false;
            isInterrupted = false;
        }

        public void OnInterrupt()
        {
            isInterrupted = true;
        }
    }
}
