using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public InputAction jumpAction;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        jumpAction.Enable();
    }

    void Update()
    {
        if (jumpAction.triggered)
        {
            playerRb.AddForce(Vector3.up * 10, ForceMode.Impulse);
        }
    }
}