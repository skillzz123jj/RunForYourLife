using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource runningSound;
    public PlayerMovement playerMovementScript;
    // Start is called before the first frame update
    void Start()
    {
        playerMovementScript.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
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
