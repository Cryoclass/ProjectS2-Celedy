using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public GameObject ToFollow;

    public float Toolong;

    public int CounterHl;

    // Start is called before the first frame update
    void Start()
    {
        ToFollow = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        KeepMoving();
    }

    public void KeepMoving()
    {
        if (Vector2.Distance(transform.position, ToFollow.transform.position) > Toolong)
        {
            transform.position = Vector2.MoveTowards(transform.position, ToFollow.transform.position, 30 * Time.deltaTime);
        }
    }

    public void Healing()
    {
        CounterHl += 1;
        if (CounterHl >= 5)
        {
            ToFollow.GetComponent<Ya_Health>().CurrentHealth += 1;
            CounterHl = 0;
        }
        
    }
    
}
