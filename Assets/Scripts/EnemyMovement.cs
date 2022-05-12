using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{


    [SerializeField] GameObject zielObejct;


    void Update()
    {
        zielObejct = GameObject.Find("EnemyZielOrt");
       GetComponent<NavMeshAgent>().destination = zielObejct.transform.position;
    }


    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Tower")
        {
            GetComponent<NavMeshAgent>().destination = other.transform.position;
            if(GetComponent<SphereCollider>()) GetComponent<SphereCollider>().enabled = false;
        }
    }
   
}
