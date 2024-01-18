using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerController2D : MonoBehaviour
{
    [SerializeField] float speed;

    CharacterController controller;
    Vector2 move;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        move.x = Input.GetKey(KeyCode.D) ? 1 : (Input.GetKey(KeyCode.A) ? -1 : 0);
        move.y = Input.GetKey(KeyCode.W) ? 1 : (Input.GetKey(KeyCode.S) ? -1 : 0);
    }

    private void FixedUpdate()
    {
        controller.Move((Vector3.right * move.x + Vector3.up * move.y) * speed * Time.deltaTime);
    }
}
