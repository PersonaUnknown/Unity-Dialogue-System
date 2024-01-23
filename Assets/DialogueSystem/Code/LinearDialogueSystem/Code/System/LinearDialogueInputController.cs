using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogueSystem
{
    // Input controller for progressing dialogue in a simple linear dialogue system
    public abstract class LinearDialogueInputController : MonoBehaviour
    {
        // Outlets
        [SerializeField] private LinearDialogueSystemController system;

        // Methods
        private void Update()
        {
            if (system == null || !InputCheck())
            {
                return;
            }

            OnInput();
        }
        private void OnInput()
        {
            if (!system.isActive)
            {
                return;
            }

            system.ProgressConversation();
        }
        public abstract bool InputCheck();
    }
}
