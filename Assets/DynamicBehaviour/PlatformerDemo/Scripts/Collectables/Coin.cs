using UnityEngine;

namespace PlatformerDemo
{
    public class Coin : Collectable
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            Player player = collision.gameObject.GetComponent<Player>();
            if (player != null)
            {
                gameObject.SetActive(false);
                player.score += 50;
                GameDemoManager.Instance.UpdateUI();
            }
        }
    }
}