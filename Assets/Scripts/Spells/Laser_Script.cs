using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_Script : MonoBehaviour
{
    public void DedIn(float timer)
    {
        Invoke("Ded", timer);
    }

    private void Ded()
    {
        Destroy(gameObject);
    }
}
