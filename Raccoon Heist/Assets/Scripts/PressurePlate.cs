using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour {
    public GameObject MovingObject;
    public Vector3 move;
    int PlatePressed = 0;
    public float MovingSpeed = 1f;
    Vector3 InitialPosition;
    Vector3 TargetPosition;
    public bool NeedsPlayerTogether = false;
    string TargetTag;
    public GameObject GiveHint;
    public bool MoveBack = true;

    void Start()
    {
        if(GiveHint != null){
            GiveHint.SetActive(false);
        }
        InitialPosition = MovingObject.transform.position;
        TargetPosition = InitialPosition + move;        
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(NeedsPlayerTogether) {
            if(other.gameObject.CompareTag("Player")){
                PlatePressed = 1;
                this.gameObject.transform.position += new Vector3(0, -0.3f, 0);
            } else if(GiveHint != null){
                GiveHint.SetActive(true);
            }
        } else {
            PlatePressed = 1;
            this.gameObject.transform.position += new Vector3(0, -0.3f, 0);
        }
        
        
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(MoveBack){
            if(NeedsPlayerTogether){
                if(other.gameObject.CompareTag("Player")){
                    PlatePressed = -1;
                    this.gameObject.transform.position += new Vector3(0, 0.3f, 0);  
                }
            } else {
                PlatePressed = -1;
                this.gameObject.transform.position += new Vector3(0, 0.3f, 0);  
            }
        }                        
    }

    void FixedUpdate() {        
        if(PlatePressed == 1 && Vector3.Distance(MovingObject.transform.position, TargetPosition) > 0.1){
            float step = MovingSpeed * Time.deltaTime;
            MovingObject.transform.position = Vector3.MoveTowards(MovingObject.transform.position, MovingObject.transform.position += move, step);                
        } else if(PlatePressed == -1 && Vector3.Distance(MovingObject.transform.position, InitialPosition) > 0.1) {
            float step = MovingSpeed * Time.deltaTime;
            MovingObject.transform.position = Vector3.MoveTowards(MovingObject.transform.position, MovingObject.transform.position -= move, step);
        }
        else {
            PlatePressed = 0;
        }
    }
}
