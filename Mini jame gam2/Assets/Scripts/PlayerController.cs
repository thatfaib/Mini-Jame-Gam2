using System.Collections;
using System.Linq;
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
    public ItemData Pflanze;
    public ItemData Ananas;
    public ItemData Mango;

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

        if(Input.GetKeyDown(KeyCode.E)){
            InventoryScript.instance.AddItem(Pflanze);
        }
        if(Input.GetKeyDown(KeyCode.F)){
            InventoryScript.instance.AddItem(Ananas);
        }
        if(Input.GetKeyDown(KeyCode.G)){
            InventoryScript.instance.AddItem(Mango);
        }
        if(Input.GetKeyDown(KeyCode.H)){
            InventoryScript.instance.RemoveItem(InventoryScript.instance.items.LastOrDefault<ItemData>());
        }

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
   
    void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            Vector3 localScale = transform.localScale;
            isFacingRight = !isFacingRight;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    IEnumerator JumpCooldown()
    {
        isJumping = true;
        yield return new WaitForSeconds(0.4f);
        isJumping = false;
    }
}