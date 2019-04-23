using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int Largeur;

    public int Hauteur;

    public GameObject T_Wall;
    public GameObject B_Wall;
    public GameObject L_Wall;
    public GameObject R_Wall;

    public GameObject T_L_Corner;
    public GameObject T_R_Corner;
    public GameObject B_L_Corner;
    public GameObject B_R_Corner;

    public float SBW = 20.58f;
    public GameObject[] Floors;
    public GameObject EntryOpen;
    public GameObject EntryClose;

    public bool TopEntry;
    public bool BotEntry;
    public bool LeftEntry;
    public bool RightEntry;

    private bool AreEntryOpen = false;

    private Vector3 Coord;

    private GameObject[] enemys;

    // Start is called before the first frame update
    void Start()
    {
        Coord = transform.position;
        int len = Floors.Length;
        int pos;
        Instantiate(T_L_Corner, Coord, transform.rotation, transform);
        Coord += new Vector3(SBW * 3 / 4, 0);
        for (int i = 0; i < Largeur; i++)
        {
            Instantiate(T_Wall, Coord, transform.rotation, transform);
            Coord += new Vector3(SBW / 2, 0);
        }
        Coord += new Vector3(SBW * 1 / 4, 0);
        Instantiate(T_R_Corner, Coord, transform.rotation, transform);

        Coord = transform.position - new Vector3(0, SBW * 3 / 4);
        for (int j = 0; j < Hauteur; j++)
        {
            Instantiate(L_Wall, Coord, transform.rotation, transform);
            Coord += new Vector3(SBW * 3 / 4, 0);
            for (int i = 0; i < Largeur; i++)
            {
                if ((j == 0 && TopEntry && i == Largeur / 2) || (j == Hauteur / 2 && LeftEntry && i == 0) || (j == Hauteur - 1 && BotEntry && i == Largeur / 2) || (j == Hauteur / 2 && RightEntry && i == Largeur - 1))
                {
                    Instantiate(EntryClose, Coord, transform.rotation, transform);
                }
                else
                {
                    pos = Random.Range(0, len);
                    Instantiate(Floors[pos], Coord, transform.rotation, transform);
                }
                Coord += new Vector3(SBW / 2, 0);
            }
            Coord += new Vector3(SBW * 1 / 4, 0);
            Instantiate(R_Wall, Coord, transform.rotation, transform);
            Coord = transform.position - new Vector3(0, SBW * j / 2 + SBW * 5 / 4);
        }

        Coord -= new Vector3(0, SBW / 4);
        Instantiate(B_L_Corner, Coord, transform.rotation, transform);
        Coord += new Vector3(SBW * 3 / 4, 0);
        for (int i = 0; i < Largeur; i++)
        {
            Instantiate(B_Wall, Coord, transform.rotation, transform);
            Coord += new Vector3(SBW / 2, 0);
        }
        Coord += new Vector3(SBW * 1 / 4, 0);
        Instantiate(B_R_Corner, Coord, transform.rotation, transform);
    }

    private void Update()
    {
        
        if ( !AreEntryOpen)
        {
            enemys = GameObject.FindGameObjectsWithTag("Enemy");
            if (enemys.Length == 0)
            {
                GameObject port;
                if (TopEntry)
                {
                    port = EntryOpen;
                    port.GetComponent<Portal_Open>().sens = PortSens.Top;
                    Instantiate(port, transform.position + new Vector3(SBW / 2 * Largeur / 2 + SBW / 2, -SBW * 3 / 4), transform.rotation, transform);
                }

                if (BotEntry)
                {
                    port = EntryOpen;
                    port.GetComponent<Portal_Open>().sens = PortSens.Bot;
                    Instantiate(port, transform.position + new Vector3(SBW / 2 * Largeur / 2 + SBW / 2, -SBW * 3 / 4 - (Hauteur - 1) * SBW / 2), transform.rotation, transform);
                }

                if (LeftEntry)
                {
                    port = EntryOpen;
                    port.GetComponent<Portal_Open>().sens = PortSens.Left;
                    Instantiate(port, transform.position + new Vector3(SBW * 3 / 4, -SBW * Hauteur / 2 / 2 - SBW / 2), transform.rotation, transform);
                }

                if (RightEntry)
                {
                    port = EntryOpen;
                    port.GetComponent<Portal_Open>().sens = PortSens.Right;
                    Instantiate(port, transform.position + new Vector3(SBW * 3 / 4 + SBW / 2 * (Largeur - 1), -SBW * Hauteur / 2 / 2 - SBW / 2), transform.rotation, transform);
                }

                AreEntryOpen = true;
            }           
        }
    }

    public void ChangeTop(bool caca)
    {
        TopEntry = caca;
    }

    public void ChangeBot(bool caca)
    {
        BotEntry = caca;
    }

    public void ChangeLeft(bool caca)
    {
        LeftEntry = caca;
    }

    public void ChangeRight(bool caca)
    {
        RightEntry = caca;
    }
}