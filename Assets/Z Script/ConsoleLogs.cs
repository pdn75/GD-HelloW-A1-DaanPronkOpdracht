using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LogPanelManager : MonoBehaviour
{
    public GameObject logPanel; // Het logpaneel dat we gebruiken
    public TextMeshProUGUI logText; // De tekstcomponent voor het weergeven van logs
    public Button closeButton; // De knop om het logpaneel te sluiten
    public GameObject[] uiItemsToToggle; // UI-elementen die we willen togglen
    public CameraController cameraController; // Verwijs naar het camera controller script
    public CharacterController playerMovement; // Vervang dit door de naam van jouw speler beweging script

    private void Start()
    {
        // Zorg ervoor dat het logpaneel niet zichtbaar is bij het starten
        logPanel.SetActive(false);
        
        // Voeg de logcallback toe om logs te registreren
        Application.logMessageReceived += Log;

        // Koppel de sluitknop
        closeButton.onClick.AddListener(CloseLogPanel);
        
        // Zorg ervoor dat de cursor onzichtbaar is in het begin
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked; // Vergrendel de cursor
    }

    private void Update()
    {
        // Detecteer de F8-toets om het logpaneel te toggelen
        if (Input.GetKeyDown(KeyCode.F8))
        {
            ToggleLogPanel();
        }
    }

    private void Log(string logString, string stackTrace, LogType type)
    {
        // Voeg het logbericht toe aan de logtekst
        string logType = type.ToString(); // Verkrijg het type log
        logText.text += $"{logType}: {logString}\n"; // Voeg het logbericht toe

        // Optioneel: Beperk het aantal regels in de log om geheugen te besparen
        if (logText.text.Split('\n').Length > 100)
        {
            string[] lines = logText.text.Split('\n');
            logText.text = string.Join("\n", lines, lines.Length - 99, 99);
        }

        // Zorg ervoor dat de scrollrect naar beneden scrollt bij nieuwe logs
        Canvas.ForceUpdateCanvases(); // Forceer een update van het canvas
        logText.GetComponent<RectTransform>().SetAsLastSibling(); // Zorg ervoor dat de laatste log onderaan komt
    }

    private void ToggleLogPanel()
    {
        bool isActive = !logPanel.activeSelf; // Bepaal de nieuwe status

        logPanel.SetActive(isActive); // Toggle zichtbaarheid van het logpaneel
        
        // Toggle de zichtbaarheid van andere UI-elementen
        SetUIItemsActive(!isActive);

        // Beperk de beweging en kijkrichting op basis van de status van het logpaneel
        if (isActive)
        {
            // Zet de camera controller en spelerbeweging uit
            if (cameraController != null)
            {
                cameraController.enabled = false; // Deactiveer camera beweging
            }
            if (playerMovement != null)
            {
                playerMovement.enabled = false; // Deactiveer spelerbeweging
            }
            Cursor.visible = true; // Maak de cursor zichtbaar
            Cursor.lockState = CursorLockMode.None; // Laat de cursor vrij
        }
        else
        {
            // Zet de camera controller en spelerbeweging weer aan
            if (cameraController != null)
            {
                cameraController.enabled = true; // Heractiveer camera beweging
            }
            if (playerMovement != null)
            {
                playerMovement.enabled = true; // Heractiveer spelerbeweging
            }
            Cursor.visible = false; // Maak de cursor onzichtbaar
            Cursor.lockState = CursorLockMode.Locked; // Vergrendel de cursor
        }
    }

    public void CloseLogPanel()
    {
        logPanel.SetActive(false); // Verberg het logpaneel
        SetUIItemsActive(true); // Zorg ervoor dat andere UI-elementen zichtbaar zijn
        ToggleLogPanel(); // Toggle om de camera controller weer te activeren
    }

    private void SetUIItemsActive(bool isActive)
    {
        // Zet de opgegeven UI-elementen aan of uit
        foreach (GameObject uiItem in uiItemsToToggle)
        {
            uiItem.SetActive(isActive);
        }
    }

    private void OnDestroy()
    {
        Application.logMessageReceived -= Log; // Verwijder de logcallback
    }
}
