using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBody : MonoBehaviour
{
    GravityAttraction planet;
    Rigidbody planetRb;
    void Awake()
    {
        planetRb = GetComponent<Rigidbody>();
        planet = GameObject.FindGameObjectWithTag("Planet").GetComponent<GravityAttraction>();
        planetRb.useGravity = false;
        planetRb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    void FixedUpdate()
    {
        planet.Attract(transform);
        
    }
}
