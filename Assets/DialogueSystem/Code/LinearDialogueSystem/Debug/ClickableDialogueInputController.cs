using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogueSystem
{
    // Clicking on GameObject displays dialogue and pressing Space Bar proceeds dialogue
    public class ClickableDialogueInputController : MonoBehaviour
    {
        // Outlets
        private LinearDialogueSource source;
        
        // Methods
        private void Start()
        {
            source = GetComponent<LinearDialogueSource>();
        }

        public void OnMouseDown()
        {
            source.StartConversation();
        }
    }
}
