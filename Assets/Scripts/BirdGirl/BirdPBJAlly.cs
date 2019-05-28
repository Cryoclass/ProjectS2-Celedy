using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdPBJAlly : AbstractAlly
{
    private float distance;
    
    private GameObject target;

    // public Animator anim;

    public GameObject bullet;

    private float TimeBtwShots;
    public float StartTimeBtwShot;

    public GameObject ShootPoint;
    private Vector3 VectOfShoot;

    private bool MooveThisF;
    public GameObject ToRotate;
    public float Offset;  

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            target = GameObject.FindGameObjectWithTag("Enemy");
        }

        if (TimeBtwShots <= 0)
        {
            if(target != null)
            {
                Shooting();
                TimeBtwShots = StartTimeBtwShot;
            }            
        }
        else
        {
            TimeBtwShots -= Time.deltaTime;
        }

        distance = Mathf.Pow(transform.position.x - ToFollow.transform.position.x, 2) + Mathf.Pow(transform.position.y - ToFollow.transform.position.y, 2);

        if (distance > 9)
            transform.position += (ToFollow.transform.position - this.transform.position) * speed * Time.deltaTime;
        else if (distance < 5)
            transform.position -= (ToFollow.transform.position - this.transform.position) * speed * Time.deltaTime;
    }


    private void Shooting()
    {
        VectOfShoot = target.transform.position - this.transform.position;
        float rotZ = Mathf.Atan2(VectOfShoot.y, VectOfShoot.x) * Mathf.Rad2Deg;
        ToRotate.transform.rotation = Quaternion.Euler(0f, 0f, rotZ);
        Instantiate(bullet, ShootPoint.transform.position, Quaternion.Euler(0f, 0f, rotZ+ Offset));
    }
    
    

    
}
