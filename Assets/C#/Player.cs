﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{
    public Rigidbody2D rig;
    public Animator anim;
     public float Speed;
     public float JumpForce;
    public bool isJumping;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }
    void Move()
    {
    //     public float Speed;
    //  float movement = Input.GetAxis("Horizontal");

    //  rig.velocity = new Vector2( movement * Speed, rig.velocity.y);

    //     if (movement > 0f)
    //     {
    //         anim.SetBool ("walk", true);
    //         transform.eulerAngles = new Vector3(0f, 0f, 0f);  
    //     }

    //     if (movement < 0f)
    //     {
    //         anim.SetBool ("walk", true);
    //         transform.eulerAngles = new Vector3(0f, 180f, 0f);
    //     }

    //     if (movement == 0f)
    //     {
    //         anim.SetBool("walk", false);
    //     }

        float movement = Input.GetAxis("Horizontal");
        
        rig.velocity = new Vector2(movement * Speed, rig.velocity.y);

        if(movement > 0f)
        {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }

        if(movement < 0f)
        {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }

        if(movement == 0f)
        {
            anim.SetBool("walk", false);
        }
    }
        void Jump()
        {
            if(Input.GetButtonDown("Jump"))
            {
                if(!isJumping)
                {
                    rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                }
            }
        }
        void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.layer == 8)
            {
                isJumping = false;
            }
        }

        void OnCollisionExit2D(Collision2D collision)
        {
           
           if (collision.gameObject.layer == 8)
           {
            isJumping = true;
           }        
        }
}
