using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlayerCam : MonoBehaviour
{
    public Camera camera;
    void Start()
    {

    }
    void Update()
    {
        if (LockControl.isPadlockOpened == true)
        {
            transform.Rotate(0, 180, 0);
            camera.transform.Rotate(40, 0, 0);

        }
        //if (LockControl.isPadlockOpened == true)
        //{
            //transform.rotation = Quaternion.Euler(0, 90, 0);
            //transform.Rotate(0, 180, 0);
           // camera.transform.Rotate(30, 0, 0);
        //}
        //transform.LookAt(box.transform);
        //camera.transform.Rotate(90, 180, 0);
        //transform.rotation = Quaternion.AngleAxis(30, Vector3.up);
        //Vector3 newRotation = new Vector3(90, 90, 90);
        //transform.eulerAngles = newRotation;
    }
}
