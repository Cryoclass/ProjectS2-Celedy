using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialPerso : MonoBehaviour
{
    public GameObject Button1;
    public GameObject Button2;
    public GameObject Speaker;

    private TextMeshProUGUI Text1;
    private TextMeshProUGUI Text2;
    private TextMeshProUGUI Displayed;

    private void Start()
    {

    }

    public void modify(string ToDisplay, string str1, string str2)
    {
        Speaker.GetComponent<TextMeshProUGUI>().text = ToDisplay;
        Button1.GetComponent<TextMeshProUGUI>().text = str1;
        Button2.GetComponent<TextMeshProUGUI>().text = str2;
    }

}
