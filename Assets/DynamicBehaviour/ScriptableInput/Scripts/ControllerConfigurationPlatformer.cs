using UnityEngine;

namespace ScriptableInput
{
    [CreateAssetMenu(fileName = "new ControllerConfig", menuName = "ScriptableObjects/ControllerConfigPlatformer")]
    public class ControllerConfigurationPlatformer : ScriptableObject
    {
        public ControllerInput left;
        public ControllerInput right;
        public ControllerInput button1;
        public ControllerInput button2;
    }
}