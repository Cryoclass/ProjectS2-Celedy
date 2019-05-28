using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ya_Shoot : MonoBehaviour
{
    private Animator anim;
    public List<GameObject> Bullets;
    public GameObject[] FirePoint; // 0=Front / 1=Side / 2=Back / 3=Reverse

    private int ActualBullet = 0;
    public float Cooldown;
    private float actuCD;
    private bool Shooting;

    private bool SideMoove;
    private bool FrontMoove;
    private bool BackMoove;
    private float TimeForAnim;

    private bool IsMovingRight;
    private bool IsMovingInY;

    public float Speed;

    public GameObject Ally;


    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        actuCD = 0;
        IsMovingInY = false;
    }

    // Update is called once per frame
    void Update()
    {
        

        // Partie Déplacement

        SideMoove = false;
        FrontMoove = false;
        BackMoove = false;

        if (Shooting)
        {
            Shooting = false;
        }
            

        if (TimeForAnim > 0)
        {
            if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
            {              

                if (Input.GetAxisRaw("Horizontal") > 0.5f)
                {
                    if (transform.rotation.y != 0)
                        transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * Speed * Time.deltaTime, 0f, 0f) * -1);
                    else
                        transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * Speed * Time.deltaTime, 0f, 0f) * 1);


                    IsMovingRight = true;
                }
                    
                else
                {
                    if (transform.rotation.y != 0)
                        transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * Speed * Time.deltaTime, 0f, 0f) * -1);
                    else
                        transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * Speed * Time.deltaTime, 0f, 0f) * 1);

                    IsMovingRight = false;
                }                   


                SideMoove = true;
            }



            if (Input.GetAxisRaw("Vertical") > 0.5f)
            {
                transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * Speed * Time.deltaTime, 0f));
                BackMoove = true;
                IsMovingInY = true;
                IsMovingRight = false;

            }
            else if (Input.GetAxisRaw("Vertical") < -0.5f)
            {
                IsMovingRight = false;
                transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * Speed * Time.deltaTime, 0f));
                IsMovingInY = true;
                FrontMoove = true;
            }
            else
            {
                IsMovingInY = false;
            }
            
        }
        else
        {
            if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
            {
                if (IsMovingInY && Input.GetAxisRaw("Horizontal") > 0.5f)
                {
                    transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * Speed * Time.deltaTime, 0f, 0f) * (-1));
                }
                else
                {
                    transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * Speed * Time.deltaTime, 0f, 0f) * (IsMovingRight ? -1 : 1));
                }




                if (Input.GetAxisRaw("Horizontal") > 0.5f)
                    IsMovingRight = true;
                else
                    IsMovingRight = false;


                SideMoove = true;
            }



            if (Input.GetAxisRaw("Vertical") > 0.5f)
            {
                transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * Speed * Time.deltaTime, 0f));
                BackMoove = true;
                IsMovingInY = true;
                IsMovingRight = false;

            }
            else if (Input.GetAxisRaw("Vertical") < -0.5f)
            {
                IsMovingRight = false;
                transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * Speed * Time.deltaTime, 0f));
                IsMovingInY = true;
                FrontMoove = true;
            }
            else
            {
                IsMovingInY = false;
            }



            if (IsMovingRight || (IsMovingInY && Input.GetAxisRaw("Horizontal") > 0.5f))
                transform.rotation = Quaternion.Euler(0f, 180, 0f);
            else
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);

        }





        anim.SetBool("Walk_back", BackMoove);
        anim.SetBool("Walk_Front", FrontMoove);

        anim.SetBool("Walk_Side", SideMoove);



        // Partie Tir

        if (Input.GetKey(KeyCode.Z) && actuCD < 0)
        {
            Shooting = true;
            TimeForAnim = 0.5f;
            Instantiate(Bullets[ActualBullet], FirePoint[2].transform.position, Quaternion.Euler(0, 0, 0));
            actuCD = Cooldown;

        }
        else if (Input.GetKey(KeyCode.Q) && actuCD < 0)
        {
            Shooting = true;
            TimeForAnim = 0.5f;
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            Instantiate(Bullets[ActualBullet], FirePoint[1].transform.position, Quaternion.Euler(0, 0, 90));
            
            actuCD = Cooldown;
        }
        else if (Input.GetKey(KeyCode.D) && actuCD < 0)
        {
            Shooting = true;
            TimeForAnim = 0.5f;
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            Instantiate(Bullets[ActualBullet], FirePoint[1].transform.position, Quaternion.Euler(0, 0, -90));
            actuCD = Cooldown;
        }
        else if (Input.GetKey(KeyCode.S) && actuCD < 0)
        {
            Shooting = true;
            TimeForAnim = 0.5f;
            Instantiate(Bullets[ActualBullet], FirePoint[0].transform.position, Quaternion.Euler(0, 0, 180));
            actuCD = Cooldown;
        }

        anim.SetBool("Shooting", Shooting);
        actuCD -= Time.deltaTime;
        TimeForAnim -= Time.deltaTime;
        

    }

    public void Teleport(float x, float y)
    {
        transform.position += new Vector3(x, y);
        gameObject.GetComponent<Ya_Invisible>().visible();
    }
}
