using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum AllyNum
{
    Null = 0,
    Bird = 1,
    Fairy = 2,
}




public class MainMenu : MonoBehaviour
{
    public void ResumeGame()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MainCam>().SetPos(0, 0);
        if (PlayerPrefs.GetInt("PlayerCurrentLifeSaved") > 0)
        {
            PlayerPrefs.SetInt("PlayerCurrentLife", PlayerPrefs.GetInt(("PlayerCurrentLifeSaved")));
            PlayerPrefs.SetInt("NbPotion", PlayerPrefs.GetInt("NbPotionSaved"));
            PlayerPrefs.SetInt("Ally", PlayerPrefs.GetInt("AllySaved"));
            
            SceneManager.LoadScene("Intro");
        }
        else
        {
            PlayerPrefs.SetInt("PlayerCurrentLife", 10);
            SceneManager.LoadScene("Intro");
        }
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PlayGame()
    {
        PlayerPrefs.SetInt("PlayerCurrentLifeSaved", 0);
        PlayerPrefs.SetInt("PlayerCurrentLife", 10);
        PlayerPrefs.SetInt("NbPotionSaved", 0);
        PlayerPrefs.SetInt("AllySaved", 0);
        
        PlayerPrefs.SetInt("NbPotion", 0);
        PlayerPrefs.SetInt("Ally", 0);
    }
}
