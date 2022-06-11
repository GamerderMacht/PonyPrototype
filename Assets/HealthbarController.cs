using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthbarController : MonoBehaviour
{
    public GameObject healthBar;
    public UnitHPSkript HPSkript;
    public Slider slider;

    private float maxHp;
    private float hp;


    void Start()
    {
        healthBar.SetActive(false);
        slider.value = SliderValue();
    }

    void Update()
    {
        hp = HPSkript.currentHealth;
        maxHp = HPSkript.maxHealth;
        slider.value = SliderValue();

        
        if (HPSkript.currentHealth < HPSkript.maxHealth)
        {
            healthBar.SetActive(true);
        }       
    }

    float SliderValue()
    {
        return hp / maxHp;
    }
}
