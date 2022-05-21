using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField, Range(-30f,30f)] float rotateSpeedUP = 1f;
    [SerializeField, Range(-30f,30f)] float rotateSpeedRight = 1f; 
    [SerializeField, Range(-30f,30f)] float rotateSpeedForward = 1f;  

/*
    [SerializeField] float rotateObjectX = 0f;
    [SerializeField] float rotateObjectY = 0f;
    [SerializeField] float rotateObjectZ = 0f;
    */
    
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.RotateAround(transform.position, transform.up, Time.deltaTime * (rotateSpeedUP / 10));
        transform.RotateAround(transform.position, transform.right, Time.deltaTime * (rotateSpeedRight / 10));
        transform.RotateAround(transform.position, transform.forward, Time.deltaTime * (rotateSpeedForward / 10));

        
    }
}
