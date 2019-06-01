using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisterSlimeLife: Take_damage
{
    public float Life;
    public GameObject medium_slime;
    public GameObject normal_slime;
    public int split;
    public int NbSplit;

    public override void InflictDamage(int i)
    {
        Life -= i;
        if (Life < 0)
        {
            if (split == 3)
            {
                for(int j = 0; j < NbSplit; j++)
                    Instantiate(medium_slime, transform.position, Quaternion.identity);
                Destroy(gameObject);
                split -= 1;
            }

            if (split == 1)
            {
                for (int j = 0; j < NbSplit; j++)
                    Instantiate(normal_slime, transform.position, Quaternion.identity);
                Destroy(gameObject);
                split -= 1;
            }

            if (split == 0)
            {
                Destroy(gameObject);
            }
            
        }
    }
}
