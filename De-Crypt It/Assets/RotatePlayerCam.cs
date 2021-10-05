using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlayerCam : MonoBehaviour
{
    public GameObject box;
    void Start()
    {
        //if (LockControl.isPadlockOpened == true)
        //transform.LookAt(box.transform);
        
    }
    void Update()
    {
        //if (LockControl.isPadlockOpened == true)
        //transform.LookAt(box.transform);


        //transform.rotation = Quaternion.Euler(0, 90, 0);


        transform.Rotate(0, 180, 0);
        //transform.rotation = Quaternion.AngleAxis(30, Vector3.up);
        //Vector3 newRotation = new Vector3(90, 90, 90);
        //transform.eulerAngles = newRotation;
    }
}
