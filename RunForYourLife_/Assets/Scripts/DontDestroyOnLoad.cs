using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    static DontDestroyOnLoad music;
    // Start is called before the first frame update
    void Start()
    {
        if (music == null)
        {

            DontDestroyOnLoad(gameObject);
            music = this;
        }
        else
        {

            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
