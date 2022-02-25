using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlow : MonoBehaviour
{
    public Transform barrelObj;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(barrelSpawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator barrelSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(6);
            Instantiate(barrelObj, new Vector3(-3, 22, 0), barrelObj.rotation);
        }
        
    }
}
