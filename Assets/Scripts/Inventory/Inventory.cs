using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public bool[] isFull;

    public GameObject[] slots;
    public GameObject itemButton;



    // Start is called before the first frame update
    void Start()
    {
        int a = PlayerPrefs.GetInt("NbPotion");
        Debug.Log(PlayerPrefs.GetInt("NbPotion"));

        for(int i = 0; i < a; i++)
        {
            isFull[i] = true;
            Instantiate(itemButton, slots[i].transform, false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
