using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class SlimeAI : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    
    private GameObject target;
    private Vector2 direction;
    private PortSens CollideWallSens;
    private float x;
    private float y;

    private void Start()
    {
        x = Random.Range(0, 360);
        y = Random.Range(0, 360);
        rb.velocity = new Vector2(x, y);
    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            CollideWallSens = collision.GetComponent<WallS>().sens;
            if (CollideWallSens == PortSens.Right)
            {
                rb.velocity = new Vector2(-x, y);
            }
            if (CollideWallSens == PortSens.Left)
            {
                rb.velocity = new Vector2(-x, y);
            }
            if (CollideWallSens == PortSens.Top)
            {
                rb.velocity = new Vector2(x, -y);
            }
            if (CollideWallSens == PortSens.Bot)
            {
                rb.velocity = new Vector2(x, -y);
            }
        }
    }
}
