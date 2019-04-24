using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementYa : MonoBehaviour
{
    private float EachX;
    private float EachY;

    public Rigidbody2D rb;
    private float k1;
    private float k2;

    private float CD = 0;

    private void Update()
    {
        if (CD > 0)
        {
            CD -= Time.deltaTime;
        }
        else
            CancelInvoke();

    }

    public void Depl(int x, int y)
    {
        rb.velocity = transform.up;

    }
    
    private void Mvmt()
    {
        transform.position += new Vector3(EachX, EachY, 0f);
    }
}
