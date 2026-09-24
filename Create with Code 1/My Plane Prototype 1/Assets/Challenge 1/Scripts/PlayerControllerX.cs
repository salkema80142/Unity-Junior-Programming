using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public float speed = 5.0f;
    public float rotationSpeed = 5.0f;
    public float verticalInput;

    public InputAction moveAction;
    private Vector2 moveInput;

    // Start is called before the first frame update
    void Start()
    {
        moveAction.Enable();
    }

    void Update()
    {
        // Get the user's vertical input
        verticalInput = Input.GetAxis("Vertical");

        // Tilt the plane up/down based on up/down arrow keys
        transform.Rotate(
            Vector3.left * Time.deltaTime * verticalInput * rotationSpeed
        );

        // Move the plane forward at a constant rate
        transform.Translate(
            Vector3.forward * Time.deltaTime * speed
        );
    }
}