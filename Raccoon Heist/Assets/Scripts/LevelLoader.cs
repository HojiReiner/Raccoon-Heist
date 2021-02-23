using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelLoader : MonoBehaviour {
    public float TransitionTime = 1f;
    public int ScoreNeeded = 0;
    public TextMeshProUGUI score;
    public GameObject WellDoneText;
    
    void Start() {
        if(score != null)
        score.text = ScoreNeeded.ToString();
    }

    void Update() {
        if(SceneManager.GetActiveScene().buildIndex == 4){
            StartCoroutine(End());
        }

        if(ScoreNeeded != 0 && score.text.Equals("0")) {
            //WellDoneText.SetActive(true);
            LoadNextLevel();
        }
       // Debug.Log(score.text);
    }
    public void LoadNextLevel() {
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int LevelIndex) {        
        this.GetComponentInChildren<Animator>().SetTrigger("Start");
        yield return new WaitForSeconds(TransitionTime);
        SceneManager.LoadScene(LevelIndex);
    }

    IEnumerator End() {        
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(0);
    }

    public void RestartLevel(){
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
    }
}
