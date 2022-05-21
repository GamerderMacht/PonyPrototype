using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableScriptOnNight : MonoBehaviour
{
    
    DayNightManagement dayNightManagement;
    public GameObject spawnPoint;


    void Start()
    {
        dayNightManagement = GameObject.Find("DayNightManagement").GetComponent<DayNightManagement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(dayNightManagement.TimeOfDay < 20 && dayNightManagement.TimeOfDay > 18)
        {
            spawnPoint.SetActive(true);
        }
        else
        {
            spawnPoint.SetActive(false);
        }
    }
}
