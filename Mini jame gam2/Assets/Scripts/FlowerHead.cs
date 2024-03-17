using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FlowerHead : MonoBehaviour
{
    GameObject player;
    GameObject target = null;
    Vector3 offset;

    void Start(){
        player = GameObject.FindWithTag("Player");
    }
    void OnTriggerStay2D(Collider2D collision){
        if(collision.gameObject ==  player)
            target = player;
            offset = target.transform.position - transform.position;
    }

    void OnTriggerExit2D(){
        target = null;
    }
    void Update(){
        if(target != null) target.transform.position = transform.position + offset; 
    }
}
