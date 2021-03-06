﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class ExitBoss : MonoBehaviour
{

    public GameObject Laser;
    private int InviIteration;
    private SpriteRenderer sprR;

    public Sprite PortalClose;
    public Sprite PortalOpen;
    public bool TpLaunched;

    public GameObject LevelGenerator;

    private bool isopen = false;
    

    public float countingCD;

    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = PortalClose;
        TpLaunched = false;
        LevelGenerator = GameObject.FindGameObjectWithTag("LevelGen");
    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ya_Foot" && isopen)
        {
            Instantiate(Laser, transform.position, transform.rotation);
            InvokeRepeating("MakeInvisible", 0, 0.2f);
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
        Debug.Log(PlayerPrefs.GetInt("BigBossBeaten"));
        Debug.Log(PlayerPrefs.GetInt("SmallBossBeaten"));

        if (PlayerPrefs.GetInt("SmallBossBeaten") >= 2)
        {
            Debug.Log("Gros boss");
            List<string> serv = LevelGenerator.GetComponent<LevelGen>().GetBigBoss();
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MainCam>().InSquelletteRoom = PlayerPrefs.GetInt("BigBossBeaten") == 0;
            int a = PlayerPrefs.GetInt("BigBossBeaten");
            if (a >= 2)
            {
                a = 1;
            }
            SceneManager.LoadScene(serv[a]);
        }
        else
        {
            Debug.Log("Petit boss");
            List<string> serv = LevelGenerator.GetComponent<LevelGen>().GetSmallBoss();
            int a = Random.Range(0, serv.Count);
            Debug.Log(a);
            SceneManager.LoadScene(serv[a]);
        }
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MainCam>().SetPos(0, 0);





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
