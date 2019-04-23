using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterLife : MonoBehaviour
{
    public float Life;

    public void damaged(int i)
    {
        Life -= i;
        if (Life < 0)
        {
            Destroy(gameObject);
        }
    }
}
