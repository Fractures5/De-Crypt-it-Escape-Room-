using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Door : MonoBehaviour
{

    public GameObject Key;
    public AnimationClip testingClip;
    public Animation doorClip;
    public bool door;

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
        if (Input.GetKeyDown(KeyCode.E) && door == true && Key.active == false)
        {
            //GameObject.FindGameObjectsWithTag("Door").Animation.Play("DoorOpen");
            doorClip.clip = testingClip;
            doorClip.Play();
        }
    }
}
