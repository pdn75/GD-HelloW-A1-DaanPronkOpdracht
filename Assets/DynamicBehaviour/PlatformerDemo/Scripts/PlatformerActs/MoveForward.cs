using UnityEngine;
using DynamicBehaviour;

namespace PlatformerDemo
{
    [CreateAssetMenu(fileName = "move", menuName = "ScriptableObjects/Acts/MoveForward")]
    public class MoveForward : Act
    {
        public float speed;

        public override void PerformAct(Actor p_actor)
        {
            PlatformerActor actor = p_actor as PlatformerActor;
            if (actor == null)
                return;

            if (actor.GetFacing() < 0)
            {
                actor.newVelocity = new Vector2(p_actor.newVelocity.x - speed, p_actor.newVelocity.y);
            }
            else if (actor.GetFacing() > 0)
            {
                actor.newVelocity = new Vector2(p_actor.newVelocity.x + speed, p_actor.newVelocity.y);
            }
            base.PerformAct(p_actor);
        }
    }
}