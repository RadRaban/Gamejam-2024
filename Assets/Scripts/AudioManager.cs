using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Sources")]
    [SerializeField] AudioSource SFXSource;
    [SerializeField] AudioSource MusicSource;

    [Header("Audio Clips")]
    public AudioClip background;
    public AudioClip buttonPressed;
    public AudioClip characterChange;
    public AudioClip doorOpen;
    public AudioClip doorClose;

    // Start is called before the first frame update
    void Start()
    {
        //MusicSource.clip = background;
        //MusicSource.loop = true;
        //MusicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}