using UnityEngine;

namespace ScriptableInput
{
    public abstract class ControllerInput : ScriptableObject
    {
        public virtual bool IsActivated()
        {
            return false;
        }
    }
}