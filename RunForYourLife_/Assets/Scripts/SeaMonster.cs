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
    public CheckPoint checkPointScript;
    public PlayerMovement playerMovementScript;

    public static SeaMonster seaMonster;
    
    void Start()
    {
        checkPointScript.GetComponent<CheckPoint>();
        playerMovementScript.GetComponent<PlayerMovement>();
        enemySpawnPosition = gameObject.transform.position;
       
    }

    
    void Update()
    {
        if (checkPointScript.moveEnemy == true)
        {
            AllowedToMove();
            
        }
       
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        if (checkPointScript.checkPoint1Hit == true)
        {
            enemySpawnPosition = checkPoint2SpawnPositionEnemy.transform.position;
            gameObject.transform.position = enemySpawnPosition;
            
        }
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.transform.position = enemySpawnPosition;
            Pause();
            playerMovementScript.PlayerDeath();
            
        }
        
        
    }
    public void AllowedToMove()
    {
                
         speed = 5;          
        
    }

 

    public void Pause()
    {

        speed = 0;
        //checkPointScript.moveEnemy = false;
        
    }

}
