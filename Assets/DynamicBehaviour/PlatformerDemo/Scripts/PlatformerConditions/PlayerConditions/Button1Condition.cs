using UnityEngine;
using DynamicBehaviour;

namespace PlatformerDemo
{
    [CreateAssetMenu(fileName = "new Condition", menuName = "ScriptableObjects/Conditions/button1")]
    public class Button1Condition : Condition
    {
        public override bool Verify(Actor p_actor)
        {
            Player player = p_actor as Player;

            if (player == null || player.config == null || player.config.button1 == null)
                return false;

            isTrue = player.config.button1.IsActivated();

            if (inverted)
                return !isTrue;

            return isTrue;
        }
    }
}