using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterLife : MonoBehaviour
{
    public float Life;
    public GameObject ally;

    public void damaged(int i)
    {
        Life -= i;
        if (Life < 0)
        {
            if (GameObject.Find("Ally"))
            {
                ally = GameObject.FindGameObjectWithTag("Ally");
                ally.GetComponent<Move>().Healing();
            }
            Destroy(gameObject);
            
        }
    }
}
