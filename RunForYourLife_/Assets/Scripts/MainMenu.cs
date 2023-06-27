using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] int scene;
    private Animator anim;

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
        SceneManager.LoadScene(1);
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
