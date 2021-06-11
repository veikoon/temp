using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.WebCam;

public class Parralax : MonoBehaviour
{
    private float length, startPosition;
    public GameObject cam;
    public float parralaxAmount;
    public float y_offset;


    void Start()
    {
        startPosition = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        
    }

    void FixedUpdate()
    {
        //Parralax effect
        float distance = (cam.transform.position.x * parralaxAmount);
        transform.position = new Vector3(startPosition + distance, cam.transform.position.y + y_offset, transform.position.z);

        //Repeat the background when reaching bounds
        float camDistance = (cam.transform.position.x * (1 - parralaxAmount));
        if (camDistance > startPosition + length) startPosition += length;
        else if (camDistance < startPosition - length) startPosition -= length;

    }
}
