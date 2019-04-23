using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdPNJ : MonoBehaviour
{
    public GameObject ActivatingCanvas;
    public bool IsAlly;
    private GameObject ToFollow;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        IsAlly = false;
        ToFollow = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (IsAlly)
        {
            if (Mathf.Pow(transform.position.x-ToFollow.transform.position.x,2) + Mathf.Pow(transform.position.y - ToFollow.transform.position.y, 2) > 9)
                transform.position += (ToFollow.transform.position - this.transform.position) * speed * Time.deltaTime;
        }
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
