using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ya_Shoot : MonoBehaviour
{
    private Animator Player;
    public List<GameObject> Bullets;
    public GameObject[] FirePoint; // 0=Front / 1=Side / 2=Back / 3=Reverse

    private int ActualBullet = 0;
    public float Cooldown;
    private float actuCD;

    // Start is called before the first frame update
    void Start()
    {
        Player = gameObject.GetComponent<Animator>();
        actuCD = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Z) && actuCD<0)
        {
            Instantiate(Bullets[ActualBullet], FirePoint[2].transform.position, Quaternion.Euler(0,0,0));
            actuCD = Cooldown;

        }
        else if (Input.GetKey(KeyCode.Q) && actuCD < 0)
        {            
            if (transform.rotation.y != 0)
            {
                Instantiate(Bullets[ActualBullet], FirePoint[3].transform.position, Quaternion.Euler(0, 0, 90));                
            }
            else
            {
                Instantiate(Bullets[ActualBullet], FirePoint[1].transform.position, Quaternion.Euler(0, 0, 90));                
            }
            actuCD = Cooldown;
        }
        else if (Input.GetKey(KeyCode.D) && actuCD < 0)
        {
            if (transform.rotation.y == 0)
            {
                Instantiate(Bullets[ActualBullet], FirePoint[3].transform.position, Quaternion.Euler(0, 0, -90));
            }
            else
            {
                Instantiate(Bullets[ActualBullet], FirePoint[1].transform.position, Quaternion.Euler(0, 0, -90));
            }
            actuCD = Cooldown;
        }
        else if (Input.GetKey(KeyCode.S) && actuCD < 0)
        {
            Instantiate(Bullets[ActualBullet], FirePoint[0].transform.position, Quaternion.Euler(0, 0, 180));
            actuCD = Cooldown;
        }

        actuCD -= Time.deltaTime;
    }
}
