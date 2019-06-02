using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum States
{
    None,
    Preparing,
    Charging
}

public class TorusIA : Take_damage
{
    private Color Col;
    private PortSens lastWallSens;
    //private Animator anim;// position: 1 = face; 2 = dos ; 3 = side;
    SpriteRenderer[] ChidrenSprites;

    private Transform PlayerPos;
    private States state;
    private string CollidTag;
    private Vector3 Target;

    public Rigidbody2D rgb;
    public float ChargeSpeed;

    public GameObject ShockWave;

    public GameObject Crack;
    private PortSens WallSens;
    public GameObject leftpoint;
    public GameObject rightpoint;
    public int Life;

    public GameObject slider;
    // Start is called before the first frame update
    void Start()
    {
        slider.GetComponent<Slider>().minValue = 0;
        slider.GetComponent<Slider>().maxValue = Life;
        slider.GetComponent<Slider>().value = Life;
        
        ChidrenSprites = gameObject.GetComponentsInChildren<SpriteRenderer>();
        Col = ChidrenSprites[0].color;
        lastWallSens = PortSens.Null;
        //anim = GetComponent<Animator>();
        PlayerPos = GameObject.FindGameObjectWithTag("Player").transform;
        GetTarget();
    }

    // Update is called once per frame
    private void MakeMeWhite()
    {
        foreach (SpriteRenderer SprRend in ChidrenSprites)
        {
            SprRend.color = new Color(1f,1f,1f);
        }
    }

    private void MakeProgresivelyRed()
    {
        state = States.Preparing;
        Col.b -= 0.1f;
        Col.g -= 0.1f;
        foreach(SpriteRenderer spr in ChidrenSprites)
        {
            spr.color = Col;
        }
        if (Col.b <= 0)
        {
            CancelInvoke("MakeProgresivelyRed");
            Charge();
        }
    }

    private void GetTarget()
    {
        Target = PlayerPos.position - transform.position;
        Target.Normalize();
        if (Target.x > Target.y)
        {
            if (-Target.x < Target.y)
            {
                //anim.SetInteger("Position",3);
                transform.rotation = Quaternion.Euler(0f,0f,0f);
            }
            else
            {
                //anim.SetInteger("Position", 1);
                transform.rotation = Quaternion.Euler(0f,0,0f);
            }
        }
        else
        {
            if (-Target.x < Target.y)
            {
                //anim.SetInteger("Position",3);
                transform.rotation = Quaternion.Euler(0f,180f,0f);            
            }
            else
            {
                //anim.SetInteger("Position", 2);
                transform.rotation = Quaternion.Euler(0f,0f,0f);
            }
        }
        InvokeRepeating("MakeProgresivelyRed",0f,0.3f);
    }
    
    private void Charge()
    {
        MakeMeWhite();
        state = States.Charging;
        rgb.velocity = Target * ChargeSpeed;
        //anim.SetBool("Charging",true);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        CollidTag = other.gameObject.tag;
        switch (CollidTag)
        {
            case "Wall":
            {
                WallSens = other.GetComponent<WallS>().sens;
                if (lastWallSens != WallSens)
                {
                    transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                    rgb.velocity = new Vector3(0, 0,0);
                    if (WallSens == PortSens.Bot || WallSens == PortSens.Top)
                    {
                        Explosion();
                    }
                    else if (WallSens == PortSens.Left)
                    {
                        ExplosionRight();
                    }
                    else if (WallSens == PortSens.Right)
                    {
                        ExplosionLeft();
                    }
                    else
                    {
                        ExplosionSides();
                    }
                    GetTarget();
                    //anim.SetBool("Shock",true);
                    lastWallSens = other.GetComponent<WallS>().sens;
                    Life--;
                    slider.GetComponent<Slider>().value = Life;
                        if (Life <= 0)
                        {
                            Destroy(gameObject);
                            PlayerPrefs.SetInt("SmallBossBeaten", PlayerPrefs.GetInt("SmallBossBeaten") + 1);
                        }
                }
                break;
            }
            case "Player":
            {
                other.gameObject.GetComponent<Ya_Health>().Take_hit();
                break;
            }
        }
    }

