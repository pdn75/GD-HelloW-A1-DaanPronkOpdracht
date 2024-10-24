using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DynamicBehaviour;

[CreateAssetMenu(fileName = "new Condition", menuName = "ScriptableObjects/Conditions/isFalling")]
public class FallingCondition : Condition
{
    public override bool Verify(Actor p_actor)
    {
        isTrue = p_actor.rb.velocity.y < -1;

        if (inverted)
            return !isTrue;

        return isTrue;
    }
}