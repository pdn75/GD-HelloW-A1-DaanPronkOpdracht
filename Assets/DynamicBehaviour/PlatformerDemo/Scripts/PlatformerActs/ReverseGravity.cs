using UnityEngine;
using DynamicBehaviour;

namespace PlatformerDemo
{
    [CreateAssetMenu(fileName = "reverseGravity", menuName = "ScriptableObjects/Acts/ReverseGravity")]
    public class ReverseGravity : Act
    {
        public override void PerformAct(Actor p_actor)
        {
            PlatformerActor actor = p_actor as PlatformerActor;
            if (actor == null)
                return;

            actor.rb.gravityScale = -actor.rb.gravityScale;

            base.PerformAct(p_actor);
        }
    }
}