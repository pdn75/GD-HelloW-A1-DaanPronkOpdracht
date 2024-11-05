using UnityEngine;
using UnityEngine.UI;

public class CanvasSwitcher : MonoBehaviour
{
    public GameObject canvas1; // Slepen Canvas1 hierheen in de Inspector
    public GameObject canvas2; // Slepen Canvas2 hierheen in de Inspector
    public Button toggleButton; // Slepen de knop hierheen in de Inspector

    private bool isCanvas1Active = true;

    void Start()
    {
        // Zorg ervoor dat Canvas1 actief is en Canvas2 niet
        canvas1.SetActive(true);
        canvas2.SetActive(false);

        // Voeg een listener toe aan de knop
        toggleButton.onClick.AddListener(ToggleCanvas);
    }

    void ToggleCanvas()
    {
        isCanvas1Active = !isCanvas1Active;

        // Schakel de zichtbaarheid van de canvassen om
        canvas1.SetActive(isCanvas1Active);
        canvas2.SetActive(!isCanvas1Active);

        // Optioneel: wijzig de knoptekst afhankelijk van het actieve canvas
        if (isCanvas1Active)
        {
            toggleButton.GetComponentInChildren<Text>().text = "Open Canvas 2";
        }
        else
        {
            toggleButton.GetComponentInChildren<Text>().text = "Open Canvas 1";
        }
    }
}
