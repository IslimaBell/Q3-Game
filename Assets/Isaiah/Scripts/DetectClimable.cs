using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectClimable : MonoBehaviour
{
    [SerializeField]
    private RefinedMovement player;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<VineScript>())
        {
            player.ClimbingAllowed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<VineScript>())
        {
            player.ClimbingAllowed = false;
        }
    }

}
