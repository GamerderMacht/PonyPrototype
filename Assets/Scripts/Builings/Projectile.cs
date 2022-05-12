using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{   
    [Header("Generelle Attribute")]
    private Transform target;
    public float speed = 10f;
    public int damagePerHit = 2;

    [Header("AoE Attribute")]
    public bool isAoEProjectile = false;
    public float aoERange = 5;


    bool hit = false;

    UnitHPSkript hPSkript;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    void Update()
    {
        if (target == null)                                        
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = target.position - transform.position;
        float speedProFrame = speed * Time.deltaTime;

        transform.Translate(direction.normalized * speedProFrame, Space.World);
        transform.LookAt(target);

        if(direction.magnitude <= speedProFrame && isAoEProjectile == false)
        {
            Debug.Log(target.gameObject.name);
            HitShit(target.gameObject);
        }

        else if (direction.magnitude <= speedProFrame && isAoEProjectile == true)
        {
            Collider[] allCollider = Physics.OverlapSphere(target.transform.position, aoERange);
            Debug.Log(allCollider);

            foreach (Collider collider in allCollider)
            {
                if (collider.tag == "Enemy" && !hit)
                {
                    Debug.LogFormat("Gegner getroffen " + collider.gameObject.name);
                    HitShit(collider.gameObject);
                    hit = true;
                }
            }
        }
    }

    void HitShit(GameObject gO)
    {
        gO.GetComponent<UnitHPSkript>().DamageTaken(damagePerHit); 
        Debug.LogFormat("Hit " + gO.name + gO.GetComponent<UnitHPSkript>().currentHealth);
        GameObject.Destroy(this.gameObject);
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
