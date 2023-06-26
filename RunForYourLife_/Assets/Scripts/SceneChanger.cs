using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public static SceneChanger levelCompleted;
    public bool completed = false;

    static SceneChanger instance;

    void Start()
    {
        if (instance == null)
        {

            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {

            Destroy(gameObject);
        }
    }

    
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            completed = true;
            SceneManager.LoadScene(2);
        }
    }
}
