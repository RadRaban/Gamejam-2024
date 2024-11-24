using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class HeavyPlate : MonoBehaviour
{
    [SerializeField] private GameObject door;

    private IDoor doorScript;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void Avake()
    {
        doorScript = door.GetComponent<IDoor>();
        Debug.Log(doorScript);
    }

    private void Start()
    {
        doorScript = door.GetComponent<IDoor>();
        Debug.Log(doorScript);
    }

    public bool isPressed = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "HeavyObject" && !isPressed)
        {
            isPressed = true;
            audioManager.PlaySFX(audioManager.buttonPressed);
            doorScript.ToggleDoor();
            Debug.Log("Section Triggered");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "HeavyObject" && isPressed)
        {
            isPressed = false;
            audioManager.PlaySFX(audioManager.buttonReleased);
            doorScript.ToggleDoor();
            Debug.Log("Heavy Object is off the button");
        }
    }



}
    
