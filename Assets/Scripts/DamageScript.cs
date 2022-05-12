using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    [SerializeField] UnitHPSkript hpScript;

    public int damageAmount;

    bool continueCoroutine = true;
    void OnTriggerEnter(Collider other)
    {
        
        if(other.tag == "Player")
        {
            hpScript = other.GetComponent<UnitHPSkript>();
            continueCoroutine = true;
            StartCoroutine(DoingDamageCycle(damageAmount));
            
            
        }        
    }
    void OnTriggerExit(Collider other)
    {
        //Wenn das Objekt wieder raus geht, wird der kontinuierliche Schaden beendet.
        StopCoroutine(DoingDamageCycle(damageAmount));
        continueCoroutine = false;
        Debug.Log("taking" + damageAmount + " damage stopped");
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
            hpScript.DamageTaken(dealingdamage);
            yield return new WaitForSecondsRealtime(1f);
        }
        
        
    }
    
}
