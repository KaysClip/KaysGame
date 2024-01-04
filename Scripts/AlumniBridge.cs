using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class AlumniBridge : MonoBehaviour
{   
    public MediaLoader mediaLoader;
    public string alumniID ="1";
    public SettingsManager settingsManager;
    public TMP_Text BrickName;
    public TMP_Text BrickCourseYr;
    
    public TMP_Text AlumniName;
    public TMP_Text AlumniCourseYr;
    public TMP_Text AlumniID;

    public GameObject infoPanel;  

    
    private string[] currentAlumniData;
    string profileURL;
    
    public string hostIPValue;
    

    private void Awake()
    {
        // Find the SettingsManager script in the scene
        settingsManager = FindObjectOfType<SettingsManager>();
        mediaLoader = FindObjectOfType<MediaLoader>();
        infoPanel = GameObject.Find("InfoPanel");

        currentAlumniData = new string[5];

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

    }

    void Start()
    {
        FetchAlumni();
    }

    void Update()
    {
        
    }

    public void ViewAlumni()
    {   
        infoPanel.transform.Find("DetailsPanel").Find("AlumniName").GetComponent<TMP_Text>().text = currentAlumniData[1];
        infoPanel.transform.Find("DetailsPanel").Find("AlumniCourse").GetComponent<TMP_Text>().text = currentAlumniData[2] + " - " + currentAlumniData[3];
        infoPanel.transform.Find("ID").Find("ID").GetComponent<TMP_Text>().text = currentAlumniData[0];

        profileURL = ""+hostIPValue+ "/Tornare/img/alumni/" + currentAlumniData[4] + ".jpg";

        mediaLoader.imageUrl = profileURL;
        
        mediaLoader.LoadImg();

    }

    public void FetchAlumni()
    {
        // Use alumniID parameter instead of alumniData.alumniID
        string url = hostIPValue+"/Tornare/alumni.php?id=" + alumniID;
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
                    string rawresponse = webRequest.downloadHandler.text;
                    string[] alumni = rawresponse.Split('*');

                    for (int i = 0; i < alumni.Length; i++)
                    {
                        if (alumni[i] != "")
                        {
                            currentAlumniData = alumni[i].Split('|');
                            Debug.Log("FU ID: " + currentAlumniData[0] + " Alumni Name: -" + currentAlumniData[1] + " Course: " + currentAlumniData[2] + " Year/Level: " + currentAlumniData[3] + " PhotoFileName: " + currentAlumniData[4] + "");
                            BrickName.text = currentAlumniData[1];
                            BrickCourseYr.text = currentAlumniData[2] + " - " + currentAlumniData[3];


                        }
                    }

                    

                    break;
            }
        }
    }
}
