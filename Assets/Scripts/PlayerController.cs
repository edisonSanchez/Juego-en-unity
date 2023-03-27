using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private  Rigidbody2D rb;
    public int speed = 400;
    private bool facingRight = false;
    private float horizontalMove;
    public Animator animator;

    //Para los altos
    public int jumpPower = 25;
    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        horizontalMove = Input.GetAxis("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        rb.velocity = new Vector2(horizontalMove * speed, rb.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
        animator.SetBool("IsGrounded", isGrounded);
        if (horizontalMove > 0.0f && facingRight)
        {
            FlipPlayer();
        }
        if (horizontalMove < 0.0f && !facingRight)
        {
            FlipPlayer();
        }
        //Salta cuando presiones Space
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
            Jump();
        }

        if (Input.GetKey(KeyCode.Space) && isJumping) 
        {
            if (jumpTimeCounter > 0) 
            {
                rb.velocity = Vector2.up * jumpPower;
                jumpTimeCounter -= Time.deltaTime;
            } 
            else 
            {
                isJumping = true;

            }
        }
        if (Input.GetKeyUp(KeyCode.Space)) 
        {
            isJumping = false;
        }
    }

    void FlipPlayer () 
    {
        facingRight = !facingRight;
        Vector2 playerScale = gameObject.transform.localScale;
        playerScale.x *= -1;
        transform.localScale = playerScale;
    }

    void Jump () 
    {
        rb.velocity = Vector2.up * jumpPower;
        isJumping = true;
        jumpTimeCounter = jumpTime;
    }
}
