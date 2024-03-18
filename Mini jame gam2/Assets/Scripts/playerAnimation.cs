using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class playerAnimation : MonoBehaviour
{
    [SerializeField] Rigidbody2D player;

    private Animator animator;
    
    void Start() {
        animator = GetComponent<Animator>();
    }

    void Update() {
        if (animator != null) {
            if (player.velocity.y != 0) {
                animator.SetTrigger("Jump");
            }
            else if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) && player.velocity.y == 0) {
                animator.SetTrigger("Walk");
            }
            else if(player.velocity.x == 0 && player.velocity.y == 0){
                animator.SetTrigger("Idle");
            }
            
        }
    }
}
