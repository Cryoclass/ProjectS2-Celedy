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
    private float invincibility = 0;

    private int life;
    // Start is called before the first frame update
    void Start()
    {
       CurrentHealth = PlayerPrefs.GetInt("PlayerCurrentLife");
    }

    // Update is called once per frame
    void Update()
    {
        life = CurrentHealth;
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

        if (invincibility > 0)
        {
            invincibility -= Time.deltaTime;
            if((invincibility < 1 && invincibility> 0.8) || invincibility < 0.6 && invincibility > 0.4 || invincibility < 0.25 && invincibility > 0.5f)
                gameObject.GetComponent<Ya_Invisible>().MakeTotallyInvisible();
            else
            {
                gameObject.GetComponent<Ya_Invisible>().visible();
            }
        }

        
    }

    public void Take_hit()
    {
        if (invincibility <= 0)
        {
            CurrentHealth -= 1;
            invincibility = 1f;
            PlayerPrefs.SetInt("PlayerCurrentLife", CurrentHealth);

            if (CurrentHealth <= 0)
            {
                FindObjectOfType<GameOver>().EndGame();
            }
        }
    }
}
