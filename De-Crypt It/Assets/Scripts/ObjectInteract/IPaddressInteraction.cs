using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This script handles the user interaction between the IP address clue in the server rooom and the player
public class IPaddressInteraction : MonoBehaviour
{
    // Keeps track of the object color
    [SerializeField]
    public Color startcolor;

    // Text variable that gives instructions to the player on how to interact with the interactable clue 
    public Text interactionText;

    // Boolean which checks if the player is in the range of the clue collider
    public bool inRange = false;

    // Static variable which is readable and modifiable by other scripts. 
    // It is used to determine if the clue is received or not by the user.
    public static bool clueReceived = false;
   
    public GameObject pingingCluePopup;

    // Update is called once per frame
    void Update()
    {
        // If the clue is not received and the user in range and interacts with the clue
        // by pressing "E", then the user will be shown the clue in their UI.
        if(clueReceived == false)
        {
            if(inRange == true && Input.GetKeyDown("e"))
            {
               interactionText.gameObject.SetActive(false); // disable clue interaction text
               pingingCluePopup.SetActive(true); // show the clue in the player UI
               clueReceived = true; // change status to let the program know the user has collected the clue
            }
        }
    }

    // This function is called when the user is close to the box collider of the invisible clue interaction field
    void OnTriggerEnter(Collider other)
    {
        // If the player receives the clue, object is not higlighted, interaction instructions is not shown and dont update the player within range
        if(clueReceived == true)
        {
            startcolor = GetComponent<Renderer>().material.color;
            GetComponent<Renderer>().material.color = startcolor;
            inRange = false;
            interactionText.gameObject.SetActive(false);
        }
        // If the player has not received the clue, object is highlighted, instructions text is shown and the player within the range is updated
        else
        {
            if (other.CompareTag("Player"))
            {
                // Highlights the interactable text, changes the range status to true and activates the text instruction
                startcolor = GetComponent<Renderer>().material.color;
                GetComponent<Renderer>().material.color = Color.green;
                inRange = true;
                interactionText.gameObject.SetActive(true);
            }
        }
    }

    // This function is called when the user is exiting the box collider of the invisible clue interaction field
    void OnTriggerExit(Collider other)
    {
        // The color of the interactable area is changed to the default color,
        // the status of the range is changed to false, and the instructions text is disabled so the user cant see it.
        if(other.CompareTag("Player"))
        {
            GetComponent<Renderer>().material.color = startcolor;
            inRange = false;
            interactionText.gameObject.SetActive(false);

        }
    }
}
