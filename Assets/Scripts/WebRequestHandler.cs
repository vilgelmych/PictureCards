using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

public class WebRequestHandler
{
   
    static string url = "https://picsum.photos/";

    static int sizeImg = 200;
   
    public static IEnumerator GetImage(UnityAction<Texture> result) 
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