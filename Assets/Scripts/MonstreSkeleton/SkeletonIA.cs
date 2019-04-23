using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonIA : MonoBehaviour
{
    public Animator anim;

    private bool moovedthisframe;
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    private float TimeBtwShots;
    public float StartTimeBtwShot;

    public GameObject ShootPoint;
    private Vector3 VectOfShoot;

    public float Offset;
    public GameObject ToRotate;
    public GameObject projectile;
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        moovedthisframe = false;
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            moovedthisframe = true;
        }        
        else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
            moovedthisframe = true;
        }
        anim.SetBool("Mooving", moovedthisframe);
        


        if (TimeBtwShots <= 0)
        {
            Shooting();
            TimeBtwShots = StartTimeBtwShot;            
        }
        else
        {
            TimeBtwShots -= Time.deltaTime;
        }
        anim.SetFloat("Shoot", TimeBtwShots);
    }

    private void Shooting()
    {
        VectOfShoot = player.position - transform.position;
        float rotZ = Mathf.Atan2(VectOfShoot.y, VectOfShoot.x) * Mathf.Rad2Deg;
        ToRotate.transform.rotation = Quaternion.Euler(0f, 0f, rotZ);
        
        Instantiate(projectile, ShootPoint.transform.position, Quaternion.Euler(0f,0f,rotZ+ Offset));
    }
}
