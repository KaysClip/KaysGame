using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonUi : MonoBehaviour
{

    
    [SerializeField] private string sceneName;
    public void MapButton(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
