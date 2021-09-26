using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ServerRoomDoorInteraction : MonoBehaviour
{
    // Keeps track of the object color
    [SerializeField]
    public Color startcolor;

    // Text variable that gives instructions to the player on how to interact with the quiz
    public Text interactionText;

    // Boolean which checks if the player is in the range of the tv object
    public bool inRange = false;

    // Static variable which is readable and modifiable by other scripts. 
    // It is used to determine if the quiz task is completed or not by the user.
    public static bool taskComplete = false;


    // This function is called when the user is close to the box collider of door
    void OnTriggerEnter(Collider other)
    {
         if (other.CompareTag("Player"))
            {
                // Highlights the interactable door, changes the range status to true and activates the text instruction
                startcolor = GetComponent<Renderer>().material.color;
                GetComponent<Renderer>().material.color = Color.green;
                inRange = true;
                interactionText.gameObject.SetActive(true);
            }
    }

    // This function is called when the user is exiting the box collider of the door
    void OnTriggerExit(Collider other)
    {
        // The color of the door is changed to the default color,
        // the status of the range is changed to false, and the instructions text is disabled so the user cant see it.
        if(other.CompareTag("Player"))
        {
            GetComponent<Renderer>().material.color = startcolor;
            inRange = false;
            interactionText.gameObject.SetActive(false);

        }
    }
    
}
