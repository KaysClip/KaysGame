using UnityEngine;
using UnityEngine.UI;

public class AudioButton : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clickSound;

    private void Start()
    {
        // Get the AudioSource component if not assigned.
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
            if (audioSource == null)
            {
                Debug.LogError("AudioSource component not found.");
                this.enabled = false;
            }
        }

        // Ensure the AudioClip is assigned to play.
        if (clickSound == null)
        {
            Debug.LogError("Click Sound AudioClip is not assigned.");
            this.enabled = false;
        }
    }

    public void OnButtonClick()
    {
        // Play the audio clip from the start every time the button is clicked.
        if (clickSound != null)
        {
            //Debug.LogError("Clicked Sound");
            audioSource.clip = clickSound;
            audioSource.Play();
        }
    }
}
