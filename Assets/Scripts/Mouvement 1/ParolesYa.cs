using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParolesYa : MonoBehaviour
{
    public Text ToDsiplay;
    public GameObject canvas;

    
    
    

    public void Speaking()
    {
        canvas.SetActive(true);
        ToDsiplay.text = "...";
    }
    
}
