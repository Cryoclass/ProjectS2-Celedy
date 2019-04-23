﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGen : MonoBehaviour
{
    public RoomScript[,] rooms;
    public int NbMaxRooms;
    public List<int[]> ActualR;
    public float spacedx;
    public float spacedy;

    public GameObject ASpawn;
    public List<int[]> PossNeigh;

    public GameObject Minimap;

    // Start is called before the first frame update
    void Start()
    {
        NbMaxRooms = Mathf.Min(11*11 - 1, NbMaxRooms);

        rooms = new RoomScript[11, 11];
        ActualR = new List<int[]>();

        ActualR.Add(new int[2] { 5, 5 });
        RoomScript Rob = new RoomScript();
        Rob.x = 5;
        Rob.y = 5;
        rooms[5, 5] = Rob;
        
        int rng;

        for (int i = 1;i<NbMaxRooms;i++)
        {
            //la je trouve une salle qui peux accueillir un voisin. Donc une qui a pas 4 voisins ou pas au bord
           
            rng = Random.Range(0, ActualR.Count);
            int nbNeigh = NbNeighf(ActualR[rng][0], ActualR[rng][1]);
            while (nbNeigh > 3)
            {
                rng = Random.Range(0, ActualR.Count );
                nbNeigh = NbNeighf(ActualR[rng][0],ActualR[rng][1]);
                // Ma fonction en gros cherche les voisins d'une salle dont on lui passe les coord en parametres.
            }


            // la je trouve les coordonnées de notre prochaine salle
            int rdNe = Random.Range(0,PossNeigh.Count);

            int nextY;
            int nextX;

            nextY = PossNeigh[rdNe][1];
            nextX = PossNeigh[rdNe][0];

            /*
            int nextY = 12;
            int nextX = 12;
            while (nextX > 10 ||nextX > 10)
            {
                nextX = 0;
                nextY = 0;
                while (nextY == 0 && nextX == 0)
                {
                    nextY = Random.Range(0, 3) - 1;
                    if (nextY == 0)
                    {
                        nextX = Random.Range(0, 2) - 1;
                    }

                    if(ActualR[rng][0] + nextX > 10 || ActualR[rng][0] + nextX < 0 || ActualR[rng][1] + nextY > 10 || ActualR[rng][1] + nextY < 0)
                    {
                        nextY = 0;
                        nextX = 0;
                    }
                    else
                    {
                        if (rooms[ActualR[rng][0] + nextX, ActualR[rng][1] + nextY] != null)
                        {
                            nextY = 0;
                            nextX = 0;
                        }
                    }
                   
                }
                nextY = ActualR[rng][1] + nextY;
                nextX = ActualR[rng][0] + nextX;
            } 
            */

            // la en gros, je suis sensé venir de trouver le prochain x et y 
            // le léger défaut c'est que je vais statistiquement plus souvent augmenter y que x

            
            Rob = new RoomScript();
            Rob.x = nextX;
            Rob.y = nextY;
            //Rob a ses coordonnées

            Rob.Neightboors.Add(ActualR[rng]);


            ActualR.Add(new int[2] { nextX, nextY });
            rooms[ActualR[rng][0], ActualR[rng][1]].Neightboors.Add(new int[2] { nextX, nextY });
            rooms[nextX, nextY] = Rob;
        }


        int counted = 0;
        foreach(RoomScript room in rooms)
        {            
            if (room != null)
            {
                ASpawn.GetComponent<RoomSpawner>().ChangeTop(room.IsTop());
                ASpawn.GetComponent<RoomSpawner>().ChangeBot(room.IsBot());
                ASpawn.GetComponent<RoomSpawner>().ChangeRight(room.IsRight());
                ASpawn.GetComponent<RoomSpawner>().ChangeLeft(room.IsLeft());
                
                Instantiate(ASpawn, transform.position + new Vector3(room.x*spacedx, room.y*spacedy), transform.rotation, transform);
                
                counted++;
            }                
        }

        Instantiate(Minimap,transform.position,transform.rotation);
    }

    private int NbNeighf(int x, int y)
    {
        int ret = 0;
        PossNeigh = new List<int[]>();

        // Au dessus
        if (y + 1 > 10)
            ret++;
        else
        {
            if (rooms[x, y + 1] != null)
            {
                ret++;
            }
            else
            {
                PossNeigh.Add(new int[2] { x, y + 1 });
            }
        }

        if (y - 1 < 0)
            ret++;
        else
        {
            if (rooms[x, y - 1] != null)
            {
                ret++;
            }
            else
            {
                PossNeigh.Add(new int[2] { x, y - 1 });
            }
        }

        if (x - 1 < 0)
            ret++;
        else
        {
            if (rooms[x-1 , y] != null)
            {
                ret++;
            }
            else
            {
                PossNeigh.Add(new int[2] { x - 1, y });
            }
        }

        if (x + 1 > 10)
            ret++;
        else
        {
            if (rooms[x + 1, y] != null)
            {
                ret++;
            }
            else
            {
                PossNeigh.Add(new int[2] { x + 1, y });
            }
        }


        return ret;
    }


    public RoomScript[,] RoomsGetter()
    {
        return rooms;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
