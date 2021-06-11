using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{

    public LayerMask groundLayer;

    public bool onGround;
    public bool onWall;
   

    public float collisionRadius = .25f;
    public Vector2 botOffset, leftOffset, rightOffset;


    // Update is called once per frame
    void Update()
    {
        //true if player touches the ground layer
        onGround = Physics2D.OverlapCircle((Vector2) transform.position + botOffset, collisionRadius, groundLayer);
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere((Vector2)transform.position + botOffset, collisionRadius);

    }
}
