using UnityEngine;
using TMPro;

public class FPSCounter : MonoBehaviour
{
    public TMP_Text fpsText;
    public float updateRate = 0.5f; // Update rate in seconds

    private float accumulatedTime = 0f;
    private int frameCount = 0;
    private float fps = 0;

    private void Update()
    {
        float deltaTime = Time.deltaTime;
        accumulatedTime += deltaTime;
        frameCount++;

        // Update the FPS every updateRate seconds
        if (accumulatedTime > updateRate)
        {
            fps = frameCount / accumulatedTime;
            frameCount = 0;
            accumulatedTime = 0;

            // Update the TextMeshPro Text
            if (fpsText != null)
            {
                fpsText.text = "FPS: " + Mathf.RoundToInt(fps);
            }
        }
    }
}
