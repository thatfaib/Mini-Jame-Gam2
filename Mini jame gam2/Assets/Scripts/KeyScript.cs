using UnityEngine;

public class KeyScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            InventoryScript.instance.keys +=1;
            Destroy(gameObject);
        }
    }
}
