using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonShoot : MonoBehaviour
{
    public float speed;

    private Transform player;
    private Vector2 target;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        target = new Vector2(player.position.x, player.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyProjectile();
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Ya_Health>().CurrentHealth += -1;
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            collision.GetComponent<Drk_IA>().PV -= 50;
            Destroy(gameObject);
        }
    }


    void DestroyProjectile()
    {
        Destroy(gameObject);
    }

}
