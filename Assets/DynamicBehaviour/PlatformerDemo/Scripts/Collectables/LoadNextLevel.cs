using UnityEngine;

namespace PlatformerDemo
{
    public class LoadNextLevel : Collectable
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            Player player = collision.gameObject.GetComponent<Player>();
            if (player != null)
            {
                GameDemoManager.Instance.LoadNextLevel();
            }
        }
    }
}