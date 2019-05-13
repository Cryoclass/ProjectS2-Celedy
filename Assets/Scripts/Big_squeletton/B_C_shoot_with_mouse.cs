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
    public GameObject PointShootInMouseOpen;

    private GameObject ActualFireBall;

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

    private bool Open_mouse = false;

    private Animator anim;

    private bool Thowing_fire_ball = false;
    private bool spawning_bat = false;

    private float FireBallAnimation_Timer = 0;

    private string collidtag;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        previous_life = life;
        max_life = life;
        ThowLaser(right_hand,0f);
        ThowLaser(left_hand,0f);
        //Chauve_souris_attaque(10,0.4f);
    }

    private void Update()
    {
        if (life <= 0)
        {
            Kill();
        }
        else if(life < 900)
        {
            DestroyLaser(right_hand);
        }
        else if (life < 1200 && !Thowing_fire_ball)
        {
            Spawn_FireBall();
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
        ManageAnimator();
    }

    public void Chauve_souris_attaque(int nombre, float delai_entre_chaque)
    {
        chauve_souris_nombre += nombre;
        InvokeRepeating("Chauve_souris_spawn",0f,delai_entre_chaque);
        chauve_souris_nombre = nombre;
    }
    
    public void Chauve_souris_spawn()
    {
        if (!Thowing_fire_ball)
        {
            Instantiate(chauve_souris, top_mouse.transform.position, transform.rotation);
            if (!Open_mouse)
                Open_mouse = true;
            if (chauve_souris_nombre > 0)
                chauve_souris_nombre--;
            else
            {
                Open_mouse = false;
                CancelInvoke("Chauve_souris_spawn");
            }
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
        right_hand.SetActive(false);
    }
    
    private void Kill_left_hand()
    {
        left_hand_alive = false;
        left_hand.SetActive(left_hand_alive);
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
    }
    public void DestroyLaser(GameObject hand)
    {
        hand.GetComponentInChildren<Laser_Script>().Ded();
    }

    private void ManageAnimator()
    {
        if(Open_mouse)
            anim.SetBool("Must_open-mouse",true);
        else
        {
            anim.SetBool("Must_open-mouse",false);
        }
    }

    private void Spawn_FireBall()
    {
        Open_mouse = true;
        Thowing_fire_ball = true;
        ActualFireBall = Instantiate(GrowingBall,PointShootInMouseOpen.transform.position,Quaternion.Euler(0f,0f,0f),gameObject.transform);
        FireBallAnimation_Timer = 5;
        InvokeRepeating("MakeFireGrow",0f,Time.deltaTime);
        InvokeRepeating("DecreaseFireTimer",0f,Time.deltaTime);
    }

    private void MakeFireGrow()
    {
        if(FireBallAnimation_Timer < 1)
            CancelInvoke("MakeFireGrow");
        ActualFireBall.transform.localScale += new Vector3(0.04f,0.04f);
    }

    private void DecreaseFireTimer()
    {
        if (FireBallAnimation_Timer > 0)
            FireBallAnimation_Timer -= Time.deltaTime;
        else
        {
            CancelInvoke("DecreaseFireTimer");
            Open_mouse = false;
        }
    }
    
}
