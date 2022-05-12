using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemyToSpawn;
    public int amountToSpawn;
    [Range(0,10)] public float spawnCooldown;


    void Update()
    {
        if(DayNightManagement.itsNight)
        {
            if(amountToSpawn != 0)
            {
                amountToSpawn--;
                StartCoroutine(SpawnEnemy(enemyToSpawn));
            }
            
        }
       
    }


    IEnumerator SpawnEnemy(GameObject enemyPrefab)
    {
        
        
        yield return new WaitForSeconds(spawnCooldown);
        
        Instantiate(enemyPrefab, GetComponentInChildren<Transform>().position, Quaternion.identity);
        if(amountToSpawn != 0) StartCoroutine(SpawnEnemy(enemyToSpawn));
    }
}
