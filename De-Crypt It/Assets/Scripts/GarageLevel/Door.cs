using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Door : MonoBehaviour
{

    public GameObject Key;
    public AnimationClip testingClip;
    public Animation doorClip;
    public bool door;
    public bool isDoorOpened = false;

    void Start(){
        doorClip = GetComponent<Animation>();
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag("Player"))
        {
            door = true;
        }
    }

    void OnTriggerExit (Collider other)
    {
        if (other.CompareTag("Player"))
        {
            door = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && door == true && Key.active == false && isDoorOpened == false)
        {
            doorClip.clip = testingClip;
            //doorClip ["WhiteDoorOpen"].speed = 1;
            //doorClip ["WhiteDoorOpen"].time = doorClip ["WhiteDoorOpen"].length;
            doorClip.Play("DoorOpen");
            isDoorOpened = true;
        }

        else if (Input.GetKeyDown(KeyCode.E) && door == true && Key.active == false && isDoorOpened == true)
        {
            doorClip.clip = testingClip;
            doorClip ["DoorClose"].speed = -1;
            doorClip ["DoorClose"].time = doorClip ["DoorClose"].length;
            doorClip.Play("DoorClose");
            isDoorOpened = false;
            
        }
        
    }
}