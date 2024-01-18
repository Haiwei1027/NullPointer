using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerController : MonoBehaviour
{
    public float speed = 5.0f;
    public float gravity = -9.81f; // Earth's gravity in m/s^2
    public float jumpHeight = 2.0f;
    private CharacterController controller;
    public Vector3 velocity; // To store the velocity of the player
    private Vector3 movement;
    private bool isGrounded;

    private Animator animator;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>(); 
    }

    void Update()
    {
        // Take input
        float horizontal = Input.GetKey(KeyCode.D) ? 1 : (Input.GetKey(KeyCode.A) ? -1 : 0);
        float vertical = Input.GetKey(KeyCode.W) ? 1 : (Input.GetKey(KeyCode.S) ? -1 : 0);

        Vector3 forward = Vector3.Cross(Vector3.down, CameraFollow.Instance.transform.right);
        Vector3 right = Vector3.Cross(forward, Vector3.down);

        movement = (forward * vertical + right * horizontal) * speed;
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
            velocity.y = -1f; // Small downward force to keep the player grounded
        }
        // Apply gravity over time if not grounded
        velocity.y += gravity * Time.deltaTime;

        controller.Move(movement * Time.deltaTime);
        controller.Move(velocity * Time.deltaTime);
    }

}
