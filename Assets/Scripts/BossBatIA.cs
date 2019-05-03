using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBatIA : MonoBehaviour
{
    private GameObject Target;
    public bool Activated;
    public float speed;

    public float ReloadTime;
    private float CD;

    public float StoppingRange;
    public float RetreatRange;

    private float Distance;

    // Start is called before the first frame update
    void Start()
    {
        CD = Random.Range(ReloadTime, ReloadTime * 20 / 100);
        GameObject.FindGameObjectWithTag("Player");        
    }

    // Update is called once per frame
    void Update()
    {
        if (Activated)
        {
            Distance = Mathf.Pow((Target.transform.position.x - transform.position.x), 2) + Mathf.Pow((Target.transform.position.y - transform.position.y), 2);
            Debug.Log(Distance);
            if (Distance > StoppingRange)
            {
                transform.position = Vector2.MoveTowards(transform.position, Target.transform.position, speed * Time.deltaTime);
            }
            else if (Distance < RetreatRange)
            {
                transform.position = Vector2.MoveTowards(transform.position, Target.transform.position, -speed * Time.deltaTime);
            }

            if (Mathf.Abs(Target.transform.position.x - transform.position.x) < Mathf.Abs(transform.position.y - Target.transform.position.y))
            {
                if (Mathf.Abs(transform.position.x - Target.transform.position.x) < 2)
                {
                    if (CD <= 0 && transform.position.y <= Target.transform.position.y)
                    {
                        // TIR
                        CD = ReloadTime;
                    }
                    else if (CD <= 0)
                    {
                        // TIR
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
                if (Mathf.Abs(transform.position.y - Target.transform.position.y) < 2)
                {
                    if (CD <= 0 && transform.position.x <= Target.transform.position.x)
                    {
                        // TIR
                        CD = ReloadTime;
                    }
                    else if (CD <= 0)
                    {
                        // TIR
                        CD = ReloadTime;
                    }
                }
                else if (transform.position.y > Target.transform.position.y)
                {
                    transform.position -= new Vector3(0, 1) * speed * Time.deltaTime;
                }
                else
                {
                    transform.position += new Vector3(0, 1) * speed * Time.deltaTime;
                }

                if (CD > 0)
                {
                    CD -= Time.deltaTime;
                }
            }            
        }
        else
        {
            Fly();
        }
    }

    private void Fly()
    {
        // gameObject.transform.localScale += new Vector3(0.01f, 0.01f, 0) * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, transform.position += new Vector3(0, 500,0), speed * Time.deltaTime);
    }
}

