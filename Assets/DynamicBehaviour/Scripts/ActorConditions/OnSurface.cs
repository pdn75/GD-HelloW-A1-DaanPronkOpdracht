using UnityEngine;
using DynamicBehaviour;

[CreateAssetMenu(fileName = "onSurface", menuName = "ScriptableObjects/Conditions/OnSurface")]
public class OnSurface : Condition
{
    public override bool Verify(Actor p_actor)
    {
        //any surface
        //bit shift the index of the layer to get a bit mask
        int layerMask = p_actor.GetCollisionMask();
        //invert bitmask.
        layerMask = ~layerMask;
        isTrue = Physics2D.Raycast(p_actor.transform.position, Vector2.down, p_actor.collisionSize.y, layerMask);

        if (inverted)
            return !isTrue;

        return isTrue;
    }
}
