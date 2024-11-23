using UnityEngine;

public class DoorOnButton : MonoBehaviour, IDoor
{
    private bool isOpen = false;
    public bool opening = false;
    public bool closing = false;
    public Transform start;
    public Transform end;

    [Range(0, 1)] public float lerpValue = 0f; // Tracks the progress of the lerp
    public float lerpSpeed = 1f; // Speed of door movement

    private void FixedUpdate()
    {
        if (opening)
        {
            // Smoothly increase lerpValue toward 1
            lerpValue += Time.deltaTime * lerpSpeed;
            if (lerpValue >= 1f)
            {
                lerpValue = 1f;
                opening = false; // Stop once fully open
            }
        }
        else if (closing)
        {
            // Smoothly decrease lerpValue toward 0
            lerpValue -= Time.deltaTime * lerpSpeed;
            if (lerpValue <= 0f)
            {
                lerpValue = 0f;
                closing = false; // Stop once fully closed
            }
        }

        // Lerp the position of the door but only child object code
        transform.GetChild(0).position = Vector3.Lerp(start.position, end.position, lerpValue);



        // Interpolate the position based on lerpValue
        //transform.position = Vector3.Lerp(start.position, end.position, lerpValue);

        //transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), lerpValue);
    }

    public void OpenDoor()
    {
        opening = true;
        closing = false;
    }

    public void CloseDoor()
    { 
        closing = true;
        opening = false;
    }

    public void ToggleDoor()
    {
        if (isOpen)
        {
            CloseDoor();
        }
        else
        {
            OpenDoor();
        }
        isOpen = !isOpen;
    }
}
