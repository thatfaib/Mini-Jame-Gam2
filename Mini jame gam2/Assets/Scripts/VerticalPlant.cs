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

    void Update()
    {
        if (active) {
            flowerHead.transform.position += new Vector3(0, speed * Time.deltaTime, 0);

            if (flowerHead.transform.position.y > growLimit.transform.position.y) {
                active = false;
            }
        }
    }

}
