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
    public int list1;
    public int list2;
    public int list3;

    public List<GameObject> collectibleList1 = new List<GameObject>();
    public List<GameObject> collectibleList2 = new List<GameObject>();
    public List<GameObject> collectibleList3 = new List<GameObject>();

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
            print(list2);
           
        }
        if (Input.GetKey(KeyCode.K))
        {
            ClearList1();
        }
        //Resets the score once player leaves the current scene
        if (MainMenu.mainMenu.resetScore == true)
        {
            ResetScoreData();
        }
        
    }

    public void ClearList1()
    {
      
        list1 = collectibleList1.Count;
        totalFruitCollected -= list1;
        foreach (GameObject collectible1 in collectibleList1)
        {
            collectible1.SetActive(true);

        }
        collectibleList1.Clear();
    }

    public void ClearList2()
    {
    
        list2 = collectibleList2.Count;
        totalFruitCollected -= list2;
        foreach (GameObject collectible2 in collectibleList2)
        {
            collectible2.SetActive(true);

        }
        collectibleList2.Clear();
    }

    public void ClearList3()
    {
        
        list3 = collectibleList3.Count;
        totalFruitCollected -= list3;
        foreach (GameObject collectible3 in collectibleList3)
        {
            collectible3.SetActive(true);

        }
        collectibleList3.Clear();
    }

    void ResetScoreData()
    {
         totalFruitCollected = 0;
         livesCollected = 0;
         completed = false;

    }
}
