using UnityEngine;
using DynamicBehaviour;

namespace PlatformerDemo
{
    [CreateAssetMenu(fileName = "ChangeDirections", menuName = "ScriptableObjects/Acts/ChangeDirections")]
    public class ChangeDirections : Act
    {
        public override void PerformAct(Actor p_actor)
        {
            PlatformerActor actor = p_actor as PlatformerActor;
            if (actor == null)
                return;

            if (actor.GetFacing() > 0)
                actor.SetFacingLeft();
            else if (actor.GetFacing() < 0)
                actor.SetFacingRight();
        }
    }
}