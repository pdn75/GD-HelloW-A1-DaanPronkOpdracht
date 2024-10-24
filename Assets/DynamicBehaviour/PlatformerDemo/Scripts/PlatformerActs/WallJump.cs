using UnityEngine;
using DynamicBehaviour;

namespace PlatformerDemo
{
    [CreateAssetMenu(fileName = "wallJump", menuName = "ScriptableObjects/Acts/WallJump")]
    public class WallJump : Act
    {
        public Vector2 jumpPower;

        public override void PerformAct(Actor p_actor)
        {
            PlatformerActor actor = p_actor as PlatformerActor;
            if (actor == null)
                return;

            if (actor.GetFacing() > 0)
            {
                actor.newVelocity = new Vector2(-jumpPower.x, jumpPower.y);
                actor.SetFacingLeft();
            }
            else if (actor.GetFacing() < 0)
            {
                actor.newVelocity = new Vector2(jumpPower.x, jumpPower.y);
                actor.SetFacingRight();
            }

            base.PerformAct(p_actor);
        }
    }
}