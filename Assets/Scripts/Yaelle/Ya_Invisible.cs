using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ya_Invisible : MonoBehaviour
{
    Color col;

    private void Start()
    {
        col = gameObject.GetComponent<SpriteRenderer>().color;
    }
    
    public void invisible()
    {
        col.a -= 0.34f;
        gameObject.GetComponent<SpriteRenderer>().color = col;
    }

    public void visible()
    {
        col.a = 1;
        gameObject.GetComponent<SpriteRenderer>().color = col;
    }

    void Update()
    {
        
    }
}
