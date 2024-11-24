using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] public GameObject mainMenuUI;
    [SerializeField] public GameObject settingsMenuUI;
    public void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("Testing");
    }

    public void ShowSettings()
    {
        mainMenuUI.SetActive(false);
        settingsMenuUI.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
