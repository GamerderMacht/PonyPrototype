using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingSpawner : MonoBehaviour
{
  
    [SerializeField] GameObject[] placeablePrefabs;
    [SerializeField] int[] placeAbleWheelInts;
    [SerializeField] public int[] goldCost;
    [SerializeField] public int[] bewohnerCost;
    [SerializeField] public bool hasObjectStanding;

    FPSController player;
    PlayerInventory playerInventory;
    MeshRenderer meshRenderer;
    WheelManager wheel;
    
    private int weaponID;
    
    GameObject levelUpWheel;
    [SerializeField] GameObject[] wheelParts = new GameObject[4];
    LevelUpSkript levelUpSkript;

    //Sounds
    public AudioClip audioClip;
    AudioSource audioSource;


    private void OnEnable() {
        meshRenderer = GetComponent<MeshRenderer>();
        wheelParts[0] = GameObject.Find("WheelOben");
        wheelParts[1] = GameObject.Find("WheelRechts");
        wheelParts[2] = GameObject.Find("WheelUnten");
        wheelParts[3] = GameObject.Find("WheelLinks");
        audioSource = GetComponent<AudioSource>();
        
    } 
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            //Wenn das Gebäude wieder weg ist
            if(transform.childCount == 0)
            {
                //man kann wieder platzieren
                //Die Baustelle ist wieder sichtbar
                hasObjectStanding = false;
                meshRenderer.enabled = true;
            } 
            

        	if(!hasObjectStanding) ChooseTowerToPlace(WheelManager.weaponID);

        }


    }

    /* TO DO-----




    */
    private void ChooseTowerToPlace(int id)
    {
        
        
        switch(id) //Id ist der Wheel Int. 0 = nichts ausgewählt
        {
            case 1: //Case Tower Archer
            if(playerInventory.currentGoldAmount >= goldCost[0] && playerInventory.currentCitizenAmount >= 2)
            {
                playerInventory.currentGoldAmount -= goldCost[0];
                playerInventory.currentCitizenAmount -= 2;
                
                audioSource.PlayOneShot(audioClip);
                meshRenderer.enabled = false;
                Debug.Log ("Tower Archer placed");
                Instantiate(placeablePrefabs[0], transform.position, transform.rotation, gameObject.transform);
                hasObjectStanding = true;
                
                wheel.weaponWheelSelected = false;
                levelUpSkript.currentLevel++;
            }
            else
            {
                Debug.Log("nicht genug Cash :(");
                wheel.weaponWheelSelected = false;
            }
            
            break;

            case 2: //Case Tower mage
            if(playerInventory.currentGoldAmount >= goldCost[1] && playerInventory.currentCitizenAmount >= 2)
            {
                playerInventory.currentGoldAmount -= goldCost[1];
                playerInventory.currentCitizenAmount -= 2;
                
                audioSource.PlayOneShot(audioClip);
                meshRenderer.enabled = false;
                Debug.Log ("Tower Mage placed");
                Instantiate(placeablePrefabs[1], transform.position, transform.rotation, gameObject.transform);
                hasObjectStanding = true;
                
                wheel.weaponWheelSelected = false;
                levelUpSkript.currentLevel++;
            }
            else
            {
                Debug.Log("nicht genug Cash :(");
                wheel.weaponWheelSelected = false;
            }
            break;

            case 3: //Case Wall 
            if(playerInventory.currentGoldAmount >= goldCost[0])
            {
                playerInventory.currentGoldAmount -= goldCost[0];


                audioSource.PlayOneShot(audioClip);
                meshRenderer.enabled = false;
                Debug.Log("Wall placed");
                Instantiate(placeablePrefabs[0], transform.position, transform.rotation, gameObject.transform);
                hasObjectStanding = true;
                wheel.weaponWheelSelected = false;
                levelUpSkript.currentLevel +=1;
            }
            else
            {
                Debug.Log("nicht genug Cash :(");
                wheel.weaponWheelSelected = false;
            }
            
            break;
            case 4: //Case Farm
            if(playerInventory.currentGoldAmount >= goldCost[0] && playerInventory.currentCitizenAmount >= 1)
            {
                playerInventory.currentGoldAmount -= goldCost[0];
                playerInventory.currentCitizenAmount -= 1;


                audioSource.PlayOneShot(audioClip);
                meshRenderer.enabled = false;
                Debug.Log("Farm placed");
                Instantiate(placeablePrefabs[0], transform.position, transform.rotation, gameObject.transform);
                hasObjectStanding = true;
                wheel.weaponWheelSelected = false;
                levelUpSkript.currentLevel +=1;
            }
            else
            {
                Debug.Log("nicht genug Cash :(");
                wheel.weaponWheelSelected = false;
            }
            break;
        }

    }

    
    void OnTriggerEnter(Collider other)
    {
    if (other.tag == "Player" && !hasObjectStanding)
    {
        levelUpSkript = GetComponent<LevelUpSkript>();
        //Nimmt die Components vom Spieler
        player = GameObject.Find("Player").GetComponent<FPSController>();
        playerInventory = GameObject.Find("Player").GetComponent<PlayerInventory>();
        wheel = GameObject.Find("WheelHUD").GetComponent<WheelManager>();
        

        
      
        //Für das Wheel. Macht bei TriggerEnter das Wheel nicht interactable, dann geht es durch alle durch. Wenn im Inspector die int Zahl steht, dann wird dieser Wheelpart
        //interactable. So die Theorie... :)
        for(int i = 0; i < 4; i++)
        {
            wheelParts[i].GetComponent<Button>().interactable = false;
        }
        wheelParts[placeAbleWheelInts[0] - 1].GetComponent<Button>().interactable = true;
        if(placeAbleWheelInts.Length > 1) wheelParts[placeAbleWheelInts[1] - 1].GetComponent<Button>().interactable = true;

        levelUpWheel = GameObject.Find("WheelLevelUp");   
        levelUpWheel.SetActive(false);
        wheel.weaponWheelSelected = true;
    }
    }
    void OnTriggerExit(Collider other)
    //Wenn wir es wieder verlassen, soll das Wheel wieder ausgehen
    //Wenn was platziert wurde. Erscheint dieses Wheel nicht mehr
    {
        if (other.tag == "Player")
        {
            levelUpWheel.SetActive(true);
            wheel.weaponWheelSelected = false;
            
            levelUpWheel.SetActive(true);
        }
    }


}
