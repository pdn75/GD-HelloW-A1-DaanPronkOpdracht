using UnityEngine;
using DynamicBehaviour;

[CreateAssetMenu(fileName = "new Condition", menuName = "ScriptableObjects/Conditions/isTouching")]
public class IsTouchingLayer : Condition
{
    public int layer;

    public override bool Verify(Actor p_actor)
    {
        int mask = 1 << layer;
        isTrue = isTrue = p_actor.actorCollider.IsTouchingLayers(mask);

        if (inverted)
            return !isTrue;

        return isTrue;
    }
}
