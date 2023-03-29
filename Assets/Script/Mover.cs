using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;

    void Start ()
    {
        rb.velocity = transform.forward * speed;
    }


}
