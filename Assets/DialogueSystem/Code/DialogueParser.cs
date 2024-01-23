using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogueSystem
{
    // Parses text based on a Dicionary of special command words. 
    // Will replace each instance of a command word in a string with the corresponding value in dict.
    public class DialogueParser : MonoBehaviour
    {
        // Configuration
        public Dictionary<string, string> wordPairs;

        // Outlets
        private void Awake()
        {
            wordPairs = new();
        }

        public string ParseText(string text)
        {
            var sb = new System.Text.StringBuilder(text);
            foreach (var pair in wordPairs)
            {
                sb.Replace(pair.Key, pair.Value);
            }

            return sb.ToString();
        }
    }
}
