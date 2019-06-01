using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class RedButton : MonoBehaviour
{
    private Ya_Health Yaelle;
    private Animator anim;
    public bool isPress;
    public GameObject effect;
    private GameObject IEffect;
    public float timer;

    private void Start()
    {
        isPress = false;
        anim = gameObject.GetComponent<Animator>();
        
    }

    private void Update()
    {
        if (isPress == true)
        {
            timer -= Time.deltaTime;
        }

        if (timer < 0)
        {
            Destroy(IEffect);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isPress = true;
            Debug.Log("Sauvegarde");
            anim.SetBool("isPress", isPress);
            IEffect = Instantiate(effect, transform.position, Quaternion.identity);

        }
    }
}
