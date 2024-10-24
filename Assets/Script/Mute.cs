using UnityEngine;
using UnityEngine.Video;

public class VideoMuteToggle : MonoBehaviour
{
    // Referenties naar de VideoPlayer en AudioSource componenten
    public VideoPlayer videoPlayer;
    public AudioSource audioSource;

    // Variabele om bij te houden of het geluid gedempt is
    private bool isMuted = false;

    void Start()
    {
        // Controleer of de AudioSource is gekoppeld
        if (audioSource != null)
        {
            videoPlayer.SetTargetAudioSource(0, audioSource);
        }
    }

    void Update()
    {
        // Controleer of de 'M'-toets is ingedrukt
        if (Input.GetKeyDown(KeyCode.M))
        {
            ToggleMute();
        }
    }

    void ToggleMute()
    {
        // Wissel tussen volume 0 (mute) en normaal volume
        if (isMuted)
        {
            audioSource.volume = 1.0f; // Zet volume terug naar 100%
            Debug.Log("Unmuted");
        }
        else
        {
            audioSource.volume = 0.0f; // Zet volume naar 0
            Debug.Log("Muted");
        }

        isMuted = !isMuted;
    }
}
