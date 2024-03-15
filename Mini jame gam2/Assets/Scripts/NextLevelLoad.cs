using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelLoad : MonoBehaviour {

    // File > Build Settings > Scenes in Build
    [SerializeField]
    int nextSceneID = 0;
    [SerializeField]
    GameObject transitionSprite;
    [SerializeField]
    GameObject moveTowards;

    bool start = false;

    void OnTriggerEnter2D(UnityEngine.Collider2D collision) {
        StartCoroutine(waitThenLoad());
    }

     void Update() {
        if(start == true) {
            transitionSprite.transform.position -= transitionSprite.transform.position * Time.deltaTime;

            if (transitionSprite.transform.position.x < moveTowards.transform.position.x) {
                SceneManager.LoadScene(nextSceneID);
                start = false;
            }
        }
    }

    IEnumerator waitThenLoad() {
        yield return new WaitForSeconds(0.5f);
        start = true;
    }

}
