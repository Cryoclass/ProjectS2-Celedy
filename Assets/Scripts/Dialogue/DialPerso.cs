using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialPerso : MonoBehaviour
{
    public Text Text1;
    public Text Text2;
    public Text Displayed;

    public void modify(string ToDisplay, string str1, string str2)
    {
        Displayed.text = ToDisplay;
        Text1.text = str1;
        Text2.text = str2;
    }

}
