using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndMusic : MonoBehaviour
{
    public AudioSource Theme;
    public bool play;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(wait());


    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(2.2f);        
        play = true;
        Theme.Play();
    }

}
