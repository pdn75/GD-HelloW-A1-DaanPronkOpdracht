using UnityEngine;
using DynamicBehaviour;

namespace PlatformerDemo
{
    [CreateAssetMenu(fileName = "new Condition", menuName = "ScriptableObjects/Conditions/AiDetectPlayer")]
    public class AiDetectPlayer : Condition
    {
        public float distance;
        public int playerLayer;

        public override bool Verify(Actor p_actor)
        {
            NPC npc = p_actor as NPC;

            if (npc == null)
                return false;

            int layerMask = 1 << playerLayer;

            if (npc.GetFacing() > 0)
            {
                isTrue = Physics2D.Raycast(p_actor.transform.position, Vector2.right, distance, layerMask);
            }
            else if (npc.GetFacing() < 0)
            {
                isTrue = Physics2D.Raycast(p_actor.transform.position, Vector2.left, distance, layerMask);
            }

            if (inverted)
                return !isTrue;

            return isTrue;
        }
    }
}