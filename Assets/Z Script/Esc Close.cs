using UnityEngine;

public class EscClose : MonoBehaviour
{
    void Update()
    {
        // Controleer of de Esc-toets is ingedrukt
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Het canvas object inactief maken (dit "sluit" het canvas)
            gameObject.SetActive(false);
        }
    }
}
