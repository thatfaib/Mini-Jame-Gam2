using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntryLevelAnimation : MonoBehaviour
{

    [SerializeField]
    GameObject transitionSprite;
    [SerializeField]
    GameObject moveTowards;

    bool start = false;

    void Start() {
        StartCoroutine(waitThenLoad());
    }

    void Update() {
        if (start == true) {
            transitionSprite.transform.position -= new Vector3(Time.deltaTime * 16, 0, 0);

            if (transitionSprite.transform.position.x < moveTowards.transform.position.x) {
                start = false;
            }
        }
    }

    IEnumerator waitThenLoad() {
        yield return new WaitForSeconds(0.5f);
        start = true;
    }
}
