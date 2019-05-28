using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdPNJ : MonoBehaviour
{
    public GameObject ActivatingCanvas;
    

    public GameObject BirdAlly;
    public GameObject BirdEnemy;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if(Input.GetKeyDown(KeyCode.A))
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
            Instantiate(BirdAlly, transform.position, transform.rotation);
        }
        else
        {
            Instantiate(BirdEnemy, transform.position, transform.rotation);
        }
        Destroy(gameObject);
        
    }


}
