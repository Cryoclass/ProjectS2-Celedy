using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringFighter : MonoBehaviour
{
    public GameObject ToRotate { get; set; }
    public GameObject WebFirePoint { get; set; }

    public Rigidbody2D rb { get; set; }

    private bool IsMoving { get; set; }

    public float TimeBtwLaunch;
    private float CdBeforeLaunch;

    public GameObject Arrow;


    private PortSens SensOfActualWall;

    public GameObject WebCreatorObj;
    private GameObject WebCreatorLauched;

    private Queue<GameObject> Webs;

    // Start is called before the first frame update
    void Start()
    {

        IsMoving = false;
        CdBeforeLaunch = TimeBtwLaunch;
    }

    // Update is called once per frame
    void Update()
    {        
        if(!IsMoving && CdBeforeLaunch <= 0)
        {
            WebCreatorLauched = Instantiate(WebCreatorObj, WebFirePoint.transform.position, ToRotate.transform.rotation, transform);
            

            CdBeforeLaunch = TimeBtwLaunch;
        }
        else if(!IsMoving)
        {
            CdBeforeLaunch -= 2 * Time.deltaTime;
        }
        else
        {

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wall" )
        {
            SensOfActualWall = collision.gameObject.GetComponent<WallS>().sens;
            rb.velocity = new Vector2(0,0);
            IsMoving = false;
        }
    }

    private void ArrowRotation()
    {

    }

    public void SetWeb()
    {

    }
    
}
