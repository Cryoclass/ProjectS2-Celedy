using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    public int[,] visited;
    private RoomScript[,] rooms;
    private float Spacedx;
    private float Spacedy;
    private int OldPosx;
    private int OldPosy;

    private float initialx;
    private float initialy;
    private LevelGen R;

    private GameObject[,] UneFoisSumm;

    public GameObject PictureToSummon;

    // Start is called before the first frame update
    void Start()
    {
        OldPosy = 5;
        OldPosx = 5;

        UneFoisSumm = new GameObject[11,11];
        initialx = GameObject.FindGameObjectWithTag("LevelGen").transform.position.x;
        initialy = GameObject.FindGameObjectWithTag("LevelGen").transform.position.y;

        R = GameObject.FindGameObjectWithTag("LevelGen").GetComponent<LevelGen>();
        rooms = R.RoomsGetter();
        Spacedx = R.spacedx;
        Spacedy = R.spacedy;

        visited = new int[11, 11];
        for (int i = 0; i < 11; i++)
        {
            for (int y = 0; y< 11; y++)
            {
                if (rooms[i, y] != null)
                {
                    visited[i,y] = 0;
                }
                else
                {
                    visited[i, y] = 2;
                }
            }
        }

        for (int i = 0; i < 11; i++)
        {
            for (int y = 0; y < 11; y++)
            {
                if (visited[i,y] == 0)
                {
                    UneFoisSumm[i,y] = Instantiate(PictureToSummon,transform.position + new Vector3(i,y),transform.rotation,transform);
                }                
            }
        }
    }

    public void ChangeCol(int x, int y)
    {
        Color col = new Color(250, 0, 0, 0);
        UneFoisSumm[OldPosx + x, OldPosy + y].GetComponent<SpriteRenderer>().color = col;
        col.b = 250;
        col.g = 250;
        UneFoisSumm[OldPosy, OldPosy].GetComponent<SpriteRenderer>().color = col;
        OldPosx += x;
        OldPosy += y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

}
