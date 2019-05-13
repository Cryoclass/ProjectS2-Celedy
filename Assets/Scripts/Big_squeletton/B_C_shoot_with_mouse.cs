using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_C_shoot_with_mouse : Take_damage
{

    public GameObject chauve_souris;
    public GameObject top_mouse;
    public GameObject bot_mouse;
    public GameObject right_hand;
    public GameObject left_hand;
    public GameObject crane;
    public GameObject Laser;
    public GameObject GrowingBall;
    public GameObject FireBall;

    public int life = 10000;
    private int previous_life;
    public int palier = 100;
    private int max_life;
    private int chauve_souris_nombre = 0;

    public bool is_dying = false;

    public int right_hand_life;
    private bool right_hand_alive = true;
    
    public int left_hand_life;
    private bool left_hand_alive = true;

    private string collidtag;
    // Start is called before the first frame update
    void Start()
    {
        previous_life = life;
        max_life = life;
        
        ThowLaser(left_hand,0f);
        ThowLaser(right_hand,0f);
        //Chauve_souris_attaque(10,0.4f);
    }

    private void Update()
    {
        if (life <= 0)
        {
            Kill();
        }
        else if(previous_life != life && ((int)(previous_life / palier) != (int)(life / palier)))
        {
            Chauve_souris_attaque((2*((max_life/palier) - life/palier)),0.4f);
            previous_life = life;
        }

        if (right_hand_alive && (right_hand_life <= 0))
        {
            Kill_right_hand();
        }
        if (left_hand_alive && (left_hand_life <= 0))
        {
            Kill_left_hand();
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
        Destroy(gameObject);
    }

    private void Kill_right_hand()
    {
        right_hand_alive = false;
        //Destroy(right_hand);
        right_hand.transform.localScale.Scale(new Vector3(0f,0f,0f));
        
    }
    
    private void Kill_left_hand()
    {
        left_hand_alive = false;
        Destroy(left_hand);
    }

    public void Left_hand_take_damage(int damage)
    {
        left_hand_life -= damage;
    }
    public void Right_hand_take_damage(int damage)
    {
        right_hand_life -= damage;
    }

    public override void InflictDamage(int i)
    {
        life -= i;
    }

    private void ThowLaser(GameObject hand_from, float duration)
    {
        GameObject las = Instantiate(Laser, hand_from.transform.position, Quaternion.Euler(0,0,0),hand_from.transform);
        las.GetComponent<Laser_Script>().DestroyIn(duration);
    }
}
