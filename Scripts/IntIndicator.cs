using UnityEngine;

public class IntIndicator : MonoBehaviour
{
    void Update()
    {
        // Ensure the sprite always faces the main camera
        transform.LookAt(Camera.main.transform);
    }
}
