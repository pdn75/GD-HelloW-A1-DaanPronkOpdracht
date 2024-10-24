using UnityEngine;

public class AutoController : MonoBehaviour
{
    // Snelheid van de beweging
    public float speed = 5f;

    // Draaisnelheid
    public float turnSpeed = 200f;

    // Weg blijven binnen deze waardes
    public float leftLimit = -8f;
    public float rightLimit = 8f;
    public float forwardLimit = 20f;

    // Raycasting parameters
    public float detectionDistance = 3f; // Afstand voor obstakeldetectie
    public LayerMask obstacleMask; // Laag voor obstakeldetectie

    // Tijdelijke variabelen
    private bool isMovingToTarget = false; // Of de auto naar de doelpositie beweegt
    private Vector3 targetPosition; // Doelpositie

    void Start()
    {
        // Kies een random startpositie
        SetRandomTargetPosition();
    }

    void Update()
    {
        // Zorg ervoor dat de auto binnen de grenzen blijft
        Vector3 position = transform.position;
        position.x = Mathf.Clamp(position.x, leftLimit, rightLimit);
        position.z = Mathf.Clamp(position.z, -Mathf.Infinity, forwardLimit);
        transform.position = position;

        // Als de auto naar de doelpositie beweegt
        if (isMovingToTarget)
        {
            // Beweeg de auto naar de doelpositie
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

            // Controleer of de auto de doelpositie heeft bereikt
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                isMovingToTarget = false; // Stop met bewegen
                // Kies een nieuwe random doelpositie
                SetRandomTargetPosition();
                isMovingToTarget = true; // Begin opnieuw met bewegen naar de nieuwe doelpositie
            }

            // Controleer voor obstakels
            AvoidObstacles();
        }
        else
        {
            isMovingToTarget = true; // Begin met bewegen naar de doelpositie
        }

        // Draai de auto in de richting van de doelpositie
        if (isMovingToTarget)
        {
            Vector3 targetDirection = (targetPosition - transform.position).normalized;
            float step = turnSpeed * Time.deltaTime;
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, step, 0.0f);
            transform.rotation = Quaternion.LookRotation(newDirection);
        }
    }

    private void SetRandomTargetPosition()
    {
        // Genereer een random positie binnen de grenzen
        float randomX = Random.Range(leftLimit, rightLimit);
        float randomZ = Random.Range(0f, forwardLimit);
        targetPosition = new Vector3(randomX, transform.position.y, randomZ);
    }

    private void AvoidObstacles()
    {
        // Raycast naar voren om obstakels te detecteren
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, detectionDistance, obstacleMask))
        {
            // Als er een obstakel is, kies een nieuwe doelpositie
            SetRandomTargetPosition();
        }
    }

    private void OnDrawGizmos()
    {
        // Gizmos voor visualisatie van de raycast
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * detectionDistance);
    }
}
