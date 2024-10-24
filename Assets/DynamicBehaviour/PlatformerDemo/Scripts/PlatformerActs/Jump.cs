using UnityEngine;
using DynamicBehaviour;

namespace PlatformerDemo
{
    [CreateAssetMenu(fileName = "jump", menuName = "ScriptableObjects/Acts/Jump")]
    public class Jump : Act
    {
        public float jumpPower;

        public override void PerformAct(Actor p_actor)
        {
            PlatformerActor actor = p_actor as PlatformerActor;
            if (actor == null)
                return;

            actor.newVelocity = new Vector2(0, jumpPower);// *-actor.rb.gravityScale;
            actor.currentJump++;

            base.PerformAct(p_actor);
        }
    }
}