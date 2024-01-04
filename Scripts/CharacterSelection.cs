using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    private GameObject[] characterList;
    private int index;

    private void Start()
    {
        index = PlayerPrefs.GetInt("CharacterSelected");

        characterList = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            characterList[i] = transform.GetChild(i).gameObject;
        }

        // Make sure all characters are initially set to inactive.
        SetAllCharactersInactive();

        if (index >= 0 && index < characterList.Length)
        {
            characterList[index].SetActive(true);
        }
        else
        {
            // Handle the case where the saved index is out of bounds.
            index = 0;
            characterList[index].SetActive(true); // Set the first character as the default.
        }
    }

    private void SetAllCharactersInactive()
    {
        foreach (GameObject go in characterList)
        {
            go.SetActive(false);
        }
    }

    public void ToggleLeft()
    {
        characterList[index].SetActive(false);

        index--;
        if (index < 0)
        {
            index = characterList.Length - 1;
        }

        characterList[index].SetActive(true);
    }

    public void ToggleRight()
    {
        characterList[index].SetActive(false);

        index++;
        if (index == characterList.Length)
        {
            index = 0;
        }

        characterList[index].SetActive(true);
    }

    public void ConfirmButton()
    {
        PlayerPrefs.SetInt("CharacterSelected", index);
        PlayerPrefs.Save(); // Make sure PlayerPrefs changes are saved.
        SceneManager.LoadScene("Game");
    }
}
