using UnityEngine;

namespace ScriptableInput
{
    [CreateAssetMenu(fileName = "New Key Input", menuName = "ScriptableObjects/Controls/InputDown")]
    public class KeyboardInputDown : ControllerInput
    {
        public KeyCode key;

        public override bool IsActivated()
        {
            return Input.GetKeyDown(key) ? true : false;
        }
    }
}