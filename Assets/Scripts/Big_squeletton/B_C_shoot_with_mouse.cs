using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_C_shoot_with_mouse : MonoBehaviour
{

    public GameObject chauve_souris;
    public GameObject top_mouse;
    public GameObject bot_mouse;
    public GameObject right_hand;
    public GameObject left_hand;
    public GameObject crane;
    private int life;
    private int previous_life;
    public int palier = 100;
    private int max_life;
    private int chauve_souris_nombre = 0;

    public bool is_dying = false;

    public int right_had_hand;
    public int left_had_hand;
    // Start is called before the first frame update
    void Start()
    {
        previous_life = life;
        max_life = life;
        
        Chauve_souris_attaque(10,0.4f);
    }

    private void Update()
    {
        if (life < 0)
        {
            
        }
        else if(previous_life != life && ((int)(previous_life / palier) != (int)(life / palier)))
        {
            Chauve_souris_attaque((2*((max_life/palier) - life/palier)),0.4f);
            previous_life = life;
        }
    }

    public void Chauve_souris_attaque(int nombre, float delai_entre_chaque)
    {
        chauve_souris_nombre += nombre;
        InvokeRepeating("Chauve_souris_spawn",0f,delai_entre_chaque);
        chauve_souris_nombre = nombre;
    }
    
    public void Chauve_souris_spawn()
    {
        Instantiate(chauve_souris, top_mouse.transform.position, transform.rotation);
        if (chauve_souris_nombre > 0)
            chauve_souris_nombre--;
        else
        {
            CancelInvoke("Chauve_souris_spawn");
        }
    }

    private void Kill()
    {
        is_dying = true;
    }
}
