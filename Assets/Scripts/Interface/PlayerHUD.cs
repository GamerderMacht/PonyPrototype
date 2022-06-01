using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHUD : MonoBehaviour
{
    [SerializeField] Slider slider = null;
    public GameObject handle;
    [SerializeField] Sprite daySprite;
    [SerializeField] Sprite nightSprite;
    [SerializeField] DayNightManagement dayNightManagement;

    
   void Start()
   {
       
   }

    void Update()
    {
        if(slider.value > 17f)
        {
            handle.GetComponent<Image>().sprite = nightSprite;
        }
        else
        {
            handle.GetComponent<Image>().sprite = daySprite;
        }
        slider.value = dayNightManagement.TimeOfDay;


        
    }

    
}
