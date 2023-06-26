using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreData : MonoBehaviour
{
    public float totalFruitCollected;
    public float livesCollected;
    //public float totalScore;

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
        
    }
}
