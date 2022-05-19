using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] Transform[] spawnPoints;

    //Items to spawn
    [SerializeField] GameObject technologiePrefab;
    [SerializeField] GameObject goldNuggetPrefab;

    void Start()
    {
        SpawnItems();
    }

    public void SpawnItems()
    {
        var maxTech = 3;
        var maxGoldNuggets = 2;
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            var spawning = Random.Range(0,3);
            
            if (spawning == 1 && maxTech != 0)
            {
                Instantiate(technologiePrefab, spawnPoints[i].transform.position,Quaternion.identity);
                maxTech--;
                
            }
            else if(spawning == 2 && maxGoldNuggets != 0)
            {
                Instantiate(goldNuggetPrefab, spawnPoints[i].transform.position, Quaternion.identity);
                maxGoldNuggets--;
                
            }
            else
            {
                
            }

        }
        
        
    }
    



}
