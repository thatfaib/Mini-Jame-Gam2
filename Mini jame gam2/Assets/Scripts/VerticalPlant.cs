using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class VerticalPlant : MonoBehaviour
{
    [SerializeField]
    GameObject flowerHead;
    [SerializeField]
    bool active = false;
    [SerializeField]
    GameObject growLimit;
    [SerializeField]
    float speed = 1f;
    float acceleration = 3f;

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

}
