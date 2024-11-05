using UnityEngine;

public class EscapeMenuManager : MonoBehaviour
{
    public GameObject escapeMenuCanvas; // The Canvas that will serve as the escape menu

    private void Start()
    {
        // Ensure the escape menu is hidden at the start of the game
        if (escapeMenuCanvas != null)
        {
            escapeMenuCanvas.SetActive(false);
            Debug.Log("Escape menu initialized as hidden.");
        }
        else
        {
            Debug.LogWarning("escapeMenuCanvas is not assigned in the Inspector!");
        }

        // Hide the cursor initially and lock it to the center of the screen
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        // Detect if the Escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Escape key detected.");
            ToggleEscapeMenu();
        }
    }

    private void ToggleEscapeMenu()
    {
        if (escapeMenuCanvas == null)
        {
            Debug.LogWarning("Escape menu canvas is not assigned!");
            return;
        }

        // Toggle the active state of the escape menu
        bool isActive = !escapeMenuCanvas.activeSelf;
        escapeMenuCanvas.SetActive(isActive);

        Debug.Log("Toggling escape menu. New state is " + (isActive ? "active" : "inactive"));

        // If the menu is active, show and unlock the cursor; otherwise, hide and lock it
        if (isActive)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None; // Unlock the cursor
            Time.timeScale = 0; // Pause the game
            Debug.Log("Escape menu is now active. Game paused.");
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked; // Lock the cursor
            Time.timeScale = 1; // Resume the game
            Debug.Log("Escape menu is now inactive. Game resumed.");
        }
    }
}
