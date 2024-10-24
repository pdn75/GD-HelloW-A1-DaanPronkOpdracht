using UnityEngine;
using DynamicBehaviour;

namespace PlatformerDemo
{
    [CreateAssetMenu(fileName = "new Condition", menuName = "ScriptableObjects/Conditions/leftButton")]
    public class LeftCondition : Condition
    {
        public override bool Verify(Actor p_actor)
        {
            Player player = p_actor as Player;

            if (player == null || player.config == null || player.config.left == null)
                return false;

            isTrue = player.config.left.IsActivated();

            if (inverted)
                return !isTrue;

            return isTrue;
        }
    }
}