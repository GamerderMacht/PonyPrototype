using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerInventory : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI[] goldAmountText;
    [SerializeField] TextMeshProUGUI[] techAmountText;

    public int currentGoldAmount;
    public int currentTechAmount;
    // Start is called before the first frame update
    void Start()
    {
        UpdateGoldAndTechAmount();
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

    void UpdateGoldAndTechAmount()
    {
        goldAmountText[0].text = currentGoldAmount.ToString();
        if(goldAmountText.Length > 1) goldAmountText[1].text = currentGoldAmount.ToString();
        techAmountText[0].text = currentTechAmount.ToString();
        if(techAmountText.Length > 1) techAmountText[1].text = currentTechAmount.ToString();
    }
}
