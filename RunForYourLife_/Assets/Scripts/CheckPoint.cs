using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{

    [SerializeField] GameObject checkPoint1;
    [SerializeField] GameObject checkPoint2;
    public Vector3 spawnPoint;
    public Rock rockScript;
    public PlayerMovement playerMovementScript;

    private void Start()
    {
        rockScript.GetComponent<Rock>();
        playerMovementScript.GetComponent<PlayerMovement>();

        spawnPoint = gameObject.transform.position;
        
    }

    private void Update()
    {
        //if (playerMovementScipt.playerIsDead == true && playerMovementScipt.playerHasNoMoreLives == true)
        //{
        //    spawnPoint = checkPoint1.transform.position;
        //    gameObject.transform.position = spawnPoint;
        //}
         if (playerMovementScript.playerIsDead == true)
        {
            transform.position = spawnPoint;
        }
         if (transform.position.y < -5)
        {
            transform.position = spawnPoint;    
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CheckPoint2"))
        {
            print("new checkpoint");
            spawnPoint = other.transform.position;  //checkPoint2.transform.position;

        }
    }

     public void Respawn()
    {
        transform.position = spawnPoint;
        // Additional logic to reset other necessary components or variables.
    }





}

