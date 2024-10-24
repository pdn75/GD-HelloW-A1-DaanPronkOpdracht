using UnityEngine;

namespace DynamicBehaviour
{
    public abstract class Condition : ScriptableObject
    {
        protected bool isTrue;
        public bool inverted = false;

        public virtual bool Verify(Actor p_actor)
        {
            if (inverted)
                return !isTrue;
            return isTrue;
        }
    }
}