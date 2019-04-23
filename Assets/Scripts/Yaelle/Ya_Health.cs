using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ya_Health : MonoBehaviour
{
    public int CurrentHealth;
    public int CurrentMaxHeart;

    public Image[] Hearts;
    public Sprite FullHeart;
    public Sprite EmptyHeart;
    public Sprite HalfHeart;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int life = CurrentHealth;
        for (int i = 0; i < Hearts.Length; i++)
        {
            if (life >= 2)
            {
                Hearts[i].sprite = FullHeart;
                life += -2;
            }                
            else if (life == 1)
            {
                Hearts[i].sprite = HalfHeart;
                life += -1;
            }                
            else
                Hearts[i].sprite = EmptyHeart;
            

            if (i < CurrentMaxHeart)
                Hearts[i].enabled = true;
            else
                Hearts[i].enabled = false;
        }

        if (CurrentHealth> 2*CurrentMaxHeart)
        {
            CurrentHealth = 2 * CurrentMaxHeart;
        }
    }
}
