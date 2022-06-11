using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyMovement : MonoBehaviour
{
    Rigidbody rbEnemy;
    [SerializeField] float unitSpeed;

    float currentSpeed;    
    public float RotationSpeed;
    public float spawnBoostSpeed;

    private GameObject target = null;
    public float range = 20;

    [Header("Shooting")]
    float fireRate = 1f;
    float fireCooldown = 0f;
    public GameObject projectile;
    public Transform bulletSpawner;


    private void Awake()
    {
        target = GameObject.Find("PlayerBase");
        UpdateTarget();
    }
    void Start()
    {
        rbEnemy = GetComponent<Rigidbody>();
    }
    void Update()
    {
        MovementSpeed();
    }  
    void FixedUpdate()
    {
        MovingAndRotation();
        UpdateTarget();
    }

    private void MovingAndRotation()
    {
        var lookPos = target.transform.position - transform.position;
        lookPos.y = 0;

        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * RotationSpeed);

        rbEnemy.AddRelativeForce(Vector3.forward * currentSpeed);

        if (Vector3.Distance(transform.position, target.transform.position) < range)
        {
            rbEnemy.AddRelativeForce(Vector3.back * currentSpeed);

            if (fireCooldown <= 0f)
            {
                Shoot();
                fireCooldown = 1f / fireRate;
            }
            fireCooldown -= Time.deltaTime;
        }
    }

    private void MovementSpeed()
    {
        if (transform.position.y < 0)
            currentSpeed = spawnBoostSpeed;
        else
            currentSpeed = unitSpeed;
    }

    void UpdateTarget()
    {
        GameObject[] allTargets = GameObject.FindGameObjectsWithTag("Base");
        GameObject nearestTarget = null;
        float shortestDistance = Mathf.Infinity;

        foreach(GameObject target in allTargets)
        {
            float distanceToTarget = Vector3.Distance(transform.position, target.transform.position);
            if(distanceToTarget < shortestDistance)
            {
                shortestDistance = distanceToTarget;
                nearestTarget = target;
            }
        }
        target = nearestTarget;
    }

    void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(projectile, bulletSpawner.transform.position, bulletSpawner.transform.rotation);         
        Projectile bulletScript = bulletGO.GetComponent<Projectile>();

        if (bulletScript != null)
            bulletScript.Seek(target);                                                                                                  
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
