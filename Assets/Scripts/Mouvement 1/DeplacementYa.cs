using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementYa : MonoBehaviour
{
    
    private bool MoveLaunched = false;
    public GameObject Gereur;
    public Rigidbody2D rb;
    private int TimeCalled = 0;
    
    public float CD = 0;

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
