using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingSpawner : MonoBehaviour
{
  
    [SerializeField] GameObject[] placeablePrefabs;
    [SerializeField] int[] placeAbleWheelInts;
    [SerializeField] bool hasObjectStanding;

    FPSController player;

    WheelManager wheel;
    private int weaponID;
    [SerializeField] GameObject[] wheelParts = new GameObject[4];


    private void OnEnable() {
        wheelParts[0] = GameObject.Find("Interface").gameObject.transform.GetChild(1).GetChild(1).GetChild(0).gameObject;
        wheelParts[1] = GameObject.Find("Interface").gameObject.transform.GetChild(1).GetChild(1).GetChild(1).gameObject;
        wheelParts[2] = GameObject.Find("Interface").gameObject.transform.GetChild(1).GetChild(1).GetChild(2).gameObject;
        wheelParts[3] = GameObject.Find("Interface").gameObject.transform.GetChild(1).GetChild(1).GetChild(3).gameObject;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Im Baubereich");
            

        	if(!hasObjectStanding) ChooseTowerToPlace(WheelManager.weaponID);

        }


    }

    private void ChooseTowerToPlace(int id)
    {
        Debug.Log("Choose the Tower");
        
        switch(id)
        {
            case 1:
            Debug.Log ("Tower Archer placed");
            Instantiate(placeablePrefabs[0], transform.position, Quaternion.identity);
            hasObjectStanding = true;
            
            wheel.weaponWheelSelected = false;
            break;
            case 2:
            Debug.Log ("Tower Mage placed");
            Instantiate(placeablePrefabs[1], transform.position, Quaternion.identity);
            hasObjectStanding = true;
            
            wheel.weaponWheelSelected = false;
            break;
            case 3:
            Debug.Log("Wall placed");
            Instantiate(placeablePrefabs[0], transform.position, Quaternion.identity);
            hasObjectStanding = true;
            break;
            case 4:
            Debug.Log("Farm placed");
            Instantiate(placeablePrefabs[0], transform.position, Quaternion.identity);
            hasObjectStanding = true;
            break;
        }

    }

    
    void OnTriggerEnter(Collider other)
    {
    if (other.tag == "Player" && !hasObjectStanding)
    {
        player = GameObject.Find("Player").GetComponent<FPSController>();
        Debug.Log(player);

        wheel = GameObject.Find("Interface").gameObject.transform.GetChild(1).GetChild(1).GetComponent<WheelManager>();
        Debug.Log(wheel);
      


        
        for(int i = 0; i < 4; i++)
        {
            wheelParts[i].GetComponent<Button>().interactable = false;
        }
        wheelParts[placeAbleWheelInts[0] - 1].GetComponent<Button>().interactable = true;
        if(placeAbleWheelInts.Length > 1) wheelParts[placeAbleWheelInts[1] - 1].GetComponent<Button>().interactable = true;
           
        
        wheel.weaponWheelSelected = true;
    }
    }
    void OnTriggerExit(Collider other)
    {
    if (other.tag == "Player")
    {
        wheel.weaponWheelSelected = false;
        if(hasObjectStanding) GetComponent<BoxCollider>().enabled = false;
        
    }
    }


}
