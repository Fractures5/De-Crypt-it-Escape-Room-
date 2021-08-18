using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{    
    //Sets the player movement speed in the ground and air
    [Header("Movement")]
    public float playerSpeed = 0.1f;
    public float speedMultiplier = 0.1f;
    [SerializeField] float airMultiplier = 0.4f;

    //Keyinput for player to jump
    [Header("Keyinput")]
    [SerializeField] KeyCode jump = KeyCode.Space;

    //Sets the jump power of the player
    [Header("Jumppower")]
    public float jumpPower = 0.2f;

    //Sets the player drag in the ground and air
    [Header("Drag")]
    public float groundDrag = 1f;
    public float airDrag = 0.5f;

    //Vector 3 to store movement direction
    Vector3 playerDirection;

    //Rigid body to act as a player model
    Rigidbody rb;

    //this is for jumping sound effect
    AudioSource jumpingSound;

    //Variables for horizontal and vertical movement
    float horizontalMovement;
    float verticalMovement;

    //Variable to check if the player model is in the ground
    bool isGrounded;

    //Capsule collider acts as a collider model
    CapsuleCollider playerCol;
    //Sets the player model height
    float playerHeight = 2f;
    //Sets the crouching height
    float crouchingHeight = 0.75f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        

        playerCol = GetComponentInChildren<CapsuleCollider>();
        //Original height and collision is maintaned since player is not crouching
        playerHeight = playerCol.height;
        //getting audiosource clip
        jumpingSound = GetComponent<AudioSource>();
    }

    private void Update()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight / 1 + 0.1f);

        MyInput();
        ControlDrag();

        if (Input.GetKeyDown(jump) && isGrounded)
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Crouch();
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            Stand();
        }
    }

    //Get horizontal and vertical movement by checking if input is 'A' or 'D' key
    void MyInput()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");
        
        //Movement direction
        playerDirection = (transform.forward * verticalMovement + transform.right * horizontalMovement) / 2;
    }
    
    //A function to change the player drag by checking if model is at the ground
    void ControlDrag()
    {
        if (isGrounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = airDrag;
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    //This function moves the player model, force is determined based on where the model is currently standing
    void MovePlayer()
    {
        if(isGrounded)
        {
            rb.AddForce(playerDirection.normalized * playerSpeed * speedMultiplier/2, ForceMode.Acceleration);
        }
        else if (!isGrounded)
        {
            rb.AddForce(playerDirection.normalized * playerSpeed/2 * speedMultiplier/2 * airMultiplier/2, ForceMode.Acceleration);
        }
        
    }

    //Function for the player to jump and also play the jumping sound
    void Jump()
    {
        jumpingSound.Play();
        rb.AddForce(transform.up * jumpPower / 2, ForceMode.Impulse);
    }
    
    //Method to reduce height
    void Crouch()
    {
        playerCol.height = crouchingHeight;
    }

    //Method to reset playerheight after crouching
    void Stand()
    {
        playerCol.height = playerHeight;
    }
}
