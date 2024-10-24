using UnityEngine;

public class PlaneCircularMover : MonoBehaviour
{
    public float rotationSpeed = 30f; // Speed of rotation in degrees per second
    public float moveSpeed = 10f;     // Speed of forward movement in units per second

    private void Update()
    {
        // Rotate around the Y-axis (the parent object's local space)
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);

        // Move the plane forward in the direction it's currently facing
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }
}
