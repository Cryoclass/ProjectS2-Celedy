﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int Largeur;
    public int Hauteur;

    public int Coordx;
    public int Coordy;

    public List<GameObject> Monsters;
    public List<GameObject> Rocks;

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
    public GameObject ExitEntry;
    public bool IsFinalRoom = false;
    private GameObject FinalPortal;

    public bool TopEntry;
    public bool BotEntry;
    public bool LeftEntry;
    public bool RightEntry;

    public int NbMinEnemy;
    public int NbMaxenemy;
    private int NbEnemy;
    
    public int NbMinRocks;
    public int NbMaxRocks;
    private int NbRocks;

    private Vector3 Coord;

    private List<int[]> PossibleSpawn;

    private List<int[]> ToSpawn;

    private GameObject[] enemys;
    private List<GameObject> PortalList;

    private List<int[]> RocksToSpawn;


    private GameObject LevelGen = null;

    // Start is called before the first frame update
    void Start()
    {
        try
        {
            LevelGen = GameObject.FindGameObjectWithTag("LevelGen");
        }
        catch (System.Exception)
        {
            throw;
        }


        RocksToSpawn = new List<int[]>();
        PossSpawnCreat();
        ToSpawn = new List<int[]>();
        NbEnemy = Random.Range(NbMinEnemy, NbMaxenemy + 1);
        NbRocks = Random.Range(NbMinRocks, NbMaxRocks + 1);
        int b;
        for (int h = 0; h < NbEnemy; h++)
        {
            b = Random.Range(0, PossibleSpawn.Count);
            ToSpawn.Add(PossibleSpawn[b]);
            PossibleSpawn.RemoveAt(b);
        }
        for (int h = 0; h < NbRocks; h++)
        {
            b = Random.Range(0, PossibleSpawn.Count);
            RocksToSpawn.Add(PossibleSpawn[b]);
            PossibleSpawn.RemoveAt(b);
        }

        PortalList = new List<GameObject>();
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
                if (j == 0 && TopEntry && i == Largeur / 2 && !IsFinalRoom)
                {
                    GameObject port;
                    port = EntryOpen;
                    port.GetComponent<Portal_Open>().sens = PortSens.Top;
                    port.GetComponent<Portal_Open>().CoordX = this.Coordx;
                    port.GetComponent<Portal_Open>().CoordY = this.Coordy;
                    PortalList.Add(Instantiate(port, Coord, transform.rotation, transform));

                }                                  
                else if (j == Hauteur / 2 && LeftEntry && i == 0 && !IsFinalRoom)
                {
                    GameObject port;
                    port = EntryOpen;
                    port.GetComponent<Portal_Open>().sens = PortSens.Left;
                    port.GetComponent<Portal_Open>().CoordX = this.Coordx;
                    port.GetComponent<Portal_Open>().CoordY = this.Coordy;
                    PortalList.Add(Instantiate(port, transform.position + new Vector3(SBW * 3 / 4, -SBW * Hauteur / 2 / 2 - SBW / 2), transform.rotation, transform));
                }
                else if (j == Hauteur - 1 && BotEntry && i == Largeur / 2 && !IsFinalRoom)
                {
                    GameObject port;
                    port = EntryOpen;
                    port.GetComponent<Portal_Open>().sens = PortSens.Bot;
                    port.GetComponent<Portal_Open>().CoordX = this.Coordx;
                    port.GetComponent<Portal_Open>().CoordY = this.Coordy;
                    PortalList.Add(Instantiate(port, transform.position + new Vector3(SBW / 2 * Largeur / 2 + SBW / 2, -SBW * 3 / 4 - (Hauteur - 1) * SBW / 2), transform.rotation, transform));
                }
                else if (j == Hauteur / 2 && RightEntry && i == Largeur - 1 && !IsFinalRoom)
                {
                    GameObject port;
                    port = EntryOpen;
                    port.GetComponent<Portal_Open>().sens = PortSens.Right;
                    port.GetComponent<Portal_Open>().CoordX = this.Coordx;
                    port.GetComponent<Portal_Open>().CoordY = this.Coordy;
                    PortalList.Add(Instantiate(port, transform.position + new Vector3(SBW * 3 / 4 + SBW / 2 * (Largeur - 1), -SBW * Hauteur / 2 / 2 - SBW / 2), transform.rotation, transform));
                }
                else if (IsFinalRoom && j == Hauteur / 2 && i == Largeur / 2)
                {
                    FinalPortal = Instantiate(ExitEntry, transform.position + new Vector3(SBW / 2 * Largeur / 2 + SBW / 2, -SBW * Hauteur / 2 / 2 - SBW / 2), transform.rotation, transform);
                }
                else
                {
                    pos = Random.Range(0, len);
                    Instantiate(Floors[pos], Coord, transform.rotation, transform);
                    if(this.LevelGen != null && this.LevelGen.GetComponent<LevelGen>().Ally.Count != 0 && Random.Range(0f,100f)>= 99.5)
                    {
                        int ab = this.LevelGen.GetComponent<LevelGen>().GetIndexOfAlly();
                        Instantiate(this.LevelGen.GetComponent<LevelGen>().Ally[ab], transform.position + new Vector3(SBW / 2 * Largeur / 2 + SBW / 2, -SBW * Hauteur / 2 / 2 - SBW / 2), transform.rotation);
                        this.LevelGen.GetComponent<LevelGen>().DestroyAlly(ab);
                    }
                }
                Coord += new Vector3(SBW / 2, 0);
                foreach(int[] inting in ToSpawn)
                {
                    if (inting[0] == i && inting[1] == j && Monsters.Count != 0)
                    {
                        Debug.Log("Conditon verif");
                        Instantiate(Monsters[Random.Range(0, Monsters.Count)], Coord, transform.rotation, transform);
                    }                    
                }
                foreach(int[] inting in RocksToSpawn)
                {
                    if (inting[0] == i && inting[1] == j && Rocks.Count != 0)
                    {
                        Debug.Log("Conditon verif");
                        Instantiate(Rocks[Random.Range(0, Rocks.Count)], Coord, transform.rotation, transform);
                    }                    
                }
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

        foreach (GameObject portal in PortalList)
        {
            portal.GetComponent<Portal_Open>().Force_Open();
        }

    }

    private void Update()
    {
        enemys = GameObject.FindGameObjectsWithTag("Enemy");
        
        if (IsFinalRoom)
        {
            GameObject[] Bosss = GameObject.FindGameObjectsWithTag("Boss");
            if (enemys.Length == 0 && Bosss.Length == 0)
            {
                try
                {
                    FinalPortal.GetComponent<ExitBoss>().OpenIt();
                }
                catch (System.Exception)
                {
                }

                try
                {
                    FinalPortal.GetComponent<TPToLocation>().OpenIt();
                }
                catch (System.Exception)
                {
                }

                try
                {
                    FinalPortal.GetComponent<PortalExitIntro>().OpenIt();
                }
                catch (System.Exception)
                {
                }

            }
            else
            {
                try
                {
                    FinalPortal.GetComponent<ExitBoss>().CloseIt();
                }
                catch (System.Exception)
                {
                }

                try
                {
                    FinalPortal.GetComponent<TPToLocation>().CloseIt();
                }
                catch (System.Exception)
                {
                }

                try
                {
                    FinalPortal.GetComponent<PortalExitIntro>().CloseIt();
                }
                catch (System.Exception)
                {
                }
                
            }
        }
        else
        {
            if (enemys.Length == 0)
            {
                foreach (GameObject portal in PortalList)
                {
                    portal.GetComponent<Portal_Open>().OpenIt();
                }
            }
            else
            {
                foreach (GameObject portal in PortalList)
                {
                    portal.GetComponent<Portal_Open>().CloseIt();
                }
            }
        }
        
    }

    public void ChangeTop(bool IsEntry)
    {
        TopEntry = IsEntry;
    }

    public void ChangeBot(bool IsEntry)
    {
        BotEntry = IsEntry;
    }

    public void ChangeLeft(bool IsEntry)
    {
        LeftEntry = IsEntry;
    }

    public void ChangeRight(bool IsEntry)
    {
        RightEntry = IsEntry;
    }

    private void PossSpawnCreat()
    {
        PossibleSpawn = new List<int[]>();
        PossibleSpawn.Add(new int[2] { 2, 0 });
        PossibleSpawn.Add(new int[2] { 3, 0 });
        PossibleSpawn.Add(new int[2] { 4, 0 });
        PossibleSpawn.Add(new int[2] { 14, 0 });
        PossibleSpawn.Add(new int[2] { 15, 0 });
        PossibleSpawn.Add(new int[2] { 16, 0 });
        PossibleSpawn.Add(new int[2] { 3, 1 });
        PossibleSpawn.Add(new int[2] { 4, 1 });
        PossibleSpawn.Add(new int[2] { 5, 1 });
        PossibleSpawn.Add(new int[2] { 13, 1 });
        PossibleSpawn.Add(new int[2] { 14, 1 });
        PossibleSpawn.Add(new int[2] { 15, 1 });
        PossibleSpawn.Add(new int[2] { 4, 2 });
        PossibleSpawn.Add(new int[2] { 5, 2 });
        PossibleSpawn.Add(new int[2] { 13, 2 });
        PossibleSpawn.Add(new int[2] { 14, 2 });
        PossibleSpawn.Add(new int[2] { 4, 3 });
        PossibleSpawn.Add(new int[2] { 5, 3 });
        PossibleSpawn.Add(new int[2] { 6, 3 });
        PossibleSpawn.Add(new int[2] { 7, 3 });
        PossibleSpawn.Add(new int[2] { 11, 3 });
        PossibleSpawn.Add(new int[2] { 12, 3 });
        PossibleSpawn.Add(new int[2] { 13, 3 });
        PossibleSpawn.Add(new int[2] { 14, 3 });
        PossibleSpawn.Add(new int[2] { 5, 4 });
        PossibleSpawn.Add(new int[2] { 6, 4 });
        PossibleSpawn.Add(new int[2] { 7, 4 });
        PossibleSpawn.Add(new int[2] { 9, 4 });
        PossibleSpawn.Add(new int[2] { 10, 4 });
        PossibleSpawn.Add(new int[2] { 11, 4 });
        PossibleSpawn.Add(new int[2] { 12, 4 });
        PossibleSpawn.Add(new int[2] { 13, 4 });
        PossibleSpawn.Add(new int[2] { 4, 5 });
        PossibleSpawn.Add(new int[2] { 5, 5 });
        PossibleSpawn.Add(new int[2] { 6, 5 });
        PossibleSpawn.Add(new int[2] { 7, 5 });
        PossibleSpawn.Add(new int[2] { 11, 5 });
        PossibleSpawn.Add(new int[2] { 12, 5 });
        PossibleSpawn.Add(new int[2] { 13, 5 });
        PossibleSpawn.Add(new int[2] { 14, 5 });
        PossibleSpawn.Add(new int[2] { 4, 6 });
        PossibleSpawn.Add(new int[2] { 5, 6 });
        PossibleSpawn.Add(new int[2] { 13, 6 });
        PossibleSpawn.Add(new int[2] { 14, 6 });
        PossibleSpawn.Add(new int[2] { 3, 7 });
        PossibleSpawn.Add(new int[2] { 4, 7 });
        PossibleSpawn.Add(new int[2] { 5, 7 });
        PossibleSpawn.Add(new int[2] { 13, 7 });
        PossibleSpawn.Add(new int[2] { 14, 7 });
        PossibleSpawn.Add(new int[2] { 15, 7 });
        PossibleSpawn.Add(new int[2] { 2, 8 });
        PossibleSpawn.Add(new int[2] { 3, 8 });
        PossibleSpawn.Add(new int[2] { 4, 8 });
        PossibleSpawn.Add(new int[2] { 14, 8 });
        PossibleSpawn.Add(new int[2] { 15, 8 });
        PossibleSpawn.Add(new int[2] { 16, 8 });
    }
}