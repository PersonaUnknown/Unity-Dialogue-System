using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace DialogueSystem
{
    // Basic UI Element that contains text and background
    public class DialogueUIElement : MonoBehaviour
    {
        // Outlets
        [SerializeField] private Image elementBackground;
        [SerializeField] private TMP_Text elementText;

        // Methods
        public void Show()
        {
            elementBackground.gameObject.SetActive(true);
            elementText.gameObject.SetActive(true);
        }

        public void Hide()
        {
            elementText.text = string.Empty;
            elementBackground.gameObject.SetActive(false);
            elementText.gameObject.SetActive(false);
        }

        public void UpdateText(string text)
        {
            elementText.text = text;
        }

        public TMP_Text GetElementText()
        {
            return elementText;
        }
    }
}
