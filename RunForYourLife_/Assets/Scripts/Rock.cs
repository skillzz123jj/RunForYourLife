using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
        public float speed;
    [SerializeField] GameObject playerMovement;
    //public bool playerIsDead = false;
    public CheckPoint checkPointScript;
    public PlayerMovement playerMovementScript;
    
    void Start()
    {
        checkPointScript.GetComponent<CheckPoint>();
    }

    
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //playerMovement.GetComponent<PlayerMovement>().enabled = false;
            playerMovementScript.playerIsDead= true;
            print("We dead");
            
        }
        
    }

}
