﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum AllyEnum
{
    Null = 0,
    Bird = 1,
    Fairy = 2
}


public class MainMenu : MonoBehaviour
{
    public void Resume()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MainCam>().SetPos(0, 0);
        Debug.Log(Application.dataPath);

        if (PlayerPrefs.GetInt("PlayerCurrentLifeSaved") > 0)
        {
            PlayerPrefs.SetInt("PlayerCurrentLife", PlayerPrefs.GetInt("PlayerCurrentLifeSaved"));
            PlayerPrefs.SetInt("NbPotion", PlayerPrefs.GetInt("NbPotionSaved"));
            PlayerPrefs.SetInt("Ally", PlayerPrefs.GetInt("AllySaved"));
            if (PlayerPrefs.GetInt("SmallBossBeaten") == 0)
            {
                SceneManager.LoadScene("Intro");
            }
            else
            {
                SceneManager.LoadScene("Transition Scene");
            }
        }
        else
        {
            Debug.Log(Application.dataPath);
        
            PlayerPrefs.SetInt("PlayerCurrentLifeSaved", 10);
            PlayerPrefs.SetInt("PlayerCurrentLife", 10);
        
            PlayerPrefs.SetInt("NbPotion", 0);
            PlayerPrefs.SetInt("NbPotionSaved", 0);
        
            PlayerPrefs.SetInt("Ally", 0);
            PlayerPrefs.SetInt("AllySaved", 0);
        
        
            PlayerPrefs.SetInt("BigBossBeaten", 0);
            PlayerPrefs.SetInt("SmallBossBeaten", 0);
        
            SceneManager.LoadScene("Intro");
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }


    public void PlayGame()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MainCam>().SetPos(0, 0);
        Debug.Log(Application.dataPath);
        
        PlayerPrefs.SetInt("PlayerCurrentLifeSaved", 10);
        PlayerPrefs.SetInt("PlayerCurrentLife", 10);
        
        PlayerPrefs.SetInt("NbPotion", 0);
        PlayerPrefs.SetInt("NbPotionSaved", 0);
        
        PlayerPrefs.SetInt("Ally", 0);
        PlayerPrefs.SetInt("AllySaved", 0);
        
        
        PlayerPrefs.SetInt("BigBossBeaten", 0);
        PlayerPrefs.SetInt("SmallBossBeaten", 0);
        
        SceneManager.LoadScene("VeryIntro");
    }
}
