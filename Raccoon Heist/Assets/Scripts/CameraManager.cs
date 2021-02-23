using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public void change(Vector3 aaa){
        transform.Find("Camera").position = new Vector3(aaa.x, aaa.y, -67);
    }
}
