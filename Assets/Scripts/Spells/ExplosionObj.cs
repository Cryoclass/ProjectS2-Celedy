using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionObj : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyProjectile", 1);
    }
       

    private void DestroyProjectile()
    {        
        Destroy(gameObject);
    }
}
