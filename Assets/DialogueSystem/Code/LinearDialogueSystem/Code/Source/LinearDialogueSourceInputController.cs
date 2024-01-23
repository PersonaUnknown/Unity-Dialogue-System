using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogueSystem
{
    // General template for how input should be handled for dialogue sources
    public abstract class LinearDialogueSourceInputController : MonoBehaviour
    {
        // Outlets
        [SerializeField] private LinearDialogueSource speaker;
        [SerializeField] private LinearDialogueSystemController system;

        // Methods
        private void Update()
        {
            if (!InputCheck())
            {
                return;
            }

            OnInput();
        }

        public void OnInput()
        {
            if (system.isActive)
            {
                return;
            }

            system.StartConversation(speaker);
        }

        public abstract bool InputCheck();
    }
}
