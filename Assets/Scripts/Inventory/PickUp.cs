using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private Inventory inventory;
    private GameObject player;
    public GameObject itemButton;
    public int i;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        inventory = player.GetComponent<Inventory>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        InInventory(other);
    }

    public void InInventory(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull[i] == false)
                {
                    inventory.isFull[i] = true;
                    Instantiate(itemButton, inventory.slots[i].transform, false);
                    PlayerPrefs.SetInt("NbPotion", PlayerPrefs.GetInt("NbPotion") + 1);
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }

    public void HealthPotion()
    {
        player.GetComponent<Ya_Health>().CurrentHealth += 2;
        Destroy(gameObject);
    }

    public void FreezeItem()
    {
        Time.timeScale = 0f;
    }

}