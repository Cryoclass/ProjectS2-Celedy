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

        if(PlayerPrefs.GetInt("SmallBossBeaten") >= 2)
        {
            PlayerPrefs.SetInt("BigBossBeaten", PlayerPrefs.GetInt("BigBossBeaten") + 1);
        }
        else
        {
            PlayerPrefs.SetInt("SmallBossBeaten", PlayerPrefs.GetInt("SmallBossBeaten") + 1);
        }
        
    }
}
