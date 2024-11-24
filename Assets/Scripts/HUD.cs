using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TMPro;
using TMPro.Examples;

public class HUDUI : MonoBehaviour
{
    public TextMeshProUGUI counterText;
    [SerializeField] public GameObject StoryUI;
    [SerializeField] public GameObject InstructionUI;

    public GameObject[] fiolki;
    public int ile = 0;

    public int s;

    private void Start()
    {
        fiolki = GameObject.FindGameObjectsWithTag("Fiolka");
        ile = fiolki.Length;
        s = scoring.score;
        counterText.text = (s/50) + " / " + ile;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) && (StoryUI.activeSelf || InstructionUI.activeSelf))
        {
            SwitchHud();
        }
    }

    void FixedUpdate()
    {
        s = scoring.score;
        counterText.text = (s / 50) + " / " + ile;
    }

    void SwitchHud()
    {
        if (StoryUI.activeSelf)
        {
            NestScreen();
        }
        else
        {
            BackToGame();
        }

        void NestScreen()
        {
            StoryUI.SetActive(false);
            InstructionUI.SetActive(true);
        }
        void BackToGame()
        {
            InstructionUI.SetActive(false);
        }
    }
}
