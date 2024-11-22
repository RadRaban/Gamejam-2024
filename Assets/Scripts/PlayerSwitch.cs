using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterManager : MonoBehaviour
{
    public GameObject[] characters; // Assign characters in the inspector
    private int currentCharacterIndex = 0;

    void Start()
    {
        UpdateControl(currentCharacterIndex);
    }

    void Update()
    {
        // Example input for switching: Press "Tab" to switch characters
        if (Keyboard.current.tabKey.wasPressedThisFrame)
        {
            SwitchToNextCharacter();
        }
    }

    public void SwitchToNextCharacter()
    {
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
    }
}
