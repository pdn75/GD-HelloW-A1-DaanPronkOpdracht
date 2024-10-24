using UnityEngine;
using DynamicBehaviour;

namespace PlatformerDemo
{
    [CreateAssetMenu(fileName = "new Condition", menuName = "ScriptableObjects/Conditions/AiDetectWall")]
    public class AiDetectWall : Condition
    {
        public float distance;
        public int layer;

        public override bool Verify(Actor p_actor)
        {
            PlatformerActor actor = p_actor as PlatformerActor;
            if (actor == null)
                return false;

            int layerMask = 1 << layer;
            if (actor.GetFacing() > 0)
            {
                isTrue = Physics2D.Raycast(p_actor.transform.position, Vector2.right, distance, layerMask);
            }
            else if (actor.GetFacing() < 0)
            {
                isTrue = Physics2D.Raycast(p_actor.transform.position, Vector2.left, distance, layerMask);
            }

            if (inverted)
                return !isTrue;

            return isTrue;
        }
    }
}