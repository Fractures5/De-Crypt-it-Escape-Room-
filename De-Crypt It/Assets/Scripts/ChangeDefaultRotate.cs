using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDefaultRotate : MonoBehaviour
{
    public GameObject Camera;
    // Update is called once per frame
    void Update()
    {
        if (LockControl.isPadlockOpened == true && LockControl.turnTowardsBox == false)
        {
            transform.Rotate(0, 0, 0);
            Camera.transform.Rotate(0, 0, 0);
            Debug.Log("Deez nuts");
        }
    }
}
