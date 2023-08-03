using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float jumpPower = 5f; // How high the Character Jumps (in units)
    public float moveSpeed = 10f; // How fast the Character Moves
    public float curSpeed; // How fast the Character Moves
    public bool isFacingRight = true;

    [SerializeField] private Animator anim;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {
        // Gather components at the start of the game to save processing! (Cache-ing)
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        anim.SetBool("IsIdle", true);
        anim.SetTrigger("IsGrounded");
    }

    // Update is called once per frame
    void Update()
    {
        /*
         * --- Unity Tip ---
         * Input.GetAxis - 
         * Input.GetAxisRaw -

        // Temporary Variables
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        bool isJumping = Input.GetButtonDown("Jump");
        */
        rb.velocity = new Vector2(curSpeed * moveSpeed, rb.velocity.y);

        if (!isFacingRight && curSpeed > 0f)
        {
            Flip();
        }
        else if(isFacingRight && curSpeed < 0f)
        {
            Flip();
        }
        UpdateAnimationState();
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            anim.SetBool("Jumped", true);
            anim.ResetTrigger("IsGrounded");
        }
        else if (context.canceled)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            anim.SetBool("Jumped", true);
            anim.ResetTrigger("IsGrounded");
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    void UpdateAnimationState()
    {
        if (IsGrounded())
        {
            anim.SetBool("Jumped", false);
            anim.SetTrigger("IsGrounded");
        }
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    public void Move(InputAction.CallbackContext context)
    {
        curSpeed = context.ReadValue<Vector2>().x;

        if(curSpeed != 0f)
        {
            anim.SetFloat("Moving", 1);
            anim.SetBool("IsIdle", false);
        }
        else
        {
            anim.SetFloat("Moving", 0);
            anim.SetBool("IsIdle", true);
        }
    }
}
