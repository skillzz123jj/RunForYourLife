using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] int scene;
    [SerializeField] Animator anim;
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
        
    }

    public void StartGame()
    {
       StartCoroutine(StartGameWithDelay());
        StartCoroutine(FadeToBlack.fadeToBlack.SceneTransition());
       
    }

    private IEnumerator StartGameWithDelay()
    {
       
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene(scene);
    }

    public void RestartGame()
    {
        
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
