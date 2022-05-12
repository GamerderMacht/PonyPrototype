using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DorfbewohnerCounter : MonoBehaviour
{
    [SerializeField] Dorfbewohner[] dorfbewohnerSkript;

    [SerializeField] TextMeshProUGUI[] dorfbewohnerCounterAnzeigeText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dorfbewohnerSkript = FindObjectsOfType<Dorfbewohner>();
        DorfbewohnerCounterHUD();

    }


    void DorfbewohnerCounterHUD()
    {
        dorfbewohnerCounterAnzeigeText[0].text = dorfbewohnerSkript.Length.ToString();
        if(dorfbewohnerCounterAnzeigeText.Length > 1) dorfbewohnerCounterAnzeigeText[1].text
         = dorfbewohnerSkript.Length.ToString();
    }
}
