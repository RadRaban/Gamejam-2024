using UnityEngine;

public class PlayerSpriteController : MonoBehaviour
{
    public Sprite forwardSprite; // Assign the sprite for when the player walks toward the camera
    public Sprite backSprite;    // Assign the sprite for when the player walks away from the camera

    private SpriteRenderer spriteRenderer;
    private Transform mainCameraTransform;
    private Vector3 lastPosition;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer component missing on player!");
        }

        mainCameraTransform = Camera.main.transform; // Get the main camera's transform
        lastPosition = transform.position; // Store the initial position of the player
    }

    void Update()
    {
        // Always face the camera
        FaceCamera();

        // Update sprite based on movement direction
        UpdateSpriteDirection();
    }

    private void FaceCamera()
    {
        // Make the sprite face the camera by matching its rotation to the camera's rotation
        Vector3 cameraDirection = mainCameraTransform.forward;
        transform.forward = new Vector3(cameraDirection.x, 0, cameraDirection.z); // Ignore y-axis for 2D sprite
    }

    private void UpdateSpriteDirection()
    {
        // Calculate the movement direction
        Vector3 movement = transform.position - lastPosition;

        // Determine if the player is moving toward or away from the camera
        Vector3 toCamera = (mainCameraTransform.position - transform.position).normalized;
        float dotProduct = Vector3.Dot(movement.normalized, toCamera);

        // If dot product is positive, player is walking toward the camera; else away
        if (dotProduct > 0)
        {
            spriteRenderer.sprite = forwardSprite; // Walking toward the camera
        }
        else if (dotProduct < 0)
        {
            spriteRenderer.sprite = backSprite; // Walking away from the camera
        }

        // Update the last position
        lastPosition = transform.position;
    }
}
