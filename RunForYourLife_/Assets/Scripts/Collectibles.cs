using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
   

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
         
            Destroy(gameObject);

        }
        
    }
   
}
