using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour {

    #region Attributes

    public Transform door;

    public Vector3 closedPosition = new Vector3(-32.276f, 13.144f, 2.152f);
    public Vector3 openedPosition = new Vector3(-32.276f, 13.144f, 2.152f);
    
    public float openSpeed = 5;

    private bool open = false;

    #endregion

    #region MonoBehaviour API

    //Update the position of the door, so that when ball collides the door will move and allow user to pass through.
    private void Update()
    {
        if (open)
        {
            door.position = Vector3.Lerp(door.position,
                openedPosition, Time.deltaTime * openSpeed);
        } else
        {
            door.position = Vector3.Lerp(door.position,
                closedPosition, Time.deltaTime * openSpeed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            OpenDoor();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            CloseDoor();
        }
    }

    #endregion

    public void CloseDoor()
    {
        open = false;
    }

    public void OpenDoor()
    {
        open = true;
    }
}

