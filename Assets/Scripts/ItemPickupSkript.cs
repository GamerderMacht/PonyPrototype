using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickupSkript : MonoBehaviour
{
    PlayerInventory playerInventory;
    
    public int goldWorth;
    public int techWorth;

    [SerializeField] bool zufälligerGoldWert;
    [SerializeField] bool zufälligerTechWert;
    public int ZufälligkeitsBonusWert;

    [Header("PickUp Zusatz")]
    [SerializeField] AudioClip pickUpSound;
                    AudioSource audioSource;
    [SerializeField] ParticleSystem pickUpParticle;
    
    
    void OnTriggerEnter(Collider other)
    {
        PickUpTheItem(other);
    }

    private void PickUpTheItem(Collider other)
    {
        if (other.tag == "Player")
        {
            playerInventory = other.GetComponent<PlayerInventory>();

            //Falls du Pisser es zufällig willst, oder falls du es zufällig willst aber du dein Wert auf 0 hattest
            if(zufälligerGoldWert || zufälligerTechWert)
            {
                if(goldWorth != 0)
                {
                    goldWorth = goldWorth + (int)Random.Range(goldWorth, goldWorth + ZufälligkeitsBonusWert);
                }
                if(techWorth != 0)
                {
                    techWorth = techWorth + (int)Random.Range(techWorth, techWorth + ZufälligkeitsBonusWert);
                }
                else
                {
                    if(zufälligerGoldWert) goldWorth = (int)Random.Range(0,50);
                    if(zufälligerTechWert) techWorth = (int)Random.Range(0,50);
                }
            }

            //Add to player inv
            playerInventory.AddGoldToInventory(goldWorth);
            playerInventory.AddTechToInventory(techWorth);
            

            //play Audio
            audioSource = other.GetComponent<AudioSource>();
            if (pickUpSound) audioSource.PlayOneShot(pickUpSound);

            //PickUpEffekt?
            if (pickUpParticle) pickUpParticle.Play();
            Destroy(pickUpParticle, 2f);
            //Destroy the Item
            Destroy(gameObject);
        }
    }
}
