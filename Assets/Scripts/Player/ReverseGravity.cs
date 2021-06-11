using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseGravity : MonoBehaviour
{
    public bool gravityReversed;
    public Rigidbody2D rb;

    public float reversedGravityScale;
    public float normalGravityScale;


    void Update()
    {
        if (gravityReversed)
        {
            rb.gravityScale = -reversedGravityScale;
        }
        else
        {
            rb.gravityScale = normalGravityScale;
        }
        
    }

}
