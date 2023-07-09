using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class ScoreCounter : MonoBehaviour
{

    [SerializeField] private TMP_Text totalFruitCollectedText;
    [SerializeField] private TMP_Text livesCollectedText;
    [SerializeField] private TMP_Text completionBonusText;
    [SerializeField] private TMP_Text totalScoreText;
    [SerializeField] private TMP_Text highScoreText;
    [SerializeField] private TMP_Text timeBonusText;
    [SerializeField] private TMP_Text newScoreText;
    [SerializeField] AudioSource newHighScoreAudio;

    private float collectibleBonusValue;
    private float livesBonusValue;
    private float completionBonusValue;
    private float totalScoreValue;
    private float timeBonusValue;

  public static ScoreCounter scoreCounter;
    void Start()
    {
        scoreCounter = this;
    }

    public void ResetScore()
    {
        collectibleBonusValue = 0;
        totalFruitCollectedText.text = collectibleBonusValue.ToString();
        livesBonusValue = 0;
        livesCollectedText.text = livesBonusValue.ToString();
        completionBonusValue = 0;
        completionBonusText.text = completionBonusValue.ToString();
        totalScoreValue = 0;
        totalScoreText.text = totalScoreValue.ToString();
    }
    void Update()
    {

        CollectibleBonusCounter();
        CountLivesBonus();
        CompletionBonusCheck();
        TimeBonusCounter();
        TotalScoreCounter();
        SaveHighScore();
        CheckForScoreReset();   
        
    }
    void CollectibleBonusCounter()
    {
        //Counts all the collected collectibles and times it by 25 to get the bonus
        collectibleBonusValue = ScoreData.scoreData.totalFruitCollected * 5;
        totalFruitCollectedText.text = collectibleBonusValue.ToString();
    }

    void CountLivesBonus()
    {
        //Counts all the extra lives and times them by 100
        livesBonusValue = ScoreData.scoreData.livesCollected * 100;
        livesCollectedText.text = livesBonusValue.ToString();
    }

    void CompletionBonusCheck()
    {
        //Gives an extra 1000 completion bonus if the level was passed successfully
        if (ScoreData.scoreData.completed == true)
        {
            completionBonusValue = 1000;
            completionBonusText.text = completionBonusValue.ToString();
        }
        else if (ScoreData.scoreData.completed == false)
        {
            completionBonusValue = 0;
        }
    }

    void TimeBonusCounter()
    {
        //Takes the time that player had left on the timer and times it by 10 to get the additional score
        if (ScoreData.scoreData.completed == true)
        {
            timeBonusValue = Counter.counter.counterValue * 5;
            timeBonusText.text = timeBonusValue.ToString("F0");
        }
        else
        {
            timeBonusValue = 0;
        }
        
    }

    void TotalScoreCounter()
    {
        //Counts all the tracked values into a total score 
        totalScoreValue = collectibleBonusValue + livesBonusValue + completionBonusValue + timeBonusValue;
        totalScoreText.text = totalScoreValue.ToString("F0");
    }

    void SaveHighScore()
    {
        //Checks if totalscore is higher then current high score if so it gets replaced
        if (GameManager.manager.highScore < totalScoreValue)
        {
            newHighScoreAudio.Play();
            newScoreText.gameObject.SetActive(true);
            GameManager.manager.highScore = totalScoreValue;
            GameManager.manager.SaveHighScore();
        }

        highScoreText.text = ((int)GameManager.manager.highScore).ToString();
    }

    void CheckForScoreReset()
    {
        //Resets the resetscore bool 
        if (MainMenu.mainMenu.resetScore == true)
        {
            newScoreText.gameObject.SetActive(false);
            MainMenu.mainMenu.resetScore = false;
        }
    }
}
