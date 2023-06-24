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
    public float speed = 1;
    public float jumpForce;
    public float rotationSpeed = 5f;
    private InputAction movementAction;
    private InputAction jumpAction;
    Vector3 playerPosition;
    [SerializeField] int scene;

    public float totalFruitCollected;
    public float fruitCollected;
    public TMP_Text totalFruitCollectedText;

    public float livesCollected;
    public TMP_Text livesCollectedText;


    public bool isGrounded = false;
    public bool hasJumped;
    public bool playerHasLives = true;
    public bool playerIsDead = false;
    public bool playerHasNoMoreLives = false;

    public CheckPoint checkPointScript;

    Animator animations;

    [SerializeField] AudioSource collectibleSound;

    


    void Start()
    {
        rb = GetComponent<Rigidbody>();

        animations = GetComponent<Animator>();

        
        // jumpAction = new InputAction();
        // jumpAction.AddBinding("<Keyboard>/space");
        // jumpAction.AddBinding("<Gamepad>/buttonSouth");
        // jumpAction.Enable();
        // //jumpAction.started += Jump;

        rb.drag = 5f; 
        rb.angularDrag = 5f;


    }


public void PlayerDeath()
{
        //If player has lives they get to respawn to their latest checkpoint if not then the game restarts

       
        if (livesCollected > 0)
        {
            checkPointScript.Respawn();

        }
        else
        {
            SceneManager.LoadScene(scene);
        }
           
}


    void Update()
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
        PlayerAnimations();
     
        Jump();

        if (Input.GetKey(KeyCode.U))
        {
            //playerIsDead= true;
            PlayerDeath();
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
        if (Input.GetKey(KeyCode.Space) &&  isGrounded)
        {

            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            Debug.Log("Jump!");
            animations.SetBool("Jump", true);
            isGrounded = false;
     

        }
        else
        {
            animations.SetBool("Jump", false);
            
        }

    }

    // void Jump(InputAction.CallbackContext context)
    // {
    //     if (context.started)
    //     {
    //         if (isGrounded && !hasJumped)                    
    //         {
    //             rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    //             Debug.Log("Jump!");
    //               animations.SetBool("Jump", true);
    //             isGrounded= false;   
    //             hasJumped = true;
    //             // Add your jump code here
    //             // For example, you can apply a vertical force to a Rigidbody component
    //             // or change a bool variable to trigger a jump animation

    //         }
    //          else
    //         {
    //             animations.SetBool("Jump", false);
    //         hasJumped = false;
    //     }
    // }
           


    //     }
        
    private void OnTriggerEnter(Collider other)
    {
        // shows collected collectibles on screen and adds new lives when enough have been collected 
        if (other.CompareTag("Fruit"))
        {
            
            print("collected");
            collectibleSound.Play();
            totalFruitCollected++;
            fruitCollected++;
            totalFruitCollectedText.text = totalFruitCollected.ToString();
            if (fruitCollected > 2)
            {
                livesCollected++;
                livesCollectedText.text = livesCollected.ToString();
                fruitCollected= 0;

            }

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



