using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisterSlimeLife: Take_damage
{
    public float Life;
    public GameObject medium_slime;
    public GameObject normal_slime;
    public int split;

    public override void InflictDamage(int i)
    {
        Life -= i;
        if (Life < 0)
        {
            if (split == 3)
            {
                Instantiate(medium_slime, transform.position, Quaternion.identity);
                Instantiate(medium_slime, transform.position, Quaternion.identity);
                Instantiate(medium_slime, transform.position, Quaternion.identity);
                Instantiate(medium_slime, transform.position, Quaternion.identity);
                Destroy(gameObject);
                split -= 1;
            }

            if (split == 1)
            {
                Instantiate(normal_slime, transform.position, Quaternion.identity);
                Instantiate(normal_slime, transform.position, Quaternion.identity);
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
