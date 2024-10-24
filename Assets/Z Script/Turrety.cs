using UnityEngine;

public class TurretMover : MonoBehaviour
{
    // Snelheid van de rotatie
    public float rotationSpeed = 30f;

    // De huidige rotatiehoek van de turret
    private float currentRotation = 0f;

    // Maximale hoeken om te draaien
    private float leftLimit = 0f;
    private float rightLimit = 80f;

    // Vlag om bij te houden in welke richting de turret draait
    private bool rotatingRight = true;

    void Update()
    {
        // Beweeg de turret afhankelijk van de draairichting
        if (rotatingRight)
        {
            currentRotation += rotationSpeed * Time.deltaTime;

            // Controleer of de turret 80 graden heeft bereikt
            if (currentRotation >= rightLimit)
            {
                currentRotation = rightLimit; // Beperk de rotatie
                rotatingRight = false; // Verander de draairichting
            }
        }
        else
        {
            currentRotation -= rotationSpeed * Time.deltaTime;

            // Controleer of de turret 0 graden heeft bereikt
            if (currentRotation <= leftLimit)
            {
                currentRotation = leftLimit; // Beperk de rotatie
                rotatingRight = true; // Verander de draairichting
            }
        }

        // Pas de rotatie toe op de turret
        transform.eulerAngles = new Vector3(0, currentRotation, 0);
    }
}
