using UnityEngine;
using DynamicBehaviour;

namespace PlatformerDemo
{
    [CreateAssetMenu(fileName = "move", menuName = "ScriptableObjects/Acts/MoveDirection")]
    public class MoveDirection : Act
    {
        public float speed;

        public enum XDirection { LEFT, RIGHT }
        public XDirection xDirection;

        public override void PerformAct(Actor p_actor)
        {
            PlatformerActor actor = p_actor as PlatformerActor;
            if (actor == null)
                return;

            if (xDirection == XDirection.LEFT)
            {
                actor.newVelocity = new Vector2(p_actor.newVelocity.x - speed, p_actor.newVelocity.y);
                actor.SetFacingLeft();
            }
            else if (xDirection == XDirection.RIGHT)
            {
                actor.newVelocity = new Vector2(p_actor.newVelocity.x + speed, p_actor.newVelocity.y);
                actor.SetFacingRight();
            }
            base.PerformAct(p_actor);
        }
    }
}