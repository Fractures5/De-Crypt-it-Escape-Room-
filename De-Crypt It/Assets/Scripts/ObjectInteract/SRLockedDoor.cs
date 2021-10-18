using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This script will handle player interaction with the locked door.
public class SRLockedDoor : MonoBehaviour
{
    // Keeps track of the object color.
    [SerializeField]
    public Color startcolor;

    // Text variable that shows the user to press "E" to interact with the door.
    public Text interactionText;

    // Text variable that shows that the door is currently locked.
    public Text lockedDoorText;

    // Boolean which checks if the player is in the range of the locked door.
    public bool inRange = false;

    // Static variable which is readable and modifiable by other scripts. 
    // It is used to determine if the quiz task is completed or not by the user.
    public static bool taskComplete = false;

    // AudioSource variable for the locked door sound effect
    public AudioSource doorLockedFX;

    void Update()
    {
        // If player is in range of the locked door and presses "E", they will be shown a message 
        // stating the door is locked followed by a locked sound effect.
        if(Input.GetKeyDown("e") && inRange == true)
        {
            Debug.Log("You have pressed E to try and open the door");
            interactionText.gameObject.SetActive(false); // hides the interaction text for the locked door.
            doorLockedFX.Play(0); // when user is in range of the locked door play locked door sound effect.
            StartCoroutine(doorIsLocked()); // invokes the method where the player will be shown the the door is locked message for 1 second.
        }
    }

    // This function is called when the user is close to the box collider of the locked door.
    void OnTriggerEnter(Collider other)
    {
         if (other.CompareTag("Player"))
            {
                // Highlights the interactable locked door, changes the range status to true and activates the text instruction
                startcolor = GetComponent<Renderer>().material.color;
                GetComponent<Renderer>().material.color = Color.green;
                inRange = true;
                interactionText.gameObject.SetActive(true);
            }
    }

    // This function is called when the user is exiting the box collider of the locked door.
    void OnTriggerExit(Collider other)
    {
        // The color of the locked door is changed to the default color,
        // the status of the range is changed to false, and the instructions text is disabled so the user cant see it.
        if(other.CompareTag("Player"))
        {
            GetComponent<Renderer>().material.color = startcolor;
            inRange = false;
            interactionText.gameObject.SetActive(false);
        }
    }

    // This method will be invoked to show the locked door message for one second to the user 
    // when they try to interact with the locked door by pressing "E".
    // This method will return the IEnumerator object.
    IEnumerator doorIsLocked()
    {
        lockedDoorText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1); // waits one second.
        lockedDoorText.gameObject.SetActive(false); // hides locked door text.
    }
    
}
