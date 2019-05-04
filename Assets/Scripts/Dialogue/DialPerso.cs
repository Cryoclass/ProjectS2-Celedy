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
        Text1 = Button1.GetComponent<TextMeshProUGUI>();
        Text2 = Button2.GetComponent<TextMeshProUGUI>();
        Displayed = Speaker.GetComponent<TextMeshProUGUI>();
    }

    public void modify(string ToDisplay, string str1, string str2)
    {
        Displayed.text = ToDisplay;
        Text1.text = str1;
        Text2.text = str2;
    }

}
