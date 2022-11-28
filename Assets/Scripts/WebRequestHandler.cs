using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

public class WebRequestHandler
{
    public static IEnumerator GetImage(string url, int sizeImg, UnityAction<Texture> result) 
    {
        using (var uwr = new UnityWebRequest(url + sizeImg, UnityWebRequest.kHttpVerbGET))
        {
            uwr.downloadHandler = new DownloadHandlerTexture();
            yield return uwr.SendWebRequest();           
            if (result != null)
                result.Invoke(DownloadHandlerTexture.GetContent(uwr));
            uwr.Dispose();
        }
    }
}