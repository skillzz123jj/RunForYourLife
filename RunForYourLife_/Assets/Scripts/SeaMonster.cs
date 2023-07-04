using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SeaMonster : MonoBehaviour
{
        public float speed;
    //float stop = 0;
    [SerializeField] GameObject playerMovement;
    [SerializeField] Vector3 enemySpawnPosition;
    [SerializeField] GameObject checkPoint2SpawnPositionEnemy;
    [SerializeField] GameObject checkPoint3SpawnPositionEnemy;
    public CheckPoint checkPointScript;
    public PlayerMovement playerMovementScript;
    public Collider enemyCollider;

    public static SeaMonster seaMonster;
    
    void Start()
    {
        checkPointScript.GetComponent<CheckPoint>();
        playerMovementScript.GetComponent<PlayerMovement>();
        //enemyCollider = gameObject.GetComponent<Collider>();
        enemySpawnPosition = gameObject.transform.position;
       
    }

    
    void Update()
    {
        if (checkPointScript.moveEnemy == true)
        {
            AllowedToMove();
            
        }
       
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        if (checkPointScript.checkPoint2Hit == true)
        {
            enemySpawnPosition = checkPoint2SpawnPositionEnemy.transform.position; 
            transform.position = enemySpawnPosition;
            Pause();
            checkPointScript.checkPoint2Hit = false;

        }
        if (checkPointScript.checkPoint3Hit == true)
        {
            enemySpawnPosition = checkPoint3SpawnPositionEnemy.transform.position;
            transform.position = enemySpawnPosition;
            Pause();
            checkPointScript.checkPoint3Hit = false;

        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || checkPointScript.playerFell == true)
        {
            gameObject.transform.position = enemySpawnPosition;
            Pause();
            playerMovementScript.PlayerDeath();
            checkPointScript.playerFell = false;
            
        }
        
        
    }
    public void AllowedToMove()
    {
                
        speed = 5;    
        checkPointScript.moveEnemy = true;
        //enemyCollider.isTrigger = true;
        
    }

 

    public void Pause()
    {

        speed = 0;
        checkPointScript.moveEnemy = false;
        //enemyCollider.isTrigger = false;
        
    }

}
