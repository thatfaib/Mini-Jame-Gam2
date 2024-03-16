using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shovel : MonoBehaviour
{
    [SerializeField]
    GameObject shovel;

    public void OnTriggerStay2D(Collider2D collision) {
        if (Input.GetKey(KeyCode.F) && collision.CompareTag("Plant")) {
                Debug.Log("Plant removed");
                Destroy(collision.gameObject);
        }
    }
}