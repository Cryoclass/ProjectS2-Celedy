using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MisterSlimeLife: Take_damage
{
    public float Life;
    public GameObject medium_slime;
    public GameObject normal_slime;
    public int split;
    public int NbSplit;

    public GameObject Slider;

    private void Start()
    {
        if (Slider != null)
        {
            Slider.GetComponent<Slider>().maxValue = Life;
            Slider.GetComponent<Slider>().minValue = 0;
        }
    }

    private void Update()
    {
        if (Slider != null)
        {
            Slider.GetComponent<Slider>().value = Life;
        }
    }

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
                PlayerPrefs.SetInt("SmallBossBeaten", PlayerPrefs.GetInt("SmallBossBeaten") + 1);
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
