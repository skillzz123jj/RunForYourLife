using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

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

    public float fruitCollected;
    public TMP_Text fruitCollectedText;
    public bool isGrounded = false;
    public bool collisionHappened;


    void Start()
    {
        rb = GetComponent<Rigidbody>();

        
        jumpAction = new InputAction();
        jumpAction.AddBinding("<Keyboard>/space");
        jumpAction.AddBinding("<Gamepad>/buttonSouth");
        jumpAction.Enable();
        jumpAction.started += Jump;

        rb.drag = 5f; 
        rb.angularDrag = 5f;


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


    }

    void Jump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (isGrounded)                    
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                Debug.Log("Jump!");
                isGrounded= false;
                // Add your jump code here
                // For example, you can apply a vertical force to a Rigidbody component
                // or change a bool variable to trigger a jump animation

            }
           

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //if (collisionHappened)
        //{
        //    collisionHappened = false;
        //    return;
        //}

        if (other.CompareTag("Fruit"))
        {
            

            print("collected");
            fruitCollected++;
            fruitCollectedText.text = fruitCollected.ToString();
            collisionHappened = true;
            
            

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



