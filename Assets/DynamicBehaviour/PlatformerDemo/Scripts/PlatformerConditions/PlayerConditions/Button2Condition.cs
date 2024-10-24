using UnityEngine;
using DynamicBehaviour;

namespace PlatformerDemo
{
    [CreateAssetMenu(fileName = "new Condition", menuName = "ScriptableObjects/Conditions/button2")]
    public class Button2Condition : Condition
    {
        public override bool Verify(Actor p_actor)
        {
            Player player = p_actor as Player;

            if (player == null || player.config == null || player.config.button2 == null)
                return false;

            isTrue = player.config.button2.IsActivated();

            if (inverted)
                return !isTrue;

            return isTrue;
        }
    }
}