using UnityEngine;

namespace ScriptableInput
{
    [CreateAssetMenu(fileName = "new ControllerConfig", menuName = "ScriptableObjects/ControllerConfig4Button")]
    public class ControllerConfiguration4Button : ScriptableObject
    {
        public ControllerInput up;
        public ControllerInput down;
        public ControllerInput left;
        public ControllerInput right;
        public ControllerInput button1;
        public ControllerInput button2;
        public ControllerInput button3;
        public ControllerInput button4;
    }
}
