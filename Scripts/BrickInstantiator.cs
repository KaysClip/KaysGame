using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BrickInstantiator : MonoBehaviour
{
    //private Alumni alumniData;
    //public GameObject Alumni;
    public SettingsManager settingsManager;
    public GameObject prefabToInstantiate;
    public GameObject parentObject;

    public string hostIPValue;

    private void Awake()
    {
        
        

        // Find the SettingsManager script in the scene
        settingsManager = FindObjectOfType<SettingsManager>();

        if (settingsManager != null)
        {
            // Access the hostIP value
            hostIPValue = settingsManager.GetHostIP();

            // Now you can use hostIPValue for further processing
            Debug.Log("Host IP from other script: " + hostIPValue);
        }
        else
        {
            Debug.LogWarning("SettingsManager script not found in the scene.");
        }

        FetchAlumniCount();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    
    public void InstantiateAlumniBrick(string alumniCountString)
    {
        // Convert the string to an integer
        if (int.TryParse(alumniCountString, out int alumniCount))
        {
            int j = 1; // Initialize j outside the loop if you want it to retain its value across iterations
            for (int i = 1; i <= alumniCount; i++)
            {
                if (prefabToInstantiate != null && parentObject != null)
                {
                    // Instantiate the prefab as a child of the specified parent
                    GameObject instantiatedPrefab = Instantiate(prefabToInstantiate, parentObject.transform);

                    // Assign the incremented integer i to alumniID
                    instantiatedPrefab.GetComponent<AlumniBridge>().alumniID = j.ToString();
                }
                j++;
            }
        }
        else
        {
            Debug.LogError("Failed to parse alumniCount as an integer.");
        }
    }

    

    public void FetchAlumniCount()
    {
        

        // Use alumniID parameter instead of alumniData.alumniID
        string url = hostIPValue+"/Tornare/alumniCount.php?";
        StartCoroutine(GetRequest(url));
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                    
                //If Fetch Success
                case UnityWebRequest.Result.Success:
                    string alumniCount = webRequest.downloadHandler.text;
                    
                    InstantiateAlumniBrick(alumniCount);


                    break;
            }
        }
    }
}
