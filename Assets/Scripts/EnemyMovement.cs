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
 
     //values for internal use
     private Transform _lookRotation;
     private Vector3 _direction;
     
void Start()
{
    rbEnemy = GetComponent<Rigidbody>();
    target = GameObject.Find("Castle").transform;
}

    void Update()
    {
        
        if (transform.position.y < 0)
        {
            currentSpeed = spawnBoostSpeed;
        }
        else
        {
            currentSpeed = unitSpeed;
        }
        
        
       
        
        
        target = GameObject.Find("Castle").transform;
        
    }
    
    void FixedUpdate()
    {
        var lookPos = target.position - transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * RotationSpeed);

        //move the enemy with velocity v1.0
        rbEnemy.AddRelativeForce( Vector3.forward * currentSpeed, ForceMode.Impulse);
    }
   

    void OnTriggerStay(Collider other)
    {
        Debug.Log("other hit");
        if(other.tag == "Tower")
        {
            Debug.Log("other is Tower");
            if(GetComponent<SphereCollider>()) GetComponent<SphereCollider>().enabled = false;
            target = other.gameObject.transform;
        }
        if(other.tag == "Wall")
        {
            Debug.Log("other is Wall");
            target = other.gameObject.transform;
        }
    }

   
}
