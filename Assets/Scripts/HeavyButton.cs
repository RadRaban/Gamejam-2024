using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyButton : MonoBehaviour
{
    public bool isPressed = false;
    private void OnTriggerEnter(Collider other)
    {


        if (other.CompareTag("Heavy Player") && isPressed == false)
        {
            isPressed = true;
            Debug.Log("Heavy player is on the button");

        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Heavy Player") && isPressed == true)
        {
            isPressed = false;
            Debug.Log("Heavy player is off the button");
        }
    }



}
    
