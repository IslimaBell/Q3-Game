using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector3(6, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Oil_Barrel 1")
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "borderR")
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(-6, 0, 0);
        }
        
        if (collision.gameObject.name == "borderL")
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(6, 0, 0);
        }
    }






}
