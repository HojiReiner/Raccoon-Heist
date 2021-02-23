using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingWall : MonoBehaviour {

    public Animator DisappearAnimation;

    void OnTriggerEnter2D(Collider2D other) {
        StartCoroutine(disappear());        
    }

    IEnumerator disappear() {
        DisappearAnimation.SetTrigger("Disappear");
        yield return new WaitForSeconds(0.5f);
        this.gameObject.SetActive(false);
    }

}
