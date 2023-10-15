using UnityEngine;

public class move : MonoBehaviour
{
    private float _directon;
    private bool isFacingRight=true;

    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private float velocity;

    [SerializeField]
    private float jumpForce;

    [SerializeField]
    private LayerMask groundLayer;
    [SerializeField]
    private Transform groundCheck;
    
    private bool isJumping = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        HandleInput();
        Flip();
    }

    void HandleInput()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        if (Input.GetButtonDown("Jump") && rb.velocity.y > 0f)
        {
         
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y* 0.5f);
        }
         
        _directon = Input.GetAxisRaw("Horizontal");

       
    }
   
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(_directon * velocity, 0f);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if ((groundLayer & (1 << collision.gameObject.layer)) != 0)
        {
            isJumping = false;
        }
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
    private void Flip()
    {
        if (isFacingRight && _directon<0f || !isFacingRight && _directon >0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 local = transform.localScale;
            local.x *= -1f;
            transform.localScale = local;
        }
    }
}