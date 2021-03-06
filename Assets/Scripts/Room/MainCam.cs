﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCam : MonoBehaviour
{
    // Start is called before the first frame update
    public bool InSquelletteRoom = false;
    public float MinX;
    public float MaxX;
    public float MinY;
    public float MaxY;

    private Transform player_pos;
    private bool PlayerFoundInSquelletteRoom;
    // Update is called once per frame
    void Start()
    {        
        PlayerFoundInSquelletteRoom = false;
}
    void Update()
    {
        if (InSquelletteRoom)
        {
            if (!PlayerFoundInSquelletteRoom)
            {
                player_pos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            }

            if (player_pos.position.x < MaxX && player_pos.position.x > MinX)
                gameObject.transform.position +=
                    new Vector3(player_pos.position.x - gameObject.transform.position.x, 0);
            if (player_pos.position.y < MaxY && player_pos.position.y > MinY)
                gameObject.transform.position += new Vector3(0,player_pos.position.y - gameObject.transform.position.y + 10);
        }
        
    }

    public void Teleport(float x, float y)
    {
        transform.position += new Vector3(x, y);
    }

    public void SetPos(float x, float y)
    {
        transform.position = new Vector3(x, y, transform.position.z);
    }
}
