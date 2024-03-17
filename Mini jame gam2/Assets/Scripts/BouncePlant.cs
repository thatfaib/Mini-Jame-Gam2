using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BouncePlant : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] ParticleSystem jumpEffect;
    ParticleSystem ps = null;
    GameObject player;


    void Start(){
        player = GameObject.FindWithTag("Player");
        rb = player.GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject == player) {
            rb.AddForce(Vector2.up * 12f, ForceMode2D.Impulse);
            ps = Instantiate(jumpEffect,gameObject.transform.position,gameObject.transform.rotation );
        }
    }
    

}
