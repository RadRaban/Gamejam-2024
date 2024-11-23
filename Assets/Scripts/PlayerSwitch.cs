using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;
using UnityEngine.TextCore.Text;

public class CharacterManager : MonoBehaviour
{
    public GameObject[] characters; // Assign characters in the inspector
    private int currentCharacterIndex = 0;
    //int curChar;
    int perwChar;
    int nextChar;
    public CinemachineVirtualCamera cam; // Assign virtual camera in the inspector

    void Start()
    {
        UpdateControl(currentCharacterIndex);
        cam.LookAt = characters[currentCharacterIndex].transform.GetChild(0);
        cam.Follow = characters[currentCharacterIndex].transform.GetChild(0);
    }

    void Update()
    {
        // Example input for switching: Press "Tab" to switch characters
        if (Keyboard.current.tabKey.wasPressedThisFrame)
        {
            Debug.Log("Tab key was pressed");
            // Check if the next character is too far away
            foreach (GameObject character in characters)
            {
                if (character == characters[currentCharacterIndex])
                {
                    continue;
                }
                if (character == characters[perwChar])
                {
                    continue;
                }
                Debug.Log(Vector3.Distance(characters[currentCharacterIndex].transform.position, character.transform.position));
                if (Vector3.Distance(characters[currentCharacterIndex].transform.position, character.transform.position) < 5f)
                {
                    Debug.Log("Close enough");
                    nextChar = System.Array.IndexOf(characters, character);
                    break;
                }
            }
            //if (Vector3.Distance(characters[currentCharacterIndex].transform.position, characters[(currentCharacterIndex + 1) % characters.Length].transform.position) > 5f)
            //{
            //    Debug.Log("Too far away from the next character");
            //    currentCharacterIndex = curChar;
            //    return;
            //}
            Debug.Log("Switching to next character");
            //UpdateControl(currentCharacterIndex);
            SwitchToNextCharacter();
        }
    }

    public void SwitchToNextCharacter()
    {
        Debug.Log("Switching to next character is in progress");
        // Disable current character
        SetCharacterControl(currentCharacterIndex, false);

        // Move to the next character
        //currentCharacterIndex = (currentCharacterIndex + 1) % characters.Length;
        if (nextChar == currentCharacterIndex)
        {
            if (Vector3.Distance(characters[currentCharacterIndex].transform.position, characters[perwChar].transform.position) < 5f)
            {
                Debug.Log("Close enough");
                currentCharacterIndex = perwChar;
                nextChar = perwChar;
            }
            
        }
        else
        {
            perwChar = currentCharacterIndex;
            currentCharacterIndex = nextChar;
        }

        // Enable the new character
        SetCharacterControl(currentCharacterIndex, true);
    }

    private void UpdateControl(int characterIndex)
    {
        // Disable input for all characters except the one at characterIndex
        for (int i = 0; i < characters.Length; i++)
        {
            SetCharacterControl(i, i == characterIndex);
        }
    }

    private void SetCharacterControl(int characterIndex, bool isActive)
    {
        var playerInput = characters[characterIndex].GetComponent<PlayerInput>();
        if (playerInput != null)
        {
            playerInput.enabled = isActive;
        }
        if (isActive)
        {
            cam.LookAt = characters[characterIndex].transform.GetChild(0);
            cam.Follow = characters[characterIndex].transform.GetChild(0);
        }
        
    }
}
