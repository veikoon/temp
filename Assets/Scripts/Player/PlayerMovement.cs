using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    //basic movement
    public float MovementSpeed = 30f;
    public float JumpForce = 5f;

    //better jump
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    public ParticleSystem Dust;


    private CollisionDetection collDetection;
    private DoubleJump doubleJumpComponent;
    private ReverseGravity reverseGravityComponent;

    


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        collDetection = GetComponent<CollisionDetection>();
        rb.gravityScale = 3;

        doubleJumpComponent = GetComponent<DoubleJump>();
        reverseGravityComponent = GetComponent<ReverseGravity>();


    }

    void Update()
    {
        //basic left right
        float xMov = Input.GetAxis("Horizontal");
        float yMov = Input.GetAxis("Vertical");

        Vector2 direction = new Vector2(xMov, yMov);
        Walk(direction);


        //basic normal jump
        if (Input.GetButtonDown("Jump"))
        {

            if (collDetection.onGround)
            {
                Debug.Log("Normal Jumped !");
                Jump();
            }
            else if (doubleJumpComponent.doubleJump)
            {
                Debug.Log("Double Jumped !");
                Jump();
                doubleJumpComponent.doubleJump = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (reverseGravityComponent.gravityReversed)
            {
                Debug.Log("Gravity Reversed to normal !");
                reverseGravityComponent.gravityReversed = false;
            }
            else
            {
                Debug.Log("Reversing Gravity !");
                reverseGravityComponent.gravityReversed = true;
            }
            

        }


            //applying gravity for better jumps
            if (rb.velocity.y < 0)
        {
            //full jump
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            //low jump
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

         
    }

    private void Walk(Vector2 direction)
    {
        rb.velocity = new Vector2(direction.x * MovementSpeed, rb.velocity.y);
    }

    private void Jump()
    {
        CreateDust();
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.velocity += Vector2.up * JumpForce;
    }

    public void CreateDust()
    {
        Dust.Play();
    }

    
}
