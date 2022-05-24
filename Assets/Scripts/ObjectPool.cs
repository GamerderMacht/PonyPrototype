using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    
    [SerializeField] GameObject[] enemyPrefab;
    [SerializeField] Transform spawnPoint;
    [SerializeField] int poolSize = 5;
    [SerializeField] int enemiesYetToSpawn;
    [SerializeField] float spawnTimer = 1f;
    [SerializeField] public static int Wave;

    GameObject[] pool;

    void Awake()
    {
        
    }
    void OnEnable()
    {
        enemiesYetToSpawn = poolSize + (Wave * 2);
        StartCoroutine(SpawnEnemy());

    }

   
 

    IEnumerator SpawnEnemy()
    {
       
        while(enemiesYetToSpawn > 0)
        {
            
            //Ab Tag 3 kommen neue hinzu
            if(enemyPrefab.Length > 1) /*  --->   */ if(Wave >= 3)
            {
                
                enemiesYetToSpawn--;
                Instantiate(enemyPrefab[1], spawnPoint.position, enemyPrefab[1].transform.localRotation);
                yield return new WaitForSeconds(spawnTimer);
            }
            //Spawn Standard enemy
            enemiesYetToSpawn--;
            Instantiate(enemyPrefab[0], spawnPoint.position, enemyPrefab[0].transform.localRotation);
            yield return new WaitForSeconds(spawnTimer);
        }
    }

    
}
