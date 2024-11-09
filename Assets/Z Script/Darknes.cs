using UnityEngine;
using UnityEngine.UI;

public class OpacityController : MonoBehaviour
{
    [Header("UI Components")]
    public Slider opacitySlider;
    public Text opacityText;
    public RawImage background; // Gebruik RawImage voor de achtergrond

    void Start()
    {
        // Stel de slider in op 0% opacity bij het starten
        opacitySlider.minValue = 0;
        opacitySlider.maxValue = 100;
        opacitySlider.value = 100; // Start bij volledig zwart
        UpdateOpacity();

        // Voeg een event listener toe om de opacity aan te passen wanneer de slider verandert
        opacitySlider.onValueChanged.AddListener(delegate { UpdateOpacity(); });
    }

    void UpdateOpacity()
    {
        // Opacity in procent ophalen
        float opacityValue = opacitySlider.value;
        opacityText.text = $"Helderheid: {opacityValue:F0}%";

        // Alpha-waarde aanpassen op basis van opacity (omgekeerd)
        Color currentColor = background.color;
        currentColor.a = 1 - (opacityValue / 100f); // Omgekeerde alpha berekening
        background.color = currentColor;
    }
}
