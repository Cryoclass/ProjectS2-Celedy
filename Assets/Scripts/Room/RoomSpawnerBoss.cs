using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawnerBoss : MonoBehaviour
{
    public int Largeur;
    public int Hauteur;

    public int Coordx;
    public int Coordy;

    public List<GameObject> SmallMonsters;
    public GameObject Boss;

    public GameObject T_Wall;
    public GameObject B_Wall;
    public GameObject L_Wall;
    public GameObject R_Wall;

    public GameObject T_L_Corner;
    public GameObject T_R_Corner;
    public GameObject B_L_Corner;
    public GameObject B_R_Corner;

    public float SBW;
    public GameObject[] Floors;


    
    private int NbEnemy;

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
                pos = Random.Range(0, len);
                Instantiate(Floors[pos], Coord, transform.rotation, transform);
                
                Coord += new Vector3(SBW / 2, 0);                
            }            Coord += new Vector3(SBW * 1 / 4, 0);
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
        enemys = GameObject.FindGameObjectsWithTag("Boss");
        if (enemys.Length == 0)
        {
            
        }
        else
        {
            
        }
    }
    
}
