using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager manager;

    public float totalFruitCollected;
    public float highScore;

    private void Awake()
    {
        if (manager == null)
        {
            DontDestroyOnLoad(gameObject);
            manager = this;
        }
        else
        {
            Destroy(gameObject);
        }

        LoadHighScore();
    }

    void Start()
    {
       

    }
    public void Update()
    {
        if (Input.GetKey(KeyCode.G))
        {
            highScore = 0;
        }
    }



    // Save the high score to PlayerPrefs
    public void SaveHighScore()
    {
        PlayerPrefs.SetFloat("HighScore", highScore);
        PlayerPrefs.Save();
    }

    // Load the high score from PlayerPrefs
    public void LoadHighScore()
    {
        highScore = PlayerPrefs.GetFloat("HighScore", 0f);
    }
}
