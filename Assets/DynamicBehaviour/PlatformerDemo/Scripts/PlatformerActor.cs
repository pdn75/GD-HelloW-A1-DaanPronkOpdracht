using UnityEngine;
using DynamicBehaviour;

namespace PlatformerDemo
{
    public class PlatformerActor : Actor
    {
        [HideInInspector]
        public int currentJump;
        [Header("Platformer Variables")]
        public int extraJumps;
        [SerializeField]
        [Range(-1, 1)]
        private int facing;//-1 left, 1 right

        public void ResetPlatformerActor()
        {
            currentJump = 0;
            extraJumps = 0;
        }

        public void SetFacingLeft()
        {
            facing = -1;
        }
        public void SetFacingRight()
        {
            facing = 1;
        }
        public int GetFacing()
        {
            return facing;
        }
    }
}