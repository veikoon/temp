using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    public SpriteRenderer spriteRenderer;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        FlipAnimation();
    }
    private void FlipAnimation()
    {
        //left right flip
        if (rb.velocity.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (rb.velocity.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        
        //gravity reversed up down flip
        if(rb.gravityScale < 0)
        {
            spriteRenderer.flipY = true;
        }
        else if (rb.gravityScale >= 0)
        {
            spriteRenderer.flipY = false;
        }
    }

}
