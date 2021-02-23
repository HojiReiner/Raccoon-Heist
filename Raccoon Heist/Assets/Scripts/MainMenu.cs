using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public LevelLoader OtherScript;
    void Update() {
        if(Input.GetKeyDown(KeyCode.Return)){
            LoadLevel();            
        }
    }
    public void LoadLevel(){
        OtherScript.GetComponent<LevelLoader>().LoadNextLevel();
    }
}
