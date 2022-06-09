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
            if(gameObject.tag == "Grid")
            {
                Debug.Log("grid entered");
                if(buildingSpawner.hasObjectStanding)
                {
                    Debug.Log("wheelhud aus");
                    wheelHud.SetActive(false);
                }
            }
            if(gameObject.tag == "Base")
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
            if(currentLevel == maxLevel)
            {
                wheelParts[0].GetComponent<Button>().interactable = false;
            }
            else
            {
                wheelParts[0].GetComponent<Button>().interactable = true;
            }
            wheelManager.weaponWheelSelected = true;
        }
        
    }
    void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")ChooseTowerToPlace(WheelManager.weaponID);
        
        
    }
    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            if(tag == "Base")
            {
                wheelManager.weaponWheelSelected = false;
                wheelHud.SetActive(true);
            }
            else
            {
                wheelManager.weaponWheelSelected = false;
                wheelHud.SetActive(true);
            }
            
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
                    if(!wheelHud.activeInHierarchy)
                    {
                        Debug.Log("yeaaaa");
                        if(playerInventory.currentGoldAmount >= levelUpGoldCost[currentLevel])
                        {
                            playerInventory.currentGoldAmount -= levelUpGoldCost[currentLevel];
                            if(gameObject.transform.GetChild(0).tag == "Tower")
                            { 
                                if(gameObject.transform.GetChild(0).GetComponent<ShootController>().bulletSpawner.name == "Crystal")
                                {
                                    Debug.Log("Eier flattern");
                                    if(gameObject.transform.childCount > 0) Destroy(gameObject.transform.GetChild(0).gameObject);
                                    Instantiate(prefabMageTowers[currentLevel], transform.position, transform.rotation, gameObject.transform);
                                    audioSource.PlayOneShot(upgradeSound);
                                    currentLevel++;
                                    wheelManager.weaponWheelSelected = false;
                                }
                                else
                                {
                                    audioSource.PlayOneShot(upgradeSound);
                                    Debug.Log ("Tower Upgraded");
                                    if(gameObject.transform.childCount > 0) Destroy(gameObject.transform.GetChild(0).gameObject);
                                    
                                    Instantiate(prefabUpgradedTowers[currentLevel], transform.position, transform.rotation, gameObject.transform);
                                    currentLevel++;
                                    //TODO: change Child for upgrade
                                    wheelManager.weaponWheelSelected = false;
                                
                                }
                            }
                            else if(gameObject.transform.GetChild(0).tag == "Wall")
                            {
                                Debug.Log("Wall flattern");
                                if(gameObject.transform.childCount > 0) Destroy(gameObject.transform.GetChild(0).gameObject);
                                Instantiate(prefabUpgradedTowers[currentLevel], transform.position, transform.rotation, gameObject.transform);
                                audioSource.PlayOneShot(upgradeSound);
                                currentLevel++;
                                wheelManager.weaponWheelSelected = false;
                            }
                            else if(gameObject.tag == "Base")
                            {
                                audioSource.PlayOneShot(upgradeSound);
                                Debug.Log ("Base Upgraded");
                                if(gameObject.transform.childCount > 0) Destroy(gameObject.transform.GetChild(1).gameObject);
                                
                                Instantiate(prefabUpgradedTowers[currentLevel], transform.position, transform.rotation, gameObject.transform);
                                currentLevel++;
                                
                                wheelManager.weaponWheelSelected = false;
                            }
                            else
                            {
                                audioSource.PlayOneShot(upgradeSound);
                                Debug.Log ("Base Upgraded");
                                if(gameObject.transform.childCount > 0) Destroy(gameObject.transform.GetChild(0).gameObject);
                                
                                Instantiate(prefabUpgradedTowers[currentLevel], transform.position, transform.rotation, gameObject.transform);
                                currentLevel++;
                                
                                wheelManager.weaponWheelSelected = false;
                            }
                            
                            
                            

                            if(gameObject.tag == "Base")
                            {
                                playerInventory.maxCitizenAmount += (currentLevel ) * 10;
                                playerInventory.currentCitizenAmount += 10 * currentLevel;
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
                    
                }
            break;

            case 2: //Destroy Object
            
                if(!wheelHud.activeInHierarchy)
                {

                
                    playerInventory.currentGoldAmount += levelUpGoldCost[currentLevel - 1];

                    audioSource.PlayOneShot(destroySound);
                    Debug.Log ("Building destroyed");
                    if(tag == "Base")
                    {
                        Destroy(gameObject.transform.GetChild(1).gameObject);
                    }
                    else
                    {
                        foreach(GameObject child in prefabUpgradedTowers)
                        {
                            Destroy(gameObject.transform.GetChild(0).gameObject);
                        }
                    }
                    
                    currentLevel = 0; playerInventory.currentCitizenAmount += buildingSpawner.bewohnerCost[0];
                    if(!GetComponent<MeshRenderer>().enabled)
                    {
                        gameObject.GetComponent<MeshRenderer>().enabled = true;
                    } 
                    
                    
                    wheelManager.weaponWheelSelected = false;
                    wheelHud.SetActive(true);
                }
            break;

         
        }

    }
}
