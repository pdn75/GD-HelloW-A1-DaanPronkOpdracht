using UnityEngine;
using DynamicBehaviour;

namespace PlatformerDemo
{
    [CreateAssetMenu(fileName = "resetJumps", menuName = "ScriptableObjects/Acts/resetJumps")]
    public class ResetJumps : Act
    {
        public override void PerformAct(Actor p_actor)
        {
            PlatformerActor actor = p_actor as PlatformerActor;
            if (actor == null)
                return;

            actor.currentJump = 0;

            base.PerformAct(p_actor);
        }
    }
}