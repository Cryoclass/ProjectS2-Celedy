using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringFighter : MonoBehaviour
{
    public GameObject ToRotate { get; set; }
    public GameObject WebFirePoint { get; set; }
    private bool RightToLeft;
    private int TimeBeforeChange;


    public Rigidbody2D rb { get; set; }

    private bool IsMoving { get; set; }

    public float TimeBtwLaunch;
    private float CdBeforeLaunch;

    public GameObject Arrow;

    public float Speed;

    private PortSens SensOfActualWall;

    public GameObject WebCreatorObj;
    private GameObject WebCreatorLauched;

    private Queue<GameObject> Webs;
    public bool WebsReceived;

    private float TimeForNextWeb;
    private float ActualTimeForNextWeb;

    // Start is called before the first frame update
    void Start()
    {
        IsMoving = false;
        CdBeforeLaunch = TimeBtwLaunch;
        TimeForNextWeb = 5 / Speed;
    }

    // Update is called once per frame
    void Update()
    {        
        if(!IsMoving && CdBeforeLaunch <= 0 && WebsReceived)
        {
            WebCreatorLauched = Instantiate(WebCreatorObj, WebFirePoint.transform.position, ToRotate.transform.rotation, transform);
            ToRotate.SetActive(false);

            WebsReceived = false;
            CdBeforeLaunch = TimeBtwLaunch;
        }
        else if(!IsMoving && WebsReceived)
        {
            ArrowRotation();
            CdBeforeLaunch -= 2 * Time.deltaTime;
        }
        else if (!IsMoving)
        {
            if (ActualTimeForNextWeb <= 0)
            {
                transform.rotation = Webs.Dequeue().transform.rotation;
                rb.velocity = transform.up * Speed;
                ActualTimeForNextWeb = TimeForNextWeb;
            }
            else
            {
                ActualTimeForNextWeb -= 2 * Time.deltaTime;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Webs.Count <= 2 && collision.tag == "Wall")
        {
            SensOfActualWall = collision.gameObject.GetComponent<WallS>().sens;
            rb.velocity = new Vector2(0, 0);
            IsMoving = false;
            ToRotate.SetActive(true);
            switch (SensOfActualWall)
            {
                case PortSens.Bot:
                    ToRotate.transform.rotation = Quaternion.Euler(0, 0, 0);
                    break;


                case PortSens.Left:
                    ToRotate.transform.rotation = Quaternion.Euler(0, 0, -90);
                    break;


                case PortSens.Right:
                    ToRotate.transform.rotation = Quaternion.Euler(0, 0, 90);
                    break;


                case PortSens.Top:
                    ToRotate.transform.rotation = Quaternion.Euler(0, 0, 180);
                    break;
            }


        }
    }

    private void ArrowRotation()
    {
        if (TimeBeforeChange <= 0)
        {
            switch (SensOfActualWall)
            {
                case PortSens.Bot:
                    if (ToRotate.transform.rotation.z >= 90 || ToRotate.transform.rotation.z <= -90)
                    {
                        RightToLeft = !RightToLeft;
                        TimeBeforeChange = 5;
                    }
                    break;


                case PortSens.Left:
                    if (ToRotate.transform.rotation.z >= 0 || ToRotate.transform.rotation.z <= -180)
                    {
                        RightToLeft = !RightToLeft;
                        TimeBeforeChange = 5;
                    }
                    break;


                case PortSens.Right:
                    if (ToRotate.transform.rotation.z >= 180 || ToRotate.transform.rotation.z <= 0)
                    {
                        RightToLeft = !RightToLeft;
                        TimeBeforeChange = 5;
                    }
                    break;


                case PortSens.Top:
                    if (ToRotate.transform.rotation.z >= 270 || ToRotate.transform.rotation.z <= 90)
                    {
                        RightToLeft = !RightToLeft;
                        TimeBeforeChange = 5;
                    }
                    break;
            }
        }

        ToRotate.transform.rotation = Quaternion.Euler(ToRotate.transform.rotation.x, ToRotate.transform.rotation.y, ToRotate.transform.rotation.z + (ToRotate ? -2 : 2));
        
    }

    public void SetWeb(Queue<GameObject> Webs)
    {
        this.Webs = Webs;
        WebsReceived = true;
    }
    
}
