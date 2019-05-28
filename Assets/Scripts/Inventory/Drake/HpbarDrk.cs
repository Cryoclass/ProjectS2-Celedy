using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpbarDrk : MonoBehaviour
{
    public GameObject Drake;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Drake.transform.position.x + 30, Drake.transform.position.y);
    }
}
