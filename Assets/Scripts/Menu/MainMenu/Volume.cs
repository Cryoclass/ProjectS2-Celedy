using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Volume : MonoBehaviour
{
    public GameObject cam;

    public void SetVolume(float Volume)
    {
        cam.GetComponent<AudioSource>().volume = Volume;
    }
}
