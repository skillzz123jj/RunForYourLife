using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{

    public TMP_Text totalFruitCollectedText;
    //public TMP_Text livesCollectedText;
    //public TMP_Text livesCollectedText;

    float score;

    
    void Start()
    {
        
    }

    
    void Update()
    {
        score = ScoreData.scoreData.totalFruitCollected * 25;
        totalFruitCollectedText.text = score.ToString();
        print(score);
    }
}
