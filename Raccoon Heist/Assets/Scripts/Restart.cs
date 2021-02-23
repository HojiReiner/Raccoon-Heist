using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : MonoBehaviour
{
    public GameObject Player;
    public GameObject canvas;

    void OnTriggerEnter2D(Collider2D other) {
        Player.SetActive(false);
        canvas.SetActive(false);
        GameObject.Find("LevelLoader").GetComponent<LevelLoader>().RestartLevel();
    }
}
