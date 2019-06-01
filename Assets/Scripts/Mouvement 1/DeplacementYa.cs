using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementYa : MonoBehaviour
{
    private Animator anim;
    private bool MoveLaunched = false;
    public GameObject Gereur;
    public Rigidbody2D rb;
    private int TimeCalled = 0;
    
    public float CD = 0;

    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }
    private void Update()
    {
        if(MoveLaunched)
        {
            if (CD > 0)
            {
                CD -= Time.deltaTime*2;
            }
            else
            {
                rb.velocity = new Vector3(0,0,0);
                MoveLaunched = false;
                if (TimeCalled == 1)
                {
                    Gereur.GetComponent<GereurMvt1>().Declencheur();
                }
            }

            if (rb.velocity.y < 0)
            {
                anim.SetBool("Walk_back", false);
                anim.SetBool("Walk_Front", true);
                anim.SetBool("Walk_Side", false);
                transform.rotation = Quaternion.Euler(0,0,0);
            }
            else if (rb.velocity.y > 0)
            {
                anim.SetBool("Walk_back", true);
                anim.SetBool("Walk_Front", false);
                anim.SetBool("Walk_Side", false);
                transform.rotation = Quaternion.Euler(0,0,0);
            }
            else if(rb.velocity.x > 0)
            {
                anim.SetBool("Walk_back", false);
                anim.SetBool("Walk_Front", false);
                anim.SetBool("Walk_Side", true);
                transform.rotation = Quaternion.Euler(0,180,0);
            }
            else if(rb.velocity.x < 0)
            {
                anim.SetBool("Walk_back", false);
                anim.SetBool("Walk_Front", false);
                anim.SetBool("Walk_Side", true);
                transform.rotation = Quaternion.Euler(0,0,0);
            }
            else
            {
                anim.SetBool("Walk_back", false);
                anim.SetBool("Walk_Front", false);
                anim.SetBool("Walk_Side", false);
            }
        }
    }

    public void Depl(int x, int y)
    {
        TimeCalled += 1;
        MoveLaunched = true;
        CD = Mathf.Max(Mathf.Abs(x), Mathf.Abs(y)) / 10f;
        Debug.Log(CD);
        rb.velocity = (transform.up * (y / CD) + (transform.right * (x / CD))) * 2;
    }
    
    
   
}
