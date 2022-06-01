using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ScoreScript : MonoBehaviour
{

    public TextMeshProUGUI ScoreText;

    private float timer;
    public int score;

    void Update ()
    {

        timer += Time.deltaTime;

        if (timer > 5f) 
        {

            score += 5;

            ScoreText.text = score.ToString();

            //Reset the timer to 0.
            timer = 0;
        }
    }
}