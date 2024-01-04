using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaTrigger : MonoBehaviour
{
    // The GameObject you want to activate/deactivate
    public GameObject objectToActivate;

    
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider that triggered this is the player
        if (other.CompareTag("Player"))
        {
            // Set the objectToActivate to active
            if (objectToActivate != null)
            {
                objectToActivate.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the collider that exited is the player
        if (other.CompareTag("Player"))
        {
            // Set the objectToActivate to inactive
            if (objectToActivate != null)
            {
                objectToActivate.SetActive(false);
            }
        }
    }

    public void SetActiveFalse()
    {
        objectToActivate.SetActive(false);
    }
}
