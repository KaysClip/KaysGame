using System;
using UnityEngine;

public class FTLocation : MonoBehaviour
{ 
    public FTBridge ftbridge;
    public string ftId ="1";

    public float xPos;
    public float yPos;
    public float zPos;
    public float yRotPos;

    public Vector3 positionOffset;
    public Vector3 rotationEulerAngles = new Vector3(0f, 0f, 0f);
    public Vector3 scaleMultiplier = new Vector3(1f, 1f, 1f);

    private void Awake()
    {
    }

    void Start()
    {
        ftbridge = FindObjectOfType<FTBridge>();

        if (ftbridge == null)
        {
            Debug.LogError("DatabaseBridge component not found in the scene.");
        }
        else
        {
            ftbridge.FetchFTPos(ftId);
        }
    }

    // This method is called by DatabaseBridge to set the interactable data
    public void SetFTPos(string[] ft_pos)
    {
        Debug.Log("Coordinates Length: " + ft_pos.Length);
        if (ft_pos != null && ft_pos.Length >= 4)
        {
            Debug.Log("FTL X("+ft_pos[0]+")FTL Y("+ft_pos[1]+")FTL Z("+ft_pos[2]+")FTL RY("+ft_pos[3]+")");
            
            xPos = float.Parse(ft_pos[0]);
            yPos = float.Parse(ft_pos[1]);
            zPos = float.Parse(ft_pos[2]);
            yRotPos = float.Parse(ft_pos[3]);

            positionOffset = new Vector3(xPos, yPos, zPos);
            rotationEulerAngles = new Vector3(0f, yRotPos, 0f);
        }
        else
        {
            Debug.LogError("Data not available from Fasttravel Data Bridge.");
        }
    }

    void Update()
    {
        transform.position = positionOffset;
        transform.rotation = Quaternion.Euler(rotationEulerAngles);
        transform.localScale = scaleMultiplier;
    }
}
