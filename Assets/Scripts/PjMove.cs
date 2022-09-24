using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PjMove : MonoBehaviour
{   
    public float Speed;
    public float JumpForce;

    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    private float Horizontal;
    private bool Nsuelo;

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    void Update()
    {
       Horizontal =Input.GetAxisRaw("Horizontal");
       if(Horizontal < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
       else if(Horizontal > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

       Animator.SetBool("Running", Horizontal !=0.0f);

       Debug.DrawRay(transform.position, Vector3.down*0.2f, Color.red);
       if (Physics2D.Raycast(transform.position, Vector3.down, 0.2f))
       {
        Nsuelo = true;
       }
       else Nsuelo = false;

       if(Input.GetKeyDown(KeyCode.W) && Nsuelo)
       {
        Jump();
       } 
    }

    private void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up*JumpForce);
    }
    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(Horizontal, Rigidbody2D.velocity.y);
    }
}
