using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video; // Zorg ervoor dat deze namespace is toegevoegd

public class BeginShot : MonoBehaviour
{
    public string nextSceneName = "BeginScene"; // Naam van de volgende scène

    public Text messageText; // Optioneel: Tekstobject voor bericht
    public Image backgroundImage; // Optioneel: Achtergrondafbeelding
    public VideoPlayer videoPlayer; // VideoPlayer component voor de video

    private void Start()
    {
        // Optioneel: Toon een boodschap
        if (messageText != null)
        {
            messageText.gameObject.SetActive(true);
            messageText.text = "Welkom in de wereld!";
        }

        // Abonneer op het event dat de video is afgelopen
        if (videoPlayer != null)
        {
            videoPlayer.loopPointReached += OnVideoEnd; // Voeg een event toe wanneer de video is afgelopen
        }
    }

    private void Update()
    {
        // Controleer of de spatiebalk wordt ingedrukt
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Laad de volgende scène
            SceneManager.LoadScene(nextSceneName);
        }
    }

    // Deze functie wordt aangeroepen wanneer de video klaar is
    private void OnVideoEnd(VideoPlayer vp)
    {
        // Laad de volgende scène
        SceneManager.LoadScene(nextSceneName);
    }
}
