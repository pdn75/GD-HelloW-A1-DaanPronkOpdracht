using UnityEngine;

namespace ScriptableInput
{
    [CreateAssetMenu(fileName = "new ControllerConfig", menuName = "ScriptableObjects/ControllerConfig8Button")]
    public class ControllerConfiguration8Button : ScriptableObject
    {
        public ControllerInput up;
        public ControllerInput down;
        public ControllerInput left;
        public ControllerInput right;
        public ControllerInput button1;
        public ControllerInput button2;
        public ControllerInput button3;
        public ControllerInput button4;
        public ControllerInput button5;
        public ControllerInput button6;
        public ControllerInput button7;
        public ControllerInput button8;
    }
}
