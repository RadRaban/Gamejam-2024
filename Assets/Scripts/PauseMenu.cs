using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] public GameObject pauseMenuUI; // Assign the Pause Menu UI Canvas here

    private bool isPaused = false;

    void Update()
    {
        // Toggle pause on Escape or P key
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        // Hide the pause menu and resume the game
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; // Resume time
        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        AudioListener.volume = 1;
    }

    public void PauseGame()
    {
        // Show the pause menu and stop the game
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; // Stop time
        isPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        AudioListener.volume = 0;
    }

    public void LoadMainMenu()
    {
        // Resume time before switching scenes
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        AudioListener.volume = 1;
        SceneManager.LoadScene("MainMenu"); // Replace "MainMenu" with your scene name
    }
}
