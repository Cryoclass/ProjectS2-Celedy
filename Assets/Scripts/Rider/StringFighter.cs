﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringFighter : Take_damage
{
    // part Boss
    public int life;

    public GameObject bullet;
    public List<GameObject> FirePoints; // 0:Top, 1:Bot, 2:Right, 3:Left

    public float Cooldown;
    private float CD;



    // Deplacement part  => Don't touch !!
    public GameObject ToRotate;
    public GameObject WebFirePoint;
    private float CDRotation;



    private bool RightToLeft;
    private int TimeBeforeChange;


    public Rigidbody2D rb;

    private bool IsMoving;

    public float TimeBtwLaunch;
    private float CdBeforeLaunch;

    public float Speed;

    private PortSens SensOfActualWall;

    public GameObject WebCreatorObj;
    private GameObject WebCreatorLauched;

    private Queue<GameObject> Webs;
    private bool WebsReceived;

    private float TimeForNextWeb;
    private float ActualTimeForNextWeb;


    public GameObject Folder;
    public GameObject Spike;

    // Start is called before the first frame update
    void Start()
    {
        IsMoving = false;
        CdBeforeLaunch = TimeBtwLaunch;
        TimeForNextWeb = 6 / Speed;
        WebsReceived = true;
        SensOfActualWall = PortSens.Bot;
        CDRotation = 2;
        Folder = Instantiate(Folder, transform.position, transform.rotation);
        if (Cooldown <= 0)
        {
            Cooldown = 1;
        }
        CD = Cooldown;
    }

    // Update is called once per frame
    void Update()
    {        
        if(!IsMoving && CdBeforeLaunch <= 0 && WebsReceived)
        {
            WebCreatorLauched = Instantiate(WebCreatorObj, WebFirePoint.transform.position, ToRotate.transform.rotation, transform);
            ToRotate.transform.rotation = Quaternion.Euler(0, 0, 0);
            ToRotate.SetActive(false);

            WebsReceived = false;
            CdBeforeLaunch = Random.Range(TimeBtwLaunch, TimeBtwLaunch+2);
        }
        else if(!IsMoving && WebsReceived)
        {
            ArrowRotation();
            CdBeforeLaunch -= 2 * Time.deltaTime;
        }
        else if (IsMoving)
        {
            if (ActualTimeForNextWeb <= 0 && Webs.Count != 0)
            {
                Instantiate(Spike, transform.position, transform.rotation, Folder.transform);
                GameObject nextWeb = Webs.Dequeue();
                transform.rotation = nextWeb.transform.rotation;
                Destroy(nextWeb);
                rb.velocity = transform.up * Speed;
                ActualTimeForNextWeb = TimeForNextWeb;
            }
            else
            {
                ActualTimeForNextWeb -= 2 * Time.deltaTime;
            }
        }

        if(CD <= 0)
        {
            QuadriShoot();
            CD = Cooldown;
        }
        else
        {
            CD -= 2* Time.deltaTime;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Webs.Count <= 5 && collision.tag == "Wall")
        {
            destroythequeue();
            CDRotation = 2;
            SensOfActualWall = collision.gameObject.GetComponent<WallS>().sens;
            rb.velocity = new Vector3(0, 0, 0);
            IsMoving = false;
            ToRotate.SetActive(true);

            switch (SensOfActualWall)
            {
                case PortSens.Bot:
                    ToRotate.transform.rotation = Quaternion.Euler(0, 0, 0);
                    gameObject.transform.rotation = Quaternion.Euler(0,0,0);                    
                    break;


                case PortSens.Left:
                    ToRotate.transform.rotation = Quaternion.Euler(0, 0, -90);
                    gameObject.transform.rotation = Quaternion.Euler(0, 0, -90);
                    break;


                case PortSens.Right:
                    ToRotate.transform.rotation = Quaternion.Euler(0, 0, 90);
                    gameObject.transform.rotation = Quaternion.Euler(0, 0, 90);
                    break;


                case PortSens.Top:
                    ToRotate.transform.rotation = Quaternion.Euler(0, 0, 180);
                    gameObject.transform.rotation = Quaternion.Euler(0, 0, 180);
                    break;
            }            
            
        }
    }

    private void ArrowRotation()
    {
        if (CDRotation <= 0)
        {
            RightToLeft = !RightToLeft;
            CDRotation = 4;
        }
        else
        {
            CDRotation -= 2.5f * Time.deltaTime;
        }

        ToRotate.transform.Rotate(0, 0, (RightToLeft ? 100 : -100)* Time.deltaTime);
        
    }

    public void SetWeb(Queue<GameObject> Webs)
    {
        this.Webs = Webs;
        WebsReceived = true;
        IsMoving = true;
    }

    private void destroythequeue()
    {
        while (Webs.Count != 0)
        {
            Destroy(Webs.Dequeue());
        }
    }

    public override void InflictDamage(int i)
    {
        life -= i;
    }

    private void QuadriShoot()
    {
        Instantiate(bullet, FirePoints[0].transform.position, Quaternion.Euler(transform.rotation.x + 0, transform.rotation.y + 0,  0 - transform.rotation.z));
        Instantiate(bullet, FirePoints[2].transform.position, Quaternion.Euler(transform.rotation.x + 0, transform.rotation.y + 0, -90 - transform.rotation.z));
        Instantiate(bullet, FirePoints[1].transform.position, Quaternion.Euler(transform.rotation.x + 0, transform.rotation.y + 0,  180 - transform.rotation.z));
        Instantiate(bullet, FirePoints[3].transform.position, Quaternion.Euler(transform.rotation.x + 0, transform.rotation.y + 0, 90 - transform.rotation.z));
    }
}
