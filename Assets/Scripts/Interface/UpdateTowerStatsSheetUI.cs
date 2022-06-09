using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpdateTowerStatsSheetUI : MonoBehaviour
{
    public TextMeshProUGUI hpText;
    public TextMeshProUGUI damageText;
    public TextMeshProUGUI attackSpeedText;
    public TextMeshProUGUI attackRangeText;
    public TextMeshProUGUI rangeText;
    public TextMeshProUGUI towerCostText;




    SkillButtonController skillButtonController;
    TowerStats towerStats;
    public void HoverEnter(int id)
    {
        if(skillButtonController == null)skillButtonController = GetComponent<SkillButtonController>();
        if(towerStats == null) towerStats = GameObject.Find("WheelHUD").GetComponent<TowerStats>();

        switch(id)
        {
            case 1:
            hpText.text = (towerStats.archerHp + " Tower HP").ToString();
            damageText.text = towerStats.archerDamage + " Damage";
            attackSpeedText.text = towerStats.archerAttackSpeed + " Attack Speed";
            attackRangeText.text = towerStats.archerRange + " Attack Range";
            towerCostText.text = towerStats.archerCost + " Gold Cost";
            break;
            case 2:
            hpText.text = (towerStats.mageHP + " Tower HP").ToString();
            damageText.text = towerStats.mageDamage + " Damage";
            attackSpeedText.text = towerStats.mageAttackSpeed + " Attack Speed";
            attackRangeText.text = towerStats.mageRange + " Attack Range";
            rangeText.text = towerStats.mageProjectileRange + " AOE Range";
            towerCostText.text = towerStats.mageCost + " Gold Cost";
            break;
            case 3:
            hpText.text = (towerStats.wallHP + " Tower HP").ToString();
            towerCostText.text = towerStats.wallCost + " Gold Cost";
            break;
            case 4:
            hpText.text = (towerStats.farmProductionRate + " Gold per Day").ToString();
           
            towerCostText.text = towerStats.farmCost + " Gold Cost";
            break;
        }

        

    }
    public void HoverExit()
    {
        hpText.text = "";
        damageText.text = "";
        attackSpeedText.text = "";
        attackRangeText.text = "";
        rangeText.text = "";
        towerCostText.text = "";

    }
}
