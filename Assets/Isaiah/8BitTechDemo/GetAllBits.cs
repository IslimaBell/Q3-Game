using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GetAllBits : MonoBehaviour
{

    //READING DATA
    public string groupID;

   
    string WEBSITE = "http://vgdapi.basmati.org/show8bits4.php?groupid=";
    string URL;
    string statusCode;
    public Text txtStatus;

    private void Start()
    {
        URL = WEBSITE + groupID.Trim();
    }

    private void OnMouseDown()
    {
        Debug.Log("Calling Website");
        StartCoroutine(GetRequest(URL));

    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            if (webRequest.isNetworkError)
            {
                Debug.Log(pages[page] + ": Error: " + webRequest.error);
            }
            else
            {
                Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                statusCode = webRequest.downloadHandler.text;
                txtStatus.text = statusCode;

                
            }
        }


    }

}
