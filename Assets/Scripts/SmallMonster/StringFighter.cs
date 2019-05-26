using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringFighter : MonoBehaviour
{
    public GameObject ToRotate { get; set; }
    public Rigidbody2D rb { get; set; }

    private bool IsMoving { get; set; }
    private float CdBeforeLaunch;

    // Start is called before the first frame update
    void Start()
    {
        IsMoving = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!IsMoving && CdBeforeLaunch <= 0)
        {

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
        {
            rb.velocity = new Vector2(0,0);
            IsMoving = false;
        }
    }
}
