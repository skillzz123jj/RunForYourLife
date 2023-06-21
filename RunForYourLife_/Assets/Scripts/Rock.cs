using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
        public float speed;
    [SerializeField] GameObject playerMovement;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerMovement.GetComponent<PlayerMovement>().enabled = false;
            
        }
        
    }

}
