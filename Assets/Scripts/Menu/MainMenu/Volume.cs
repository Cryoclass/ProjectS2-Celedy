using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Volume : MonoBehaviour
{

    public AudioMixer audiomixer;
    public float Vol;

    public void SetVolume(float Volume)
    {
        audiomixer.SetFloat("volume", Mathf.Log(Volume,1.1f));
        Vol = Mathf.Log(Volume,1.1f);
    }
    
}
