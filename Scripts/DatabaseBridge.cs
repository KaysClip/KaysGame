using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Text.RegularExpressions;

public class DatabaseBridge : MonoBehaviour
{   
    //experiment with private/public
    public Interactable interactable;
    private InteractionScript interactionScript;
    public SettingsManager settingsManager;

    public GameObject instantiatedObject;
    public GameObject interactableContainer;
    public GameObject interactableTemplate;
    public string hostIPValue;
    public string formatted;

    public string[] intdesc;
    public string[] coordinates;

    // Add a public method to get intdesc
    // Add a public property to get intdesc
    public string[] Coordinates
    {
        get { return coordinates; }
    }
    

    private void Awake()
    {
        interactable = GetComponent<Interactable>();
        if (interactable == null)
        {
            Debug.LogError("Interactable component not found on this GameObject.");
        }

        

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

        FetchCoordinatesForObject(interactable.objectId);
    }
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void FetchDataForObject(string objectId)
    {
        if (interactable == null)
        {
            Debug.LogError("Interactable component is missing.");
            return;
        }

        // Construct the URL with the current objectId
        string url = hostIPValue+"/Tornare/interact.php?id=" + interactable.objectId;
        StartCoroutine(GetRequest(url));
    }

    public void FetchCoordinatesForObject(string objectId)
    {
        if (interactable == null)
        {
            Debug.LogError("Interactable component is missing.");
            return;
        }

        // Construct the URL with the current objectId
        string url = hostIPValue+"/Tornare/interact.php?id=" + interactable.objectId;
        StartCoroutine(GetPosition(url));
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


                        if (instantiatedObject != null)
                        {
                            DestroyImmediate(instantiatedObject);
                        }
                        Debug.Log("[InteractableName]-Not found will use default");

                        // Instantiate a duplicate of the template
                        instantiatedObject = Instantiate(interactableTemplate, interactableContainer.transform);
                        //instantiatedObject.GetComponent<DataViewer>().interactableName.text = intdesc[0];
                        //instantiatedObject.GetComponent<DataViewer>().interactableDesc.text = intdesc[1];
                        break;
                    case UnityWebRequest.Result.ProtocolError:
                        Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                        break;

                    //post
                    case UnityWebRequest.Result.Success:
                        string rawresponse = webRequest.downloadHandler.text;
                        string[] intrct = rawresponse.Split('*');

                        // Check if an object has already been instantiated
                        if (instantiatedObject != null)
                        {
                            DestroyImmediate(instantiatedObject);
                            //interactionScript.ShowBtn();
                            Debug.Log("");
                        }

                        for (int i = 0; i < intrct.Length; i++)
                        {
                            if (intrct[i] != "")
                            {
                                intdesc = intrct[i].Split('|');
                                Debug.Log("[InteractableName]-"+intdesc[0]+"[Description]-"+intdesc[1]+"[Position]-"+intdesc[2]+"");

                                coordinates = intdesc[2].Split(',');
                                Debug.Log("PosX()"+coordinates[0]+")PosY("+coordinates[1]+")PosZ("+coordinates[2]+")RotY("+coordinates[3]+")");
                                
                                

                                // Instantiate a duplicate of the template
                                instantiatedObject = Instantiate(interactableTemplate, interactableContainer.transform);
                                instantiatedObject.GetComponent<DataViewer>().interactableName.text = intdesc[0];

                                
                                Debug.Log(formatted);
                                
                                //formatted = Regex.Replace(intdesc[1], @"<p>(.*?)</p>", "<i>$1</i>");
                                //span
                                // Replace <strong> with <b>
                                formatted = Regex.Replace(intdesc[1], @"<strong>(.*?)</strong>", "<b>$1</b>");
                                //formatted = Regex.Replace(formatted, @"<em>(.*?)</em>", "<i>$1</i>");
                                formatted = Regex.Replace(formatted, @"<p>(.*?)", "<page>     $1");
                                formatted = Regex.Replace(formatted, @"</p>(.*?)", "$1");

                                instantiatedObject.GetComponent<DataViewer>().interactableDesc.text = formatted;
                                
                                instantiatedObject.GetComponent<DataViewer>().posx.text = coordinates[0];
                                instantiatedObject.GetComponent<DataViewer>().posy.text = coordinates[1];
                                instantiatedObject.GetComponent<DataViewer>().posz.text = coordinates[2];
                                
                            }
                        }

                        break;
                }
            }
        }

    






    
    IEnumerator GetPosition(string uri)
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


                        if (instantiatedObject != null)
                        {
                            DestroyImmediate(instantiatedObject);
                        }
                        Debug.Log("[InteractableName]-Not found will use default");
                        break;

                    case UnityWebRequest.Result.ProtocolError:
                        Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                        break;

                    //post
                    case UnityWebRequest.Result.Success:
                        string rawresponse = webRequest.downloadHandler.text;
                        string[] intrct = rawresponse.Split('*');

                        for (int i = 0; i < intrct.Length; i++)
                        {
                            if (intrct[i] != "")
                            {

                                intdesc = intrct[i].Split('|');
                                Debug.Log("[InteractableName]-"+intdesc[0]+"[Description]-"+intdesc[1]+"[Position]-"+intdesc[2]+"");
                                Debug.Log(intdesc[2]);
                                

                                string[] coordinates = intdesc[2].Split(',');
                                Debug.Log("PosX()"+coordinates[0]+")PosY("+coordinates[1]+")PosZ("+coordinates[2]+")RotY("+coordinates[3]+")");

                                /*
                                string[] intdesc = intrct[i].Split(''|'');
                                Debug.Log("[PosX]-"+intdesc[0]+"[PosY]-"+intdesc[1]+"[PosZ]-"+intdesc[2]+"[RotX]-"+intdesc[3]+"");
                                */

                                interactable.SetInteractableData(coordinates);
                            }
                        }
                        
                        break;
                }
            }
        }
}