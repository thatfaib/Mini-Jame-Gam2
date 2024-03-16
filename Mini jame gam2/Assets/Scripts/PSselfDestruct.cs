using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PSselfDestruct : MonoBehaviour
{

    void Start() {
        StartCoroutine(waitThenLoad());
    }

    IEnumerator waitThenLoad() {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
