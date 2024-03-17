using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class col : MonoBehaviour
{
   
    [SerializeField] float timer = 2f;
    [SerializeField] GameObject pustblume;
    float countdown = 1f;
    void Start()
    {
        
    }

    
    void Update()
    {
        if(countdown < 0) {
            Instantiate(pustblume, gameObject.transform.position, gameObject.transform.rotation);
            countdown = timer;
        } else {
            countdown-=Time.deltaTime;
        }
    }
}
