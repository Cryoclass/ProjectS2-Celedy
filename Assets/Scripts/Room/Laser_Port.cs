using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_Port : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyHim", 0.7f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void DestroyHim()
    {
        Destroy(gameObject);
    }
}
