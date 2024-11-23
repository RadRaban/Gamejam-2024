using UnityEngine;

public class CursorManager : MonoBehaviour
{
    void Start()
    {
        // Lock the cursor to the center of the screen
        Cursor.lockState = CursorLockMode.Locked;

        // Make the cursor invisible
        Cursor.visible = false;

        // Focus the game window
        FocusGameWindow();
    }

    void FocusGameWindow()
    {
#if UNITY_EDITOR
        // Unity Editor-specific behavior
        UnityEditor.EditorWindow.focusedWindow.maximized = true;
#else
        // For standalone builds, this usually ensures the game window is focused
        Screen.fullScreen = true;
#endif
    }

    void OnApplicationFocus(bool hasFocus)
    {
        if (hasFocus)
        {
            // Ensure cursor remains locked and hidden when the application regains focus
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
