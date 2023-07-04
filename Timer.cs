using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerlbl;        //TMP is used for timerlbl in canvas
    public float timer = 60f;               //The game will last 60 seconds

    private void Update()   
    {
        if (timer > 0)                      //If timer is greater than 0
        {
            timer -= Time.deltaTime;        //keep decreasing time
            DisplayTime(timer);             //Display timer as timerlbl

        }
        else
        {
            Trainer.gameOver = true;                                //Else set bool gameOver to true
            timerlbl.text = "Game Over. Press R to play again";     //changing the text within timerlbl to "Game Over. Press R to play again"
        }

    }

    private void DisplayTime(float displayTime)                 
    {
        float minutes = Mathf.FloorToInt(displayTime / 60);     //Show minutes
        float seconds = Mathf.FloorToInt(displayTime % 60);     //Show seconds
        timerlbl.text = $"{minutes}:{seconds}";                 //Display in the format 00:00 where minutes:seconds

    }
}
