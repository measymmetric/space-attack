using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour
{
    public float tumble;
    public Rigidbody rigidbody;
    void Start()
    {
        rigidbody.angularVelocity = Random.insideUnitSphere * tumble;
    }
}
