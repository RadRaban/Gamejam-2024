using UnityEngine;

public class PlayerTiltAnimation : MonoBehaviour
{
    public float tiltAngle = 10f; // Maximum tilt angle in degrees
    public float tiltSpeed = 5f; // Speed of tilting
    public float straightenSpeed = 3f; // Speed of returning to upright position

    private Rigidbody2D rb; // Replace with Rigidbody for 3D or other movement system
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Ensure your player has a Rigidbody2D
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        // Calculate tilt based on movement
        float horizontalMovement = rb.velocity.x;

        if (Mathf.Abs(horizontalMovement) > 0.1f) // If player is moving
        {
            // Calculate tilt direction (left or right)
            float tilt = -Mathf.Sign(horizontalMovement) * tiltAngle;

            // Smoothly rotate to target tilt
            Quaternion targetRotation = Quaternion.Euler(0, 0, tilt);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * tiltSpeed);
        }
        else
        {
            // Straighten the sprite when stopping
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, Time.deltaTime * straightenSpeed);
        }
    }
}
