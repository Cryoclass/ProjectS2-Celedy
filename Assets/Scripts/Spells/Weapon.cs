using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public void Shooti(GameObject gam)
    {
        Instantiate(gam, transform.position, transform.rotation);
    }
}
