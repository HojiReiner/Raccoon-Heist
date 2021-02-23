using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHint : MonoBehaviour
{
    public GameObject UIScore;
    void OnTriggerEnter2D(Collider2D other){
        this.gameObject.SetActive(false);
        UIScore.SetActive(true);
    }
}
