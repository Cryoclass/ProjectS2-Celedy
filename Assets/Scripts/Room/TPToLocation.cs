using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPToLocation : MonoBehaviour
{

    public GameObject Laser;
    private int InviIteration;
    private SpriteRenderer sprR;

    public Sprite PortalClose;
    public Sprite PortalOpen;
    private bool TpLaunched;    

    private bool isopen = false;

    public float XToTp;
    public float YToTp;
    

    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = PortalClose;
        TpLaunched = false;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ya_Foot" && isopen)
        {
            Instantiate(Laser, transform.position, transform.rotation);
            InvokeRepeating("MakeInvisible", 0, 0.2f);
            if (!TpLaunched)
            {
                TpLaunched = true;
                Invoke("Tplauncher", 1);
                /*
                Task.Run(() =>
                {
                    TpLaunched = true;
                    switch (sens)
                    {
                        case PortSens.Left:
                            GameObject.FindGameObjectWithTag("Player").GetComponent<YaMoove>().Teleport((int)-deplx * 1 / 10, 0);
                            break;

                        case PortSens.Bot:
                            GameObject.FindGameObjectWithTag("Player").GetComponent<YaMoove>().Teleport(0, (int)-deply * 1 / 10);
                            break;

                        case PortSens.Top:
                            GameObject.FindGameObjectWithTag("Player").GetComponent<YaMoove>().Teleport(0, (int)deply * 1 / 10);
                            break;

                        case PortSens.Right:
                            GameObject.FindGameObjectWithTag("Player").GetComponent<YaMoove>().Teleport((int)deplx * 1 / 10, 0);
                            break;

                        default:
                            break;
                    }
                    Thread.Sleep(200);
                    InviIteration = 0;
                    TpLaunched = false;
                    
                });
                */
            }
        }



    }

    private void Tplauncher()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Ya_Shoot>().SetPos(XToTp, YToTp - 4);
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<Ya_Shoot>().Ally != null)
            GameObject.FindGameObjectWithTag("Player").GetComponent<Ya_Shoot>().Ally.GetComponent<AbstractAlly>().SetPos(XToTp, YToTp);
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MainCam>().SetPos(XToTp, YToTp);

        // PlayerPrefs.GetInt("PlayerCurrentLife");
    }

    private void MakeInvisible()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Ya_Invisible>().invisible();

        if (GameObject.FindGameObjectWithTag("Player").GetComponent<Ya_Shoot>().Ally != null)
            GameObject.FindGameObjectWithTag("Player").GetComponent<Ya_Shoot>().Ally.GetComponent<AbstractAlly>().invisible();
        InviIteration++;
    }

    public void OpenIt()
    {
        if (!isopen)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = PortalOpen;
            isopen = true;
        }
    }
    public void CloseIt()
    {
        if (isopen)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = PortalClose;
            isopen = false;
        }
    }
}
