using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillButtonController : MonoBehaviour
{
    [SerializeField] Image buttonImage;
    [SerializeField] string skillName;
    [SerializeField] string skillDescription;
    [SerializeField] string skillChanges;
    [SerializeField] public int skillcurrentLevel;
    [SerializeField] public int skillmaxLevel;
    
    public int Id;
    Button thisButtonInteractable;


    SkillTree skillTree;
    void Start()
    {
        skillTree = GameObject.Find("SkillTree").GetComponent<SkillTree>();

        thisButtonInteractable = GetComponent<Button>();
        if(Id == 0 || Id == 3 || Id == 6 || Id == 9)
        {
            thisButtonInteractable.interactable = true;
            
        }
    }


    public void HoverEnter()
    {
        UpdateMiddleText();
    }

    

    public void HoverExit()
    {
        EmptyMiddleText();
    }

    

    public void Selected()
    {
        SkillBought();

    
        Debug.Log("Skill selected");
    }

    


    void Update()
    {
        
    }
    private void UpdateMiddleText()
    {
        skillTree.skillName.text = skillName;
        skillTree.skillDescription.text = skillDescription;
        skillTree.skillChanges.text = skillChanges;
        skillTree.skillLevel.text = (skillcurrentLevel + " / " + skillmaxLevel);
    }

    private void EmptyMiddleText()
    {
        skillTree.skillName.text = null;
        skillTree.skillDescription.text = null;
        skillTree.skillChanges.text = null;
        skillTree.skillLevel.text = null;
    }

    private void SkillBought()
    {
        skillcurrentLevel++;
        UpdateMiddleText();
        if (skillcurrentLevel >= skillmaxLevel)
        {
            thisButtonInteractable.interactable = false;
        }

        if (Id == 2 || Id == 5 || Id == 8 || Id == 11){//nothing wenn
        }
        else
        {
            var otherButton = skillTree.skillButtons[Id + 1].gameObject.GetComponent<SkillButtonController>();
            if (otherButton.skillcurrentLevel == otherButton.skillmaxLevel){//nothing
            }
            else
            {
                skillTree.skillButtons[Id + 1].interactable = true;
            }

        }
        SkillTree.ButtonPressed(Id);
    }
}
