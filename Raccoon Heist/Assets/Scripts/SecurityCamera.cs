using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityCamera : MonoBehaviour
{   
    [Header("Detect")]
    public bool player;
    public bool racoon;

    [Header("Movement")]
    public bool move;
    public float angle = 5;

    float z;
    float zBase;
    float add = 0.25f;
    SpriteRenderer sr;
    void Start() {
        sr = gameObject.GetComponent<SpriteRenderer>();
        z = transform.rotation.eulerAngles.z;
        zBase = z;
    }
    
    void FixedUpdate()
    {   
        if(move){
            if(Math.Abs(z - (zBase - angle)) < 0.001f|| Math.Abs(z - (zBase + angle)) < 0.001f){
                add = -add;
            }
            z += add;
    
            transform.localRotation = Quaternion.Euler(0, 0, z);
        
        }
    }

    void OnTriggerStay2D(Collider2D other) {
        if((other.CompareTag("Player") && player) || (other.CompareTag("Racoon") && racoon)){
            GameObject.Find("LevelLoader").GetComponent<LevelLoader>().RestartLevel();
        }
    }
}
