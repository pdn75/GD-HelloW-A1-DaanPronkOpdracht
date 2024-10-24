using UnityEngine;
using DynamicBehaviour;

namespace PlatformerDemo
{
    [CreateAssetMenu(fileName = "new Condition", menuName = "ScriptableObjects/Conditions/AiDetectHole")]
    public class AiDetectHole : Condition
    {
        public float distance;
        public int layer;

        public override bool Verify(Actor p_actor)
        {
            PlatformerActor actor = p_actor as PlatformerActor;
            if (actor == null)
                return false;

            if (actor.GetFacing() > 0)
            {
                //bit shift the index of the layer to get a bit mask
                int layerMask = 1 << layer;
                isTrue = !Physics2D.Raycast(
                    new Vector2(p_actor.transform.position.x + distance, p_actor.transform.position.y),
                    Vector2.down,
                    1,
                    layerMask
                    );
            }
            else if (actor.GetFacing() < 0)
            {
                //bit shift the index of the layer to get a bit mask
                int layerMask = 1 << layer;
                isTrue = !Physics2D.Raycast(
                    new Vector2(p_actor.transform.position.x - distance, p_actor.transform.position.y),
                    Vector2.down,
                    1,
                    layerMask
                    );
            }

            if (inverted)
                return !isTrue;

            return isTrue;
        }
    }
}