using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisterSlime : MonsterLife
{
    public int i;
    public GameObject mini_slime;
    public GameObject normal_slime;


    public void damaged(int i)
    {
        Life -= i;
        if (Life < 0)
        {
            Instantiate(normal_slime, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

}
