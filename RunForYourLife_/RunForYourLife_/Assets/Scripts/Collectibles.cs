using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
              
            gameObject.SetActive(false);

        }
        
    }
   
}
