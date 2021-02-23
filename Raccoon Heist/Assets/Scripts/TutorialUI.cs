using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialUI : MonoBehaviour
{
    public GameObject AdText;
    public GameObject SpaceText;
    public GameObject EText;
    public GameObject QText;
    public GameObject HintText;
    public float TransitionTime = 1f;
    public GameObject GiveHint;
    bool HintGiven = false;
    public GameObject CameraBool;
    public GameObject CameraText;
    bool cameraHint = false;

    // Start is called before the first frame update
    void Start()
    {   
        StartCoroutine(MovementUI());
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if(!HintGiven) {
            if(GiveHint.activeSelf) {
                StartCoroutine(hint());
                HintGiven = true;
            } 
        }
        if(!CameraBool.activeSelf && !cameraHint){
            StartCoroutine(CameraHint());
            cameraHint = true;
        }
    }

    IEnumerator MovementUI(){
        yield return new WaitForSeconds(2f);
        AdText.SetActive(true);
        yield return new WaitForSeconds(TransitionTime);
        AdText.GetComponent<Animator>().SetTrigger("FadeOut");
        yield return new WaitForSeconds(1f);
        AdText.SetActive(false);
        SpaceText.SetActive(true);
        yield return new WaitForSeconds(TransitionTime);
        SpaceText.GetComponent<Animator>().SetTrigger("FadeOut");
        yield return new WaitForSeconds(2f);
        SpaceText.SetActive(false);
        EText.SetActive(true);
        yield return new WaitForSeconds(TransitionTime + 2);
        EText.GetComponent<Animator>().SetTrigger("FadeOut");
        yield return new WaitForSeconds(1f);
        EText.SetActive(false);
        QText.SetActive(true);
        yield return new WaitForSeconds(TransitionTime + 2);
        QText.GetComponent<Animator>().SetTrigger("FadeOut");
        yield return new WaitForSeconds(1f);
        QText.SetActive(false);
    }

    IEnumerator hint(){
        //yield return new WaitForSeconds(1f);
        HintText.SetActive(true);
        yield return new WaitForSeconds(TransitionTime + 5);
        HintText.GetComponent<Animator>().SetTrigger("FadeOut");
        yield return new WaitForSeconds(1f);
        HintText.SetActive(false);
    }

    IEnumerator CameraHint(){
        CameraText.SetActive(true);
        yield return new WaitForSeconds(TransitionTime + 5);
        CameraText.GetComponent<Animator>().SetTrigger("FadeOut");
        yield return new WaitForSeconds(1f);
        CameraText.SetActive(false);
    }
} 
