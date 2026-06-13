using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header ("Movement Settings")]
    private Rigidbody rb;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float maxSpeed = 5f;
    [SerializeField] private float jumpForce = 7f;
    private Vector2 moveInput;

    private bool isGrounded = true;





    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    
    }

    private void FixedUpdate()
    {
        Movimentacao();
    }

    private void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
    private void OnJump()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;

        }
    }

    private void Movimentacao()
    {
        if (rb.linearVelocity.magnitude < maxSpeed)
        {
            Vector3 moveDirection = new Vector3
                (moveInput.x, 0, moveInput.y) * moveSpeed;
            rb.linearVelocity = new Vector3
                (moveDirection.x, rb.linearVelocity.y, moveDirection.z);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}

