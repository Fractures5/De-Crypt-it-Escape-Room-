using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlayerCam : MonoBehaviour
{
    public GameObject Camera;
    public GameObject Capsule;
    //public Camera camera;

    public static bool hasPlayerTurned = false;

    public float Rotation;

    void Start()
    {
        hasPlayerTurned = false;
    }
    void Update()
    {
        if (LockControl.turnTowardsBox == true)
        {
            Debug.Log("Player should turn towards box, bool been set to true");
            transform.Rotate(0, 180, 0);
            Camera.transform.Rotate(40, 0, 0);
        }
        if (LockControl.turnTowardsBox == false)
        {
            Debug.Log("fuck unity");
        }
        /*if (LockControl.isPadlockOpened == true && LockControl.turnTowardsBox == true && EasyModePauseGame.isGamePaused == false && hasPlayerTurned == false)
        {
            Debug.Log("should have turned kient");
            transform.Rotate(0, 180, 0);
            Camera.transform.Rotate(40, 0, 0);
            StartCoroutine(WaitForSeconds());
            hasPlayerTurned = true;
            
        }
        else if (LockControl.isPadlockOpened == true && LockControl.turnTowardsBox == false)
        {
            //transform.Rotate(0, 0, 0);
            //Camera.transform.Rotate(0, 0, 0);
            Debug.Log("Deez nuts");
        }

        if (EasyModePauseGame.isGamePaused == true && LockControl.turnTowardsBox == false)
        {
            Camera.GetComponent<FirstPersonLook>().enabled = false;
            Capsule.SetActive(false);
            Debug.Log("Game should be paused");
        }

        if (hasPlayerTurned = true)
        {
            LockControl.turnTowardsBox = false;
        }*/
    }

    IEnumerator WaitForSeconds()
    {
        yield return new WaitForSeconds(1);
        //LockControl.turnTowardsBox = false;
        //hasPlayerTurned = true;
        Debug.Log("edibles");
        //LockControl.turnTowardsBox = false;

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
