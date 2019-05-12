using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_Script : MonoBehaviour
{
    // Start is called before the first frame update
    public void DestroyIn(float duration)
    {
        Debug.Log("je devrais mourir 1");
        Invoke(nameof(Ded),duration);
    }

    private void Ded()
    {
        Debug.Log("je devrais mourir 2");
        Destroy(gameObject);
    }
}
