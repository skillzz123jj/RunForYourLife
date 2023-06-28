using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{

    [SerializeField] GameObject checkPoint1;
    [SerializeField] GameObject checkPoint2;
    [SerializeField] GameObject enemySpawnPoint;
    public bool checkPoint1Hit;
    public Vector3 spawnPoint;
    public Vector3 enemySpawnPointVector;
    public Rock rockScript;
    public PlayerMovement playerMovementScript;
    public bool gameStarted;

    private void Start()
    {
        //rockScript.GetComponent<Rock>();
        playerMovementScript.GetComponent<PlayerMovement>();

        spawnPoint = gameObject.transform.position;
        
    }

    private void Update()
    {
         
        if (transform.position.y < -2)
        {
             
            playerMovementScript.PlayerDeath();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CheckPoint2"))
        {
            
            print("new checkpoint");
            checkPoint1Hit = true;
            enemySpawnPointVector = enemySpawnPoint.transform.position;
            spawnPoint = other.transform.position;  

        }
        if (other.CompareTag("StartGame"))
        {
            gameStarted= true;
        }
    }

     public void Respawn()
    {
        transform.position = spawnPoint;
      
    }
}

