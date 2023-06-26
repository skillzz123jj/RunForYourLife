using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{

    public TMP_Text totalFruitCollectedText;
    public TMP_Text livesCollectedText;
    public TMP_Text completionBonusText;

    float collectibleBonus;
    float livesBonus;
    float completionBonus;

    
    void Start()
    {
        
    }

    
    void Update()
    {
        collectibleBonus = ScoreData.scoreData.totalFruitCollected * 25;
        totalFruitCollectedText.text = collectibleBonus.ToString();
        //print(score);

        livesBonus = ScoreData.scoreData.livesCollected * 100;
        livesCollectedText.text = livesBonus.ToString();

        if (SceneChanger.levelCompleted.completed == true)
        {
            completionBonus = 1000;
            completionBonusText.text= completionBonus.ToString();
        }
        else if (SceneChanger.levelCompleted.completed == false)
        {
            completionBonus= 0;
        }
    }
}
