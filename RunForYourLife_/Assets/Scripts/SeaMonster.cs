using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SeaMonster : MonoBehaviour
{
        public float speed;
    float stop = 0;
    [SerializeField] GameObject playerMovement;
    public CheckPoint checkPointScript;
    public PlayerMovement playerMovementScript;
    
    void Start()
    {
        checkPointScript.GetComponent<CheckPoint>();
    }

    
    void Update()
    {
        AllowedToMove();
        TakeABreak();
        //transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
          
            print("We dead");
            checkPointScript.Respawn();
            
        }
        
    }
    void AllowedToMove()
    {
        if (checkPointScript.gameStarted == true)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            
        }
    }

    void TakeABreak()
    {
        if (checkPointScript.checkPoint1Hit == true) 
        {
            transform.Translate(Vector2.right * stop * Time.deltaTime);
            checkPointScript.gameStarted = false;

        }
    }
}
