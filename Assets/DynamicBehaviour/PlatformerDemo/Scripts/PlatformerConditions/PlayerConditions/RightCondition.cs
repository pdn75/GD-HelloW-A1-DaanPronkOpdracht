using UnityEngine;
using DynamicBehaviour;

namespace PlatformerDemo
{
    [CreateAssetMenu(fileName = "new Condition", menuName = "ScriptableObjects/Conditions/rightButton")]
    public class RightCondition : Condition
    {
        public override bool Verify(Actor p_actor)
        {

            Player player = p_actor as Player;

            if (player == null || player.config == null || player.config.right == null)
                return false;

            isTrue = player.config.right.IsActivated();

            if (inverted)
                return !isTrue;

            return isTrue;
        }
    }
}