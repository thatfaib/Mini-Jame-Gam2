using System.Collections;
using System.Linq;
using UnityEngine;

public class PlayerController  : MonoBehaviour
{
    float horizontal;
    float speed = 6f;
    float jumpingPower = 12f;
    bool isFacingRight = true;

    bool isJumping; 
    
    float coyoteTime = 0.2f;
    float coyoteTimeCounter;

    float jumpBufferTime = 0.2f;
    float jumpBufferCounter;

    [SerializeField] GameObject rayEnd;
    [SerializeField] GameObject rayStart;

    [SerializeField] Rigidbody2D rb;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] ItemData Item1;
    [SerializeField] ItemData Item2;
    [SerializeField] ItemData Item3;
    [SerializeField] ItemData Item4;

   
    void Start(){
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

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

      
        if(Input.GetKeyDown(KeyCode.Alpha1)){
            InventoryScript.instance.AddItem(Item1);
        }
        if(Input.GetKeyDown(KeyCode.Alpha2)){
            InventoryScript.instance.AddItem(Item2);
        }
        if(Input.GetKeyDown(KeyCode.Alpha3)){
            InventoryScript.instance.AddItem(Item3);
        }
        if(Input.GetKeyDown(KeyCode.Alpha4)){
            InventoryScript.instance.AddItem(Item4);
        }
        if(Input.GetKeyDown(KeyCode.H)){
            InventoryScript.instance.RemoveItem(InventoryScript.instance.items.LastOrDefault<ItemData>());
        }
        if(Input.GetKeyDown(KeyCode.E)){
            InventoryScript.instance.selectNext();
        }
        if(Input.GetKeyDown(KeyCode.Q)){
            InventoryScript.instance.selectPrevious();
        }

       }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    bool isGrounded(){
        float rayLength = 0.05f;

        if (Physics2D.Raycast(rayStart.transform.position, Vector2.down, rayLength, groundLayer)){
            return true;
        }
        if (Physics2D.Raycast(rayEnd.transform.position, Vector2.down, rayLength, groundLayer)) {
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