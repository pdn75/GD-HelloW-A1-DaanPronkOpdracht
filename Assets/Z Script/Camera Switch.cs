using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public List<Camera> cameras; // Sleep hier je camera's naartoe in de Unity Editor
    private int currentCameraIndex = 0;

    void Start()
    {
        // Alleen de eerste camera aanzetten, de rest uitzetten
        for (int i = 0; i < cameras.Count; i++)
        {
            cameras[i].enabled = (i == 0);
        }
    }

    void Update()
    {
        // Controleren of de 'V'-toets is ingedrukt
        if (Input.GetKeyDown(KeyCode.V))
        {
            SwitchCamera();
        }
    }

    void SwitchCamera()
    {
        // Huidige camera uitschakelen
        cameras[currentCameraIndex].enabled = false;

        // Index verhogen en weer op nul zetten als hij de lijstlengte bereikt
        currentCameraIndex = (currentCameraIndex + 1) % cameras.Count;

        // Nieuwe camera aanzetten
        cameras[currentCameraIndex].enabled = true;
    }
}
