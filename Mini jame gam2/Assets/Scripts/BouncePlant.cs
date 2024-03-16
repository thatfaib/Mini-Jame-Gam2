using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePlant : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rb;
    [SerializeField]
    ParticleSystem jumpEffect;

    ParticleSystem ps = null;

    bool bounce = false;

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            bounce = true;
        }
    }

    void FixedUpdate() {
        if(bounce) {
            rb.AddForce(transform.up * 15f, ForceMode2D.Impulse);
            ps = Instantiate(jumpEffect);
            bounce = false;
        }
    }

}
