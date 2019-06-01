using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalExitIntro : MonoBehaviour
{
    public GameObject Laser;

    private int InviIteration;
    private bool TpLaunched;

    public bool isopen = false;

    public string SceneToLoad;
    

    public Sprite open;
    public Sprite close;

    private float countingCD;

    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = close;
        TpLaunched = false;
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
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MainCam>().SetPos(0, 0);
        PlayerPrefs.SetInt("PlayerCurrentLife", GameObject.FindGameObjectWithTag("Player").GetComponent<Ya_Health>().CurrentHealth);
        SceneManager.LoadScene(SceneToLoad);
    }

    private void MakeInvisible()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Ya_Invisible>().invisible();
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<Ya_Shoot>().Ally != null)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Ya_Shoot>().Ally.GetComponent<AbstractAlly>().invisible();
        }
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
