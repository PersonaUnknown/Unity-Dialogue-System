using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogueSystem
{
    public class DialogueInputController : MonoBehaviour
    {
        // Outlets
        public DialogueSystemController system;

        // Methods
        private void Update()
        {
            if (!IsSystemReady()) { return; }

            if (CheckInput())
            {
                OnDialogueInput();
            }
        }

        public bool IsSystemReady()
        {
            return system != null && system.GetSpeaker() != null;
        }

        public void OnDialogueInput()
        {
            system.GetSpeaker().NextLine();
        }

        public bool CheckInput()
        {
            return Input.GetKeyDown(KeyCode.Space);
        }
    }
}
