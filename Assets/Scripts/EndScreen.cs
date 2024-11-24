using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using TMPro;
using TMPro.Examples;

public class EndScreen : MonoBehaviour
{
    public int s;
    public TextMeshProUGUI counterText;

    private void Start()
    {
        s = scoring.score;
        counterText.text = "Score: " + s;
    }
    public void BackToMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }
}
