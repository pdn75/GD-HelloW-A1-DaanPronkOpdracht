using UnityEngine;
using UnityEngine.UI; // Zorg ervoor dat je deze toevoegt voor UI-elementen
using TMPro; // Voeg deze regel toe voor TextMeshPro

public class VolumeControl : MonoBehaviour
{
    public Slider volumeSlider; // Verbind deze met de Slider in de UI
    public TextMeshProUGUI volumeText; // Verbind deze met de TextMeshPro tekst in de UI

    private void Start()
    {
        // Zet de initiële volume-instelling (bijvoorbeeld 0.5)
        volumeSlider.value = AudioListener.volume; // Begin met de huidige volume-instelling
        UpdateVolumeText(volumeSlider.value); // Update de tekst
        volumeSlider.onValueChanged.AddListener(UpdateVolume); // Voeg listener toe aan de slider
    }

    // Methode om het volume bij te werken
    public void UpdateVolume(float value)
    {
        AudioListener.volume = value; // Stel het volume in op basis van de slider waarde
        UpdateVolumeText(value); // Update de volume tekst
    }

    // Update de tekstweergave van het volume
    private void UpdateVolumeText(float value)
    {
        if (volumeText != null)
        {
            volumeText.text = $"{Mathf.RoundToInt(value * 500)}%"; // Toon het volume in procenten
        }
    }

    // Methode om het volume met een vaste stap te verhogen
    public void IncreaseVolume(float step)
    {
        float newVolume = Mathf.Clamp(AudioListener.volume + step, 0f, 1f); // Zorg ervoor dat het volume binnen de grenzen blijft
        UpdateVolume(newVolume); // Update het volume
    }

    // Methode om het volume met een vaste stap te verlagen
    public void DecreaseVolume(float step)
    {
        float newVolume = Mathf.Clamp(AudioListener.volume - step, 0f, 1f); // Zorg ervoor dat het volume binnen de grenzen blijft
        UpdateVolume(newVolume); // Update het volume
    }
}
