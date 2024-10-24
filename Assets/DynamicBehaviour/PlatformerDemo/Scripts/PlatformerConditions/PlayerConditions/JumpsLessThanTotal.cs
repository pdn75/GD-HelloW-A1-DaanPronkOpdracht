using UnityEngine;
using DynamicBehaviour;

namespace PlatformerDemo
{
    [CreateAssetMenu(fileName = "JumpsLessThanTotal", menuName = "ScriptableObjects/Conditions/JumpsLessThanTotal")]
    public class JumpsLessThanTotal : Condition
    {
        public override bool Verify(Actor p_actor)
        {
            PlatformerActor actor = p_actor as PlatformerActor;

            if (actor == null)
                return false;

            isTrue = actor.currentJump < actor.extraJumps;

            if (inverted)
                return !isTrue;

            return isTrue;
        }
    }
}