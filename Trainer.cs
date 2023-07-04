using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Trainer : MonoBehaviour                                    
{
    public GameObject targetPrefab;                                             //The target is defined as a game object and is used as a prefab
    public static Trainer instance;                                             //instance is a way of achieving access without instantiation - other scripts can use this instance
    public static bool gameOver;                                                //gameOver bool is defined
    public static int targetsHit = 1, targetsMissed = 1, accuracy;              //targetsHit and targetsMissed are defined as integers with the value "1". accuracy is defined as an integer
    public Slider AccuracySlider;                                               //AccuracySlider is defined as a UI feature (Slider)

    public TextMeshProUGUI targetsHitlbl, targetsMissedlbl, accuracylbl;        //TextMeshPro is used as the canvas text as it is 3D

    private void Start()
    {
        SpawnTargets();          //Targets are spawned straight away - no play button
        gameOver = false;        //gameOver bool is set to false
        instance = this;         //instance is set to this procedure
    }


    private void Update()
    {
            int sum = targetsHit + targetsMissed;                           //new local variable is created called "sum" which is a total of targetsHit and targetsMissed - which equals to the amount of shots fired
            AccuracySlider.value = targetsHit * 100 / sum;                  //The accuracy slider will progress depending on the accuracy, which is calculated by targetsHit * 100 / sum
            targetsHitlbl.text = "Targets Hit: " + targetsHit;              //targetsHitlbl in canvas will display "Targets Hit: " and the number of targets hit
            targetsMissedlbl.text = "Targets Missed: " + targetsMissed;     //targetsMissedlbl in canvas will display "Targets Missed: " and the number of targets missed
            accuracylbl.text = "Accuracy: " + AccuracySlider.value + "%";   //accuracylbl in canvas will display "Accuracy: " and the value in the accuracy slider with a percentage symbol

            if (gameOver == true)                                           //Once the timer ends, the gameOver boolean will turn true
            {
                if (Input.GetKeyDown(KeyCode.R))                            //This will give the user the option to play again if the key R is inputted
                {
                    SceneManager.LoadScene(0);                              //The scene will reload
                    targetsHit = 1;                                         //And the scores will reset
                    targetsMissed = 1;
                  
                }
            }

    }
    
    public void SpawnTargets()                                                                  //Procedure to spawn targets
    {
        Vector3 randomSpawn = new Vector3(Random.Range(-10, 10), 5, Random.Range(-0, 20));      //Same as the 2D, random positioning in Vector3 format - game object will spawn in different places
        Instantiate(targetPrefab, randomSpawn, Quaternion.identity);                            //Quaternion will keep the game object with default values everytime it spawns
    }
}


