using System.Collections;
using System.Collections.Generic;
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


    // 	//public float speed = 6.0F;
	// private Vector3 moveDirection = Vector3.zero;
	// public GameObject player;
	// public float turnspeed=180f;
	// public float jumpSpeed = 8.0F; 
	// public float gravity = 20.0F;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // movementAction = new InputAction();
        // movementAction.AddBinding("<Gamepad>/leftStick");
        // movementAction.Enable();
        // movementAction.performed += Move;


        jumpAction = new InputAction();
        jumpAction.AddBinding("<Keyboard>/space");
        jumpAction.AddBinding("<Gamepad>/buttonSouth");
        jumpAction.Enable();
        jumpAction.started += Jump;

        rb.drag = 5f; // Adjust this value to control the linear drag
        rb.angularDrag = 5f;


    }

    // void Move(InputAction.CallbackContext context)
    // {
    //     Vector2 movementVector = context.ReadValue<Vector2>();
    //     movementX = movementVector.x;
    //     movementY = movementVector.y;
    // }
    // private void OnMove(InputValue movementValue)
    // {
    //     Vector2 movementVector = movementValue.Get<Vector2>();
    //     movementX = movementVector.x;
    //     movementY = movementVector.y;
    // }

    void Update()
    {
        //Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        //rb.AddForce(movement * speed);


        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * speed;
        rb.AddForce(movement, ForceMode.Acceleration);

         transform.Rotate(Vector3.down, horizontalInput * rotationSpeed * Time.deltaTime);
 transform.Rotate(Vector3.down, verticalInput * rotationSpeed * Time.deltaTime);
    //    CharacterController controller = GetComponent<CharacterController>();
	// 			moveDirection = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
	// 			player.transform.rotation = Quaternion.RotateTowards (player.transform.rotation, Quaternion.LookRotation (moveDirection), turnspeed * Time.deltaTime);
	// 		moveDirection.y -= gravity * Time.deltaTime;
	// 		controller.Move(moveDirection * speed * Time.deltaTime);


    }

    void Jump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            Debug.Log("Jump!");
            // Add your jump code here
            // For example, you can apply a vertical force to a Rigidbody component
            // or change a bool variable to trigger a jump animation
        }
    }
}



