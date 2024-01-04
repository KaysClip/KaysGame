using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class SetActiveScript : MonoBehaviour
{
    [Serializable]
    public class GameObjectButtonPair
    {
        public Button button;
        public List<GameObject> gameObjects; // Use a List to store multiple game objects
    }

    public List<GameObjectButtonPair> gameObjectButtonPairs;

    private void Start()
    {
        foreach (var pair in gameObjectButtonPairs)
        {
            if (pair.button != null)
            {
                pair.button.onClick.AddListener(() => TaskOnEnter(pair.gameObjects));
            }
            else
            {
                Debug.LogError("Button component not found on GameObjectButtonPair.");
            }
        }
    }

    public void Show(GameObject obj)
    {
        // Activate the map selection UI when called
        obj.SetActive(true);
    }

    public void Hide(GameObject obj)
    {
        // Deactivate the map selection UI when called
        obj.SetActive(false);
    }

    void TaskOnEnter(List<GameObject> objectsToToggle)
    {
        // Toggle the state of all game objects in the list
        foreach (var obj in objectsToToggle)
        {
            obj.SetActive(!obj.activeSelf);
        }
    }
}
