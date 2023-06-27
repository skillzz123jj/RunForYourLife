using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking.PlayerConnection;

public class ScoreCounter : MonoBehaviour
{
    
    public TMP_Text totalFruitCollectedText;
    public TMP_Text livesCollectedText;
    public TMP_Text completionBonusText;
    public TMP_Text totalScoreText;
    public TMP_Text highScoreText;

    float collectibleBonus;
    float livesBonus;
    float completionBonus;
    float totalScore;

  public static ScoreCounter scoreCounter;
    void Start()
    {
      
    }

    public void ResetScore()
    {
        collectibleBonus = 0;
        totalFruitCollectedText.text = collectibleBonus.ToString();
        livesBonus = 0;
        livesCollectedText.text = livesBonus.ToString();
        completionBonus = 0;
        completionBonusText.text = completionBonus.ToString();
        totalScore = 0;
        totalScoreText.text = totalScore.ToString();
    }
    void Update()
    {
        //Counts all the collected collectibles and times it by 25 to get the bonus
        collectibleBonus = ScoreData.scoreData.totalFruitCollected * 25;
        totalFruitCollectedText.text = collectibleBonus.ToString();

        //Counts all the extra lives and times them by 100
        livesBonus = ScoreData.scoreData.livesCollected * 100;
        livesCollectedText.text = livesBonus.ToString();

        //Gives an extra 1000 completion bonus if the level was passed successfully
        if (ScoreData.scoreData.completed == true)
        {
            completionBonus = 1000;
            completionBonusText.text= completionBonus.ToString();
        }
        else if (ScoreData.scoreData.completed == false)
        {
            completionBonus= 0;
        }

        totalScore = collectibleBonus + livesBonus + completionBonus;
        totalScoreText.text = totalScore.ToString();

        if (GameManager.manager.highScore < totalScore)
        {
            GameManager.manager.highScore = totalScore;
        }
        highScoreText.text = GameManager.manager.highScore.ToString();
        //ResetScore();
    }
}
