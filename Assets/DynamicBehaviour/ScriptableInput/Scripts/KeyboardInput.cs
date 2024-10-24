using UnityEngine;

namespace ScriptableInput
{
    [CreateAssetMenu(fileName = "New Key Input", menuName = "ScriptableObjects/Controls/Input")]
    public class KeyboardInput : ControllerInput
    {
        public KeyCode key;

        public override bool IsActivated()
        {
            return Input.GetKey(key) ? true : false;
        }
    }
}