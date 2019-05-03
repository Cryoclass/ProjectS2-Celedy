using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionScenesMusic : MonoBehaviour
{
    private static TransitionScenesMusic instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
