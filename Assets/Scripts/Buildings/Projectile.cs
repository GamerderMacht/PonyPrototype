using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{   
    [Header("Generelle Attribute")]
    public GameObject target;
    public float speed = 10f;
    public int damagePerHit = 2;

    [Header("AoE Attribute")]
    public bool isAoEProjectile = false;
    public float aoERange = 5;

    UnitHPSkript hPSkript;
                                                                                             /*
                                                                                              * Enemies werden in ShootController.cs getrackt 
                                                                                              * und ueber Seek() an Projectile.cs gepassed
                                                                                              */
    public void Seek(GameObject _target)
    {
        target = _target;
    }

    void Update()
    {
        /*
         * Falls kein Target vorhanden ist, werden Projectiles zerstört
         */
                                                                                        
        if (target == null)                                        
        {
            Destroy(gameObject);
            return;
        }

        /*
         * Hier wir Richtung und Geschwindigkeit des Pj. berrechnet
         * Translate() bewegt das Pj nach vorne in Richtung direction
         * LookAt() rotiert das Pj immer Richtung target
         */

        Vector3 direction = target.transform.position - transform.position;
        float speedProFrame = speed * Time.deltaTime;
        transform.Translate(direction.normalized * speedProFrame, Space.World);
        transform.LookAt(target.transform);

        /*
         * Fuer Single Targets
         * sollte das Pj im nächsten Frame das target erreichen 
         * fuehre HitShit() aus
         */

        if(direction.magnitude <= speedProFrame && isAoEProjectile == false)
            HitShit(target);
        
        
                                                                                             /*
                                                                                              * fuer Multi target 
                                                                                              * alle collider in der AoERange werden in allCollider gespeichert
                                                                                              * 
                                                                                              */

        if (direction.magnitude <= speedProFrame && isAoEProjectile == true)
        {
            Collider[] allCollider = Physics.OverlapSphere(target.transform.position, aoERange);

            foreach (Collider collider in allCollider)
            {
                if (collider.tag == "Enemy")
                {
                    Debug.LogFormat("Gegner getroffen " + collider.gameObject.name);
                    HitShit(collider.gameObject);
                    Debug.Log(this.gameObject.name);
                }
            }

        }
    }

    void HitShit(GameObject gO)                                                 
    {
        gO.GetComponent<UnitHPSkript>().DamageTaken(damagePerHit);
        target = null;
    }


    private void OnDrawGizmos()                                                                                                                // nur zum visualisieren der range
    {
        if (isAoEProjectile == true)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, aoERange);
        }
    }
}
