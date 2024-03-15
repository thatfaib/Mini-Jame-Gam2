using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float horizontal;
    float speed = 8f;
    float jumpingPower = 16f;
    bool isFacingRight = true;

    bool isJumping;
    
    float coyoteTime = 0.2f;
    float coyoteTimeCounter;

    float jumpBufferTime = 0.2f;
    float jumpBufferCounter;

    [SerializeField] Rigidbody2D rb;
    [SerializeField] LayerMask groundLayer;

     void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (isGrounded())
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Jump"))
        {
            jumpBufferCounter = jumpBufferTime;
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }

        if (coyoteTimeCounter > 0f && jumpBufferCounter > 0f && !isJumping)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);

            jumpBufferCounter = 0f;

            StartCoroutine(JumpCooldown());
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);

            coyoteTimeCounter = 0f;
        }

        Flip();
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    bool isGrounded(){
        float rayLength = 0.6f;

        if (Physics2D.Raycast(transform.position,Vector2.down, rayLength, groundLayer)){
            return true;
        }
        return false;
    }
   
    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            Vector3 localScale = transform.localScale;
            isFacingRight = !isFacingRight;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private IEnumerator JumpCooldown()
    {
        isJumping = true;
        yield return new WaitForSeconds(0.4f);
        isJumping = false;
    }
}