using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerInventory : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI[] goldAmountText;
    [SerializeField] TextMeshProUGUI[] techAmountText;
    [SerializeField] TextMeshProUGUI[] citizenAmountText;

    public int currentGoldAmount;
    public int currentTechAmount;
    public int currentCitizenAmount;
    public int maxCitizenAmount;
    // Start is called before the first frame update
    void Start()
    {
        UpdateGoldAndTechAmount();
        maxCitizenAmount = (GameObject.Find("PlayerBase").GetComponent<LevelUpSkript>().currentLevel + 1) * 5;
        currentCitizenAmount = maxCitizenAmount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void LateUpdate()
    {
        UpdateGoldAndTechAmount();
    }


    public void AddGoldToInventory(int goldAmount)
    {
        currentGoldAmount += goldAmount;


        goldAmountText[0].text = currentGoldAmount.ToString();
        if(goldAmountText.Length > 1) goldAmountText[1].text = currentGoldAmount.ToString();
    }

    public void AddTechToInventory(int techAmount)
    {
        currentTechAmount += techAmount;


        techAmountText[0].text = currentTechAmount.ToString();
        if(techAmountText.Length > 1) techAmountText[1].text = currentTechAmount.ToString();
    }
    public void AddCitizenToInventory(int citizenAmount)
    {
        currentTechAmount += citizenAmount;


        techAmountText[0].text = citizenAmount.ToString();
        if(citizenAmountText.Length > 1) citizenAmountText[1].text = currentCitizenAmount.ToString();
    }

    void UpdateGoldAndTechAmount()
    {
        goldAmountText[0].text = currentGoldAmount.ToString();
        if(goldAmountText.Length > 1) goldAmountText[1].text = currentGoldAmount.ToString();

        techAmountText[0].text = currentTechAmount.ToString();
        if(techAmountText.Length > 1) techAmountText[1].text = currentTechAmount.ToString();

        citizenAmountText[0].text = (currentCitizenAmount).ToString()+ " / " + maxCitizenAmount.ToString();
        if(citizenAmountText.Length > 1) citizenAmountText[1].text = currentCitizenAmount.ToString();

    }
}
