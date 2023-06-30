using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{

    [SerializeField] GameObject checkPoint1;
    [SerializeField] GameObject checkPoint2;
    [SerializeField] GameObject enemySpawnPoint;
    public Vector3 spawnPoint;
    public Vector3 enemySpawnPointVector;
    public PlayerMovement playerMovementScript;
    public bool checkPoint1Hit;
    public bool gameStarted;

    private void Start()
    {
       
       playerMovementScript.GetComponent<PlayerMovement>();

        spawnPoint = gameObject.transform.position;
        
    }

    private void Update()
    {
        //Player dies if they fall off the map
         
        if (transform.position.y < -2)
        {
             
            playerMovementScript.PlayerDeath();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CheckPoint2"))
        {
            //Triggers a new checkpoint
            print("new checkpoint");
            checkPoint1Hit = true;
            enemySpawnPointVector = enemySpawnPoint.transform.position;
            spawnPoint = other.transform.position;  

        }
        if (other.CompareTag("StartGame"))
        {
            //Checks the bool so enemy starts moving
            gameStarted= true;
        }
    }

     public void Respawn()
    {
        transform.position = spawnPoint;
      
    }
}

