using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public void ChangeSceneWithWarning(string sceneName)
    {
        // Display a warning dialog box or perform any other desired actions
        // You can customize the warning message or implement your own dialog system

        Debug.Log("Go back to main menu?"); // Example warning message

        // Call a function to display a dialog box or perform any other desired actions

        // Assuming the player confirms the change, load the new scene
        SceneManager.LoadScene(sceneName);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}