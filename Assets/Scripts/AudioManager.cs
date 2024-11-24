using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Sources")]
    [SerializeField] AudioSource SFXSource;
    [SerializeField] AudioSource MusicSource;

    [Header("Audio Clips")]
    public AudioClip background;
    public AudioClip pipes;
    public AudioClip jump;
    public AudioClip buttonPressed;
    public AudioClip buttonReleased;
    public AudioClip characterChange;
    public AudioClip doorOpen;
    public AudioClip doorClose;
    public AudioClip pickUp;

    Scene m_Scene;
    string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        m_Scene = SceneManager.GetActiveScene();
        sceneName = m_Scene.name;
        Debug.Log("Scena: " + sceneName);
        if (sceneName == "End")
        {
            MusicSource.clip = pipes;
            MusicSource.Play(); ;
        }
        else
        {
            MusicSource.clip = background;
            MusicSource.Play();
        }
        
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
