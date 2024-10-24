using UnityEngine;
using DynamicBehaviour;

[CreateAssetMenu(fileName = "againstWall", menuName = "ScriptableObjects/Conditions/againstWall")]
public class AgainstWall : Condition
{
    public enum XDirection { LEFT, RIGHT }
    public XDirection xDirection;
    public int layer;

    public override bool Verify(Actor p_actor)
    {
        int layerMask = 1 << layer;
        if (xDirection == XDirection.LEFT)
        {
            isTrue = Physics2D.Raycast(p_actor.transform.position, Vector2.left, p_actor.collisionSize.x, 512);
            //Debug.Log("Wall Left");
        }
        else if (xDirection == XDirection.RIGHT)
        {
            isTrue = Physics2D.Raycast(p_actor.transform.position, Vector2.right, p_actor.collisionSize.x, 512);
            //Debug.Log("Wall Right");
        }

        if (inverted)
            return !isTrue;

        return isTrue;
    }
}
