using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneRoom : MonoBehaviour
{
    public GameObject Roomspawneur;
    public int Largeur;
    public int Hauteur;

    public bool TopEntry;
    public bool BotEntry;
    public bool LeftEntry;
    public bool RightEntry;

    public int NbMinEnemy;
    public int NbMaxenemy;
    
    // Start is called before the first frame update
    void Start()
    {
        Roomspawneur.GetComponent<RoomSpawner>().TopEntry = this.TopEntry;
        Roomspawneur.GetComponent<RoomSpawner>().BotEntry = this.BotEntry;
        Roomspawneur.GetComponent<RoomSpawner>().RightEntry = this.RightEntry;
        Roomspawneur.GetComponent<RoomSpawner>().LeftEntry = this.LeftEntry;
        Roomspawneur.GetComponent<RoomSpawner>().NbMinEnemy = this.NbMinEnemy;
        Roomspawneur.GetComponent<RoomSpawner>().NbMaxenemy = this.NbMaxenemy;
        Instantiate(Roomspawneur, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
