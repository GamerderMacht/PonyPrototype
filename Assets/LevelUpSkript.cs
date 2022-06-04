using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpSkript : MonoBehaviour
{
    //Object Level Up Skript 2.1 03.06.22
    [SerializeField] public int currentLevel;
    [SerializeField] int maxLevel;

    [SerializeField] int[] levelUpGoldCost;

    [SerializeField] bool isDestroyable;

    [SerializeField] GameObject[] prefabUpgradedTowers;
    [SerializeField] GameObject[] prefabMageTowers;

    //Wheel Parts
    [SerializeField] int[] wheelsInteger;
    [SerializeField] GameObject[] wheelParts = new GameObject[2];


    GameObject wheelHud;
    BuildingSpawner buildingSpawner;
    [SerializeField] WheelManager wheelManager;
    [SerializeField] PlayerInventory playerInventory;
    AudioSource audioSource;
    public AudioClip upgradeSound;
    public AudioClip destroySound;

    void Start()
    {
        if(gameObject.GetComponent<BuildingSpawner>() != null) buildingSpawner = GetComponent<BuildingSpawner>();
        wheelParts[0] = GameObject.Find("WheelLevelLinks");
        wheelParts[1] = GameObject.Find("WheelLevelRechts");
        wheelManager = GameObject.FindGameObjectWithTag("LevelUpSystem").GetComponent<WheelManager>();
        playerInventory = GameObject.Find("Player").GetComponent<PlayerInventory>();
        audioSource = GetComponent<AudioSource>();
        wheelHud = GameObject.Find("WheelHUD");
    }

    void OnTriggerEnter(Collider other)
    {
        
        
        if (other.tag == "Player")
        {
            if(buildingSpawner.hasObjectStanding)
            {
                wheelHud.SetActive(false);
            }
            
            
            if(isDestroyable)
            {
                wheelParts[1].GetComponent<Button>().interactable = true;
            }
            else if(!isDestroyable)
            {
                wheelParts[1].GetComponent<Button>().interactable = false;
            }
            wheelManager.weaponWheelSelected = true;
        }
        
    }
    void OnTriggerStay(Collider other)
    {
        ChooseTowerToPlace(WheelManager.weaponID);
        
    }
    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            if(buildingSpawner.hasObjectStanding) wheelHud.SetActive(true);
            wheelManager.weaponWheelSelected = false;
        }
        
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
                    if(playerInventory.currentGoldAmount >= levelUpGoldCost[currentLevel])
                    {
                        playerInventory.currentGoldAmount -= levelUpGoldCost[currentLevel];
                        {
                            audioSource.PlayOneShot(upgradeSound);
                            Debug.Log ("Tower Upgraded");
                            //Destroy(gameObject.transform.GetChild(0));
                            currentLevel++;
                            //TODO: change Child for upgrade
                            wheelManager.weaponWheelSelected = false;
                            
                        }
                        

                        if(gameObject.tag == "Base")
                        {
                            playerInventory.maxCitizenAmount = (currentLevel + 1) * 5;
                            playerInventory.currentCitizenAmount +=5;
                            audioSource.PlayOneShot(upgradeSound);
                            wheelManager.weaponWheelSelected = false;

                        } 
                        
                        
                    }
                    else
                    {
                        //ADD UI IMAGE MIT TEXT ZU WENIG CASH
                        Debug.Log("nicht genug Cash :(");
                        wheelManager.weaponWheelSelected = false;
                    }
                }
            break;

            case 2: //Destroy Object
            
                playerInventory.currentGoldAmount += levelUpGoldCost[currentLevel];

                audioSource.PlayOneShot(destroySound);
                Debug.Log ("Building destroyed");
                foreach(GameObject child in prefabUpgradedTowers)
                {
                    Destroy(child);
                }
                if(!GetComponent<MeshRenderer>().enabled)
                {
                    gameObject.GetComponent<MeshRenderer>().enabled = true;
                } 
                
                
                wheelManager.weaponWheelSelected = false;
            break;

         
        }

    }
}
