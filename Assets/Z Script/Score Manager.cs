using UnityEngine;
using TMPro;

namespace MyGameNamespace
{
    public class ScoreManager : MonoBehaviour
    {
        [Tooltip("Sleep hier de TextMeshPro-component die de score toont.")]
        public TextMeshProUGUI scoreText;

        [Tooltip("Het totale aantal objecten dat verzameld moet worden.")]
        public int totalObjects = 4;  // Stel hier het totaal aantal in

        private int collectedObjects = 0;

        // Start wordt één keer aangeroepen bij het begin van het spel
        private void Start()
        {
            // Initialiseer de scoretekst bij het begin van het spel
            UpdateScoreText();
        }

        // Functie om de score te verhogen en de tekst bij te werken
        public void AddScore(int amount)
        {
            // Verhoog het aantal verzamelde objecten
            collectedObjects += amount;

            // Werk de tekst bij
            UpdateScoreText();
        }

        // Functie om de scoretekst bij te werken in het formaat '1/4'
        private void UpdateScoreText()
        {
            if (scoreText != null)
            {
                scoreText.text = collectedObjects + "/" + totalObjects;
            }
            else
            {
                Debug.LogWarning("ScoreText is niet ingesteld in de Inspector.");
            }
        }
    }
}
