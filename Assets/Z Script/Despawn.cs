using UnityEngine;

namespace MyGameNamespace
{
    public class DeleteOnTouchConfigurable : MonoBehaviour
    {
        [Tooltip("Het object dat verwijderd moet worden wanneer de speler ermee in aanraking komt.")]
        public GameObject objectToDelete;

        [Tooltip("De tag van het object dat dit object kan verwijderen bij aanraking.")]
        public string playerTag = "Player";

        // Referentie naar ScoreManager om de score op te hogen
        [Tooltip("Sleep hier de ScoreManager om de score op te hogen.")]
        public ScoreManager scoreManager;

        // Deze functie wordt aangeroepen wanneer een ander object de trigger raakt
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(playerTag))
            {
                if (objectToDelete != null)
                {
                    Destroy(objectToDelete);

                    // Verhoog de score met 1
                    if (scoreManager != null)
                    {
                        scoreManager.AddScore(1);
                    }
                    else
                    {
                        Debug.LogWarning("ScoreManager is niet ingesteld in de Inspector.");
                    }
                }
                else
                {
                    Debug.LogWarning("objectToDelete is niet ingesteld in de Inspector.");
                }
            }
        }
    }
}
