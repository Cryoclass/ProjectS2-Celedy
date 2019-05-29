using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebCreator : MonoBehaviour
{
    public GameObject Web;
    public Rigidbody2D rb;

    private Queue<GameObject> Webs;
    public float speed;

    private float newZ;

    private float CD;
    private float ActualCD;

    private int CountReb = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.up * speed;
        Webs = new Queue<GameObject>();
        CD = 5 / speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (CountReb < 6)
        {
            if (ActualCD >= 0)
            {
                ActualCD -= 2 * Time.deltaTime;
            }
            else
            {
                ActualCD = CD;
                Webs.Enqueue(Instantiate(Web, transform.position, transform.rotation));
            }
        }        
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Wall")
        {
            CountReb++;
            Debug.Log(CountReb);
            if(CountReb >= 6)
            {
                rb.velocity = new Vector3(0, 0, 0);
                SendInfo();
                Destroy(gameObject);
            }
            else
            {
                PortSens sens = collision.gameObject.GetComponent<WallS>().sens;
                switch (sens)
                {
                    case PortSens.Bot:
                        newZ = Random.Range(0, 180) - 90;
                        break;

                    case PortSens.Top:
                        newZ = Random.Range(0, 180) + 90;
                        break;

                    case PortSens.Right:
                        newZ = Random.Range(0, 180);
                        break;

                    case PortSens.Left:
                        newZ = Random.Range(0, 180) - 180;
                        break;
                }
                transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, newZ);
                rb.velocity = transform.up * speed;
            }            
        }

    }

    public Queue<GameObject> GetWebs()
    {
        return Webs;
    }

    public void SendInfo()
    {
        transform.GetComponentInParent<StringFighter>().SetWeb(Webs);
    }
    
}
