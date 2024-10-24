using UnityEngine;

namespace PlatformerDemo
{
    public class ResetOneJump : Collectable
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            Player player = collision.gameObject.GetComponent<Player>();
            if (player != null)
            {
                gameObject.SetActive(false);
                if (player.currentJump >= 0)
                    player.currentJump--;
            }
        }
    }
}