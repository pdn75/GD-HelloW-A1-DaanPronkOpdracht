using UnityEngine;
using DynamicBehaviour;

namespace PlatformerDemo
{
    [CreateAssetMenu(fileName = "wallJump", menuName = "ScriptableObjects/Acts/WallJumpDirection")]
    public class WallJumpDirection : Act
    {
        public Vector2 jumpPower;

        public enum XDirection { LEFT, RIGHT }
        public XDirection xDirection;

        public override void PerformAct(Actor p_actor)
        {
            PlatformerActor actor = p_actor as PlatformerActor;
            if (actor == null)
                return;

            if (xDirection == XDirection.LEFT)
            {
                actor.newVelocity = new Vector2(-jumpPower.x, jumpPower.y);
                actor.SetFacingLeft();
            }
            else if (xDirection == XDirection.RIGHT)
            {
                actor.newVelocity = new Vector2(jumpPower.x, jumpPower.y);
                actor.SetFacingRight();
            }

            base.PerformAct(p_actor);
        }
    }
}