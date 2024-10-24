using UnityEngine;
using DynamicBehaviour;

[CreateAssetMenu(fileName = "new Condition", menuName = "ScriptableObjects/Conditions/idle")]
public class IdleCondition : Condition
{
    public override bool Verify(Actor p_actor)
    {
        if (inverted)
            return !p_actor.isIdle;

        return p_actor.isIdle;
    }
}