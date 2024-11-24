using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;

public class PickUpPoint : MonoBehaviour
{
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public bool Picked = false;
    private void OnTriggerEnter(Collider other)
    {
        if ((other.tag == "HeavyPlayer" || other.tag == "Player") && !Picked)
        {
            Picked = true;
            audioManager.PlaySFX(audioManager.pickUp);
            Debug.Log("Pick Up Triggered");
            scoring.score += 50;
            Debug.Log("Score: " + scoring.score);
            Destroy(gameObject);
        }
    }

}
