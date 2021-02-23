using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaDetect : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D other) {
        if(other.CompareTag("Beacon")){
            transform.parent.gameObject.GetComponent<CameraManager>().change(transform.position);
        }
    }
    
}
