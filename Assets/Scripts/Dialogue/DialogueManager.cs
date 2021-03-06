﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class DialogueManager : MonoBehaviour
{
    private List<string> sentences;
    private int i;
    public GameObject WithModify;
    public string link;

    public GameObject ThePNJ;

    public GameObject canvas;

    private string[] splited;

    // Start is called before the first frame update
    void Start()
    {
        splited = new string[1];
        i = 0;
        sentences = new List<string>();
        sentences.Add("");

        using (StreamReader myReader = new StreamReader(link))
        {
            string RTE = myReader.ReadToEnd();
            foreach(string a in RTE.Split('\n'))
            {
                sentences.Add(a);
            }
        }
        Changed(1);
        canvas.SetActive(false);

    }

    public void Changed(int oupas)
    {
        Debug.Log("Les boutons marchent");

        i = i * 2 + oupas;

        if(i < sentences.Count)
        {
            splited = sentences[i].Split('+');                      
              
            WithModify.GetComponent<DialPerso>().modify(splited[0], splited[1], splited[2]);

            if (splited[0] == " ' ")
            {
                canvas.SetActive(false);
                Time.timeScale = 1f;
            }            
        }
        else
        {
            if (splited[1] == " *New Ally* ")
            {          
                ThePNJ.GetComponent<BirdPNJ>().DialogueSucceed(true);
            }
            else if(splited[1] == " *Start Fight* ")
            {
                ThePNJ.GetComponent<BirdPNJ>().DialogueSucceed(false);
            }
            else
            {
                ThePNJ.GetComponent<BirdPNJ>().SetCanSpeak(false);
            }
            canvas.SetActive(false);
            Time.timeScale = 1f;
        }
        
    }

    public void Activate()
    {
        canvas.SetActive(true);
    }

    public void Desactivate()
    {
        canvas.SetActive(false);
    }
    
}
