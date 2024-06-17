using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;

    private bool isGrounded;
    private bool isSprinting;

    private float baseSpeed = 10f;

    public float speed = 10f;
    public float gravity = -50f;
    public float jumpForce = 2f;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        // Lock Cursor and Make Invisible
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        isGrounded = controller.isGrounded;
    }

    public void ProcessMove(Vector2 input)
    {
        // Set Cardinal Movement Directions
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;

        // Process Cardinal Movement
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);

        // Set Gravity
        playerVelocity.y += gravity * Time.deltaTime;
        if (isGrounded && playerVelocity.y < 0) { playerVelocity.y = -2f; }

        // Process Gravity
        controller.Move(playerVelocity * Time.deltaTime);
    }

    public void Jump()
    {
        if (isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpForce * -3f * gravity);
        }
    }

    public void Sprint()
    {
        isSprinting = !isSprinting;
        if (isSprinting)
        {
            speed = 15f;
        }
        else
        {
            speed = baseSpeed;
        }
    }
}
