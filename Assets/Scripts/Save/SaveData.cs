using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    
    
    public void SavingData()
    {
        PlayerPrefs.SetInt("PlayerCurrentLifeSaved", PlayerPrefs.GetInt("PlayerCurrentLife"));
        PlayerPrefs.SetInt("NbPotionSaved", PlayerPrefs.GetInt("NbPotion"));
        PlayerPrefs.SetInt("AllySaved", PlayerPrefs.GetInt("Ally"));
        PlayerPrefs.SetInt("BigBossBeaten", PlayerPrefs.GetInt(""));
        PlayerPrefs.SetInt("SmallBossBeaten", PlayerPrefs.GetInt(""));
    }
}
