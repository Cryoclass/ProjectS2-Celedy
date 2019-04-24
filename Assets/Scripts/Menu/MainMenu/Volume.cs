using UnityEngine;

public class Volume : MonoBehaviour
{
    public GameObject cam;

    public void SetVolume(float Volume)
    {
        cam.GetComponent<AudioSource>().volume = Volume;
    }
}
