using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GereurMvt1 : MonoBehaviour
{
    public GameObject Yaelle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Declencheur()
    {
        Yaelle.GetComponent<DeplacementYa>().Depl(0, -20);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
