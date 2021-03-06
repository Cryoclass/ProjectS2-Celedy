using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    private GameObject Player;


    //Slider
    public GameObject HeadSlider;
    public GameObject RHandSlider;
    public GameObject LHandSlider;




    private bool Last_chaves_souris = false;
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
    // private bool spawning_bat = false;

    private float FireBallAnimation_Timer = 0;

    private bool Last_laser_was_symetric = false;
    private bool Is_Shooting_Laser = false;

    private float laser_timer = 9;

    private string collidtag;

    private GameObject current_little_fireBall;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        previous_life = life;
        max_life = life;
        Player = GameObject.FindGameObjectWithTag("Player");

        LHandSlider.GetComponent<Slider>().maxValue = left_hand_life;
        RHandSlider.GetComponent<Slider>().maxValue = right_hand_life;
        HeadSlider.GetComponent<Slider>().maxValue = max_life;

        LHandSlider.GetComponent<Slider>().minValue = 0;
        RHandSlider.GetComponent<Slider>().minValue = 0;
        HeadSlider.GetComponent<Slider>().minValue = 0;


        HeadSlider.GetComponent<Slider>().value = life;
        LHandSlider.GetComponent<Slider>().value = left_hand_life;
        RHandSlider.GetComponent<Slider>().value = right_hand_life;
    }

    private void Update()
    {
        if (laser_timer <= 0)
        {
            Attack_laser();
        }
        if (life <= 0)
        {
            Kill();
        }
        else if (life < 1200 && !Thowing_fire_ball)
        {
            Spawn_FireBall();
        }
        else if(previous_life != life && ((int)(previous_life / palier) != (int)(life / palier)))
        {
            if (!Last_chaves_souris)
            {
                Chauve_souris_attaque((8*((max_life/palier) - life/palier)),0.4f);
                Last_chaves_souris = !Last_chaves_souris;
            }
            else
            {
                Last_chaves_souris = !Last_chaves_souris;
                Spawn_FireBall();
            }
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
        if (laser_timer > 0)
        {
            laser_timer -= Time.deltaTime;
            if (laser_timer < 13)
                Is_Shooting_Laser = false;
        }
        if(laser_timer <= 0)
            Attack_laser();
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
        LHandSlider.GetComponent<Slider>().value = left_hand_life;
    }
    public void Right_hand_take_damage(int damage)
    {
        right_hand_life -= damage;
        RHandSlider.GetComponent<Slider>().value = right_hand_life;
    }

    public override void InflictDamage(int i)
    {
        life -= i;
        HeadSlider.GetComponent<Slider>().value = life;
    }

    private void ThowLaser(GameObject hand_from, float duration)
    {
        GameObject las = Instantiate(Laser, hand_from.transform.position + new Vector3(1f,-5,0f), Quaternion.Euler(0,0,0),hand_from.transform);
        las.GetComponent<Laser_Script>().DedIn(duration);
    }


    public void DestroyLaser(GameObject hand)
    {
        hand.GetComponentInChildren<Laser_Script>().DedIn(0f);
    }

    private void ManageAnimator()
    {
        if (!Open_mouse && Is_Shooting_Laser && Last_laser_was_symetric)
        {
            anim.SetBool("Laser_opposit",true);
            anim.SetBool("Is_Shooting_Laser",true);
            anim.SetBool("Must_open-mouse",false);
        }
        else if (!Open_mouse && Is_Shooting_Laser && !Last_laser_was_symetric)
        {
            anim.SetBool("Laser_opposit",false);
            anim.SetBool("Is_Shooting_Laser",true);
            anim.SetBool("Must_open-mouse",false);
        }
        else if(Open_mouse && Is_Shooting_Laser && Last_laser_was_symetric)
        {
            anim.SetBool("Laser_opposit",true);
            anim.SetBool("Is_Shooting_Laser",true);
            anim.SetBool("Must_open-mouse",true);
        }
        else if (Open_mouse && Is_Shooting_Laser && !Last_laser_was_symetric)
        {
            anim.SetBool("Laser_opposit",false);
            anim.SetBool("Is_Shooting_Laser",true);
            anim.SetBool("Must_open-mouse",true);
        }
        else if (Open_mouse)
        {
            anim.SetBool("Must_open-mouse",true);
            anim.SetBool("Is_Shooting_Laser",false);
        }
        
        else
        {
            anim.SetBool("Must_open-mouse",false);
            anim.SetBool("Is_Shooting_Laser",false);
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

    private void ShootFireBall()
    {
        if(ActualFireBall!= null)
        {
            if (ActualFireBall.transform.localScale.x <= 2 || ActualFireBall.transform.localScale.y <= 2)
            {
                Destroy(ActualFireBall);
                CancelInvoke("ShootFireBall");
            }
            VectOfShoot = Player.transform.position - PointShootInMouseOpen.transform.position;
            float rotZ = Mathf.Atan2(VectOfShoot.y, VectOfShoot.x) * Mathf.Rad2Deg;
            ActualFireBall.transform.localScale -= new Vector3(0.3f, 0.3f);
            current_little_fireBall = Instantiate(FireBall, PointShootInMouseOpen.transform.position, Quaternion.Euler(0f, 0f, rotZ - 90), transform);
            current_little_fireBall.GetComponent<SpellArchetype>().FromEnemy = true;
        }
        
    }

    private Vector3 VectOfShoot { get; set; }

    private void MakeFireGrow()
    {
        if (FireBallAnimation_Timer < 1)
        {
            CancelInvoke("MakeFireGrow");
            InvokeRepeating("ShootFireBall",1,0.4f);
            GrowingBall.GetComponentInChildren<ParticleSystem>().Stop();
        }
        if(ActualFireBall != null) ActualFireBall.transform.localScale += new Vector3(0.01f,0.01f);
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
    private void Attack_laser()
    {
        if (laser_timer <= 0)
        {
            laser_timer = 26;
            Is_Shooting_Laser = true;
            Last_laser_was_symetric = !Last_laser_was_symetric;
            ThowLaser(left_hand,14.6f);
            ThowLaser(right_hand,14.6f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Ya_Health>().Take_hit();
        }
    }
}
