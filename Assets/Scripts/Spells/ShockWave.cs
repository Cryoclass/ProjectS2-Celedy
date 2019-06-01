using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockWave : MonoBehaviour
{
    public float speed;
    public float Duration;
    public Rigidbody2D rb;
    public int damage;

    public float rotate;

    public bool FromEnemy = false;
    private string collisiontag;

    void Start()
    {
        rb.velocity = (-transform.right- transform.up).normalized * speed;
        Invoke("DestroyProjectile", Duration);        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collisiontag = collision.gameObject.tag;
        if (collisiontag == "Wall")
        {
            DestroyProjectile();
        }

        if (FromEnemy)
        {
            if (collisiontag == "Player")
            {
                collision.gameObject.GetComponent<Ya_Health>().Take_hit();
                DestroyProjectile();
            }
        }
    }

    private void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
