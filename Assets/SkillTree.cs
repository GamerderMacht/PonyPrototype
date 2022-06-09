using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillTree : MonoBehaviour
{
    CanvasGroup canvasGroup;
    [SerializeField] GameObject Wheel0; 

    [SerializeField] GameObject Wheel1;
    bool treeVisible;

    //variables for each Skill
    
    public TextMeshProUGUI skillName;
    public TextMeshProUGUI skillDescription;
    public TextMeshProUGUI skillChanges;
    public TextMeshProUGUI skillLevel;

    //Buttons
    public Button[] skillButtons;
    

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }







    public static void ButtonPressed(int id)
    {
        switch(id)
        {
            case 0:
            //name Reinforced Arrows
            Debug.Log("arrow");
            break;
            case 1:
            //name Arrow Quiver
            break;
            case 2:
            //name Scaling Arrows
            break;
            case 3:
            //name Greater Explosion
            break;
            case 4:
            //name Mana Sickness
            break;
            case 5:
            //name Supremacy Attack
            break;
            case 6:
            //name Reinforced Walls
            //DAS HIER
            break;
            case 7:
            //name Natures Blessing
            //DAS HIER
            break;
            case 8:
            //name Peek-A-Boo!
            break;
            case 9:
            //name Better wheat quality
            //DAS HIER
            break;
            case 10:
            //name wheat whealth
            //DAS HIER
            break;
            case 11:
            //name genetic evolution
            //DAS HIER
            break;
        }
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            if(treeVisible)
            {
                Wheel0.SetActive(true);
                Wheel1.SetActive(true);

                canvasGroup.alpha = 0;
                treeVisible = false;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            else
            {
                //An machen
                Wheel0.SetActive(false);
                Wheel1.SetActive(false);

                canvasGroup.alpha = 1;
                treeVisible = true;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            } 
            

        }
    }


    public void ApplyButton()
    {

    }
}
