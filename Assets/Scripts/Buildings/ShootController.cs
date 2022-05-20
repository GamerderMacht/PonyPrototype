using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    [Header("Target Tracking")]
    public float range = 10;
    public GameObject currentTarget;
    [Header("Shooting")]
    float fireRate = 1f;
    float fireCooldown = 0f;
    public GameObject projectile;
    public Transform bulletSpawner;


    private void Start()
    {
        InvokeRepeating("UpdateEnemy", 0f, 0.5f);                                       //eigenes update um leistung zu sparen
    }

    private void Update()
    {
        if (currentTarget == null)                                                      //auch zum leistung safen
            return;

        if (fireCooldown <= 0f)                                                        
        {
            Shoot();
            fireCooldown = 1f / fireRate;
        }
        fireCooldown -= Time.deltaTime;
    }

    private void UpdateEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");                                      //array für alle enemies die gerade im spiel sind 
        GameObject nearestEnemy = null;                                                                         
        float shortestDistance = Mathf.Infinity;                                                                //infinity damit wert nicht null wird

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if (nearestEnemy != null && shortestDistance <= range)
            currentTarget = nearestEnemy;
        else
            currentTarget = null;
    }

    void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(projectile, bulletSpawner.transform.position, bulletSpawner.transform.rotation);         //neues GO zuweisen, damit wir ein verweis auf jede kugel haben 
        Projectile bulletScript = bulletGO.GetComponent<Projectile>();

        if (bulletScript != null)
            bulletScript.Seek(currentTarget);                                                                                                  //so kann das aktuelle target in das skript von jeder kugel gepassed werden
    }

    private void OnDrawGizmos()                                                                                                                // nur zum visualisieren der range
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
