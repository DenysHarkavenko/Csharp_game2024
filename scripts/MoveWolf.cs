using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWolf : MonoBehaviour
{
    public float speed = 1.0f;
    public float sprintSpeed = 5.0f;
    public float jumpSpeed = 1.0f;
    private float currentSpeed;
    private Wolf wolf;
    private Stamina stamina;

    public CharacterController controller;

    private float verticalVelocity;
    public float gravity = 1.0f;

    public AudioManager audioManager; 

    void Start()
    {
        wolf = GetComponent<Wolf>();
        stamina = GetComponent<Stamina>();
        currentSpeed = speed;
    }

    void Update()
    {
        bool isMoving = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D);
        bool isSprinting = (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) && isMoving && !Input.GetKey(KeyCode.LeftControl) && !Input.GetKey(KeyCode.RightControl);
        bool isJumping = Input.GetKeyDown(KeyCode.Space) && controller.isGrounded;
        bool isSitting = Input.GetKeyDown(KeyCode.LeftControl);
    
        if (isSprinting && stamina.currentStamina > 0)
        {
            currentSpeed = sprintSpeed;
            stamina.DrainStamina(stamina.staminaDrainRate);
            audioManager.StartRunningSound(); 
        }
        else
        {
            currentSpeed = speed;
            if (audioManager.runningAudioSource.isPlaying) 
            {
                audioManager.StopRunningSound(); 
            }
        }
    
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        movement = transform.TransformDirection(movement);
        movement *= currentSpeed * Time.deltaTime;
    
        if (isJumping && stamina.currentStamina > 0)
        {
            verticalVelocity = jumpSpeed;
            stamina.DrainStamina(stamina.staminaDrainRate);
        }
        else if (controller.isGrounded)
        {
            verticalVelocity = 0;
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }

        movement.y = verticalVelocity;
    
        controller.Move(movement);
    
        if (!isMoving || !isSprinting)
        {
            stamina.RegenStamina(stamina.staminaRegenRate);
        }
    
        if (isSitting)
        {
            isSprinting = false;
        }
    }
}