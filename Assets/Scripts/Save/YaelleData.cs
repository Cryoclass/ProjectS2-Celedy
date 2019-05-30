using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class YaelleData : MonoBehaviour
{
    //sauvegarde la progression du joueur
    public int CurrentHealth;
    public int CurrentMaxHeart;
    public float[] position;
    public int Etage; //
    public bool Is_befor_boss;
    public int Boss;

    public YaelleData(Ya_Health Yaelle)
    {
        CurrentHealth = Yaelle.CurrentHealth;
        CurrentMaxHeart = Yaelle.CurrentMaxHeart;
        position = new float[3];
        position[0] = Yaelle.transform.position.x;
        position[1] = Yaelle.transform.position.y;
        position[2] = Yaelle.transform.position.z;
        
    }
}
