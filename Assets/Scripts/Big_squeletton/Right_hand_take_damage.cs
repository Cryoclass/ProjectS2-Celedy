using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Right_hand_take_damage : MonoBehaviour
{

    public bool is_right = true;//true -> right hand    //false -> left hand

    public void OnTriggerEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Ya_Health>().Take_hit();
        }

        if (collision.gameObject.tag == "Bullet")
        {
            if (is_right)
                gameObject.GetComponentInParent<B_C_shoot_with_mouse>().Right_hand_take_damage(collision.gameObject.GetComponent<SpellArchetype>().damage);
            else
            {
                gameObject.GetComponentInParent<B_C_shoot_with_mouse>().Left_hand_take_damage(collision.gameObject.GetComponent<SpellArchetype>().damage);

            }
        }
    }
}
