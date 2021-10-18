using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This script will handle the interaction with the desk in the tutorial mode
public class TutorialInteraction : MonoBehaviour
{
    [SerializeField]
    // declare the start color 
    public Color startcolor;
    // store an image for popup showing instructions
    public GameObject parchment;
    // Boolean that check if the player is within object range
    public bool isRange = false;
    // Text variable which gives intructions to the player on how to interact with them
    public Text interactionText;
    // boolean to check if the pop up parchment is open or not
    public bool isParchmentOpen = false;
    // audio object for the pickup sound
    public AudioSource playPickup;

    // Update is called once per frame
    void Update()
    {
        //If the player is in range and presses E, then they are shown the parchment with the instructions.
        if (isRange == true && Input.GetKeyDown("e"))
        {
            //If the paper object is not shown, show it.
            if(isParchmentOpen == false)
            {
                playPickup.Play(0);
                interactionText.gameObject.SetActive(false);
                parchment.gameObject.SetActive(true);
                isParchmentOpen = true;

            }
            //If the paper object is shown, then dont show it.
            else if (isParchmentOpen == true)
            {
                playPickup.Play(0);
                interactionText.gameObject.SetActive(true);
                parchment.gameObject.SetActive(false);
                isParchmentOpen = false;
            }
        }
    }

    // When player enters the collision range for the paper, then they are able to interact with the paper.
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Highlights the interactable object and changes the is range status to true.
            // Shows the interaction text to the player.
            startcolor = GetComponent<Renderer>().material.color;
            GetComponent<Renderer>().material.color = Color.green;
            interactionText.gameObject.SetActive(true);
            isRange = true;
        }
    }
    // If the player leaves the collision range of the paper, the paper display will then be closed.
    void OnTriggerExit(Collider other)
    {
        // Changes the interactable object color to thr default and changes is range status to false.
        // Interaction text is also hidden.
        if (other.CompareTag("Player"))
        {
            GetComponent<Renderer>().material.color = startcolor;
            interactionText.gameObject.SetActive(false);
            parchment.gameObject.SetActive(false);
            isRange = false;
            isParchmentOpen = false;
        }
    }

    
}
