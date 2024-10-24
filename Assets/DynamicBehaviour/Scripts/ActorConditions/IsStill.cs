using UnityEngine;
using DynamicBehaviour;

[CreateAssetMenu(fileName = "IsStill", menuName = "ScriptableObjects/Conditions/IsStill")]
public class IsStill : Condition
{
    public override bool Verify(Actor p_actor)
    {
        isTrue = p_actor.rb.velocity.magnitude < 1;

        if (inverted)
            return !isTrue;

        return isTrue;
    }
}
