using TMPro.Examples;
using UnityEngine;

public class FootstepManager : MonoBehaviour
{
    public LayerMask groundLayer; // Define what is considered ground
    public AudioSource audioSource; // The AudioSource component
    public AudioClip defaultFootstep; // Default sound if no specific surface is detected
    public FootstepSound[] surfaceSounds; // Array to define surface-specific sounds

    private CharacterController characterController;
    private string currentSurfaceTag; // Stores the most recently detected surface tag
    private string previousSurfaceTag; // Stores the most recently detected surface tag
    private float surfaceRecheckInterval = 0.5f; // Time interval to recheck the surface
    private float surfaceRecheckTimer = 0f; // Timer to track intervals

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        currentSurfaceTag = GetSurfaceTag(); // Initial surface check
        previousSurfaceTag = currentSurfaceTag;
    }

    void Update()
    {
        // Timer-based surface recheck
        surfaceRecheckTimer += Time.deltaTime;
        if (surfaceRecheckTimer >= surfaceRecheckInterval)
        {
            surfaceRecheckTimer = 0f; // Reset timer
            currentSurfaceTag = GetSurfaceTag(); // Update surface tag
            Debug.Log("Rechecked surface: " + (currentSurfaceTag ?? "None"));
        }

        // Check if the player is moving and on the ground
        if (characterController.isGrounded && characterController.velocity.magnitude > 0.1f)
        {
            if (currentSurfaceTag != previousSurfaceTag)
            {
                Debug.Log("Surface changed from " + previousSurfaceTag + " to " + currentSurfaceTag);
                previousSurfaceTag = currentSurfaceTag;
                StopFootstep();
                PlayFootstep();
            }
            // Play footsteps on a timer or based on distance moved
            if (!audioSource.isPlaying) // Ensure sounds don't overlap
            {
                PlayFootstep();
            }
        }
        if (characterController.isGrounded && characterController.velocity.magnitude < 0.1f)
        {
            StopFootstep();
        }
    }

    private void StopFootstep()
    {
        audioSource.Stop();
    }

    private void PlayFootstep()
    {
        AudioClip clip = GetFootstepSound(currentSurfaceTag); // Use the current surface tag
        Debug.Log("Playing footstep sound: " + clip.name);
        audioSource.PlayOneShot(clip);
    }

    private string GetSurfaceTag()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 5f, groundLayer))
        {
            Debug.Log("Surface tag detected: " + hit.collider.tag);
            return hit.collider.tag; // Get the tag of the surface
        }

        return null;
    }

    private AudioClip GetFootstepSound(string surfaceTag)
    {
        foreach (FootstepSound sound in surfaceSounds)
        {
            if (sound.surfaceTag == surfaceTag)
            {
                return sound.clip;
            }
        }

        return defaultFootstep; // Fallback to default sound
    }
}

[System.Serializable]
public class FootstepSound
{
    public string surfaceTag; // Surface tag (e.g., "Grass," "Wood")
    public AudioClip clip;    // Footstep sound for that surface
}
