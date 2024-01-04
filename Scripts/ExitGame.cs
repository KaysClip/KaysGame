using UnityEngine;

public class ExitGame : MonoBehaviour
{
    // This function will be called when the attached button is clicked
    public void ExitGameButtonClicked()
    {
        // Check if the application is running in the Unity Editor
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // If not running in the editor, quit the application
        Application.Quit();
#endif
    }
}
