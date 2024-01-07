using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerController : MonoBehaviour
{
    public float speed = 5.0f;
    public float gravity = -9.81f; // Earth's gravity in m/s^2
    public float jumpHeight = 2.0f;
    private CharacterController controller;
    private Vector3 velocity; // To store the velocity of the player
    private Vector3 movement;
    private bool isGrounded;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Take input
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        movement = Camera.main.transform.TransformVector(new Vector3(horizontal, 0, vertical) * speed);
        if (movement.magnitude > 0)
        {
            transform.rotation = Quaternion.LookRotation(new Vector3(movement.x,0,movement.z));
        }

        // Jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        
        
        
    }

    private void FixedUpdate()
    {
        // Check if on the ground
        isGrounded = controller.isGrounded;
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Small downward force to keep the player grounded
        }
        // Apply gravity over time if not grounded
        velocity.y += gravity * Time.deltaTime;

        controller.Move(movement * Time.deltaTime);
        controller.Move(velocity * Time.deltaTime);
    }

}
