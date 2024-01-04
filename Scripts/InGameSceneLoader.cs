using UnityEngine;
using UnityEngine.SceneManagement;


public class IngGameSceneLoader : MonoBehaviour
{
    public string sceneName; // The name of the scene you want to load

    public void ChangeSceneWithWarning()
    {
        // Display a warning dialog box or perform any other desired actions
        // You can customize the warning message or implement your own dialog system

        Debug.Log("Are you sure you want to change the scene?"); // Example warning message

        // Call a function to display a dialog box or perform any other desired actions

        // Assuming the player confirms the change, load the new scene
        ChangeScene();
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}