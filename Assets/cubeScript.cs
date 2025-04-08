using UnityEngine;

public class cubeScript : MonoBehaviour
{
    const float z1 = 1.33f;
    const float z2 = -1.304f;
    bool movingRight = true;
    private Rigidbody rb; // Reference to the platform's Rigidbody
    public float movementSpeed = 3f; // Units per second (adjust as needed)

    void Start()
    {
        // Get the Rigidbody component and set it to kinematic
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true; // Critical for MovePosition to work correctly
    }

    void FixedUpdate() // Use FixedUpdate for physics-based updates
    {
        // Check current position to reverse direction
        if (transform.localPosition.z >= z1)
        {
            movingRight = false;
        }
        else if (transform.localPosition.z <= z2)
        {
            movingRight = true;
        }

        // Calculate movement direction
        float direction = movingRight ? 1f : -1f;
        Vector3 movement = Vector3.forward * (movementSpeed * direction * Time.fixedDeltaTime);

        // Apply movement using physics
        rb.MovePosition(rb.position + movement);
    }
}