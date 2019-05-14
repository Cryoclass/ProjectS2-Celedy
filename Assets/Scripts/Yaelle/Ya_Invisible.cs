using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ya_Invisible : MonoBehaviour
{
    Color col;
    SpriteRenderer[] AllSprite;

    private void Start()
    {
        AllSprite = gameObject.GetComponentsInChildren<SpriteRenderer>();
        col = AllSprite[0].color;
    }
    
    public void invisible()
    {
        col.a -= 0.34f;
        foreach(SpriteRenderer spr in AllSprite)
        {
            spr.color = col;
        }
    }

    public void visible()
    {
        col.a = 1;
        foreach (SpriteRenderer spr in AllSprite)
        {
            spr.color = col;
        }
    }

    public void MakeTotallyInvisible()
    {
        col.a = 0;
        foreach (SpriteRenderer spr in AllSprite)
        {
            spr.color = col;
        }
    }
}
