using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingAnimation : MonoBehaviour
{
    [Tooltip("Axes")]
    [SerializeField] private float x;
    [SerializeField] private float y;
    [SerializeField] private float z;
    private void Update()
    {
        // Rotation des anneaux autour des distorsions
        transform.Rotate(new Vector3(x, y, z) * Time.deltaTime);
    }
}
