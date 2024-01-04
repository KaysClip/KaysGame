using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class InteractionScript : MonoBehaviour
{
    private DatabaseBridge databaseBridge;
    private Interactable interactable;
    private bool playerInRange;
    public GameObject InteractBtn;
    public GameObject MapBtn;
    private ObjectActivator objectActivator;

    private void Awake()
    {
        interactable = GetComponent<Interactable>();
        if (interactable == null)
        {
            Debug.LogError("Interactable component not found on this GameObject.");
        }

        // Find the DatabaseBridge script on the same GameObject
        databaseBridge = GetComponent<DatabaseBridge>();
        if (databaseBridge == null)
        {
            Debug.LogError("DatabaseBridge component not found on this GameObject.");
        }

        // Find the ObjectActivator script in the scene
        objectActivator = FindObjectOfType<ObjectActivator>();
        if (objectActivator == null)
        {
            Debug.LogError("ObjectActivator script not found in the scene.");
        }
    }

    void Start()
    {
        InteractBtn.SetActive(false);

        Button intbtn = InteractBtn.GetComponent<Button>();
        intbtn.onClick.AddListener(TaskOnClick);

        Button mapbtn = MapBtn.GetComponent<Button>();
        mapbtn.onClick.AddListener(MapBtnOnClick);
    }

    void Update()
    {
        // Your update logic here...
    }

    public void ShowBtn()
    {
        InteractBtn.SetActive(true);
    }

    public void HideBtn()
    {
        InteractBtn.SetActive(false);

        // Deactivate all assigned GameObjects when hiding the button
        
    }

    void MapBtnOnClick()
    {
        Destroy(databaseBridge.instantiatedObject);
    }

    void TaskOnClick()
    {
        Interact();
        objectActivator.ActivateDeactivateObjects(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            ShowBtn();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            HideBtn();
            objectActivator.ActivateDeactivateObjects(true);
            playerInRange = false;
            //Destroy(databaseBridge.instantiatedObject);
        }
        Destroy(databaseBridge.instantiatedObject);
    }

    void Interact()
    {
        if (playerInRange)
        {
            interactable.Interact();
            
            if (interactable != null && databaseBridge != null)
            {
                string objectId = interactable.objectId;
                databaseBridge.FetchDataForObject(objectId);
                HideBtn();
            }
        }
    }
}
