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
    private InputAction movementAction;
    private InputAction jumpAction;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        movementAction = new InputAction();
        movementAction.AddBinding("<Gamepad>/leftStick");
        movementAction.Enable();
        movementAction.performed += Move;


        jumpAction = new InputAction();
        jumpAction.AddBinding("<Keyboard>/space");
        jumpAction.AddBinding("<Gamepad>/buttonSouth");
        jumpAction.Enable();
        jumpAction.started += Jump;

        rb.drag = 5f; // Adjust this value to control the linear drag
        rb.angularDrag = 5f;


    }

    void Move(InputAction.CallbackContext context)
    {
        Vector2 movementVector = context.ReadValue<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }
    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void FixedUpdate()
    {
        //Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        //rb.AddForce(movement * speed);


        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * speed;
        rb.AddForce(movement, ForceMode.Acceleration);

       


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



