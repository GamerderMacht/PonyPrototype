using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
public float maxHealth;
    public float currentHealth;

    
    [SerializeField] bool CR_running = false;
    public int regenerationValue;
    
    
    [SerializeField] Image imageBlutAlpha;
    [SerializeField] float percentage;
    
    void Start()
    {
        
        currentHealth = maxHealth;
        
        
        
    }
    // Update is called once per frame
    void Update()
    {
        //Player Healing--------
        percentage = 1- (currentHealth / maxHealth);
        if(currentHealth != maxHealth && !CR_running)
        {
            PlayerRegeneration();
        }
        //--------------------
    }

    public void DamageTaken(int damageAmount)
    {
        currentHealth -= damageAmount;
        Debug.Log (damageAmount + " damage taken!");
        StartCoroutine(CantRegenerate());
        

        if(gameObject.tag == "Player" && currentHealth !> 0)
        {
            
            DamageTakenImageMethod(0.2f);

            //play Player Hurt sound;
            //play Player Hurt animation;


        }
        if (gameObject.tag != "Player" && currentHealth <= 0)
        {
            //Gegner sind dann Tod
            Debug.Log("Tod");
            Destroy(gameObject, 0.5f);
        }
        if(currentHealth <= 0)
        {
            //Spieler /Objekt stirbt

            Debug.Log("Spieler Tod");


            //Spieler Tod Animation
            //Scoreboard - Wie viel man geschafft hat?
            //HUD Overlay starten mit Score - Buttons

        }
        
    
    }

    private void DamageTakenImageMethod(float value)
    {
        //wir wollten ja visuell Damage anzeigen lassen statt HP Bar -> Roter Screen
        //Suchen das PlayerHUD, nehmen von da das Image für PlayerDamageTaken
        if(imageBlutAlpha){ 
            imageBlutAlpha = GameObject.FindGameObjectWithTag("PlayerHUD").transform.Find("PlayerDamageTakenImage").gameObject.GetComponent<Image>();
            //Color wert ändern und dann wieder ausgeben
            var imageAlpha = imageBlutAlpha.color;
            imageAlpha.a = percentage;
            imageBlutAlpha.color = imageAlpha;
        }
        //Debug.Log(imageAlpha.a);
    }

    void PlayerRegeneration()
    {
        if(CR_running == false)
        

        if(currentHealth < maxHealth)
        {
            currentHealth += regenerationValue * Time.deltaTime;
            
            DamageTakenImageMethod(-percentage);
        }
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        /*
        isPassiveHealing = true;
        while (currentHealth < maxHealth)
        {
            Debug.Log("Is Healing");
            currentHealth++;
            DamageTakenImageMethod(-0.2f);
        }

        yield return new WaitForSeconds(5);

        isPassiveHealing = false;
        */
        
    }
    IEnumerator CantRegenerate()
        {
            CR_running = true;
            yield return new WaitForSeconds(5);
            CR_running = false;
        }
}
