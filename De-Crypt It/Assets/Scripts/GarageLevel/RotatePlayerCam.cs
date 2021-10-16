using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlayerCam : MonoBehaviour
{
    public GameObject Camera;
    public GameObject Capsule;
    //public Camera camera;

    public bool hasPlayerTurned = false;

    public float Rotation;
    void Start()
    {
    }
    void Update()
    {
        if (LockControl.isPadlockOpened == true && /*LockControl.turnTowardsBox == true &&*/ EasyModePauseGame.isGamePaused == false /*&& hasPlayerTurned == false*/)
        {
            transform.Rotate(0, 180, 0);
            Camera.transform.Rotate(40, 0, 0);
            StartCoroutine(WaitForSeconds());
        }

        if (EasyModePauseGame.isGamePaused == true && LockControl.turnTowardsBox == false)
        {
            //Camera.GetComponent<FirstPersonLook>().enabled = false;
            Capsule.SetActive(false);
        }

        if (hasPlayerTurned = true)
        {
            LockControl.turnTowardsBox = false;
        }
    }

    IEnumerator WaitForSeconds()
    {
        yield return new WaitForSeconds(5);
        //LockControl.turnTowardsBox = false;
        //hasPlayerTurned = true;

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
