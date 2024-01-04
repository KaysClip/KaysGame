using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    private TextMeshProUGUI diamondText;

    // Start is called before the first frame update
    void Start()
    {
        // Use GetComponentInChildren if the TextMeshProUGUI is a child of the InventoryUI GameObject
        diamondText = GetComponentInChildren<TextMeshProUGUI>();

        // If the TextMeshProUGUI is not a child, you may use FindObjectOfType
        // diamondText = FindObjectOfType<TextMeshProUGUI>();
    }

    // Update is called once per frame
    public void UpdateDiamondText(PlayerInventory playerInventory)
    {
        diamondText.text = playerInventory.NumberOfDiamonds.ToString();
    }
}
