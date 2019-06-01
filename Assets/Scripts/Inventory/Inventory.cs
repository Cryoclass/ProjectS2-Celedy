using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public bool[] isFull;
    public Collider2D other;

    public GameObject[] slots;



    // Start is called before the first frame update
    void Start()
    {
        int a = PlayerPrefs.GetInt("NbPotion");
        for(int i = 0; i < a; i++)
        {
            GetComponent<PickUp>().InInventory(other);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
