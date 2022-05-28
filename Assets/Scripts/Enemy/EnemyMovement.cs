using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyMovement : MonoBehaviour
{


   

    Rigidbody rbEnemy;
    [SerializeField] float unitSpeed;

    float currentSpeed;
    public float spawnBoostSpeed;

    //values that will be set in the Inspector
     public Transform target;
     public float RotationSpeed;  
  
     
void Start()
{
    rbEnemy = GetComponent<Rigidbody>();
    target = GameObject.Find("Castle").transform;
}

    void Update()
    {
        MovementSpeed();
        CheckForTarget();
    }

   
    
    void FixedUpdate()
    {
        MovingAndRotation();
    }

    private void MovingAndRotation()
    {
        var lookPos = target.position - transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * RotationSpeed);

        //move the enemy with velocity v1.0
        rbEnemy.AddRelativeForce(Vector3.forward * currentSpeed);
    }


    void OnTriggerEnter(Collider other)
    {
        
        if(other.tag == "Tower")
        {
            target = other.gameObject.transform;
        }
        if(other.tag == "Wall")
        {
            target = other.gameObject.transform;
        }
    }

     private void CheckForTarget()
    {
        if (target == null)
        {
            
            target = GameObject.Find("Castle").transform;

        }
    }

    private void MovementSpeed()
    {
        if (transform.position.y < 0)
        {
            currentSpeed = spawnBoostSpeed;
        }
        else
        {
            currentSpeed = unitSpeed;
        }
    }
   
}
