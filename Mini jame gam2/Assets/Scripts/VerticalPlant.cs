using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class VerticalPlant : MonoBehaviour
{
    [SerializeField] GameObject flowerHead;
    [SerializeField] bool active = false;
    [SerializeField] GameObject growLimit;
    [SerializeField] float speed = 1f;
    float acceleration = 3f;

    private void Start() {
        StartCoroutine(waitThenLoad());
    }

    void Update()
    {
        if (active) {
            speed += Time.deltaTime * acceleration;
            flowerHead.transform.position += new Vector3(0, speed * Time.deltaTime, 0);

            if (flowerHead.transform.position.y > growLimit.transform.position.y) {
                active = false;
                speed = 2f;
            }
        }
    }

    IEnumerator waitThenLoad() {
        yield return new WaitForSeconds(1.5f);
        active = true;
    }

}
