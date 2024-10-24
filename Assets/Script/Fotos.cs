using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    public float snelheid = 5f; // Snelheid van de beweging
    public Vector3 richting = new Vector3(1, 0, 0); // Richting van de beweging (X-as)

    void Update()
    {
        // Beweeg het object
        transform.position += richting.normalized * snelheid * Time.deltaTime;
    }
}
