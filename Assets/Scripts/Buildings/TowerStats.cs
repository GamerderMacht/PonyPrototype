using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerStats : MonoBehaviour
{
    [Header("Archer")]
    //Archer
    public int archerHp;
    public float archerDamage;
    public float archerAttackSpeed;
    public int archerRange;
    public int archerCost;

    [Header("Mage")]
    //Mage
    public int mageHP;
    public float mageDamage;
    public float mageAttackSpeed;
    public int mageRange;
    public int mageProjectileRange;
    public int mageCost;

    [Header("Wall")]
    //Wall
    public int wallHP;
    public bool wallCanRegenerate;
    public int wallCost;

    [Header("Farm")]
    //Farm
    public int farmProductionRate;
    public int farmCost;
    public bool canProduceTech;

}
