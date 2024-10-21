using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class BeginShot : MonoBehaviour
{
    public float duration = 3f; // Duur van de begin shot
    public string nextSceneName = "BeginScene"; // Naam van de volgende scène

    public Text messageText; // Optioneel: Tekstobject voor bericht
    public Image backgroundImage; // Optioneel: Achtergrondafbeelding

    private void Start()
    {
        // Start de intro
        StartCoroutine(ShowIntro());
    }

    private IEnumerator ShowIntro()
    {
        // Optioneel: Toon een boodschap
        if (messageText != null)
        {
            messageText.gameObject.SetActive(true);
            messageText.text = "Welkom in de wereld!";
        }

        // Wacht de opgegeven duur
        yield return new WaitForSeconds(duration);

        // Laad de volgende scène
        SceneManager.LoadScene(nextSceneName);
    }
}
