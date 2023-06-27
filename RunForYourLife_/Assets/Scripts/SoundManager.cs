using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource runningSound;
    public PlayerMovement playerMovementScript;
    
    void Start()
    {
        playerMovementScript.GetComponent<PlayerMovement>();
    }

    
    void Update()
    {
        if (playerMovementScript.isGrounded == true && Input.GetAxis("Horizontal") != 0 || playerMovementScript.isGrounded == true && Input.GetAxis("Vertical") != 0)
        {
            runningSound.enabled = true;
        }
        else 
        {
            runningSound.enabled = false;
        }
    }
}
