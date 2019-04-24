using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int Largeur;
    public int Hauteur;

    public int Coordx;
    public int Coordy;

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

    public bool TopEntry;
    public bool BotEntry;
    public bool LeftEntry;
    public bool RightEntry;

    private bool AreEntryOpen = false;

    private Vector3 Coord;

    private List<int[]> PossibleSpawn;

    private GameObject[] enemys;
    private List<GameObject> PortalList;

    // Start is called before the first frame update
    void Start()
    {
        PossSpawnCreat();

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
                if (j == 0 && TopEntry && i == Largeur / 2)
                {
                    GameObject port;
                    port = EntryOpen;
                    port.GetComponent<Portal_Open>().sens = PortSens.Top;
                    port.GetComponent<Portal_Open>().CoordX = this.Coordx;
                    port.GetComponent<Portal_Open>().CoordY = this.Coordy;
                    PortalList.Add(Instantiate(port, Coord, transform.rotation, transform));

                }                                  
                else if (j == Hauteur / 2 && LeftEntry && i == 0)
                {
                    GameObject port;
                    port = EntryOpen;
                    port.GetComponent<Portal_Open>().sens = PortSens.Left;
                    port.GetComponent<Portal_Open>().CoordX = this.Coordx;
                    port.GetComponent<Portal_Open>().CoordY = this.Coordy;
                    PortalList.Add(Instantiate(port, transform.position + new Vector3(SBW * 3 / 4, -SBW * Hauteur / 2 / 2 - SBW / 2), transform.rotation, transform));
                }
                else if (j == Hauteur - 1 && BotEntry && i == Largeur / 2)
                {
                    GameObject port;
                    port = EntryOpen;
                    port.GetComponent<Portal_Open>().sens = PortSens.Bot;
                    port.GetComponent<Portal_Open>().CoordX = this.Coordx;
                    port.GetComponent<Portal_Open>().CoordY = this.Coordy;
                    PortalList.Add(Instantiate(port, transform.position + new Vector3(SBW / 2 * Largeur / 2 + SBW / 2, -SBW * 3 / 4 - (Hauteur - 1) * SBW / 2), transform.rotation, transform));
                }
                else if (j == Hauteur / 2 && RightEntry && i == Largeur - 1)
                {
                    GameObject port;
                    port = EntryOpen;
                    port.GetComponent<Portal_Open>().sens = PortSens.Right;
                    port.GetComponent<Portal_Open>().CoordX = this.Coordx;
                    port.GetComponent<Portal_Open>().CoordY = this.Coordy;
                    PortalList.Add(Instantiate(port, transform.position + new Vector3(SBW * 3 / 4 + SBW / 2 * (Largeur - 1), -SBW * Hauteur / 2 / 2 - SBW / 2), transform.rotation, transform));
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
        enemys = GameObject.FindGameObjectsWithTag("Enemy");
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

    private void PossSpawnCreat()
    {
        PossibleSpawn = new List<int[]>();
        PossibleSpawn.Add(new int[2] {2,0 });
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
        PossibleSpawn.Add(new int[2] { 8, 4 });
        PossibleSpawn.Add(new int[2] { 9, 4 });
        PossibleSpawn.Add(new int[2] { 10, 4 });
        PossibleSpawn.Add(new int[2] { 11, 4 });
        PossibleSpawn.Add(new int[2] { 5, 4 });
    }
}