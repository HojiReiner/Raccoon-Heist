using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{

    int score = 10;
    public TextMeshProUGUI ScoreText;

    public void DecrementScore() {
        score --;
        ScoreText.text = score.ToString();  
    }
}
