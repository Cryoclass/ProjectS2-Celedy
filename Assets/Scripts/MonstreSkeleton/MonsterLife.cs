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
            Debug.Log("0pv");

            if (GameObject.FindWithTag("AllyFairy") != null)
            {
                ally = GameObject.FindGameObjectWithTag("AllyFairy");
                ally.GetComponent<Move>().Healing();
            }

            Destroy(gameObject);
            
        }
    }
}
