using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeleportManager : MonoBehaviour
{
    private DatabaseBridge databaseBridge;
    private InteractionScript interactionScript;
    public Transform[] teleportLocations; // An array of the teleport locations (set these in the Inspector)
    private int currentLocationIndex = 0; // Index to track the current teleport location
    public GameObject player; // Reference to the player GameObject
    public GameObject uiToDisable;

    private CharacterController characterController; // Reference to the character controller script

    void Start()
    {
        
        
        // Ensure there is at least one teleport location
        if (teleportLocations.Length == 0)
        {
            Debug.LogError("No teleport locations set!");
            enabled = false;
            return;
        }

        // Get the CharacterController script from the player GameObject
        if (player != null)
        {
            characterController = player.GetComponent<CharacterController>();
            if (characterController == null)
            {
                Debug.LogError("CharacterController component not found on the player GameObject!");
                enabled = false;
                return;
            }
        }
        else
        {
            Debug.LogError("Player GameObject not assigned!");
            enabled = false;
            return;
        }
    }
    

    // Function to teleport to the next location
    public void TeleportToNextLocation()
    {
        // Increment the index and loop back to 0 if necessary
        currentLocationIndex = (currentLocationIndex + 1) % teleportLocations.Length;
        // Teleport the player to the new location
        TeleportPlayer();
    }

    // Function to teleport to a specific location by index
    public void TeleportToLocation(int index)
    {
        if (index >= 0 && index < teleportLocations.Length)
        {
            currentLocationIndex = index;
            // Teleport the player to the new location
            TeleportPlayer();
        }
        else
        {
            Debug.LogError("Invalid teleport location index!");
        }
    }

    // Function to actually move the player to the current location and disable the UI
    private void TeleportPlayer()
    {

        if (characterController != null)
        {
            // Disable any relevant components or scripts on the character controller here if needed
            characterController.enabled = false; // Disable the character controller script temporarily

            // Teleport the player to the new location
            player.transform.position = teleportLocations[currentLocationIndex].position;

            // Re-enable any components or scripts that were disabled
            characterController.enabled = true; // Re-enable the character controller script

            // Disable the UI if a reference to the UI GameObject is provided
            if (uiToDisable != null)
            {
                uiToDisable.SetActive(false);
                
            }
            
        }
        else
        {
            Debug.LogError("CharacterController component not found on the player GameObject!");
        }
    }
}