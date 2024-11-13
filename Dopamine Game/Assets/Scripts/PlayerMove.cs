using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody rb;
    public float walkingSpeed = 3.0f;

    public bool jumpEnabled;
    public float jumpSpeed = 1.0f;
    public bool crouchEnabled;
    public float crouchHeight = 0.4f;
    private float normalHeight;
    
    public KeyCode forwardKey = KeyCode.W;
    public KeyCode backKey = KeyCode.S;
    public KeyCode leftKey = KeyCode.A;
    public KeyCode rightKey = KeyCode.D;
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode crouchKey = KeyCode.LeftControl;

    private AudioSource audioSource;  // Voeg de AudioSource toe
    public AudioClip walkingClip;     // Sleep hier je loopgeluid in de inspector
    private bool isWalking = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        normalHeight = transform.localScale.y;
        
        // Haal de AudioSource op en stel het geluid in
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = walkingClip;
        audioSource.loop = true; // Zorg ervoor dat het geluid in een loop wordt afgespeeld
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3();
        bool hasInput = false;

        // Walking
        if (Input.GetKey(forwardKey))
        {
            movement += transform.forward * walkingSpeed;
            hasInput = true;
        }
        if (Input.GetKey(backKey))
        {
            movement += -transform.forward * walkingSpeed;
            hasInput = true;
        }
        if (Input.GetKey(rightKey))
        {
            movement += transform.right * walkingSpeed;
            hasInput = true;
        }
        if (Input.GetKey(leftKey))
        {
            movement += -transform.right * walkingSpeed;
            hasInput = true;
        }

        // Controleren of het loopgeluid moet worden afgespeeld
        if (hasInput && !isWalking)
        {
            audioSource.Play();
            isWalking = true;
        }
        else if (!hasInput && isWalking)
        {
            audioSource.Pause();
            isWalking = false;
        }

        // Jumping
        if (jumpEnabled && Input.GetKey(jumpKey) && isGrounded()) 
        {
            movement += transform.up * jumpSpeed;
        }

        // Beperk beweging als er geen input is
        if (!hasInput) {
            rb.constraints = 
                RigidbodyConstraints.FreezePositionX | 
                RigidbodyConstraints.FreezePositionZ |
                RigidbodyConstraints.FreezeRotationY |
                RigidbodyConstraints.FreezeRotationZ;
        } else {
            rb.constraints = 
                RigidbodyConstraints.FreezeRotationY |
                RigidbodyConstraints.FreezeRotationZ;
        }

        // Handhaaf verticale snelheid
        movement.y += rb.velocity.y;

        // Pas de snelheid aan de Rigidbody toe
        rb.velocity = movement;
    }

    void Update() {
        if (crouchEnabled && Input.GetKeyDown(crouchKey)) {
            // Crouching
            transform.localScale = new Vector3(transform.localScale.x, crouchHeight, transform.localScale.z);
        } else if (crouchEnabled && Input.GetKeyUp(crouchKey)) {
            // Not crouching
            transform.localScale = new Vector3(transform.localScale.x, normalHeight, transform.localScale.z);
        }
    }

    // Check if player is on the ground
    bool isGrounded() {
        return Physics.Raycast(transform.position, -Vector3.up, 0.1f + transform.localScale.y);
    }
}

