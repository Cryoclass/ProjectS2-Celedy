using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class  YaMoove : MonoBehaviour
{
    private Animator anim;
    private bool Was_Moving;
    private Vector2 LastMove;
    private bool IsMovingRight;
        

    public float Speed;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        

        Was_Moving = false;

        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * Speed * Time.deltaTime, 0f, 0f) * (IsMovingRight ? -1 : 1));
            Was_Moving = true;
            LastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);

            if (Input.GetAxisRaw("Horizontal") > 0.5f)
                IsMovingRight = true;
            else
                IsMovingRight = false;
        }

        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
            transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * Speed * Time.deltaTime, 0f));
            Was_Moving = true;
            LastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
            IsMovingRight = false;
        }

        if (IsMovingRight)
            transform.rotation = Quaternion.Euler(0f, 180, 0f);
        else
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);

        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        anim.SetBool("Was_Moving", Was_Moving);
        anim.SetFloat("LastMoveX", LastMove.x);
        anim.SetFloat("LastMoveY", LastMove.y);
    }

    

    

    public void Teleport(int x,int y)
    {
        transform.position += new Vector3(x, y);
        gameObject.GetComponent<Ya_Invisible>().visible();
    }

}