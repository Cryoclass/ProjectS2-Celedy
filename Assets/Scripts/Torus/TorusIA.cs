using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum States
{
    None,
    Preparing,
    Charging
}

public class TorusIA : MonoBehaviour
{
    SpriteRenderer[] ChidrenSprites;

    private Transform PlayerPos;
    private States state;
    private string CollidTag;
    private Vector3 Target;

    public Rigidbody2D rgb;
    public float ChargeSpeed;

    public GameObject ShockWave;

    public GameObject Crack;
    // Start is called before the first frame update
    void Start()
    {
        ChidrenSprites = gameObject.GetComponentsInChildren<SpriteRenderer>();
        PlayerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    private void MakeMeWhite()
    {
        foreach (SpriteRenderer SprRend in ChidrenSprites)
        {
            SprRend.color += new Color(255,255,255);
        }
    }

    private void MakeProgresivelyRed()
    {
        state = States.Preparing;
        foreach (SpriteRenderer SprRend in ChidrenSprites)
        {
            SprRend.color += new Color(5,0,0);
        }

        if (ChidrenSprites.Length < 1 || ChidrenSprites[0].color.r >= 255)
        {
            CancelInvoke("MakeProgresivelyRed");
            Charge();
        }
    }

    private void Charge()
    {
        MakeMeWhite();
        state = States.Charging;
        Target = PlayerPos.position - transform.position;
        Target.Normalize();
        rgb.velocity = Target * ChargeSpeed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        CollidTag = other.gameObject.tag;
        switch (CollidTag)
        {
            case "Wall":
            {
                rgb.velocity = new Vector2(0, 0);
                Explosion();
                break;
            }
            case "Player":
            {
                other.gameObject.GetComponent<Ya_Health>().Take_hit();
                break;
            }
        }
    }

    private void Explosion()
    {
        Instantiate(ShockWave, transform.position, Quaternion.Euler(0f,0f,0f), transform);
        Instantiate(ShockWave, transform.position, Quaternion.Euler(0f,0f,30), transform);
        Instantiate(ShockWave, transform.position, Quaternion.Euler(0f,0f,60), transform);
        Instantiate(ShockWave, transform.position, Quaternion.Euler(0f,0f,90), transform);
        Instantiate(ShockWave, transform.position, Quaternion.Euler(0f,0f,120), transform);
        Instantiate(ShockWave, transform.position, Quaternion.Euler(0f,0f,150), transform);
        Instantiate(ShockWave, transform.position, Quaternion.Euler(0f,0f,180), transform);
        Instantiate(ShockWave, transform.position, Quaternion.Euler(0f,0f,210), transform);
        Instantiate(ShockWave, transform.position, Quaternion.Euler(0f,0f,240), transform);
        Instantiate(ShockWave, transform.position, Quaternion.Euler(0f,0f,270), transform);
        Instantiate(ShockWave, transform.position, Quaternion.Euler(0f,0f,300), transform);
        Instantiate(ShockWave, transform.position, Quaternion.Euler(0f,0f,330), transform);

        Instantiate(Crack);
    }
}
