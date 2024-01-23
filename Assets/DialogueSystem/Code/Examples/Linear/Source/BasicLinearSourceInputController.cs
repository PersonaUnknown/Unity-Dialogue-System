using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogueSystem.Examples
{
    public class BasicLinearSourceInputController : LinearDialogueSourceInputController
    {
        // Behavior
        public bool inputPressed;
        
        // Methods
        private void OnMouseDown()
        {
            inputPressed = true;
            StartCoroutine(AfterMouseDown());
        }

        private IEnumerator AfterMouseDown()
        {
            WaitForEndOfFrame endOfFrame = new WaitForEndOfFrame();
            yield return endOfFrame;
            yield return endOfFrame;
            inputPressed = false;
        }

        public override bool InputCheck()
        {
            return inputPressed;
        }
    }
}
