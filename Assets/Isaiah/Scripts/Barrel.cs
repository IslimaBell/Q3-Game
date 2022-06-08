using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Barrel : MonoBehaviour
{

    public GameObject player;
    public RefinedMovement RM;
    public Animator animator;


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
        if(other.tag == "Oil")
        {
            Destroy(gameObject);
        }
        
        if(other.tag == "Hammer")
        {
            Destroy(gameObject);
        }

             
        if (other.tag == "Player")
        {
            StartCoroutine(RespawningLevel());
            RM.isDead = true;
            RM.mainTheme.Stop();
            RM.DeathSound.Play();
            player.GetComponent<RefinedMovement>().enabled = false;
            animator.SetBool("IsDead", true);
            
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

    IEnumerator RespawningLevel()
    {
        RM.mainTheme.Stop();
        RM.DeathSound.Play();
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }




}
