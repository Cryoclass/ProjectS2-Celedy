using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementYa : MonoBehaviour
{
    private float EachX;
    private float EachY;

    private bool LaunchedMove;
    public Rigidbody2D rb;
    private float k1;
    private float k2;

    private float CD = 0;

    private void Update()
    {
        if (LaunchedMove)
        {
            if (CD > 0)
            {
                CD -= Time.deltaTime;
            }
            else
            {
                Stoping();
            }
        }      
    }

    public void Depl(int x, int y)
    {
        LaunchedMove = true;
        CD = Mathf.Max(Mathf.Abs(x), Mathf.Abs(y))/10;
        rb.velocity = transform.up*(y/CD) + transform.right*(x/CD);
    }
    
    private void Stoping()
    {
        LaunchedMove = false;
        rb.velocity = new Vector3(0,0,0);
    }
}
