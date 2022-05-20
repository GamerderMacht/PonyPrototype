using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    [SerializeField] BoxCollider boxCollider;
    [SerializeField] int health;
    [SerializeField] ParticleSystem particleSystemBreak;
    [SerializeField] GameObject drop;
    bool ableToHurt = true; //Kann der SPieler die Box kapuitt machen?
    [SerializeField] float hurtTimeoutMax; //How long invicible after hit? NULL XDD

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip breakSound;
    [SerializeField] AudioClip hitSound;
    [SerializeField] FPSController fPSController;

   
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void HurtMe(int hurtPower)
    {
        if (ableToHurt)
        {
            health -= hurtPower;
            if(health <= 0)
            {
                Break();
            }
            else
            {
                if(hitSound) audioSource.PlayOneShot(hitSound);
                StartCoroutine(TempInvincible());
            }
            
        }
    }

    public void Break()
    {
        ableToHurt = false;
        if(particleSystemBreak) Instantiate(particleSystemBreak, transform.position, Quaternion.identity);
        if(breakSound) audioSource.PlayOneShot(breakSound);
        if(drop) Instantiate(drop,new Vector3(transform.position.x,transform.position.y + 0.5f, transform.position.z), Quaternion.identity);


        Destroy(gameObject);
    }

    IEnumerator TempInvincible()
    {
        ableToHurt = false;
        yield return new WaitForSeconds(hurtTimeoutMax);
        ableToHurt = true;

    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            HurtMe(1);
        }
    }
}
