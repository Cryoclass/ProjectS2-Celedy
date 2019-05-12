using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Middle_laser_script : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        string collisiontag;
        collisiontag = collision.gameObject.tag;
        if (collisiontag == "Player")
        {
            collision.gameObject.GetComponent<Ya_Health>().Take_hit();
        }
    }
}
