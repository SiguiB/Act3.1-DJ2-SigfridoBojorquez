using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PjMove : MonoBehaviour
{   
    public GameObject BulletPrefab;
    public float Speed;
    public float JumpForce;

    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    private float Horizontal;
    private bool Nsuelo;
    private float LastShoot;

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

       if(Input.GetKeyDown(KeyCode.J) && Time.time > LastShoot + 0.25f)
       {
        Shoot();
        LastShoot = Time.time;
       }
    }

    private void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up*JumpForce);
    }
    public void Shoot()
    {
        Vector3 direction;
        if(transform.localScale.x == 1.0f) direction = Vector3.right;
        else direction = Vector3.left;

        GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 0.1f, Quaternion.identity);
        bullet.GetComponent<BulletScript>().SetDirection(direction);
    }
    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(Horizontal, Rigidbody2D.velocity.y);
    }
}
