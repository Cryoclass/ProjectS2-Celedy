using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blue_Ball : MonoBehaviour
{
    private GameObject Target;
    public int Range;

    public GameObject Bullet;

    private float angle;
    private int ShootDirection; // 1 = Right ; 2 = Left ; 3 = Up ; 4 = Down
    private float TestAngle;

    private float StoppingRange;
    private float RetreatRange;

    private float CD;
    public float ReloadTime;
    public float speed;

    public List<GameObject> Drops;
    public int RateDrop;
	private Vector3 LastLaserPos;
	private int NbLaserLeft;
	private Vector3 Direction;
    public float SBLaser;
    private float Distance;
    private GameObject LastLaser;
    public float stoppingDistance;
    public float retreatDistance;
    public float randStop;
    public float randRetreat;

    public GameObject Laser;
    // Start is called before the first frame update
    void Start()
    {
        RetreatRange = Random.Range(retreatDistance, randRetreat);
        StoppingRange = Random.Range(stoppingDistance, randStop);
        Target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Distance = Mathf.Pow((Target.transform.position.x - transform.position.x), 2) + Mathf.Pow((Target.transform.position.y - transform.position.y), 2);
        Debug.Log(Distance);
        if ( Distance > StoppingRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, Target.transform.position, speed * Time.deltaTime);
        }
        else if(Distance < RetreatRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, Target.transform.position, -speed * Time.deltaTime);
        }

        if(Mathf.Abs(Target.transform.position.x - transform.position.x) < Mathf.Abs(transform.position.y - Target.transform.position.y))
        {
            if(Mathf.Abs(transform.position.x - Target.transform.position.x) < 2)
            {
                if(CD <= 0 && transform.position.y <= Target.transform.position.y)
                {
                    LastLaserPos = transform.position;
                    Direction = new Vector3(0, 1);
                    InvokeRepeating("Laser_attack", 0f, 0.1f);
                    CD = ReloadTime;
                }
                else if(CD <= 0)
                {
                    LastLaserPos = transform.position;
                    Direction = new Vector3(0, -1);
                    InvokeRepeating("Laser_attack", 0f, 0.1f);
                    CD = ReloadTime;
                }
            }
            else if (transform.position.x > Target.transform.position.x)
            {
                transform.position -= new Vector3(1, 0) * speed * Time.deltaTime;
            }
            else
            {
                transform.position += new Vector3(1, 0) * speed * Time.deltaTime;
            }
        }
        else
        {
            if(Mathf.Abs(transform.position.y - Target.transform.position.y) < 2)
            {
                if (CD <= 0 && transform.position.x <= Target.transform.position.x)
                {
                    LastLaserPos = transform.position + new Vector3(0, -5);
                    Direction = new Vector3(1, 0);
                    InvokeRepeating("Laser_attack", 0f, 0.1f);
                    CD = ReloadTime;
                }
                else if (CD <= 0)
                {
                    LastLaserPos = transform.position + new Vector3(0, -5);
                    Direction = new Vector3(-1, 0);
                    InvokeRepeating("Laser_attack", 0f, 0.1f);
                    CD = ReloadTime;
                }
            }
            else if (transform.position.y > Target.transform.position.y)
            {
                transform.position -= new Vector3(0,1) * speed * Time.deltaTime;
            }
            else
            {
                transform.position += new Vector3(0, 1) * speed * Time.deltaTime;
            }
        }


        if (CD > 0)
        {
            CD -= Time.deltaTime;
        }
    }
	
	private void Laser_attack()
	{
        if (NbLaserLeft <= 0)
        {
            NbLaserLeft = 8;
            CancelInvoke("Laser_attack");
        }
        else
        {
            LastLaserPos += Direction * SBLaser;
            LastLaser = Instantiate(Laser, LastLaserPos, Quaternion.Euler(0f, 0f, 0f));
            LastLaser.GetComponent<Laser_Script>().DedIn(1.5f);
            NbLaserLeft--;
        }
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.GetComponent<Ya_Health>().Take_hit();
        }
    }
}
