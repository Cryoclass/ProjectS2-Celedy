using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Volume : MonoBehaviour
{

    public AudioMixer audiomixer;

    public void SetVolume(float Volume)
    {
        audiomixer.SetFloat("volume", Volume);
    }
    
}
