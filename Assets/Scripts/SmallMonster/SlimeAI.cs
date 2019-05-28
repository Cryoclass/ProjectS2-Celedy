using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using Random = UnityEngine.Random;

public class SlimeAI : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    
    private GameObject target;
    private Vector3 direction;
    private PortSens CollideWallSens;
    private float x;
    private float y;

    private PortSens LastWall;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        
        x = (float) Math.Cos(Random.Range(0, 360));
        y = (float) Math.Cos(Random.Range(0, 360));
        direction = new Vector3(x, y, 0f);
        direction.Normalize();
        
    }

    private void Update()
    {
        transform.position += direction * speed;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            CollideWallSens = collision.GetComponent<WallS>().sens;
            if (CollideWallSens == PortSens.Right)
            {
                Debug.Log("Right");
                if (LastWall != PortSens.Right)
                {
                    direction = new Vector3(-direction.x,direction.y);
                    LastWall = PortSens.Right;
                }
                
            }
            if (CollideWallSens == PortSens.Left)
            {
                Debug.Log("Left");
                if (LastWall != PortSens.Left)
                {
                    direction = new Vector3(-direction.x, direction.y);
                    LastWall = PortSens.Left;
                }
            }
            if (CollideWallSens == PortSens.Top)
            {
                Debug.Log("Top");
                if (LastWall != PortSens.Top)
                {
                    direction = new Vector3(direction.x, -direction.y);
                    LastWall = PortSens.Top;
                }
            }
            if (CollideWallSens == PortSens.Bot)
            {
                Debug.Log("Bot");
                if (LastWall != PortSens.Bot)
                {
                    direction = new Vector3(direction.x, -direction.y);
                    LastWall = PortSens.Bot;
                }
            }
        }

        if (collision.gameObject.tag == "Player")
        {
            collision.GetComponent<Ya_Health>().Take_hit();
        }
        
        
        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
    }
}
