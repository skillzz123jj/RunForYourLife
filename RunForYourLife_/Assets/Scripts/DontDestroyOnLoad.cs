using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    static DontDestroyOnLoad music;

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

}
