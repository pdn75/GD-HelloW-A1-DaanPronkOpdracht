using UnityEngine;
using UnityEngine.UI;

public class FPSCounter : MonoBehaviour
{
    public Text fpsText; // Reference to the UI Text component
    private float deltaTime = 0.0f;

    void Update()
    {
        // Calculate the time since the last frame
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;

        // Calculate FPS
        float fps = 1.0f / deltaTime;

        // Update the UI Text
        fpsText.text = string.Format("{0:0.} FPS ", fps);
    }
}
