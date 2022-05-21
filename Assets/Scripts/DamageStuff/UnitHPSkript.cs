using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitHPSkript : MonoBehaviour
{
public int maxHealth;
public int wavebonusHP; 
public int currentHealth;

        
    void Start()
    {
        if(gameObject.tag == "Enemy")
        {
            wavebonusHP = ObjectPool.Wave * 5;
            maxHealth = maxHealth + wavebonusHP;
        } 
        currentHealth = maxHealth;
              
    }

    public void DamageTaken(int damageAmount)
    {
        currentHealth -= damageAmount;
        Debug.Log (damageAmount + " damage taken!");
        
        if (currentHealth <= 0)
        {
            //Objekt ist Tod / kaputt
            Debug.Log("Tod");
            Destroy(gameObject, 0.5f);
        }
    }
}
