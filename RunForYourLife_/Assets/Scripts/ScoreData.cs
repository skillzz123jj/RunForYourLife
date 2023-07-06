using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreData : MonoBehaviour
{
    public float totalFruitCollected;
    public float livesCollected;   
    public bool completed;
    public float fruitWave2;
    public int list;

    public List<GameObject> collectibleList1 = new List<GameObject>();

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
        if (Input.GetKey(KeyCode.L))
        {
            //list = collectibleList1.Count;
            //totalFruitCollected =- list;
            print(totalFruitCollected);
           
        }
        if (Input.GetKey(KeyCode.K))
        {
            ClearTheList();
        }
        //Resets the score once player leaves the current scene
        if (MainMenu.mainMenu.resetScore == true)
        {
            ResetScoreData();
        }
        
    }

    public void ClearTheList()
    {
        //float list = collectibleList1.Count;
        //totalFruitCollected = -list;
        //PlayerMovement.playerMovement.totalFruitCollectedText.text = totalFruitCollected.ToString();
        list = collectibleList1.Count;
        totalFruitCollected -= list;
        foreach (GameObject collectible1 in collectibleList1)
        {
            collectible1.SetActive(true);

        }
        collectibleList1.Clear();
    }


    void ResetScoreData()
    {
         totalFruitCollected = 0;
         livesCollected = 0;
         completed = false;

    }
}
