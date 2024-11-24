using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using TMPro.Examples;

public class HUDUI : MonoBehaviour
{
    [SerializeField] public GameObject HUD;

    public TextMeshProUGUI counterText;

    public int s = scoring.score;
    //public int collected = s / 50;
    

    void FixedUpdate()
    {
        
    }


}
