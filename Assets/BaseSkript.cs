using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSkript : MonoBehaviour
{
    //Level Up Mit einWohner
    //Level up mit mehr HP
    //TEsten mit 50 - 100 hp
   int baseHP = 3;
   UIEndScreen uIEndScreen;


   void OnTriggerEnter(Collider other)
   {
       if(other.tag == "Enemy")
       {
           baseHP--;
           Destroy(other.gameObject, 0.5f);
           if(baseHP <= 0)
           {
               uIEndScreen = GameObject.Find("UI").GetComponent<UIEndScreen>();
               //GameOverScreen
               uIEndScreen.GameLost();
           }
           
       }
   }

}
