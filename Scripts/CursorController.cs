using UnityEngine;

public class CursorController : MonoBehaviour
{
    private bool cursorVisible = true;

    private void Start()
    {
        // Ensure the cursor is visible at the beginning (optional)
        Cursor.visible = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl)) // You can change KeyCode.Space to any key you want
        {
            ToggleCursorVisibility();
        }
    }

    private void ToggleCursorVisibility()
    {
        cursorVisible = !cursorVisible;
        Cursor.visible = cursorVisible;

        // Lock the cursor when it is invisible to keep it centered (optional)
        Cursor.lockState = cursorVisible ? CursorLockMode.None : CursorLockMode.Locked;
    }
}