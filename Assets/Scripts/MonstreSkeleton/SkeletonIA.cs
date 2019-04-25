using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonIA : MonoBehaviour
{
    public Animator anim;

    public List<GameObject> drops;
    public int droprate;

    public float speed;
    public float stoppingDistance;
    public float retreatDistance;
    public float randStop;
    public float randRetreat;


    private float TimeBtwShots;
    public float StartTimeBtwShot;
    
    

    public GameObject ShootPoint;
    private Vector3 VectOfShoot;

    private bool MooveThisF;
    public float Offset;
    public GameObject ToRotate;
    public GameObject projectile;
    private Transform player;


    //Test pour l'effet de gel
    public bool CanShoot = true;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        TimeBtwShots = Random.Range(StartTimeBtwShot*0.5f, StartTimeBtwShot*1.5f);
        retreatDistance = Random.Range(retreatDistance,randRetreat);
        stoppingDistance = Random.Range(stoppingDistance,randStop);

    }

    // Update is called once per frame
    void Update()
    {
        MooveThisF = false;
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            MooveThisF = true;
        }
        
        else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
            MooveThisF = true;
        }

        if (transform.position.x > player.position.x)
        {
            transform.rotation = Quaternion.Euler(0f, 180, 0f);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }

        anim.SetBool("Mooving", MooveThisF);

        if (CanShoot)
        {
            if (TimeBtwShots <= 0)
            {
                Shooting();
                TimeBtwShots = StartTimeBtwShot;
            }
            else
            {
                TimeBtwShots -= Time.deltaTime;
            }

            anim.SetFloat("Shooting", TimeBtwShots);
        }
        else
        {
            anim.SetBool("Mooving",false);
        }
    }

    private void Shooting()
    {
        VectOfShoot = player.position - transform.position;
        float rotZ = Mathf.Atan2(VectOfShoot.y, VectOfShoot.x) * Mathf.Rad2Deg;
        ToRotate.transform.rotation = Quaternion.Euler(0f, 0f, rotZ);
        Instantiate(projectile, ShootPoint.transform.position, Quaternion.Euler(0f, 0f, rotZ + Offset));
    }

    private void OnDestroy()
    {
        if(Random.Range(0,100) < droprate)
        {
            if(drops.Count != 0)
                Instantiate(drops[Random.Range(0, drops.Count)], transform.position, transform.rotation);
        }
    }
}
