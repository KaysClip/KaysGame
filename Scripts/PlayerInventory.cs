using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public int NumberOfDiamonds { get; private set; }

    public UnityEvent<PlayerInventory> OnDiamondCollected;

    public AudioSource audioSource; // Reference to the AudioSource component in the Unity Editor

    public void DiamondCollected()
    {
        NumberOfDiamonds++;

        // Play the collected sound if the AudioSource is set up
        if (audioSource != null)
        {
            audioSource.Play();
        }

        OnDiamondCollected.Invoke(this);
    }
}
