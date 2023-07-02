//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class FadeToBlack : MonoBehaviour
//{

//    [SerializeField] GameObject blackOutSquare;

//    public static FadeToBlack fadeToBlack;


//    // Start is called before the first frame update
//    void Start()
//    {
//        fadeToBlack = this;

//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (Input.GetKeyDown(KeyCode.A))
//        {
//            StartCoroutine(SceneTransition());
//        }
//        if (Input.GetKeyDown(KeyCode.S))
//        {
//            StartCoroutine(SceneTransition(false));
//        }
//    }

//    public IEnumerator SceneTransition (bool fadeToBlack = true, int fadeSpeed = 5)
//    {
//        Color objectColor = blackOutSquare.GetComponent<Image>().color;
//        float fadeAmount;

//        if (fadeToBlack)
//        {
//            while (blackOutSquare.GetComponent<Image>().color.a < 1)
//            {
//                fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);

//                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
//                blackOutSquare.GetComponent<Image>().color = objectColor;
//                yield return null;
//            }
//        } else
//        {
//            while (blackOutSquare.GetComponent<Image>().color.a > 0)
//            {
//                fadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime);

//                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
//                blackOutSquare.GetComponent<Image>().color = objectColor; 
//                yield return null;


//            }


//        }
//    }
//}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeToBlack : MonoBehaviour
{
    [SerializeField] GameObject blackOutSquare;

    public static FadeToBlack fadeToBlack;

    private bool fadeToBlackActive = true;

    private void Awake()
    {
        fadeToBlack = this;
    }

    private void Start()
    {
        SceneManager.activeSceneChanged += OnSceneChanged;
    }

    private void OnDestroy()
    {
        SceneManager.activeSceneChanged -= OnSceneChanged;
    }

    private void OnSceneChanged(Scene previousScene, Scene newScene)
    {
        fadeToBlackActive = true;
        StartCoroutine(SceneTransition(fadeToBlackActive));
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            fadeToBlackActive = true;
            StartCoroutine(SceneTransition(fadeToBlackActive));
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            fadeToBlackActive = false;
            StartCoroutine(SceneTransition(fadeToBlackActive));
        }
    }

    public IEnumerator SceneTransition(bool fadeToBlack = true, int fadeSpeed = 5)
    {
        Color objectColor = blackOutSquare.GetComponent<Image>().color;
        float fadeAmount;

        if (fadeToBlack)
        {
            while (blackOutSquare.GetComponent<Image>().color.a < 1)
            {
                fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                blackOutSquare.GetComponent<Image>().color = objectColor;
                yield return null;
            }
        }
        else
        {
            while (blackOutSquare.GetComponent<Image>().color.a > 0)
            {
                fadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                blackOutSquare.GetComponent<Image>().color = objectColor;
                yield return null;
            }
        }
    }
}
