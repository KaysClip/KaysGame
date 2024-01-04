using System;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public DatabaseBridge databaseBridge;
    public string objectId = "1";
    private Animator animator;

    public event Action<string> OnInteract;

    public float xCoordinate;
    public float yCoordinate;
    public float zCoordinate;
    public float yRotation;

    public Vector3 positionOffset;
    public Vector3 rotationEulerAngles = new Vector3(0f, 0f, 0f);
    public Vector3 scaleMultiplier = new Vector3(1f, 1f, 1f);

    private void Awake()
    {
        animator = GetComponent<Animator>();
        
    }
    void Start()
    {
        databaseBridge = FindObjectOfType<DatabaseBridge>();

        if (databaseBridge == null)
        {
            Debug.LogError("DatabaseBridge component not found in the scene.");
        }
        else
        {
            databaseBridge.FetchCoordinatesForObject(objectId);
        }
    }

    // This method is called by DatabaseBridge to set the interactable data
    public void SetInteractableData(string[] coordinates)
    {
        Debug.Log("Coordinates Length: " + coordinates.Length);
        if (coordinates != null && coordinates.Length >= 4)
        {
            xCoordinate = float.Parse(coordinates[0]);
            yCoordinate = float.Parse(coordinates[1]);
            zCoordinate = float.Parse(coordinates[2]);
            yRotation = float.Parse(coordinates[3]);

            positionOffset = new Vector3(xCoordinate, yCoordinate, zCoordinate);
            rotationEulerAngles = new Vector3(0f, yRotation, 0f);
        }
        else
        {
            Debug.LogError("Data not available from DatabaseBridge.");
        }
    }

    void Update()
    {
        transform.position = positionOffset;
        transform.rotation = Quaternion.Euler(rotationEulerAngles);
        transform.localScale = scaleMultiplier;
    }

    public void Interact()
    {
        Debug.Log("It works!");
        animator.SetTrigger("Talk");
        OnInteract?.Invoke(objectId);
    }
}
