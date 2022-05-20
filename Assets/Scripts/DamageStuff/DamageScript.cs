using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    //Dieses Skript sorgt dafür, das Objekte (z.B. Türm) schaden erleiden können
    PlayerHP hpScript;
    [SerializeField] UnitHPSkript objectHpSkript;

    public int damageAmount;

    [SerializeField] bool continueCoroutine = true;
    void OnTriggerEnter(Collider other)
    {
        
        if(other.tag == "Player")
        {
            hpScript = other.GetComponent<PlayerHP>();
            
            StartCoroutine(DoingDamageCycle(damageAmount));
            
            
        }
        if(other.tag == "Tower" || other.tag == "Wall")
        {
            
            objectHpSkript = other.GetComponent<UnitHPSkript>();
            continueCoroutine = true;
            Debug.Log("Tower bekam dmg");
            StartCoroutine(DoingDamageCycle(damageAmount));
        }

    }
    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Tower" || other.tag == "Wall")
        {
            StopCoroutine(DoingDamageCycle(damageAmount));
            Debug.Log("taking" + damageAmount + " damage stopped");
            continueCoroutine = false;
        }
        //Wenn das Objekt wieder raus geht, wird der kontinuierliche Schaden beendet.
        
        
        
    }
    
    /*
    void OnTriggerStay(Collider other)
    {
        hpScript = other.GetComponent<HpScript>();
        StartCoroutine(DoingDamageCycle(damageAmount));
        
    }
    */

    //Coroutine dass das andere Obejkt Schaden bekommt
    //COROUTINE FÜR KONTINUIERLICHEN SCHADEN
    IEnumerator DoingDamageCycle(int dealingdamage)
    {
        Debug.Log("Routine started");
        while(continueCoroutine)
        {
            
            objectHpSkript.DamageTaken(dealingdamage);
            yield return new WaitForSecondsRealtime(1f);
        }
        
        
    }
    
}
