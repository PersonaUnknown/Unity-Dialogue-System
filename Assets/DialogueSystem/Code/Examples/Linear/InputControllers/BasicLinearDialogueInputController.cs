using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogueSystem
{
    public class BasicLinearDialogueInputController : LinearDialogueInputController
    {
        public override bool InputCheck()
        {
            return Input.GetKeyDown(KeyCode.Space);
        }
    }
}
