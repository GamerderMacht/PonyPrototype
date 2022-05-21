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
    // Start is called before the first frame update
    

    void Update()
    {
        if(slider.value > 18f || slider.value < 6f)
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
