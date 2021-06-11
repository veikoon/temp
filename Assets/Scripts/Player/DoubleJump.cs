using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJump : MonoBehaviour
{

    public bool doubleJump;

    private CollisionDetection collDetection;

    void Awake()
    {
        collDetection = GetComponent<CollisionDetection>();
    }

    void Update()
    {
        if (collDetection.onGround)
        {
            doubleJump = true;
        }
    }
}