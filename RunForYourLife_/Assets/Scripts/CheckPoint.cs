using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{

    [SerializeField] GameObject checkPoint1;
    [SerializeField] GameObject checkPoint2;
    public Vector3 spawnPoint;
    public Rock rockScript;
    public PlayerMovement playerMovementScipt;

    private void Start()
    {
        rockScript.GetComponent<Rock>();
        playerMovementScipt.GetComponent<PlayerMovement>();

        spawnPoint = gameObject.transform.position;
        
    }

    private void Update()
    {
        //if (playerMovementScipt.playerIsDead == true && playerMovementScipt.playerHasNoMoreLives == true)
        //{
        //    spawnPoint = checkPoint1.transform.position;
        //    gameObject.transform.position = spawnPoint;
        //}
         if (playerMovementScipt.playerIsDead == true)
        {
            gameObject.transform.position = spawnPoint;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CheckPoint2"))
        {
            print("new checkpoint");
            spawnPoint = checkPoint2.transform.position;
            
        }
    }





}

