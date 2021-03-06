﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallBatIa : MonoBehaviour
{
    public float speed;
    public float offset;
    public Rigidbody2D rgbd2D;
    private GameObject Target;
    private bool Throwed;
    private Vector3 direction { get; set; }
    private float Immobilized;

    // Start is called before the first frame update
    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player");
        SetImmo(1.5f);
    }


    // Update is called once per frame
    void Update()
    {
        if(!Throwed && Immobilized <= 0)
        {
            direction = Target.transform.position - this.transform.position;
            Debug.Log(Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
            transform.rotation = Quaternion.Euler(0f, 0f, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + offset);
            rgbd2D.velocity = transform.up * speed;
            Throwed = true;
        }
        else if(!Throwed)
        {
            Immobilized -= Time.deltaTime;
        }
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            rgbd2D.velocity = new Vector2(0, 0);
            Throwed = false;
        }
        else if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Ya_Health>().Take_hit();
        }
    }

    public void SetImmo(float a)
    {
        Throwed = false;
        Immobilized = a;
    }
}
