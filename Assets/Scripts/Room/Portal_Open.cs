using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;


public enum PortSens
{
    Right,
    Left,
    Top,
    Bot
}

public class Portal_Open : MonoBehaviour
{
    public GameObject Laser;
    private int InviIteration;
    public PortSens sens;
    public bool TpLaunched;
    public float deplx;
    public float deply;

    public float countingCD;

    void Start()
    {
        TpLaunched = false;
        deplx = GameObject.FindGameObjectWithTag("LevelGen").GetComponent<LevelGen>().spacedx;
        deply = GameObject.FindGameObjectWithTag("LevelGen").GetComponent<LevelGen>().spacedy;
    }

    // Update is called once per frame
    void Update()
    {
        if (InviIteration >= 3)
            CancelInvoke("MakeInvisible");

        if (countingCD >= 0)
            countingCD -= Time.deltaTime;
        else if (TpLaunched)
        {
            TpLaunched = false;
            InviIteration = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ya_Foot")
        {
            Instantiate(Laser, transform.position,transform.rotation);
            InvokeRepeating("MakeInvisible",0,0.2f);
            if (!TpLaunched)
            {
                countingCD = 3;
                TpLaunched = true;
                Invoke("Tplauncher", 2);
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
        switch (sens)
        {
            case PortSens.Left:
                GameObject.FindGameObjectWithTag("Player").GetComponent<YaMoove>().Teleport((int)(-deplx * 1 / 3), 0);
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MainCam>().Teleport((int)-deplx, 0);
                try
                {
                    GameObject.FindGameObjectWithTag("MiniMap").GetComponent<MiniMap>().ChangeCol(-1, 0);
                }
                catch (Exception)
                {

                    
                }                    
                break;

            case PortSens.Bot:
                GameObject.FindGameObjectWithTag("Player").GetComponent<YaMoove>().Teleport(0, (int)-deply * 1 / 2);
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MainCam>().Teleport(0, (int)-deply);
                GameObject.FindGameObjectWithTag("MiniMap").GetComponent<MiniMap>().ChangeCol(0, -1);
                break;

            case PortSens.Top:
                GameObject.FindGameObjectWithTag("Player").GetComponent<YaMoove>().Teleport(0, (int)deply * 1 / 2);
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MainCam>().Teleport(0, (int)deply);
                GameObject.FindGameObjectWithTag("MiniMap").GetComponent<MiniMap>().ChangeCol(0, 1);
                break;

            case PortSens.Right:
                GameObject.FindGameObjectWithTag("Player").GetComponent<YaMoove>().Teleport((int)(deplx * 1 / 3), 0);
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MainCam>().Teleport((int)deplx, 0);
                GameObject.FindGameObjectWithTag("MiniMap").GetComponent<MiniMap>().ChangeCol(1, 0);
                break;

            default:
                break;
        }
        Debug.Log("TpDone");
    }

    private void MakeInvisible()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Ya_Invisible>().invisible();
        InviIteration++;
    }
}
