using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class RandomImageDownloader : MonoBehaviour
{
    [SerializeField]
    private Texture2D randomImage;

    string url = "https://picsum.photos/200/300";

    void Start()
    {
        StartCoroutine(DownloadImage(url));
        
    }

    IEnumerator DownloadImage(string MediaUrl)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(MediaUrl);
        yield return request.SendWebRequest();
        
        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            Debug.Log(request.error);
        else
            randomImage = ((DownloadHandlerTexture)request.downloadHandler).texture;
            GetComponent<RawImage>().texture = randomImage;
    }

}


