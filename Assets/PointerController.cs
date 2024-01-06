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
    private bool isGrounded;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Check if on the ground
        isGrounded = controller.isGrounded;
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Small downward force to keep the player grounded
        }

        // Adjusted to invert input axis if necessary
        float horizontal = Input.GetAxis("Horizontal") * -1; // Invert if necessary
        float vertical = Input.GetAxis("Vertical") * -1; // Invert if necessary

        Vector3 movement = new Vector3(horizontal, 0, vertical) * speed;
        controller.Move(movement * Time.deltaTime);

        // Jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Apply gravity over time if not grounded
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

}
