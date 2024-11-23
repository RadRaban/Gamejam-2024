using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class CharacterManager : MonoBehaviour
{
    public GameObject[] characters; // Assign characters in the inspector
    private int currentCharacterIndex = 0;
    int curChar;
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
            curChar = currentCharacterIndex;
            // Check if the next character is too far away
            if (Vector3.Distance(characters[currentCharacterIndex].transform.position, characters[(currentCharacterIndex + 1) % characters.Length].transform.position) > 5f)
            {
                Debug.Log("Too far away from the next character");
                currentCharacterIndex = curChar;
                return;
            }
            SwitchToNextCharacter();
        }
    }

    public void SwitchToNextCharacter()
    {
        Debug.Log("Switching to next character");
        // Disable current character
        SetCharacterControl(currentCharacterIndex, false);

        // Move to the next character
        currentCharacterIndex = (currentCharacterIndex + 1) % characters.Length;

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
        cam.LookAt = characters[characterIndex].transform.GetChild(0);
        cam.Follow = characters[characterIndex].transform.GetChild(0);
    }
}
