using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class FTBridge : MonoBehaviour
{
    private FTLocation ftlocation;
    public GameObject MapLocName;
    public SettingsManager settingsManager;

    public string hostIPValue;

    private void Awake()
    {
        ftlocation = GetComponent<FTLocation>();
        if (ftlocation == null)
        {
            Debug.LogError("FTLocation component not found on this GameObject.");
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

        FetchFTPos(ftlocation.ftId);
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void FetchFTPos(string ftId)
    {
        if (ftlocation == null)
        {
            Debug.LogError("FTLocation component is missing.");
            return;
        }

        // Use ftid parameter instead of ftlocation.ftid
        string url = hostIPValue+"/Tornare/fasttravel.php?id=" + ftId;
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
                //post
                case UnityWebRequest.Result.Success:
                    string rawresponse = webRequest.downloadHandler.text;
                    string[] fsttrvl = rawresponse.Split('*');

                    for (int i = 0; i < fsttrvl.Length; i++)
                    {
                        if (fsttrvl[i] != "")
                        {
                            string[] currentFtData = fsttrvl[i].Split('|');
                            Debug.Log("ID: " + currentFtData[0] + " Name: -" + currentFtData[1] + " Description: " + currentFtData[2] + " Position: " + currentFtData[3] + "");

                            string[] currentFtPos = currentFtData[3].Split(',');
                            MapLocName.GetComponent<MapLocData>().locationName.text = currentFtData[1];
                            ftlocation.SetFTPos(currentFtPos);
                        }
                    }

                    break;
            }
        }
    }
}
