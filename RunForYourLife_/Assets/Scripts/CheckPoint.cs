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
    public SeaMonster seaMonsterSript;
    public bool checkPoint1Hit = true;
    public bool checkPoint2Hit;
    public bool checkPoint3Hit;
    public bool moveEnemy;
    public bool playerFell;
    public bool checkPoint2ForEnemy;
    public bool checkPoint3ForEnemy;

  

    private void Start()
    {
       
       playerMovementScript.GetComponent<PlayerMovement>();
        seaMonsterSript.GetComponent<SeaMonster>();

        spawnPoint = gameObject.transform.position;

        StartCoroutine(FadeToBlack.fadeToBlack.SceneTransition(false));
    }

    private void Update()
    {
        //Player dies if they fall off the map
         
        if (transform.position.y < -2)
        {
             
            playerMovementScript.PlayerDeath();
            playerFell = true;

         
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CheckPoint2"))
        {
            //Triggers a new checkpoint
            checkPoint2Hit = true;
            checkPoint2ForEnemy = true;
            print("checkpoint2");
            checkPoint1Hit = false;
            spawnPoint = other.transform.position;
            

        }
        if (other.CompareTag("CheckPoint3"))
        {
            //Triggers a new checkpoint
       
            checkPoint3Hit = true;
            checkPoint3ForEnemy = true;
            checkPoint2Hit = false;
            //checkPoint1Hit= false;
            spawnPoint = other.transform.position;

        }
        if (other.CompareTag("StartGame"))
        {
            //Checks the bool so enemy starts moving

            seaMonsterSript.AllowedToMove();
            
        }
    }

     public void Respawn()
    {
        transform.position = spawnPoint;
       
    }
}

