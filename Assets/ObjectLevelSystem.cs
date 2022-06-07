using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectLevelSystem : MonoBehaviour
{
    //VERSION 1.0 LEVEL UP















    //Dont use. Buggy not working
    [SerializeField] public int currentLevel = 0;
    [SerializeField] int maxLevel = 3;
    [SerializeField] int[] upgradeGoldCost;

    [SerializeField] int[] wheelLeftAndRight;
    
    [SerializeField] GameObject[] objectOneLevel;
    [SerializeField] GameObject[] objectTwoLevel;
    public bool isDestroyable;
    [SerializeField] bool hasObjectStanding;
    //Get Scripts------
    PlayerInventory playerInventory;
    WheelManager wheel;
    GameObject[] wheelParts = new GameObject[2];
    GameObject bauWheel;
    BuildingSpawner buildingSpawner;
   void OnEnable()
   {
        wheelParts[0] = GameObject.Find("WheelLevelLinks");
        wheelParts[1] = GameObject.Find("WheelLevelRechts");
       
   }
    void Start()
    {
        wheel = GameObject.FindGameObjectWithTag("LevelUpSystem").GetComponent<WheelManager>();
        bauWheel = GameObject.Find("WheelHUD");
        buildingSpawner = GetComponent<BuildingSpawner>();
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Player" && hasObjectStanding)
        {
            bauWheel.SetActive(false);
            //Nimmt die Components vom Spieler
        
            playerInventory = GameObject.Find("Player").GetComponent<PlayerInventory>();
            for(int i = 0; i < wheelLeftAndRight.Length; i++)
            {
                wheelParts[i].GetComponent<Button>().interactable = false;
            }
            if(currentLevel != maxLevel) wheelParts[wheelLeftAndRight[0] - 1].GetComponent<Button>().interactable = true;
            if(wheelLeftAndRight.Length > 1 && isDestroyable) wheelParts[wheelLeftAndRight[1] - 1].GetComponent<Button>().interactable = true;
            
            
            wheel.weaponWheelSelected = true;
        }
    }
    void OnTriggerStay(Collider other)
    {
        ChooseTowerToPlace(WheelManager.weaponID);
        Debug.Log(WheelManager.weaponID + "ist grad die id");
    }
    void OnTriggerExit(Collider other)
    //Wenn wir es wieder verlassen, soll das Wheel wieder ausgehen
    //Wenn was platziert wurde. Erscheint dieses Wheel nicht mehr
    {
        if (other.tag == "Player")
        {
            
            wheel.weaponWheelSelected = false;
            
            
        }
        bauWheel.SetActive(true);
    }

    private void ChooseTowerToPlace(int id)
    {
        Debug.Log("Choose the Tower333333");
        
        switch(id) //Id ist der Wheel Int. 0 = nichts ausgewählt
        {
            
            case 1: //UPGRADES PEOPLE UPGRADES
            if(currentLevel < maxLevel)
            {
                Debug.Log("yeaaaa");
                if(playerInventory.currentGoldAmount >= upgradeGoldCost[currentLevel])
                {
                    Debug.Log("yea2222");
                    playerInventory.currentGoldAmount -= upgradeGoldCost[currentLevel];

                    
                    //BUGGY NOT USABLE
                        Debug.Log("Archer Upgraded");
                        objectOneLevel[currentLevel].SetActive(false);
                        currentLevel++;
                        objectOneLevel[currentLevel].SetActive(true);
                    
                    
                    
                        Debug.Log("Mage Upgraded");
                        objectTwoLevel[currentLevel].SetActive(false);
                        currentLevel++;
                        objectTwoLevel[currentLevel].SetActive(true);
                    
                   
                    
                        Debug.Log ("Tower Upgraded");
                        objectOneLevel[currentLevel].SetActive(false);
                        currentLevel++;
                        objectOneLevel[currentLevel].SetActive(true);
                    
                    

                    if(gameObject.tag == "Base")
                    {
                        playerInventory.maxCitizenAmount = (currentLevel + 1) * 5;
                        playerInventory.currentCitizenAmount +=5;

                    } 
                    
                    wheel.weaponWheelSelected = false;
                }
                else
                {
                    Debug.Log("nicht genug Cash :(");
                    wheel.weaponWheelSelected = false;
                }
            }
            
            
            break;

            case 2: //Destroy Object
            
                playerInventory.currentGoldAmount += upgradeGoldCost[currentLevel];

                
                Debug.Log ("Building destroyed");
                foreach(GameObject child in objectOneLevel)
                {
                    child.SetActive(false);
                }
                if(!GetComponent<MeshRenderer>().enabled)
                {
                    gameObject.GetComponent<MeshRenderer>().enabled = true;
                } 
                
                
                wheel.weaponWheelSelected = false;
            break;

         
        }

    }
}
