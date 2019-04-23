using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdPNJ : MonoBehaviour
{
    public GameObject ActivatingCanvas;
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
}
