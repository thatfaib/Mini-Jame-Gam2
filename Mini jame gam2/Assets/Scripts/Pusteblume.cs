using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PusteBlume : MonoBehaviour {
    [SerializeField] GameObject flowerHead;
    [SerializeField] bool active = false;
    [SerializeField] GameObject growLimit;
    [SerializeField] float speed = 1f;
    [SerializeField] float lifetime = 4f;

    float acceleration = 2f;

    void Awake(){
        active = true;
    }
    void Update() {
        if (active) {
            speed += Time.deltaTime * acceleration;
            flowerHead.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);

            if (flowerHead.transform.position.x > growLimit.transform.position.x) {
                active = false;
                speed = 2f;

            }
        }
        if(lifetime < 0) Destroy(gameObject);
        lifetime -= Time.deltaTime;
    }
    
}