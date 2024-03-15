using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SamenScript : MonoBehaviour
{
    bool canPlant;
    
    // Update is called once per frame
    void Update()
    {
        if(canPlant && Input.GetKeyDown(KeyCode.E)){
            Debug.Log("planzen");
        }
        
        
    }

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.layer == LayerMask.NameToLayer("Töpfe")){
            canPlant = true;
        }

    }
    void OnTriggerExit2D(Collider2D collision){
       if(collision.gameObject.layer == LayerMask.NameToLayer("Töpfe")){
            canPlant = false;
        }

    }
}
