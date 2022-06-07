using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BitChanger : MonoBehaviour
{
    public string groupID;
    public string groupPW;
    public int bitToChange;
    public int bitValue;

    string URL = "http://vgdapi.basmati.org/mods4.php";

    void Start()
    {

    }

    IEnumerator Upload()
    {
        WWWForm form = new WWWForm();
        // form.AddField("myField", "myData");
        form.AddField("groupid", groupID);
        form.AddField("grouppw", groupPW);
        form.AddField("row", bitToChange);
        form.AddField("s4", bitValue);

        using (UnityWebRequest www = UnityWebRequest.Post(URL, form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Form upload complete!");
            }
        }
    }

    private void OnMouseDown()
    {
        Debug.Log("PUSHING DATA....");
        StartCoroutine(Upload());
    }

}
