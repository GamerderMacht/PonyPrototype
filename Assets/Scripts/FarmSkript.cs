using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmSkript : MonoBehaviour
{
    //variables
    [Header("Variablen")]
    [SerializeField] int waitForNextGoldToProduce;
    [SerializeField] int amountOfGoldFromFarm;


   PlayerInventory playerInventory;
   DayNightManagement dayNightManagement;


   void OnEnable()
   {
       playerInventory = GameObject.Find("Player").GetComponent<PlayerInventory>();
       dayNightManagement = GameObject.Find("DayNightManagement").GetComponent<DayNightManagement>();
       StartCoroutine(ProduceGold());
   }


   void Update()
   {
       
   }


   IEnumerator ProduceGold()
   {
       while(true)
       {
           GetGold();
           yield return new WaitForSeconds(waitForNextGoldToProduce);
       }
       
   }

    private void GetGold()
    {
        playerInventory.currentGoldAmount += amountOfGoldFromFarm;
        return;
    }
}
