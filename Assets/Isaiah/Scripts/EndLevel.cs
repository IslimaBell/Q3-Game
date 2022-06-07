using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
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
        /*
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
        */

        Debug.Log("Waiting...");
        yield return new WaitForSeconds(2);
        Debug.Log("done");
        

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Hammer")
        {
            Destroy(gameObject);
            Debug.Log("PUSHING DATA....");
            SceneManager.LoadScene("Win");
            StartCoroutine(Upload()); 
            
            
        }
    }


        
    

}
