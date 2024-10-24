using UnityEngine;
using DynamicBehaviour;

[CreateAssetMenu(fileName = "isGrounded", menuName = "ScriptableObjects/Conditions/IsGrounded")]
public class OnGround : Condition
{
    public int groundLayer;
    int layer;

    public override bool Verify(Actor p_actor)
    {
        //only ground
        layer = 1 << groundLayer;
        isTrue = Physics2D.Raycast(p_actor.transform.position, Vector2.down, p_actor.collisionSize.y, layer);

        if (inverted)
            return !isTrue;

        return isTrue;
    }
}
