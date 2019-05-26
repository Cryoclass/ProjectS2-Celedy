using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCam : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
