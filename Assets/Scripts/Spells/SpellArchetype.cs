﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellArchetype : MonoBehaviour
{
    public float speed;
    public float Duration;
    public Rigidbody2D rb;
    public int damage;

    public float rotate;

    public GameObject Expl;

    private string collisiontag;

    void Start()
    {
        rb.velocity = transform.up * speed;
        Invoke("DestroyProjectile", Duration);        
    }
    
    
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, rotate) * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collisiontag = collision.gameObject.tag;
        if (collisiontag == "Player")
        {
            collision.gameObject.GetComponent<Ya_Health>().Take_hit();
            DestroyProjectile();
        }
        else if (collisiontag == "Wall")
        {
            DestroyProjectile();
        }
        else if (collisiontag == "Enemy")
        {
            collision.GetComponent<MonsterLife>().damaged(damage);
            DestroyProjectile();
        }
        else if(collisiontag == "Boss")
        {
            DestroyProjectile();
        }
    }

    private void DestroyProjectile()
    {
        //Instantiate(Expl, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
