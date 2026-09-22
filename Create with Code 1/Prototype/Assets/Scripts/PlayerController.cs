using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public float turnSpeed;
    public InputAction moveAction;
    public Vector2 moveInput;

    // Start is called once before the first frame update
    void Start()
    {
        moveAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = moveAction.ReadValue<Vector2>();

        transform.Translate(Vector3.forward * Time.deltaTime * speed * moveInput.y);

        transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * moveInput.x);
    }
}
