using UnityEngine;

namespace DynamicBehaviour
{
    public abstract class Act : ScriptableObject
    {
        public bool resetIdle;
        public bool setCanAct;
        public float resetTime;
        public Condition[] conditions;

        public bool CheckConditions(Actor p_actor)
        {
            for (int i = 0; i < conditions.Length; ++i)
            {
                if (!conditions[i].Verify(p_actor))
                    return false;
            }
            return true;
        }

        public virtual void PerformAct(Actor p_actor)
        {
            if (resetIdle)
                p_actor.ResetIdle();
        }
    }
}