using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Counter : MonoBehaviour
{
    [SerializeField] private TMP_Text counterText;
    public float counterValue = 60;

    public static Counter counter;

    
    void Start()
    {
        if (counter == null)
        {
            DontDestroyOnLoad(gameObject);
            counter = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    
    void Update()
    {
        //Counter that counts down from the given value and stops there
        counterValue -= Time.deltaTime;
        counterText.text = counterValue.ToString("F0");

        if (counterValue < 0)
        {
            counterValue = 0;
        }

    }
}
