using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public Material daySkybox;
    public Material nightSkybox;
    public Light sun;  // Make sure Light is referenced correctly

    public float dayLength = 120f;  // Length of a full day in seconds
    private float time;

    void Start()
    {
        time = 0f;
    }

    void Update()
    {
        time += Time.deltaTime;

        float t = Mathf.PingPong(time / dayLength, 1);

        // Update the sun's rotation
        sun.transform.rotation = Quaternion.Euler((t * 360f) - 90f, 170f, 0);

        // Interpolate between day and night skybox
        if (t < 0.5f)
        {
            RenderSettings.skybox.Lerp(daySkybox, nightSkybox, t * 2);
        }
        else
        {
            RenderSettings.skybox.Lerp(nightSkybox, daySkybox, (t - 0.5f) * 2);
        }

        // Adjust lighting intensity
        sun.intensity = Mathf.Lerp(1f, 0.2f, t);
    }
}
