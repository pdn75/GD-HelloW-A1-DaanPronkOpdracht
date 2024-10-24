using UnityEngine;
using DynamicBehaviour;

namespace PlatformerDemo
{
    [CreateAssetMenu(fileName = "AiFacing", menuName = "ScriptableObjects/Conditions/AiFacing")]
    public class AiFacing : Condition
    {
        public enum XDirection { LEFT, RIGHT }
        public XDirection xDirection;

        public override bool Verify(Actor p_actor)
        {
            PlatformerActor actor = p_actor as PlatformerActor;
            if (actor == null)
                return false;

            if (xDirection == XDirection.LEFT)
            {
                isTrue = actor.GetFacing() < 0;
            }
            else if (xDirection == XDirection.RIGHT)
            {
                isTrue = actor.GetFacing() > 0;
            }

            if (inverted)
                return !isTrue;

            return isTrue;
        }
    }
}