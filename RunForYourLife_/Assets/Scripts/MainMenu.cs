using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] int scene;
    private Animator anim;
    public bool resetScore;

    [SerializeField] GameObject water;
    [SerializeField] GameObject lava;
    [SerializeField] GameObject mainScreen;
    [SerializeField] GameObject hardModeScreen;

    public static MainMenu mainMenu;
    private void Awake()
    {
        if (mainMenu == null)
        {
            mainMenu = this; 
        }
        else
        {
            Destroy(gameObject); 
        }
    }
    void Start()
    {
        GameObject objWithAnimator = GameObject.FindWithTag("SeaMonster");
        if (objWithAnimator != null)
        {
            anim = objWithAnimator.GetComponent<Animator>();
        }
        else
        {
            Debug.LogError("Could not find object with tag 'ObjectWithTag'");
        }
    }

    public void StartGame()
    {
        //StartCoroutine(StartGameWithDelay());
        SceneManager.LoadScene(scene);
    }

    //private IEnumerator StartGameWithDelay()
    //{
    //    if (anim != null)
    //    {
    //        anim.SetTrigger("SeaMonster");
    //    }
      
    //    yield return new WaitForSeconds(20f);
    //    SceneManager.LoadScene(scene);
    //}

    public void RestartGame()
    {
        //ScoreCounter.scoreCounter.ResetScore();
        resetScore= true;
       SceneManager.LoadScene(1);
    }
    public void BackToMenu()
    {
        resetScore = true;
        SceneManager.LoadScene(0);
    }

    public void HardMode()
    {
        mainScreen.SetActive(false);
        water.SetActive(false);
        hardModeScreen.SetActive(true);
        lava.SetActive(true);
    }

    public void NormalMode()
    {
        mainScreen.SetActive(true);
        water.SetActive(true);
        hardModeScreen.SetActive(false);
        lava.SetActive(false);
    }

    public void StartHardModeGame() 
    {
        SceneManager.LoadScene("Scene2");
    
    }
}
