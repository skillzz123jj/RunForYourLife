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
    [SerializeField] private TMP_Text totalFruitCollectedText;
    [SerializeField] private TMP_Text livesCollectedText;


    public bool isGrounded = false;
    public bool playerHasLives = true;
    public bool playerIsDead = false;
    public bool playerHasNoMoreLives = false;

    public CheckPoint checkPointScript;

    Animator animations;

    [SerializeField] AudioSource collectibleSound;


    public static PlayerMovement playerMovement;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.drag = 5f;
        rb.angularDrag = 5f; //Helps rotate player more smoothly

        animations = GetComponent<Animator>();

    }


public void PlayerDeath()
{
        //If player has lives they get to respawn to their latest checkpoint if not then the game restarts

       
        if (ScoreData.scoreData.livesCollected > 0)
        {
            ScoreData.scoreData.livesCollected--;
            livesCollectedText.text = ScoreData.scoreData.livesCollected.ToString();
            checkPointScript.playerIsAlive= false;
            checkPointScript.Respawn();

        }
        else
        {
            SceneManager.LoadScene(2);
        }
           
}


    void Update()
    {

        PlayerInput();
        PlayerAnimations();    
        Jump();

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

    private void PlayerAnimations()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            animations.SetBool("Walk", true);

        }
        else
        {
            animations.SetBool("Walk", false);
        }

    }

    void Jump()
    {
        if (Input.GetKey(KeyCode.Space) && isGrounded || Input.GetKeyDown(KeyCode.JoystickButton1) && isGrounded)
        {

            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);          
            animations.SetBool("Jump", true);
            isGrounded = false;
     

        }
        else
        {
            animations.SetBool("Jump", false);
            
        }

    }

    
    private void OnTriggerEnter(Collider other)
    {
        // shows collected collectibles on screen and adds new lives when enough have been collected 
        if (other.CompareTag("Fruit"))
        {
            
            print("collected");
            collectibleSound.Play();
            ScoreData.scoreData.totalFruitCollected++;
            fruitCollected++;
            totalFruitCollectedText.text = ScoreData.scoreData.totalFruitCollected.ToString();
            if (fruitCollected > 2)
            {
                ScoreData.scoreData.livesCollected++;
                livesCollectedText.text = ScoreData.scoreData.livesCollected.ToString();
                fruitCollected= 0;

            }

        }
        //Finishes the level and gives player a completion bonus
        if (other.CompareTag("Finish"))
        {
            ScoreData.scoreData.completed = true;
            SceneManager.LoadScene(2);          

        }

    }

    public void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.tag == "Ground")
        {
            isGrounded = true;

        }
       
    }
    
}



