using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerPlatformer : MonoBehaviour
{
    public float speed = 8f;
    public float jumpForce = 14f;
    public Transform groundCheck;
    public float groundRadius = 0.15f;
    public LayerMask groundMask;

    Rigidbody2D rb;
    float moveX;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal");

        bool grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundMask);

        if (Input.GetButtonDown("Jump") && grounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveX * speed, rb.linearVelocity.y);
    }
}