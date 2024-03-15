using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
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
            if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.Space)) {
                animator.SetTrigger("Walk");
            }
            else if(Input.GetKey(KeyCode.Space) && player.velocity.y != 0) {
                animator.SetTrigger("Jump");
            }
            else {
                animator.SetTrigger("Idle");
            }
            
        }
    }
}
