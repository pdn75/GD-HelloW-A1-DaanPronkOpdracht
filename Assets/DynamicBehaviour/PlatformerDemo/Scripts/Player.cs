using UnityEngine;
using ScriptableInput;

namespace PlatformerDemo
{
    public class Player : PlatformerActor
    {
        public ControllerConfigurationPlatformer config;
        [HideInInspector]
        public int lives;
        [HideInInspector]
        public int score;
    }
}