using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public bool[] isFull;

    public GameObject[] slots;
    public GameObject itemButton;

    private GameObject[] pots;



    // Start is called before the first frame update
    void Start()
    {
        pots = new GameObject[4];
        
        int a = PlayerPrefs.GetInt("NbPotion");
        Debug.Log(PlayerPrefs.GetInt("NbPotion"));

        for(int i = 0; i < a; i++)
        {
            isFull[i] = true;
            AddPot(Instantiate(itemButton, slots[i].transform, false), i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            for (int i = 0; i < pots.Length; i++)
            {
                if (pots[i] != null)
                {
                    pots[i].GetComponent<HealthPotion>().Use();
                    break;
                }
            }
        }
    }


    public void AddPot(GameObject pot,int index)
    {
        pots[index] = pot;
    }
}
