using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdPNJ : MonoBehaviour
{
    public GameObject ActivatingCanvas;
    

    public GameObject BirdAlly;
    public GameObject BirdEnemy;

    private bool CanSpeak;

    // Start is called before the first frame update
    void Start()
    {
        CanSpeak = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if(Input.GetKeyDown(KeyCode.A) && CanSpeak)
            {                
                ActivatingCanvas.GetComponent<DialogueManager>().Activate();
                Time.timeScale = 0f;
            }
        }
    }

    public void DialogueSucceed(bool succeeded)
    {
        if(succeeded)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Ya_Shoot>().ChangeAlly(Instantiate(BirdAlly, transform.position, transform.rotation));
        }
        else
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Ya_Shoot>().ChangeAlly(Instantiate(BirdEnemy, transform.position, transform.rotation));
        }
        Destroy(gameObject);
        
    }

    public void SetCanSpeak(bool CanSpeak)
    {
        this.CanSpeak = CanSpeak;
    }


}
