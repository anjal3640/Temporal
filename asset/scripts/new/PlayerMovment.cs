
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float acceleration = 40f;
    [SerializeField] private float deceleration = 45f;
    [SerializeField] private float jumpForce = 11f;

    [Header("Ground Check")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.2f;
    [SerializeField] private LayerMask groundLayer;

    [Header("Animation")]
    [SerializeField] private Animator animator;

    private Rigidbody2D rb;

    private float horizontalInput;
    private bool jumpRequested;
    private bool isActive;

    // Animator states
    private bool isMoving;
    private bool isGrounded;
    private bool isJumping;
    private bool isFalling;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!isActive)
            return;

        horizontalInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            jumpRequested = true;
        }
    }

    private void FixedUpdate()
    {
        // Ground detection
        if (groundCheck != null)
        {
            isGrounded = Physics2D.OverlapCircle(
                groundCheck.position,
                groundCheckRadius,
                groundLayer
            );
        }

        // Horizontal movement
        float targetSpeed = isActive
            ? horizontalInput * moveSpeed
            : 0f;

        float movementRate = Mathf.Abs(targetSpeed) > 0.01f
            ? acceleration
            : deceleration;

        float newSpeed = Mathf.MoveTowards(
            rb.linearVelocity.x,
            targetSpeed,
            movementRate * Time.fixedDeltaTime
        );

        rb.linearVelocity = new Vector2(newSpeed, rb.linearVelocity.y);

        // Jump
        if (isActive && jumpRequested && isGrounded)
        {
            rb.linearVelocity = new Vector2(
                rb.linearVelocity.x,
                jumpForce
            );
        }

        jumpRequested = false;

        // Animation states
        isMoving = Mathf.Abs(rb.linearVelocity.x) > 0.1f;
        isJumping = !isGrounded && rb.linearVelocity.y > 0.1f;
        isFalling = !isGrounded && rb.linearVelocity.y < -0.1f;

        UpdateAnimator();
    }

    private void UpdateAnimator()
    {
        if (animator == null)
            return;

        animator.SetBool("IsMoving", isMoving);
        animator.SetBool("IsGrounded", isGrounded);
        animator.SetBool("IsJumping", isJumping);
        animator.SetBool("IsFalling", isFalling);
    }

    public void SetActive(bool active)
    {
        isActive = active;

        if (!isActive)
        {
            horizontalInput = 0f;
            jumpRequested = false;
        }
    }
}
