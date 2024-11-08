using UnityEngine;
using UnityEngine.UI;

public class DarknessController : MonoBehaviour
{
    public RawImage darknessOverlay; // Sleep hier het RawImage-element in van de DarknessCanvas
    public Slider darknessSlider;    // Sleep hier de slider in

    void Start()
    {
        // Koppel de slider aan de UpdateDarkness functie
        darknessSlider.onValueChanged.AddListener(UpdateDarkness);

        // Start met volledige helderheid (geen donkerte)
        darknessSlider.value = 0;
    }

    void UpdateDarkness(float value)
    {
        // Pas de alpha-waarde van de overlay aan om de donkerte in te stellen
        Color overlayColor = darknessOverlay.color;
        overlayColor.a = value; // Alpha-waarde is gebaseerd op de slider-waarde
        darknessOverlay.color = overlayColor;
    }
}
