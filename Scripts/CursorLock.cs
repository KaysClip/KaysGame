using UnityEngine;

public class CursorLock : MonoBehaviour
{
    void Start()
    {
        UnlockCursor();
    }

    public void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Add other methods or logic as needed...
}

