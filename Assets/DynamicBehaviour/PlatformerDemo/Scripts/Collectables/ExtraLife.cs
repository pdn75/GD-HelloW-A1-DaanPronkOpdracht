using UnityEngine;

namespace PlatformerDemo
{
    public class ExtraLife : Collectable
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            Player player = collision.gameObject.GetComponent<Player>();
            if (player != null)
            {
                gameObject.SetActive(false);
                player.lives++;
            }
        }
    }
}