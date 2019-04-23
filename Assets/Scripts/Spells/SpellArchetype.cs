using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellArchetype : MonoBehaviour
{
    public float speed;
    public float Duration;
    public Rigidbody2D rb;

    public float rotate;

    public GameObject Expl;

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

    private void DestroyProjectile()
    {
        Instantiate(Expl, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
