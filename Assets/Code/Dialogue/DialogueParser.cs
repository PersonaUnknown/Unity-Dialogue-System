using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
namespace DialogueSystem
{
    public class DialogueParser : MonoBehaviour
    {
        // Outlets
        public static DialogueParser instance;

        // Configuration
        private Dictionary<string, string> commandPairs;

        // Methods
        private void Awake()
        {
            instance = this;
            commandPairs = new();
        }
        public string ParseText(string text)
        {
            var sb = new System.Text.StringBuilder(text);
            foreach (var pair in commandPairs)
            {
                sb.Replace(pair.Key, pair.Value);
            }
            return sb.ToString();
        }
        public void AddPair(string key, string value)
        {
            if (commandPairs.ContainsKey(key))
            {
                commandPairs.Remove(key);
            }
            commandPairs.Add(key, value);
        }
        
        // Debug / Testing Methods (Do Not Use)
        public string ParseTextConcat(string text)
        {
            foreach (var pair in commandPairs)
            {
                text.Replace(pair.Key, pair.Value);
            }
            return text;
        }
        public string ParseTextSB(string text)
        {
            var sb = new System.Text.StringBuilder(text);
            foreach (var pair in commandPairs)
            {
                sb.Replace(pair.Key, pair.Value);
            }
            return sb.ToString();
        }
    }
}
