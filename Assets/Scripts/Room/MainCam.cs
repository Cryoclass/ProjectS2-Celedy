using System.Collections;
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
    // Update is called once per frame
    void Start()
    {
        player_pos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    void Update()
    {
        if (InSquelletteRoom)
        {
            if (player_pos.position.x < MaxX || player_pos.position.x > MinX)
                gameObject.transform.position = Vector3.MoveTowards(transform.position,player_pos.position,1);
            if (player_pos.position.y < MaxY || player_pos.position.y > MinY)
                gameObject.transform.position = Vector3.MoveTowards(transform.position,player_pos.position,1);
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
