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

    public float StoppingRange;
    public float RetreatRange;

    private float CD;
    public float ReloadTime;
    public float speed;

    public List<GameObject> Drops;
    public int RateDrop;
	private Vector3 LastLaserPos;
	private int NbLaserLeft;
	private Vector3 Direction;
    private float Distance;

	public GameObject Laser;
    // Start is called before the first frame update
    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player");
        StoppingRange = StoppingRange * StoppingRange;
        RetreatRange = RetreatRange * RetreatRange;
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
                    Instantiate(Bullet, transform.position + new Vector3(0, 7), Quaternion.Euler(0, 0, 0));
                    CD = ReloadTime;
                }
                else if(CD <= 0)
                {
                    Instantiate(Bullet, transform.position + new Vector3(0, -7), Quaternion.Euler(0, 0, -180));
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
                    Instantiate(Bullet, transform.position + new Vector3(5, 0), Quaternion.Euler(0, 0, -90));
                    CD = ReloadTime;
                }
                else if (CD <= 0)
                {
                    Instantiate(Bullet, transform.position + new Vector3(-5, 0), Quaternion.Euler(0, 0, 90));
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
	        CancelInvoke("Laserattack");
	    else
	    {
	        LastLaserPos += Direction;
	        //Instantiate(Laser, LastLaserPos);
	        NbLaserLeft--;
	    }
	}
}
