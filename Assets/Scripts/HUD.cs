using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using TMPro;
using TMPro.Examples;

public class HUDUI : MonoBehaviour
{
    public TextMeshProUGUI counterText;

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

    void FixedUpdate()
    {
        s = scoring.score;
        counterText.text = (s / 50) + " / " + ile;
    }


}
