using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections; // Add this line to include the System.Collections namespace

public class MediaLoader : MonoBehaviour
{
    public string imageUrl;
    public Image uiImage;

    void Start()
    {
        // Load the image from the URL and assign it to the UI Image
        StartCoroutine(LoadImageFromUrl(imageUrl, uiImage));
    }


    public void LoadImg()
    {
        StartCoroutine(LoadImageFromUrl(imageUrl, uiImage));
    }

    IEnumerator LoadImageFromUrl(string url, Image targetImage)
    {
        using (UnityWebRequest www = UnityWebRequestTexture.GetTexture(url))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError("Error loading image from URL: " + www.error);
            }
            else
            {
                // Get the downloaded texture
                Texture2D texture = DownloadHandlerTexture.GetContent(www);

                // Create a sprite from the downloaded texture
                Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));

                // Assign the sprite to the UI Image component
                targetImage.sprite = sprite;
            }
        }
    }
}