    private void ExplosionRight()
    {
        Instantiate(ShockWave, rightpoint.transform.position,Quaternion.Euler(0, 0, 0));
        Instantiate(ShockWave, rightpoint.transform.position,Quaternion.Euler(0, 0, 30));
        Instantiate(ShockWave, rightpoint.transform.position,Quaternion.Euler(0, 0, 60));
        Instantiate(ShockWave, rightpoint.transform.position,Quaternion.Euler(0, 0, 90));
        Instantiate(ShockWave, rightpoint.transform.position,Quaternion.Euler(0, 0, 120));
        Instantiate(ShockWave, rightpoint.transform.position,Quaternion.Euler(0, 0, 150));
        Instantiate(ShockWave, rightpoint.transform.position,Quaternion.Euler(0, 0, 180));
        Instantiate(ShockWave, rightpoint.transform.position,Quaternion.Euler(0, 0, 210));
        Instantiate(ShockWave, rightpoint.transform.position,Quaternion.Euler(0, 0, 240));
        Instantiate(ShockWave, rightpoint.transform.position,Quaternion.Euler(0, 0, 270));
        Instantiate(ShockWave, rightpoint.transform.position,Quaternion.Euler(0, 0, 300));        
        Instantiate(ShockWave, rightpoint.transform.position,Quaternion.Euler(0, 0, 330));        
        Instantiate(Crack,transform.position,transform.rotation);
    }
    private void ExplosionLeft()
    {
        Instantiate(ShockWave, leftpoint.transform.position,Quaternion.Euler(0, 0, 0));
        Instantiate(ShockWave, leftpoint.transform.position,Quaternion.Euler(0, 0, 30));
        Instantiate(ShockWave, leftpoint.transform.position,Quaternion.Euler(0, 0, 60));
        
        Instantiate(ShockWave, leftpoint.transform.position,Quaternion.Euler(0, 0, 210));
        Instantiate(ShockWave, leftpoint.transform.position,Quaternion.Euler(0, 0, 240));
        Instantiate(ShockWave, leftpoint.transform.position,Quaternion.Euler(0, 0, 270));
        Instantiate(ShockWave, leftpoint.transform.position,Quaternion.Euler(0, 0, 300));
        Instantiate(ShockWave, leftpoint.transform.position,Quaternion.Euler(0, 0, 330));
        
        Instantiate(Crack,transform.position,transform.rotation);
    }
    private void Explosion()
    {
        Instantiate(ShockWave, transform.position,Quaternion.Euler(0, 0, 0));
        Instantiate(ShockWave, transform.position,Quaternion.Euler(0, 0, 30));
        Instantiate(ShockWave, transform.position,Quaternion.Euler(0, 0, 60));
        Instantiate(ShockWave, transform.position,Quaternion.Euler(0, 0, 90));
        Instantiate(ShockWave, transform.position,Quaternion.Euler(0, 0, 120));
        Instantiate(ShockWave, transform.position,Quaternion.Euler(0, 0, 150));
        Instantiate(ShockWave, transform.position,Quaternion.Euler(0, 0, 180));
        Instantiate(ShockWave, transform.position,Quaternion.Euler(0, 0, 210));
        Instantiate(ShockWave, transform.position,Quaternion.Euler(0, 0, 240));
        Instantiate(ShockWave, transform.position,Quaternion.Euler(0, 0, 270));
        Instantiate(ShockWave, transform.position,Quaternion.Euler(0, 0, 300));
        Instantiate(ShockWave, transform.position,Quaternion.Euler(0, 0, 330));
        
        
        Instantiate(Crack,transform.position,transform.rotation);
    }

    private void ExplosionSides()
    {
        Instantiate(ShockWave, transform.position,Quaternion.Euler(0, 0, 0));
        Instantiate(ShockWave, transform.position,Quaternion.Euler(0, 0, 30));
        Instantiate(ShockWave, transform.position,Quaternion.Euler(0, 0, 60));
        
        Instantiate(ShockWave, transform.position,Quaternion.Euler(0, 0, 210));
        Instantiate(ShockWave, transform.position,Quaternion.Euler(0, 0, 240));
        Instantiate(ShockWave, transform.position,Quaternion.Euler(0, 0, 270));
        Instantiate(ShockWave, transform.position,Quaternion.Euler(0, 0, 300));
        Instantiate(ShockWave, transform.position,Quaternion.Euler(0, 0, 330));
        Instantiate(ShockWave, rightpoint.transform.position,Quaternion.Euler(0, 0, 90));
        Instantiate(ShockWave, rightpoint.transform.position,Quaternion.Euler(0, 0, 120));
        Instantiate(ShockWave, rightpoint.transform.position,Quaternion.Euler(0, 0, 150));
        Instantiate(ShockWave, rightpoint.transform.position,Quaternion.Euler(0, 0, 180));
        Instantiate(ShockWave, rightpoint.transform.position,Quaternion.Euler(0, 0, 210));
        Instantiate(ShockWave, rightpoint.transform.position,Quaternion.Euler(0, 0, 240));
        Instantiate(ShockWave, rightpoint.transform.position,Quaternion.Euler(0, 0, 270));
        
        Instantiate(Crack,transform.position,transform.rotation);
    }
    public override void InflictDamage(int i){}
}
