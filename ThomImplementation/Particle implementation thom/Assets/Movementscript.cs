using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movementscript : MonoBehaviour
{
    public float rotationSpeed = 100f;
    public float moveSpeed = 5f;
    public float jumpHeight = 2f;
    public float gravity = 9.8f;

    private CharacterController characterController;
    private Vector3 velocity;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Check if the player is grounded
        bool isGrounded = characterController.isGrounded;

        // Rotate the player
        Rotate();

        // Move the player
        Move();

        // Apply gravity
        ApplyGravity();

        // Jump if the player is on the ground
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        // Apply the final movement
        characterController.Move(velocity * Time.deltaTime);
    }

    void Rotate()
    {
        float rotationInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, rotationInput * rotationSpeed * Time.deltaTime);
    }

    void Move()
    {
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the movement direction
        Vector3 moveDirection = new Vector3(0f, 0f, verticalInput);
        moveDirection.Normalize();

        // Convert movement direction to world space
        moveDirection = transform.TransformDirection(moveDirection);

        // Apply speed to the movement
        moveDirection *= moveSpeed;

        // Set the Y component of velocity to the current vertical velocity to maintain it
        moveDirection.y = velocity.y;

        // Set the velocity
        velocity = moveDirection;
    }

    void ApplyGravity()
    {
        // Apply gravity to the vertical velocity
        velocity.y -= gravity * Time.deltaTime;
    }

    void Jump()
    {
        // Set a positive vertical velocity to make the player jump
        velocity.y = Mathf.Sqrt(2f * jumpHeight * gravity);
    }
}
