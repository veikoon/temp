using UnityEngine;
using UnityEngine.AI;
using System.Collections;


public class Npc : MonoBehaviour
{

    public Transform[] points;
    public float speed;
    private int currentPoint;
    private int destinationPoint;
    private int direction;


    void Start()
    {
        destinationPoint = 0;
        GotoNextPoint();
    }


    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (points.Length == 0)
            return;
        destinationPoint = (destinationPoint + 1) % points.Length;
    }


    void Update()
    {

        transform.position = Vector3.MoveTowards(transform.position, points[destinationPoint].position, Time.deltaTime * speed);
        if (transform.position ==  points[destinationPoint].position)
            GotoNextPoint();
    }
}