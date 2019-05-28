using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Drk_IA : MonoBehaviour
{
    private GameObject Target;
    public int Range;
    private Vector3 Distance;
    private float angle;
    private int ShootDirection; // 1 = Right ; 2 = Left ; 3 = Up ; 4 = Down
    private float TestAngle;

    private Animator anim;
    private bool Was_Moving;
    private Vector2 LastMove;
    private float x;
    private float y;

    private float CD;
    public float ReloadTime;
    public float speed;

    public List<GameObject> Drops;
    public int RateDrop;


    public Slider HealthBar;
    public Canvas Chose;

    // Start is called before the first frame update
    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        HealthBar.value = transform.GetComponent<MonsterLife>().Life;

        Was_Moving = false;
        x = 0;
        y = 0;

        Distance = (Target.transform.position - this.transform.position);
        


        angle = Vector3.Angle(new Vector3(1, 0, 0), Distance);
        if (Target.transform.position.y < this.transform.position.y)
            angle = -angle;



        if (45 <= angle && angle < 135)
        {
            TestAngle = angle - 90;
            Was_Moving = true;
            x = 1;
            LastMove = new Vector2(x, 0f);
            if (Mathf.Abs(transform.position.x - Target.transform.position.x) < 0.1)
            {
                
            }
            else
            {                
                if (TestAngle < 0)
                    transform.position = transform.position + new Vector3(2 * Time.deltaTime, 0, 0)*speed;
                else
                    transform.position = transform.position + new Vector3(-2 * Time.deltaTime, 0, 0) * speed;
            }

        }
        else if (-135 <= angle && angle < -45)
        {
            TestAngle = angle + 90;
            Was_Moving = true;
            x = -1;
            LastMove = new Vector2(x, 0f);
            if (Mathf.Abs(transform.position.x - Target.transform.position.x) < 0.1)
            {
                
            }
            else
            {                
                if (TestAngle < 0)
                    transform.position = transform.position + new Vector3(-10 * Time.deltaTime, 0, 0) * speed;
                else
                    transform.position = transform.position + new Vector3(10 * Time.deltaTime, 0, 0) * speed;
            }

        }
        else if (-45 <= angle && angle < 45)
        {
            TestAngle = angle;
            Was_Moving = true;
            y = 1;
            LastMove = new Vector2(0f, y);
            if (Mathf.Abs(transform.position.y - Target.transform.position.y) < 0.1)
            {
                
            }
            else
            {
                
                if (TestAngle < 0)
                    transform.position = transform.position + new Vector3(0, -10 * Time.deltaTime, 0) * speed;
                else
                    transform.position = transform.position + new Vector3(0, 10 * Time.deltaTime, 0) * speed;
            }
        }
        else
        {
            TestAngle = (angle - 180) % 360;
            Was_Moving = true;
            y = -1;
            LastMove = new Vector2(0f, y);
            if (Mathf.Abs(transform.position.y - Target.transform.position.y) < 0.1)
            {
                
            }
            else
            {                
                if (TestAngle < -60)
                    transform.position = transform.position + new Vector3(0, 10*-speed * Time.deltaTime, 0) ;
                else
                    transform.position = transform.position + new Vector3(0, 10*speed * Time.deltaTime, 0);
            }

        }


        if (Distance.sqrMagnitude > Range)
        {
            transform.position += Distance * speed * Time.deltaTime;
        }
        else if (Distance.sqrMagnitude < Range *9/10)
        {
            transform.position -= Distance * speed * Time.deltaTime;
        }
        

        anim.SetFloat("MoveX", y);
        anim.SetFloat("MoveY", x);
        anim.SetBool("Was_Moving", Was_Moving);
        anim.SetFloat("LastMoveX", LastMove.y);
        anim.SetFloat("LastMoveY", LastMove.x);

        CD -= 10 * Time.deltaTime;      
                    
    }

    private void OnDestroy()
    {
        if (Drops != null && Random.Range(0, 100) > RateDrop)
            Instantiate(Drops[Random.Range(0, Drops.Count)], transform.position, transform.rotation);
    }
}
