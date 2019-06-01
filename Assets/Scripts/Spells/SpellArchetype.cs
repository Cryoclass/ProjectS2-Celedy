using System.Collections;
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

    public bool FromEnemy = false;
    private string collisiontag;

    void Start()
    {
        rb.velocity = transform.up * speed;
        rb.velocity = (transform.up + new Vector3(0f, 0f)) * speed;
        Invoke("DestroyProjectile", Duration);
    }


    void Update()
    {
        transform.Rotate(new Vector3(0, 0, rotate) * Time.deltaTime);
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
        else
        {
            if (collisiontag == "Enemy")
            {
                collision.GetComponent<MonsterLife>().damaged(damage);
                DestroyProjectile();
            }
            else if (collisiontag == "Boss")
            {
                collision.gameObject.GetComponent<Take_damage>().InflictDamage(damage);
                DestroyProjectile();
            }
        }



    }

    private void DestroyProjectile()
    {
        //Instantiate(Expl, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}