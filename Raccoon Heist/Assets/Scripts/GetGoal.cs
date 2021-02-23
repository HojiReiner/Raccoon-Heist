using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GetGoal : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    int score;
    
    void OnTriggerEnter2D(Collider2D other) {
        score = Int32.Parse(ScoreText.text);
        score--;
        ScoreText.text = score.ToString();
        this.gameObject.SetActive(false);
    }
}
