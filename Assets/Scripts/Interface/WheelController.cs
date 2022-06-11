using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WheelController : MonoBehaviour
{

    public int Id;
    private Animator anim;
    public string itemName;
    public TextMeshProUGUI itemText;
    public UpdateTowerStatsSheetUI updateTowerStatsSheetUI;
    
    bool selected = false;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(selected)
        {
            
            itemText.text = itemName;
        }
       
    }

    public void Selected()
    {
        Debug.Log("es wurde " + Id);
        selected = true;
        WheelManager.weaponID = Id;
    }

    public void Deselected()
    {
        selected = false;
        WheelManager.weaponID = 0;
    }

    public void HoverEnter()
    {
        Debug.Log("Hoverd");
        anim.SetBool("Hover", true);
        itemText.text = itemName;
        updateTowerStatsSheetUI = GetComponent<UpdateTowerStatsSheetUI>();
        updateTowerStatsSheetUI.HoverEnter(Id);
    }
    public void HoverExit()
    {
        anim.SetBool("Hover", false);
        itemText.text = "";
        updateTowerStatsSheetUI.HoverExit();
    }
}
