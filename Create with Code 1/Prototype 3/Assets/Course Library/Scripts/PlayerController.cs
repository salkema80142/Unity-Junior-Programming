using UnityEngine;
using UnityEngine.InputSystem;
// Required if you want to use the specific UI Image component directly
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public InputAction jumpAction;
    public float jumpForce = 10;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver = false;
    private Animator playerAnim;

    [Header("UI Elements")]
    // Drag your Game Over Image or Screen GameObject into this slot in the Unity Inspector
    public GameObject gameOverImage;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        jumpAction.Enable();
        Physics.gravity *= gravityModifier;
        playerAnim = GetComponent<Animator>();

        // Ensure the Game Over image is hidden when the game starts
        if (gameOverImage != null)
        {
            gameOverImage.SetActive(false);
        }
    }

    void Update()
    {
        if (jumpAction.triggered && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over");
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);

            // Activates the Game Over image on your screen
            if (gameOverImage != null)
            {
                gameOverImage.SetActive(true);
            }
        }
    }
}
