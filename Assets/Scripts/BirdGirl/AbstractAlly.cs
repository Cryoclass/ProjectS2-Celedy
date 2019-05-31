using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractAlly : MonoBehaviour
{
    public GameObject ToFollow;
    public bool DoesHeal;
    public float speed;

    Color col;
    SpriteRenderer[] AllSprite;

    // Start is called before the first frame update
    void Start()
    {
        AllSprite = gameObject.GetComponentsInChildren<SpriteRenderer>();
        col = AllSprite[0].color;
        
        ToFollow = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void invisible()
    {
        col.a -= 0.34f;
        foreach (SpriteRenderer spr in AllSprite)
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

    public void Teleport(float x, float y)
    {
        transform.position += new Vector3(x, y);
        visible();
    }

    
    
}
