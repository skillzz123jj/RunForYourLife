using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreData : MonoBehaviour
{
    public float totalFruitCollected;
    public float livesCollected;   
    public bool completed;

    public static ScoreData scoreData;

    void Start()
    {
        if (scoreData == null)
        {
            DontDestroyOnLoad(gameObject);
            scoreData = this;
        }
        else
        {
          
            Destroy(gameObject);
        }

    }

    void Update()
    {
        //Resets the score once player leaves the current scene
        if (MainMenu.mainMenu.resetScore == true)
        {
            ResetScoreData();
        }
        
    }

    void ResetScoreData()
    {
         totalFruitCollected = 0;
         livesCollected = 0;
         completed = false;

    }
}
