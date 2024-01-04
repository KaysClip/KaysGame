using UnityEngine;

public class HotkeyManager : MonoBehaviour
{
    [System.Serializable]
    public class Hotkey
    {
        public KeyCode key;
        public GameObject associatedButton;
    }

    public Hotkey[] hotkeys;

    void Update()
    {
        // Check for hotkey presses
        foreach (Hotkey hotkey in hotkeys)
        {
            if (Input.GetKeyDown(hotkey.key))
            {
                // Perform the button action
                if (hotkey.associatedButton != null)
                {
                    hotkey.associatedButton.GetComponent<ButtonAction>().OnClick();
                }
            }
        }
    }
}

public class ButtonAction : MonoBehaviour
{
    public void OnClick()
    {
        // Define the action to be performed when the associated button is clicked
        Debug.Log("Button Clicked!");
    }
}
