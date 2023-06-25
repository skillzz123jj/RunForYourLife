//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.SceneManagement;

//public class MainMenu : MonoBehaviour
//{
//    [SerializeField] int scene;
//    [SerializeField] Animator anim;
//    // Start is called before the first frame update
//    void Start()
//    {
//        anim= GetComponent<Animator>();
//    }

//    // Update is called once per frame
//    void Update()
//    {

//    }

//    public void StartGame()
//    {


//        StartCoroutine(StartGameWithDelay());
//    }

//    private IEnumerator StartGameWithDelay()
//    {
//        anim.SetTrigger("SeaMonster");
//        yield return new WaitForSeconds(20f);
//        SceneManager.LoadScene(scene);

//    }

//}
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
        StartCoroutine(StartGameWithDelay());
    }

    private IEnumerator StartGameWithDelay()
    {
        if (anim != null)
        {
            anim.SetTrigger("SeaMonster");
        }
        else
        {
            Debug.LogError("Animator component is not assigned");
        }

        yield return new WaitForSeconds(20f);
        SceneManager.LoadScene(scene);
    }
}
