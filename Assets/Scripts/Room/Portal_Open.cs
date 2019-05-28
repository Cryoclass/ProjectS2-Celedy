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
    public bool isopen = false;

    public int CoordX;
    public int CoordY;

    public GameObject LevelGenerator;

    public Sprite open;
    public Sprite close;

    public float countingCD;

    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = close;
        TpLaunched = false;
        LevelGenerator = GameObject.FindGameObjectWithTag("LevelGen");
        deplx = LevelGenerator.GetComponent<LevelGen>().spacedx;
        deply = LevelGenerator.GetComponent<LevelGen>().spacedy;
    }

    // Update is called once per frame
    void Update()
    {
        if (InviIteration >= 3)
            CancelInvoke("MakeInvisible");

        if (countingCD >= 0)
        {
            countingCD -= Time.deltaTime;
        }
        else if (TpLaunched)
        {
            TpLaunched = false;
            InviIteration = 0;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ya_Foot" && isopen)
        {
            Instantiate(Laser, transform.position,transform.rotation);
            InvokeRepeating("MakeInvisible",0,0.2f);
            if (!TpLaunched)
            {
                countingCD = 2;
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
        switch (sens)
        {
            case PortSens.Left:
                LevelGenerator.GetComponent<LevelGen>().Instantiater(CoordX - 1, CoordY);
                GameObject.FindGameObjectWithTag("Player").GetComponent<Ya_Shoot>().Teleport((int)(-deplx * 1 / 2.5), 0);
                GameObject.FindGameObjectWithTag("Player").GetComponent<Ya_Shoot>().Ally.GetComponent<AbstractAlly>().Teleport((float)(-deplx * 1 / 2.5), 0);
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
                LevelGenerator.GetComponent<LevelGen>().Instantiater(CoordX, CoordY - 1);
                GameObject.FindGameObjectWithTag("Player").GetComponent<Ya_Shoot>().Teleport(0, (int)(-deply * 1 / 1.5));
                GameObject.FindGameObjectWithTag("Player").GetComponent<Ya_Shoot>().Ally.GetComponent<AbstractAlly>().Teleport(0, (int)(-deply * 1 / 1.5));
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MainCam>().Teleport(0, (int)-deply);
                try
                {
                    GameObject.FindGameObjectWithTag("MiniMap").GetComponent<MiniMap>().ChangeCol(0, -1);
                }
                catch (Exception)
                {

                    
                }                
                break;

            case PortSens.Top:
                LevelGenerator.GetComponent<LevelGen>().Instantiater(CoordX, CoordY + 1);
                GameObject.FindGameObjectWithTag("Player").GetComponent<Ya_Shoot>().Teleport(0, (int)(deply * 1 / 1.5f));
                GameObject.FindGameObjectWithTag("Player").GetComponent<Ya_Shoot>().Ally.GetComponent<AbstractAlly>().Teleport(0, (int)(deply * 1 / 1.5f));
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MainCam>().Teleport(0, (int)deply);
                try
                {
                    GameObject.FindGameObjectWithTag("MiniMap").GetComponent<MiniMap>().ChangeCol(0, 1);
                }
                catch (Exception)
                {

                    
                }                
                break;

            case PortSens.Right:
                LevelGenerator.GetComponent<LevelGen>().Instantiater(CoordX + 1, CoordY);
                GameObject.FindGameObjectWithTag("Player").GetComponent<Ya_Shoot>().Teleport((int)(deplx * 1 / 2.5), 0);
                GameObject.FindGameObjectWithTag("Player").GetComponent<Ya_Shoot>().Ally.GetComponent<AbstractAlly>().Teleport((int)(deplx * 1 / 2.5), 0);
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MainCam>().Teleport((int)deplx, 0);
                try
                {
                    GameObject.FindGameObjectWithTag("MiniMap").GetComponent<MiniMap>().ChangeCol(1, 0);
                }
                catch (Exception)
                {
                    
                }                
                break;

            default:
                break;
        }
        Debug.Log("TpDone");
    }

    private void MakeInvisible()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Ya_Invisible>().invisible();
        GameObject.FindGameObjectWithTag("Player").GetComponent<Ya_Shoot>().Ally.GetComponent<AbstractAlly>().invisible();
        InviIteration++;
    }

    public void OpenIt()
    {
        if (!isopen)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = open;
            isopen = true;
        }
    }
    public void CloseIt()
    {
        if (isopen)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = close;
            isopen = false;
        }
    }
}
