using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WheelManager : MonoBehaviour
{

    public Animator anim;

    [HideInInspector]
    public bool weaponWheelSelected = false;
    //public int wepID;


    public Image selectedItem;
    public Sprite noImage;
    public static int weaponID;

    void Update()
    {
        

        /*
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            weaponWheelSelected = !weaponWheelSelected;
        }
        */
        
        if(weaponWheelSelected)
        {
            anim.SetBool("OpenWeaponWheel", true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            anim.SetBool("OpenWeaponWheel", false);
            Cursor.lockState = CursorLockMode.Locked;
		    Cursor.visible = false;
            weaponID = 0;
            

        }

        switch(weaponID)
        {
            case 0: //nothing selected
                selectedItem.sprite = noImage;
                break;
            case 1: 
            Debug.Log("WheelOben");
                
                break;
            case 2: 
            Debug.Log("WheelRechts");
                
                break;
            case 3: 
            Debug.Log("WheelUnten");
               
                break;
            case 4: 
            Debug.Log("WheelLink");
                
                break;
            
        }
    }
}
