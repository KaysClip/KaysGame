using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI; // Add this line

public class ToggleDepthOfField : MonoBehaviour
{
    public PostProcessProfile postProcessProfile;
    public Button toggleButton; // Assign your UI button in the Inspector

    private DepthOfField depthOfField;

    private void Start()
    {
        if (postProcessProfile != null)
        {
            depthOfField = postProcessProfile.GetSetting<DepthOfField>();
        }
        else
        {
            Debug.LogError("PostProcessProfile is not assigned to ToggleDepthOfField script.");
        }

        // Attach the method to the button click event
        if (toggleButton != null)
        {
            toggleButton.onClick.AddListener(ToggleDepthOfFieldEffect);
        }
        else
        {
            Debug.LogError("Toggle Button is not assigned to ToggleDepthOfField script.");
        }
    }

    private void ToggleDepthOfFieldEffect()
    {
        if (depthOfField != null)
        {
            depthOfField.enabled.value = !depthOfField.enabled.value;
        }
        else
        {
            Debug.LogError("DepthOfField effect not found in the PostProcessProfile.");
        }
    }
}
