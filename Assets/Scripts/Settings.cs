using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    [SerializeField] public GameObject mainMenuUI;
    [SerializeField] public GameObject settingsMenuUI;
    public void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void Back()
    {
        mainMenuUI.SetActive(true);
        settingsMenuUI.SetActive(false);
    }
}
