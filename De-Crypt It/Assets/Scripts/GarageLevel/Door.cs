using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Door : MonoBehaviour
{

    public GameObject Key;
    public AnimationClip testingClip;
    public Animation doorClip;
    public bool door;
    public bool isDoorOpened = false;
    public Text doorOpenInstructions;
    public Text doorCloseInstructions;
    public bool isRange = false;

    void Start(){
        doorClip = GetComponent<Animation>();
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag("Player"))
        {
            door = true;
            if (isRange == false)
            {
                doorOpenInstructions.gameObject.SetActive(false);
                doorCloseInstructions.gameObject.SetActive(false);
            }

            if (Key.active == false && isDoorOpened == false)
            {
                doorOpenInstructions.gameObject.SetActive(true);
                doorCloseInstructions.gameObject.SetActive(false);
            }

            if (Key.active == false && isDoorOpened == true)
            {
                doorCloseInstructions.gameObject.SetActive(true);
                doorOpenInstructions.gameObject.SetActive(false);
            }
        }
    }

    void OnTriggerExit (Collider other)
    {
        if (other.CompareTag("Player"))
        {
            door = false;
            isRange = false;
            doorOpenInstructions.gameObject.SetActive(false);
            doorCloseInstructions.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && door == true && Key.active == false && isDoorOpened == false)
        {
            doorClip.clip = testingClip;
            doorClip.Play("DoorOpen");
            isDoorOpened = true;
            doorOpenInstructions.gameObject.SetActive(false);
            doorCloseInstructions.gameObject.SetActive(true);
        }

        else if (Input.GetKeyDown(KeyCode.E) && door == true && Key.active == false && isDoorOpened == true)
        {
            doorClip.clip = testingClip;
            doorClip ["DoorClose"].speed = -1;
            doorClip ["DoorClose"].time = doorClip ["DoorClose"].length;
            doorClip.Play("DoorClose");
            isDoorOpened = false;
            doorCloseInstructions.gameObject.SetActive(false);
            doorOpenInstructions.gameObject.SetActive(true);
            
        }
        
    }
}