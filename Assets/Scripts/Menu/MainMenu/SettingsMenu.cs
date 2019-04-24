using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    Resolution[] resolutions;
    public Dropdown infoResolution;
    
   

    void Start()
    {
        resolutions = Screen.resolutions;
        infoResolution.ClearOptions();
        
        List<string> _resolutions = new List<string>();

        for (int i = 0; i < resolutions.Length; i++)
        {
            string _resolution = resolutions[i].width + "x" + resolutions[i].height;
            _resolutions.Add(_resolution);
        }
        
        infoResolution.AddOptions(_resolutions);
    }
    
    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void SetResolution(int index)
    {
        Resolution resolution = resolutions[index];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    
    
    
}
