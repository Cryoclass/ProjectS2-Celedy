using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Right_hand_take_damage : Take_damage
{

    public bool is_right = true;//true -> right hand    //false -> left hand

    public override void InflictDamage(int i)
    {
        if(is_right)
            gameObject.GetComponentInParent<B_C_shoot_with_mouse>().Right_hand_take_damage(i);
        else
        {
            gameObject.GetComponentInParent<B_C_shoot_with_mouse>().Left_hand_take_damage(i);
        }
    }
}
