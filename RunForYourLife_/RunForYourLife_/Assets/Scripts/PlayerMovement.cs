using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float rotationSpeed = 5f;
    private InputAction movementAction;
    private InputAction jumpAction;
    private Vector3 playerPosition;
    [SerializeField] private int scene;

    
    public float fruitCollected;
    public TMP_Text totalFruitCollectedText;
    [SerializeField] private TMP_Text livesCollectedText;


    public bool isGrounded = false;
    public bool playerHasLives = true;
    public bool playerIsDead = false;
    public bool playerHasNoMoreLives = false;

    public CheckPoint checkPointScript;
    [SerializeField] AudioSource collectibleSound;


    public static PlayerMovement playerMovement;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.drag = 5f;
        rb.angularDrag = 5f; //Helps rotate player more smoothly

       
    }

public void PlayerDeath()
{
        //If player has lives they get to respawn to their latest checkpoint if not then the game restarts

       
        if (ScoreData.scoreData.livesCollected > 0)
        {
            ScoreData.scoreData.livesCollected--;
            livesCollectedText.text = ScoreData.scoreData.livesCollected.ToString();
            checkPointScript.Respawn();
            if (checkPointScript.checkPoint1Hit == true)
            {
                ScoreData.scoreData.ClearList1();
            }           
            else if (checkPointScript.checkPoint2Hit == true)
            {
                ScoreData.scoreData.ClearList2();
            }
            else if (checkPointScript.checkPoint3Hit == true)
            {
                print("clear list 3");
                ScoreData.scoreData.ClearList3();
            }
            totalFruitCollectedText.text = ScoreData.scoreData.totalFruitCollected.ToString();

        }
        else
        {
            SceneManager.LoadScene(2);
            StartCoroutine(FadeToBlack.fadeToBlack.SceneTransition());
        }
           
}

    void FixedUpdate()
    {
        PlayerInput(); 
        Jump();
        UpdateLives();
        
    }
    
    private void PlayerInput()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        movementDirection.Normalize();

        transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);

        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }


    void Jump()
    {
        if (Input.GetKey(KeyCode.Space) && isGrounded || Input.GetKeyDown(KeyCode.JoystickButton1) && isGrounded)
        {

            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);          
            isGrounded = false;
     
        }
    

    }

    
    private void OnTriggerEnter(Collider other)
    {
        // shows collected collectibles on screen and adds new lives when enough have been collected 
        if (other.CompareTag("Fruit"))
        {
            GameObject fruit = other.gameObject;
         
            collectibleSound.Play();
            ScoreData.scoreData.totalFruitCollected++;
            fruitCollected++;
            ScoreData.scoreData.collectibleList1.Add(fruit);
            totalFruitCollectedText.text = ScoreData.scoreData.totalFruitCollected.ToString();
        
        }


        else if (other.CompareTag("Fruit2"))
        {
            GameObject fruit2 = other.gameObject;
           
            collectibleSound.Play();
            ScoreData.scoreData.totalFruitCollected++;
            fruitCollected++;
            ScoreData.scoreData.collectibleList2.Add(fruit2);
            totalFruitCollectedText.text = ScoreData.scoreData.totalFruitCollected.ToString();
          
        }

        else if (other.CompareTag("Fruit3"))
        {
            GameObject fruit3 = other.gameObject;
           
            collectibleSound.Play();
            ScoreData.scoreData.totalFruitCollected++;
            fruitCollected++;
            ScoreData.scoreData.collectibleList3.Add(fruit3);
            totalFruitCollectedText.text = ScoreData.scoreData.totalFruitCollected.ToString();
          
        }

            //Finishes the level and gives player a completion bonus
            if (other.CompareTag("Finish"))
        {
            StartCoroutine(FinishGameWithDelay());
            ScoreData.scoreData.completed = true;
            StartCoroutine(FadeToBlack.fadeToBlack.SceneTransition());         

        }

    }

    private void UpdateLives()
    {
        if (fruitCollected > 5)
        {
            ScoreData.scoreData.livesCollected++;
            livesCollectedText.text = ScoreData.scoreData.livesCollected.ToString();
            fruitCollected = 0;

        }

    }
    private IEnumerator FinishGameWithDelay()
    {
        //A slight delay when enterin a new scene so screen has time to go black

        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(2);
    }

    public void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.tag == "Ground")
        {
            isGrounded = true;

        }
       
    }
    
}



