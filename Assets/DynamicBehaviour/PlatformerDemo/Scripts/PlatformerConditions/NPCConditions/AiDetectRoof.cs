using UnityEngine;
using DynamicBehaviour;

[CreateAssetMenu(fileName = "new Condition", menuName = "ScriptableObjects/Conditions/AiDetectRoof")]
public class AiDetectRoof : Condition
{
    public float distance;
    public int layer;

    public override bool Verify(Actor p_actor)
    {
        int layerMask = 1 << layer;
        isTrue = Physics2D.Raycast(p_actor.transform.position, Vector2.up, distance, layerMask);

        if (inverted)
            return !isTrue;

        return isTrue;
    }
}
