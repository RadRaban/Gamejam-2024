using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class HeavyButton : MonoBehaviour
{
    public bool isPressed = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "HeavyPlayer" && !isPressed)
        {
            isPressed = true;

            Debug.Log("Section Triggered");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && isPressed)
        {
            isPressed = false;
            Debug.Log("Heavy player is off the button");
        }
    }



}
    
