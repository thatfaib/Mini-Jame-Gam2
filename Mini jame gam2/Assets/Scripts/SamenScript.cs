using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SamenScript : MonoBehaviour
{
    bool canPlant;
    [SerializeField] LayerMask topfLayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(canPlant);
        
    }

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.layer == topfLayer){
            canPlant = true;
        }

    }
    void OnTriggerExit2D(Collider2D collision){
       if(collision.gameObject.layer == topfLayer){
            canPlant = false;
        }

    }
}
