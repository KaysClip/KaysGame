using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PositionTracker : MonoBehaviour
{
    public Transform objectToTrack;
    public TMP_Text positionText;

    private void Update()
    {
        if (objectToTrack != null && positionText != null)
        {
            Vector3 position = objectToTrack.position;
            positionText.text = "Position: X=" + position.x + " Y=" + position.y + " Z=" + position.z;
        }
    }
}
