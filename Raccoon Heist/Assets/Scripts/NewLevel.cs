using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewLevel : MonoBehaviour {
    public LevelLoader OtherScript;
    public GameObject canvas;
     
    void OnTriggerEnter2D(Collider2D other) {
        OtherScript.GetComponent<LevelLoader>().LoadNextLevel();
        canvas.SetActive(false);
    }
}
